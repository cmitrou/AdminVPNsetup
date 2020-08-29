using System.ServiceProcess;

namespace NewBridgeClient
{
    internal class Service
    {
        public static void _Start_sevpnservice()
        {
            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
                sc.Start();
            // System.Threading.Thread.Sleep(500);
            return;
        }

        public static void _Stop_sevpnservice()
        {
            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            if (sc.Status == ServiceControllerStatus.Running)
                sc.Stop();
            //   System.Threading.Thread.Sleep(500);
            return;
        }
    }
}