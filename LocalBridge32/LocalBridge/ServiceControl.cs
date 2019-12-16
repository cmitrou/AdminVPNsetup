using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace LocalBridge
{
    class ServiceControl
    {
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
    }
}
