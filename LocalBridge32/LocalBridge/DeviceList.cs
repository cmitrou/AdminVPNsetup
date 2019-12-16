using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;
using System.IO;

namespace LocalBridge
{
    class DeviceList
    {
        public static void _GetfLocalBridgeDeviceList()
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
            string arg = "/c cd \"" + directory + "\" && vpncmd.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD BridgeDeviceList > c:\\temp\\BridgeDeviceList.txt && exit";
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
                        // CardTables._netcards = found;
                    }
                }
                file.Close();
            //    File.Delete("c:\\temp\\BridgeDeviceList.txt");
                //   CardTables._netcards.ForEach(i => Console.WriteLine("{0}", i));
                return found;
            }
        }
        public static List<string> _Print_Local_Bridge()
        {
            List<string> BridgeFound = new List<string>();
            string Line;
            if (File.Exists("c:\\temp\\localbridge.txt"))
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
        public static void _Save_LocalBridge()
        {
            if (File.Exists("c:\\temp\\BridgeList.txt")) { File.Delete("c:\\temp\\BridgeList.txt"); };
            string directory = "c:\\Program Files\\VPN_Tools";
            string arg = "/c cd \"" + directory + "\" && vpncmd.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD BridgeList > c:\\temp\\BridgeList.txt && exit";
            Process GlbDL = new Process();
            GlbDL.StartInfo.FileName = "cmd.exe";
            GlbDL.StartInfo.Arguments = arg;
            GlbDL.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            GlbDL.Start();
            GlbDL.WaitForExit();
            GlbDL.Close();
        }
    }
}
