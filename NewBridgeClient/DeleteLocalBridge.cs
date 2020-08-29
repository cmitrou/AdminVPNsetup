using System.Diagnostics;

namespace NewBridgeClient
{
    public class _cmd
    {
        public string Binary { get; set; }

        public _cmd(string binary)
        {
            this.Binary = binary;
        }

        public _cmd()
        {
            this.Binary = Data.AppRunDir + Data._vpncmd_exe;
        }

        //  public string Execmd(string hostPort, string type, string command, string parameters, string extraArguments = "")
        public string Execmd(string hostPort, string type, string command, string parameters, string extraArguments = "")
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = this.Binary,
                    Arguments = hostPort + " /" + type + extraArguments + " /CMD " + command + " " + parameters,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            string _end = "end";
            process.Start();
            process.WaitForExit();
            process.Close();
            return _end;
        }
    }
}