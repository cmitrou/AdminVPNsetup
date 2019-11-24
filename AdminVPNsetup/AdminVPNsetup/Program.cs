using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace AdminVPNsetup
{
    class Program
    {
        public static string Rt { get; private set; }

        static void Main(string[] args)

        {
            string machineName = System.Environment.MachineName;
            
            bool rtdx = CheckInstall.CheckIfInstallDirExists("c:\\Program Files\\VPN_Tools");
            if (rtdx)
            {
                Console.WriteLine("Install Dir Exists");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Install Dir Does not Exists");
                Console.ReadKey();
            }
            string SubDirPath = "c:\\Program Files\\VPN_Tools\\backup.vpn_bridge.config";
            bool subdirx = CheckInstall.CheckIfSubDirExists(SubDirPath);
            if (subdirx)
            {
                Console.WriteLine("BackUpDir exists");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("BackUp dir Doesnt Exists. Please run Bridge");
                Console.ReadKey();
            }
            string ServiceBridgeExists = "sevpnbridge";
            bool srvx = CheckInstall.ServiceExists(ServiceBridgeExists);
            if (srvx)
            {
                Console.WriteLine("Service has been Installed");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Service has not been Installed");
                Console.ReadKey();
            }
            string serviceNane = "sevpnbridge";
            Rt = string.Empty;
            // string fg = servicecheckifrunning(serviceNane, Rt);
            string fg = CheckInstall.BridgeServiceCondition(serviceNane, Rt);
            Console.WriteLine(fg);
            Console.ReadKey();
            ServiceController sc = new ServiceController("sevpnbridge");
            string rf = CheckInstall.StartupType(serviceNane);
            Console.WriteLine(rf);
            Console.ReadKey();
            string svstm = CheckInstall.GetStartupType(serviceNane);
            Console.WriteLine(svstm);
            Console.ReadKey();
            var svc = new ServiceController("sevpnbridge");
            ServiceHelper.ChangeStartMode(svc, ServiceStartMode.Manual);
            
            // var svc1 = new ServiceController("sevpnbridge");
            if (svc.Status != ServiceControllerStatus.Stopped)
            {
                svc.Stop();
            }
            svc.Close();
        }
     }
}

