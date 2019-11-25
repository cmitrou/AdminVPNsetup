using System;
using System.ServiceProcess;

namespace AdminVPNsetup
{
    public class ctl
    {
        public static string Rt { get; private set; }
        public static string InstallDirExists { get; private set; }
        public static string SubDirPathExists { get; private set; }
        public static string BridgeService { get; private set; }
        public static string BridgeServiceStartMode { get; private set; }
        public static string BridgeServiceCondition { get; private set; }
        //   private static void Main(string[] args)
        public static  void MainControl()
        {
            string machineName = System.Environment.MachineName;
            
            bool rtdx = CheckInstall.CheckIfInstallDirExists("c:\\Program Files\\VPN_Tools");
            if (rtdx)
            {
             InstallDirExists = "Exists";   
            }
            else
            {
                InstallDirExists = "Not Exists";
            }
            string SubDirPath = "c:\\Program Files\\VPN_Tools\\backup.vpn_bridge.config";
            bool subdirx = CheckInstall.CheckIfSubDirExists(SubDirPath);
            if (subdirx)
            {
                SubDirPathExists = "Exists";
            }
            else
            {
                SubDirPathExists = "Not Exists";
            }
            string ServiceBridgeExists = "sevpnbridge";
            bool srvx = CheckInstall.ServiceExists(ServiceBridgeExists);
            if (srvx)
            {
                BridgeService = "Exists";
            }
            else
            {
                BridgeService = "Not Exists";
            }
            string serviceNane = "sevpnbridge";
            Rt = string.Empty;
            // string fg = servicecheckifrunning(serviceNane, Rt);
             string fg = CheckInstall.BridgeServiceCondition(serviceNane, Rt);
            BridgeServiceCondition = fg;
            ServiceController sc = new ServiceController("sevpnbridge");
            string rf = CheckInstall.StartupType(serviceNane);
            
            string svstm = CheckInstall.StartupType(serviceNane);
            BridgeServiceStartMode = svstm;
                        var svc = new ServiceController("sevpnbridge");
            System.ServiceProcess.ServiceHelper.ChangeStartMode(svc, ServiceStartMode.Manual);

            // var svc1 = new ServiceController("sevpnbridge");
            if (svc.Status != ServiceControllerStatus.Stopped)
            {
                svc.Stop();
            }
            svc.Close();
        }
    }
}