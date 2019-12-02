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
        public int flag = 0;
        public static string Rt { get; private set; }
        public static string GrD { get; set; }
        public static string CardChoise { get; set; }

        static void Main(string[] args)

        {


            new VPNsetupMenu().Run();
            Console.ReadKey();

            _Check_Installation();
            //  Console.ReadKey();
            CheckInstall.GetfLocalBridgeDeviceList();
            _PrintBridgeCapableList();
            CheckInstall._Save_LocalBridge();
            CheckInstall._Print_Local_Bridge();
            _Local_Bridge_Set();
            Console.WriteLine("  ");
            Console.WriteLine("Ready to setup");
            Console.WriteLine("Enter the index number of Network Card you wish to setup as Local Bridge");
            Console.ReadKey();
            if (CardTables.flag == 0)
            {
                LocalBridgeChang.localbridgechange();
            }
            else
            {
                Console.ReadKey();
            }
            // _Enter_choise();




        }
        //
        // Check if Install and Setup is correct
        //
        public static void _Check_Installation()
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
        public static void _PrintBridgeCapableList()
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
        static void _Enter_choise()
        {
            string _val = "";
            Console.Write("Enter your value: ");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            Console.WriteLine("The Value You entered is : " + _val);
            CardChoise = _val;
            Console.ReadKey();
        }
        public static string _is_Directory_exists()
        {
            ctl.MainControl();
            Console.WriteLine("Check if Program Install Exists:" + "  " + ctl.InstallDirExists);
            string gh = null;
            return gh = ctl.InstallDirExists;
        }
        public static string _is_SubDirectory_exists()
        {
            ctl.MainControl();
            Console.WriteLine("Check if Program Sub Dirs exists:" + " " + ctl.SubDirPathExists);
            string gj = null;
            return gj = ctl.SubDirPathExists;           
        }
        public static string _is_Service_installed()
        {
            ctl.MainControl();
            Console.WriteLine("Check is Bridge Service is installed:" + " " + ctl.BridgeService);
            string gk = null;
            return gk = ctl.BridgeService;
        }
        public static string _Bridge_service_condition()
        {
            string serviceNane = "sevpnbridge";
            Rt = string.Empty;
            // string fg = servicecheckifrunning(serviceNane, Rt);
            string fg = CheckInstall.BridgeServiceCondition(serviceNane, Rt);
          //  CheckInstall.BridgeServiceCondition = fg;
            ServiceController sc = new ServiceController("sevpnbridge");
            string rf = CheckInstall.StartupType(serviceNane);
            Console.WriteLine("Check Bridge Service Startup Mode:" + " " + rf);
            return rf;
        }
        public static string _BridgeServiceCondition()
        {

            string ServiceName = "sevpnbridge";
            ServiceController sc = new ServiceController(ServiceName);
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    Console.WriteLine("Bridge Service Condition:" + "Running " );
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    Console.WriteLine("Bridge Service Condition:" + "Stopped ");
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    Console.WriteLine("Bridge Service Condition:" + "Paused ");
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    Console.WriteLine("Bridge Service Condition:" + "Stopping ");
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    Console.WriteLine("Bridge Service Condition:" + "Starting ");
                    return "Starting";
                default:
                    Console.WriteLine("Bridge Service Condition:" + "Status Changing ");
                    return "Status Changing";
            }
        }
    }
}

