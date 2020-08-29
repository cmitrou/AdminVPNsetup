using SoftEtherApi;
using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace NewBridgeClient
{
    internal class NicInfo
    {
        public static string result { get; set; }

        public static void _brdgeNicName()
        {
            BridgeList._lcl_bridge("p");
            Data._lcl_bridge = Data._tmp;
            //string nic_Descr = string.Empty;
            string patern = "[(ID=]+\\d+[)|]+[Operating]+g";
            string repl = "";
            Regex rgx = new System.Text.RegularExpressions.Regex(patern);
            string input = Data._lcl_bridge;
            string result1 = rgx.Replace(input, repl).Trim();

            if (result1.Contains("(2)"))
            {
                string relult3 = ReplaceLastOccurance(result1, "(2)", "#2");
                result = relult3;
                Data.netnamefound = true;
            }
            else
            {
                _returnEth();
                Data.netnamefound = true;
                return;
            }

            // Console.WriteLine(result);
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                string _rt1 = adapter.Description.Trim();
                // string _rt2 = adapter.Id.Trim();
                ;
                if (_rt1 == result.Trim())

                {
                    Data._bridgeWindowsname = adapter.Name.ToString();
                    Data._localBridgeDHCPflag = adapter.GetIPProperties().GetIPv4Properties().IsDhcpEnabled;
                }
            }

            return;
        }

        public static void _setLocalBridgeAdditionalIP()
        {
            //  _brdgeNicName();
            Process _p3 = new Process();
            _p3.StartInfo.FileName = "netsh.exe";
            _p3.StartInfo.UseShellExecute = false;
            _p3.StartInfo.CreateNoWindow = true;
            _p3.StartInfo.RedirectStandardOutput = true;
            string arg5 = " " + "interface ip add address name=" + "\"" + Data._bridgeWindowsname + "\"" + " "
                + Data._localbridgevpnip + " " + Data._localbridgevpnmask + " " + "SkipAsSource=true";
            _p3.StartInfo.Arguments = arg5;
            try
            {
                _p3.Start();
                _p3.WaitForExit(2000);
                string infostring = _p3.StandardOutput.ReadToEnd();
                Data._infostring = infostring;
                _p3.Close();
            }
            catch
            { }
            // _set169();
            return;
        }

        public static void _setLocalBridgeStatic()
        {
            string arg = "interface ip set address name=" + "\"" + Data._bridgeWindowsname + "\"" + " " + "static" + " "
                  + Data._localbridgevpnip + " " + Data._localbridgevpnmask + " "; // + Data._localbridgeGW + " " + " 1 "; // no need getway
            var _p1 = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = arg,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
        }

        public static void _startwithDhcpON()
        {
            string _dhcparg = "interface ip set address name=" + "\"" + Data._bridgeWindowsname + "\"" + " dhcp";
            var _dh = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = _dhcparg,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            _dh.Start();
            _dh.WaitForExit(2000);
            _dh.Close();
            ManagementClass mClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mObjCol = mClass.GetInstances();
            foreach (ManagementObject mObj in mObjCol)
            {
                if ((bool)mObj["IPEnabled"])
                {
                    ManagementBaseObject mboDNS = mObj.GetMethodParameters("SetDNSServerSearchOrder");
                    if (mboDNS != null)
                    {
                        mboDNS["DNSServerSearchOrder"] = null;
                        mObj.InvokeMethod("SetDNSServerSearchOrder", mboDNS, null);
                    }
                }
            }
            return;
        }

        public static string ReplaceLastOccurance(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        public static void _returnEth()
        {
            BridgeList._lcl_bridge("p");
            Data._lcl_bridge = Data._tmp;
            string patern = "[(ID=]+\\d+[)|]+[Operating]+g";
            string repl = "";
            Regex rgx = new System.Text.RegularExpressions.Regex(patern);
            string input = Data._lcl_bridge;
            string result1;
            string result2 = rgx.Replace(input, repl).Trim();
            if (result2.Contains("|Operating")) { string result1a = result2.Replace("|Operating", "").Replace(" ", " ").Trim();
                result1 = result1a;
            } else { result1 = result2; }

            var ip = "127.0.0.1";
            ushort port = 5555;
            var pw = "pirkon12";
            using (var softEther = new SoftEther(ip, port))
            {
                var connectResult = softEther.Connect();
                if (!connectResult.Valid())
                {
                    return;
                }
                var authResult = softEther.Authenticate(pw);
                if (!authResult.Valid())
                {
                    return;
                }
                var EthDev = softEther.ServerApi.GetEthernetDeviceList();
                for (int i = 0; i < EthDev.Elements.Count; i++)
                {
                    if (EthDev.Elements[i].DeviceName.Contains(result1))
                        Data._bridgeWindowsname = EthDev.Elements[i].NetworkConnectionName;
                }
                return;
            }
        }
    }
}