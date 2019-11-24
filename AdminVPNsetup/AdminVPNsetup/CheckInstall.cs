using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.ComponentModel;

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
    }
}


