using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsVPN
{
    class CascadeStat

    {
        public static string _GetConnStatus(string cascade_name)
        {
            string _cascStat="Offline";
            string arg = "/c Ping localhost -n 5 > NULL && " + "vpncmd.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /ADMINHUB:BRIDGE /CMD CascadeList";

            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line.Contains("Online"))
                {
                    vpnValues._cascade_connection_status = "Online";
                    _cascStat = "Online";
                }
                else { vpnValues._cascade_connection_status = "Offline"; _cascStat = "Offline"; }
            }
            proc.WaitForExit(500);// Waits here for the process to exit.
            proc.Close();
            
            return _cascStat.ToString();
        }
    }
}
