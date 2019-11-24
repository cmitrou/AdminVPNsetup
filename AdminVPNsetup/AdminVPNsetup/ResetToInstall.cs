using System;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AdminVPNsetup
{
    public class ResetToInstall
    {
        static string checkServiceRunning()
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
      



        }
    }

    