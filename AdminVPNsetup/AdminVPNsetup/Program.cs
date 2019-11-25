using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.IO;

namespace AdminVPNsetup
{
    class Program
    {
        public static string Rt { get; private set; }
        public static string GrD { get; set; }

        static void Main(string[] args)

        {
            _Check_Installation();
          //  Console.ReadKey();
            CheckInstall.GetfLocalBridgeDeviceList();
            _PrintBridgeCapableList();
            CheckInstall._Save_LocalBridge();
            CheckInstall._Print_Local_Bridge();
            _Local_Bridge_Set();
            Console.ReadKey();


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
             //   Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You need to install service and set it to Manual");
            //    Console.ReadKey();
            }
        }         
        static void _PrintBridgeCapableList()
        {
          
            var Cap_crds = CheckInstall._Capable_cards();
            int w1;
            for (int w = 0; w < Cap_crds.Count; w++)
            {
                w1 = w + 1; 
                Console.WriteLine(w1.ToString() + ". " + Cap_crds[w].ToString());

            }            
        } 
        static void _Local_Bridge_Set()
        {
            string LBS = File.ReadAllText("c:\\temp\\localbridge.txt");
            Console.WriteLine(" Local Bridge");
            Console.WriteLine(LBS);
        }
    }
}

