using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using ToolsVPN.Properties;


namespace ToolsVPN
{
    class PrepareToConnect
    {
        public static class _prep_to_connect
        {
           
        }
        public static void _Delete_cascade_connection()
        {
            if (!string.IsNullOrEmpty(vpnValues._cascdade_connection_name))
            {
                StreamWriter v = new StreamWriter(vpnValues._tmp_dir + "\\delcasc");
                v.Write("HUB BRIDGE \n" + "CascadeDelete " + vpnValues._cascdade_connection_name);
                v.Close();
                string directory = vpnValues._ExecDir;
                string arg = "/c cd \"" + directory + "\" && vpncmd.exe " + vpnValues._local_host_name + ":" + 
                   vpnValues._local_host_port + " /SERVER /PASSWORD:" +
                   vpnValues._local_host_server_password + " /IN:" + 
                   vpnValues._tmp_dir + "\\delcasc" + " && exit";
                Process delcasc = new Process();
                delcasc.StartInfo.FileName = "cmd.exe";
                delcasc.StartInfo.Arguments = arg;
                delcasc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                delcasc.Start();
                delcasc.WaitForExit();
                delcasc.Close();
                File.Delete(vpnValues._tmp_dir + "\\delcasc");
            }
            return;

        }
        public static void _Check_Cascade_setup()
        {
            if (File.Exists(vpnValues._tmp_dir+"\\cascadelist.txt")) { File.Delete(vpnValues._tmp_dir+"\\cascadelist.txt"); };
            if (File.Exists(vpnValues._tmp_dir+"\\cascd_list")) { File.Delete(vpnValues._tmp_dir+"\\cascd_list"); };
            StreamWriter s = new StreamWriter(vpnValues._tmp_dir + "\\cascd_list");
            s.Write("Hub BRIDGE \n" + "CascadeList");
            s.Close();
            string directory = vpnValues._ExecDir;
            // string arg1 = " CascadeList > cascadelist.txt && exit";            
            string arg = "/c cd \"" + directory + "\" && vpncmd.exe " + vpnValues._local_host_name + ":" + 
                vpnValues._local_host_port + " /SERVER /PASSWORD:" +
                vpnValues._local_host_server_password + " /IN:" + 
                vpnValues._tmp_dir +"\\cascd_list" + " /OUT:" + vpnValues._tmp_dir + "\\cascadelist.txt && exit" ;
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
                    vpnValues._cascdade_connection_name = line.Replace("Setting Name          |", "");
                }
            }
            string Status = "Status";
            foreach (string line in lines)
            {
                if (line.Contains(Status))
                {
                    //   Console.WriteLine(line.Replace("|", ""));
                    vpnValues._cascade_connection_status = line.Replace("Status                |", "");
                }
            }
            string Destination_VPN_Server = "Destination VPN Server";
            foreach (string line in lines)
            {
                if (line.Contains(Destination_VPN_Server))
                {
                    //   Console.WriteLine(line.Replace("|", ""));
                    vpnValues._cascade_remote_server = line.Replace("Destination VPN Server|", "");
                }
            }
            File.Delete("c:\\temp\\cascadelist.txt");
            File.Delete("c:\\temp\\cascd_list");
            return;
        }
        public static void _Create_Cascade_connection()
        {
            if(File.Exists(vpnValues._tmp_dir + "\\cascc")) { File.Delete(vpnValues._tmp_dir + "\\cascc"); };
            if (string.IsNullOrEmpty(vpnValues._cascdade_connection_name))
            {
                StreamWriter c = new StreamWriter(vpnValues._tmp_dir + "\\cascc");
                c.Write("HUB BRIDGE \n" + "CascadeCreate " + vpnValues._cascade_connection_create + " /SERVER:" +
                    vpnValues._vpn_host + ":" + vpnValues._vpn_host_port +
                    " /HUB:" + vpnValues._vpn_hub_name + " /USERNAME:" + vpnValues._vpn_user +
                    "\n" + "CascadePasswordSet " + vpnValues._cascade_connection_create +
                    " /PASSWORD:" + vpnValues._vpn_user_pass + " /TYPE:standard");
                   
                c.Close();
                string directory = vpnValues._ExecDir;
                string arg = "/c cd \"" + directory +
                   "\" && vpncmd.exe " + vpnValues._local_host_name + ":" + vpnValues._local_host_port + " /SERVER /PASSWORD:" + 
                   vpnValues._local_host_server_password + " /IN:" + 
                    vpnValues._tmp_dir + "\\cascc" + " && exit";
                Process casdc = new Process();
                casdc.StartInfo.FileName = "cmd.exe";
                casdc.StartInfo.Arguments = arg;
                casdc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                casdc.Start();
               
                casdc.WaitForExit();
                casdc.Close();
                File.Delete(vpnValues._tmp_dir + "\\cascc");
            }
            return;
        }
        public static void _Cascade_conx_start()
        {
            if(File.Exists(vpnValues._tmp_dir + "\\casdstart")) { File.Delete(vpnValues._tmp_dir + "\\casdstart"); };
            if(vpnValues._cascade_connection_status.Contains("Offline"))
            {
                StreamWriter cs = new StreamWriter(vpnValues._tmp_dir + "\\casdstart");
                cs.Write("HUB BRIDGE \n" + "CascadeOnline " + vpnValues._cascade_connection_create);
                cs.Close();
                string directory = vpnValues._ExecDir;
                string arg = "/c cd \"" + directory +
                    "\" && vpncmd.exe " + vpnValues._local_host_name +":" + vpnValues._local_host_port + " /SERVER /PASSWORD:" + 
                    vpnValues._local_host_server_password + " /IN:" +
                    vpnValues._tmp_dir + "\\casdstart" + " && exit";
                Process castr = new Process();
                castr.StartInfo.FileName = "cmd.exe";
                castr.StartInfo.Arguments = arg;
                castr.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                castr.Start();
                castr.WaitForExit();
                castr.Close();
                File.Delete(vpnValues._tmp_dir + "\\casdstart");
            }
            return;
        }
        public static void _Cascade_conx_stop()
        {
            if (File.Exists(vpnValues._tmp_dir + "\\casdstop")) { File.Delete(vpnValues._tmp_dir + "\\casdstop"); };
            if (String.IsNullOrEmpty(vpnValues._cascade_connection_status)) { return; }
            if (vpnValues._cascade_connection_status.Contains("Online"))
            {
                StreamWriter cst = new StreamWriter(vpnValues._tmp_dir + "\\casdstop");
                cst.Write("HUB BRIDGE \n" + "CascadeOffline " + vpnValues._cascade_connection_create);
                cst.Close();
                string directory = vpnValues._ExecDir;
                string arg = "/c cd \"" + directory +
                    "\" && vpncmd.exe " + vpnValues._local_host_name + ":" + vpnValues._local_host_port + " /SERVER /PASSWORD:" +
                    vpnValues._local_host_server_password + " /IN:" +
                    vpnValues._tmp_dir + "\\casdstop" + " && exit";
                Process castp = new Process();
                castp.StartInfo.FileName = "cmd.exe";
                castp.StartInfo.Arguments = arg;
                castp.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                castp.Start();
                castp.WaitForExit();
                castp.Close();
                File.Delete(vpnValues._tmp_dir + "\\casdstop");
            }
            return;
        }
        public static string _BridgeServiceCondition(string serviceName)
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
        public static void _Start_sevpnservice()
        {
            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
                sc.Start();
            System.Threading.Thread.Sleep(1000);
            return;
        }
        public static void _Stop_sevpnservice()
        {
            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            if (sc.Status == ServiceControllerStatus.Running)
                sc.Stop();
            System.Threading.Thread.Sleep(1000);
            return;
        }
        public static void _init()
        {
            vpnValues._vpn_host = Resources.Server;
            vpnValues._vpn_host_port = Resources.Port;
            vpnValues._vpn_hub_name = Resources.vpnhubname;
            vpnValues._ExecDir = Resources.ExecDir;
            vpnValues._vpnbridge_exe = Resources.vpnbridge_exe;
            vpnValues._vpncmd_exe = Resources.vpncmd_exe;
            vpnValues._tmp_dir = Resources.tmp_dir;
            vpnValues._cascdade_connection_name = Resources.CascadeConnectionName;
            vpnValues._cascade_connection_create = Resources.CascadeConnectionCreate;
            vpnValues._local_host_name = Resources.LocalServer;
            vpnValues._local_host_port = Resources.LocalHostPort;
            vpnValues._local_hub_name = Resources.LocalHubName;
            vpnValues._local_host_server_password = Resources.LocalServerPassword;
            PrepareToConnect._Start_sevpnservice();
            System.Threading.Thread.Sleep(500);
            PrepareToConnect._Check_Cascade_setup();
            PrepareToConnect._Start_sevpnservice();
            System.Threading.Thread.Sleep(500);
          //  PrepareToConnect._Delete_cascade_connection();
          //  PrepareToConnect._Stop_sevpnservice();
            System.Threading.Thread.Sleep(1000);
        }
    }
    
}
