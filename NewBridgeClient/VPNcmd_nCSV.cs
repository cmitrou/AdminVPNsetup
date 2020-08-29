using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NewBridgeClient
{
    public class VPNcmd_nCSV
    {
        public string Binary { get; set; }

        public VPNcmd_nCSV(string binary)
        {
            this.Binary = binary;
        }

        public VPNcmd_nCSV()
        {
            this.Binary = Data.AppRunDir + Data._vpncmd_exe;
            // this.Binary = "vpncmd";
        }

        public string ExecuteCommand(string hostPort, string type, string command, string parameters, string extraArguments = "")
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = this.Binary,
                    Arguments = hostPort + " /" + type + extraArguments + " /CMD " + command + " " + parameters,
                    RedirectStandardOutput = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            process.Start();

            List<string> line = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                line.Add(process.StandardOutput.ReadLine());
            }
            foreach (var result in line.Where(s => s.IndexOf("1") == 0))
            {
                Data._tmp = result.ToString().Substring(24);
            }
            string output = Data._tmp;
            process.WaitForExit();
            return output;
            process.Close();
            process.Kill();
        }
    }
}