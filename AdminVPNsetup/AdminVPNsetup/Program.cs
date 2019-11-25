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
            _Check_Installation();
            CheckInstall.GetfLocalBridgeDeviceList();
        }
        //
        // Check if Install and Setup is correct
        //
        static void _Check_Installation()
        {
            ctl.MainControl();
            Console.WriteLine("Check if Program Install Exists:" + "  " + ctl.InstallDirExists);
            Console.WriteLine("Check if Config SubDir Exists:  " + "  " + ctl.SubDirPathExists);
            Console.WriteLine("Check if Service installed:     " + "  " + ctl.BridgeService);
            if (ctl.BridgeService == "Exists")
            {
                Console.WriteLine("Check if Service Running:       " + "  " + ctl.BridgeServiceCondition);
                Console.WriteLine("Check if Service set to Manual: " + "  " + ctl.BridgeServiceStartMode);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You need to install service and set it to Manual");
                Console.ReadKey();
            }
        }
    }
}

