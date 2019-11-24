using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
 
          //  string adminpass = string.Empty;
         //   string username = string.Empty;
         //   string userpass = string.Empty;
           string dirvpn = "c:\\Program Files\\VPN_Tools";
        //    string setup_arg = "/K cd \"" + dirvpn + "\" && vpncmd_x64.exe localhost:5555 /SERVER /CMD ServerPasswordSet pirkon13";
        //   Process setup_procces = new Process();
        //    setup_procces.StartInfo.FileName = "cmd.exe";
        //    setup_procces.StartInfo.Arguments = setup_arg;
          //  setup_procces.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
       //     setup_procces.Start();
        //    setup_procces.WaitForExit();
        //   System.Threading.Thread.Sleep(100);
        //   setup_procces.Close();
            // Get Bridge Intefaces 
            string BidgeIntefaces_cat = "/K cd \"" + dirvpn + "\" && /c vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon13 /CMD BridgeDeviceList";
            Process BridgeInterfaces_procces = new Process();
            BridgeInterfaces_procces.StartInfo.FileName = "cmd.exe";
            BridgeInterfaces_procces.StartInfo.Verb = "runas";
            BridgeInterfaces_procces.StartInfo.UseShellExecute = false;
            // BridgeInterfaces_procces.StartInfo.RedirectStandardError = true;
            BridgeInterfaces_procces.StartInfo.CreateNoWindow = true;
           // BridgeInterfaces_procces.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            BridgeInterfaces_procces.StartInfo.RedirectStandardOutput = true;
            BridgeInterfaces_procces.StartInfo.Arguments = BidgeIntefaces_cat;
            BridgeInterfaces_procces.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var stdOutput = new StringBuilder();
            BridgeInterfaces_procces.OutputDataReceived += (a, b) => stdOutput.AppendLine(b.Data);
            BridgeInterfaces_procces.Start();
            BridgeInterfaces_procces.BeginOutputReadLine();
            string cards = stdOutput.ToString();
            Console.WriteLine(cards);
            BridgeInterfaces_procces.WaitForExit();
            if (BridgeInterfaces_procces.ExitCode == 0)
            {
                 stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();
                if (stdOutput.Length != 0)
                {
                    message.AppendLine("stdoutput:");
                    message.AppendLine(stdOutput.ToString());
                }
            }

          //  string cards = stdOutput.ToString();
            Console.WriteLine(cards);
            BridgeInterfaces_procces.Close();
          //  Console.WriteLine(output);
            Console.ReadKey();
            
        }
    }  
            
        
}

    

