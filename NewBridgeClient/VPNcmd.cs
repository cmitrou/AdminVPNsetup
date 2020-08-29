using System;
using System.Diagnostics;

namespace NewBridgeClient
{
    public class VPNcmd
    {
        public string Binary { get; set; }

        public VPNcmd(string binary)
        {
            this.Binary = binary;
        }

        public VPNcmd()
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
                    Arguments = hostPort + " /" + type + " /CSV" + extraArguments + " /CMD " + command + " " + parameters,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            if (!String.IsNullOrEmpty(error))
                throw new Exception(error);
            string str1 = output.Split('[')[0].TrimEnd() + '\n';
            output = str1;//.Substring(str1.IndexOf('\n'));
            return output;//.Substring(output.IndexOf('\n'));
            process.WaitForExit();
            process.Close();
            process.Kill();
        }
    }
}