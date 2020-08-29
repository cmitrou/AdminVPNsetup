using System;
using System.Windows.Forms;

namespace NewBridgeClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OsCheck._setEnv();
            Application.Run(new Form1());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (ServicesCond.vpnServ)
            {
                Service._Stop_sevpnservice();
                //  NicInfo._deletevpnip();
                //   NicInfo._startwithDhcpON();
            }
            System.Environment.Exit(1);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (ServicesCond.vpnServ)
            {
                Service._Stop_sevpnservice();
                //   NicInfo._deletevpnip();
                //     NicInfo._startwithDhcpON();
            }
            System.Environment.Exit(1);
        }
    }
}