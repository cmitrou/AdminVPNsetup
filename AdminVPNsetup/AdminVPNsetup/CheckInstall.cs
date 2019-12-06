using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Management;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace AdminVPNsetup
{
    public class CheckInstall
    {

        public static bool CheckIfInstallDirExists(string InstallDirPath)
        {
            return (Directory.Exists(InstallDirPath));
        }

        public static bool CheckIfSubDirExists(string SubDirPath)
        {
            // static 
            return (Directory.Exists(SubDirPath));
        }

        public static bool ServiceExists(string ServiceBridgeExists)
        {

            string machineName = System.Environment.MachineName;

            return (ServiceController.GetServices().Any(s => s.ServiceName == "sevpnbridge"));

        }

        public static string BridgeServiceCondition(string serviceName, string rt)
        {

            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }
        public static string GetStartupType(string serviceName)
        {
            string wmiQuery = "Select StartMode from Win32_Service where DisplayName='" + serviceName + "'";

            ManagementObjectSearcher wmi = new ManagementObjectSearcher(wmiQuery);
            ManagementObjectCollection coll = wmi.Get();

            foreach (var service in coll)
            {
                return service["StartMode"].ToString();
            }

            return string.Empty;
        }

        public static string StartupType(string serviceName)
        {
            if (serviceName != null)
            {
                string path = "Win32_Service.Name='" + serviceName + "'";
                ManagementPath p = new ManagementPath(path);
                ManagementObject managementObject = new ManagementObject(p);
                return managementObject["StartMode"].ToString();
            }
            else
            {
                return null;
            }
        }
        public static void GetfLocalBridgeDeviceList()
        {
            ServiceController sc1 = new ServiceController();
            sc1.ServiceName = "sevpnbridge";
        //    Console.WriteLine("The Bridge Service status is currently set to {0}", sc1.Status.ToString());
            if (sc1.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine("Starting the Bridge Service...");
            }
            try
            {
                sc1.Start();
                sc1.WaitForStatus(ServiceControllerStatus.Running);
            //    Console.WriteLine("The Bridge Service status is now set to {0}.", sc1.Status.ToString());
            }
            catch (InvalidOperationException)
            {
            //    Console.WriteLine("Could not start service");
            }

          //  Console.WriteLine("Check if Service Running:       " + "  " + ctl.BridgeServiceCondition);
            //  Console.ReadKey();
            string directory = "c:\\Program Files\\VPN_Tools";
            string arg = "/c cd \"" + directory + "\" && vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD BridgeDeviceList > c:\\temp\\BridgeDeviceList.txt && exit";
            Process GlbDL = new Process();
            GlbDL.StartInfo.FileName = "cmd.exe";
            GlbDL.StartInfo.Arguments = arg;
            GlbDL.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            GlbDL.Start();
            GlbDL.WaitForExit();
            GlbDL.Close();
        }
        public static List<string> _Capable_cards()
        {
            List<string> found = new List<string>();
            string line;
            StreamReader file = new StreamReader("c:\\temp\\BridgeDeviceList.txt");
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("(ID="))
                    {
                        found.Add("\"" + line + "\"");
                        File.WriteAllLines("c:\\temp\\checked.txt", found);
                        CardTables._netcards = found;
                    }
                }
                file.Close();
                File.Delete("c:\\temp\\BridgeDeviceList.txt");
                return found;
            }
        }
        public static void _Hub_list()
        {
            string file2 = "c:\\temp\\hublist1.txt";
            if (File.Exists(file2)) { File.Delete(file2); }
            string directory = "c:\\Program Files\\VPN_Tools";
            string arg = "/c cd \"" + directory + "\" && vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD Hublist > " + file2 + " && exit";
            Process hbl = new Process();
            hbl.StartInfo.FileName = "cmd.exe";
            hbl.StartInfo.Arguments = arg;
            hbl.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            hbl.Start();
            hbl.WaitForExit();
            hbl.Close();
            string Virtual_Hub_name = "Virtual Hub Name";
            string[] lines = File.ReadAllLines(file2);
            foreach(string line in lines)
            {
                if(line.Contains(Virtual_Hub_name))
                {
                  //  Console.WriteLine(line.Replace("|",""));
                    CardTables._Hub_name = line.Replace("|", "");
                }
            }
            string Status = "Status";
            foreach (string line in lines)
            {
                if(line.Contains(Status))
                {
                  //  Console.WriteLine(line.Replace("|", ""));
                    CardTables._Hub_status = line.Replace("|", "");
                }
            }
            string Type = "Type";
            foreach (string line in lines)
            {
                if (line.Contains(Type))
                {
                 //   Console.WriteLine(line.Replace("|", ""));
                    CardTables._Hub_type = line.Replace("|", "");
                }
            }
            Console.WriteLine(CardTables._Hub_name);
            Console.WriteLine(CardTables._Hub_status);
            Console.WriteLine(CardTables._Hub_type);
            return;

        }


        public static void _Save_LocalBridge()
        {
            if(File.Exists("c:\\temp\\BridgeList.txt")) { File.Delete("c:\\temp\\BridgeList.txt"); };
            string directory = "c:\\Program Files\\VPN_Tools";
            string arg = "/c cd \"" + directory + "\" && vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD BridgeList > c:\\temp\\BridgeList.txt && exit";
            Process GlbDL = new Process();
            GlbDL.StartInfo.FileName = "cmd.exe";
            GlbDL.StartInfo.Arguments = arg;
            GlbDL.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            GlbDL.Start();
            GlbDL.WaitForExit();
            GlbDL.Close();
        }

        public static void _Check_Cascade_setup()

        {
            if(File.Exists("c:\\temp\\cascadelist.txt")) { File.Delete("c:\\temp\\cascadelist.txt"); };
            string directory = "c:\\Program Files\\VPN_Tools";
           // string arg1 = " CascadeList > cascadelist.txt && exit";            
            string arg = "/c cd \"" + directory + "\" && vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /IN:cascd_list /OUT:c:\\temp\\cascadelist.txt";
          //  arg += arg1;
            Process cscl = new Process();
            cscl.StartInfo.FileName = "cmd.exe";
            cscl.StartInfo.Arguments = arg;
            cscl.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            cscl.Start();
            cscl.WaitForExit();
            cscl.Close();

            string SettingName = "Setting Name";
            string[] lines = File.ReadAllLines("c:\\temp\\cascadelist.txt");
            foreach (string line in lines)
            {
                if (line.Contains(SettingName))
                {
               //    Console.WriteLine(line.Replace("|", ""));
                    CardTables._Cascade_Setting_Name = line.Replace("|", "");
                }
            }
            string Status = "Status";
            foreach(string line in lines)
            {
                if(line.Contains(Status))
                {
                 //   Console.WriteLine(line.Replace("|", ""));
                    CardTables._Cascade_Status = line.Replace("|", "");
                }
            }
            string Destination_VPN_Server = "Destination VPN Server";
            foreach(string line in lines)
            {
                if (line.Contains(Destination_VPN_Server))
                {
                 //   Console.WriteLine(line.Replace("|", ""));
                    CardTables._Destination_VPN_Server = line.Replace("|", "");
                }
            }
            return;
        }

        public static List<string> _Print_Local_Bridge()
        {
            List<string> BridgeFound = new List<string>();
            string Line;
            if(File.Exists("c:\\temp\\localbridge.txt"))
            {
                File.Delete("c:\\temp\\localbridge.txt");
                    }
            StreamReader File1 = new StreamReader("c:\\temp\\BridgeList.txt");
            {
                while ((Line = File1.ReadLine()) != null)
                {
                    if (Line.Contains("(ID="))
                    {
                        BridgeFound.Add(Line);
                        File.WriteAllLines("c:\\temp\\localbridge.txt", BridgeFound);
                        File.WriteAllText("c:\\temp\\localbridge.txt", File.ReadAllText("c:\\temp\\localbridge.txt").Replace("|", ""));
                       
                    }
                }
            }
            
            File1.Close();
            if (File.Exists("c:\\temp\\localbridge.txt"))
            {
                string lbrg = File.ReadAllText("c:\\temp\\localbridge.txt");
                //                Console.WriteLine("Local Bridge is setup to:   " + lbrg);

                CardTables._local_bridge_interface_ = lbrg.Replace("1     ", "").Replace("BRIDGE          ", "");
                Console.WriteLine(CardTables._local_bridge_interface_);
                return BridgeFound;
            }
            else 
              {
                string none = "NONE";
                File.AppendAllText("c:\\temp\\localbridge.txt", none + Environment.NewLine);
             //   File.Delete("c:\\temp\\BridgeList.txt");
                //string[] test = File.ReadAllLines("c:\\temp\\localbridge.txt");
                //if (test.Contains("NONE"))
                //{
                //    Console.WriteLine("No Local Bridge inteface has been setup");

                //    return BridgeFound;
                //}
                //else
                //{
                //    File.WriteAllText("c:\\temp\\localbridgeSetup.txt", File.ReadAllText("c:\\temp\\localbridgeSetup.txt").Replace("|", ""));
 //               Console.WriteLine("Local Bridge is not setup");
                CardTables._local_bridge_interface_ = none;
                Console.WriteLine(CardTables._local_bridge_interface_);

                return BridgeFound;
                //}
            }
        }
    }
}

