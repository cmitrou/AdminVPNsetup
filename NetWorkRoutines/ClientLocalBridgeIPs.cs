using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkRoutines
{
    class ClientLocalBridgeIPs
    {
        public static void _setLcBr_IP()
        {
            _LocalBridge_SetStatic();
            _LocalBridge_SetStatic_DNS();
            _LocalBridge_Set169();
            return;
        }
        public static void _setLcBr_Dhcp()
        {
            _LocalBridge_SetDHCP();
            _SetLocalBridgeDNS_DHCP();
            return;
        }
        public static void _LocalBridge_SetStatic()
        {
            Process _p1a = new Process();
            _p1a.StartInfo.FileName = "netsh.exe";
            _p1a.StartInfo.UseShellExecute = true;
            _p1a.StartInfo.CreateNoWindow = true;
            _p1a.StartInfo.RedirectStandardOutput = false;
            string arg2 = ClientParam._vpn_add_IP + " " + "255.255.255.0" + " " + ClientParam._vpn_Local_bridge_gw + " " + "1";
            string arg4 = "interface ip set address name=" + "\"" + ClientParam._vpn_bridge_name + "\"" + " " + "static" + " ";
            string arg3 = arg4 + arg2;
            _p1a.StartInfo.Arguments = arg3;
            try
            {
                _p1a.Start();
                _p1a.WaitForExit(500);
                string infostring = _p1a.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1a.Close();
            }
            catch { }
        }
        public static void _LocalBridge_SetStatic_DNS()
        {
            Process _p1b = new Process();
            _p1b.StartInfo.FileName = "netsh.exe";
            _p1b.StartInfo.UseShellExecute = false;
            _p1b.StartInfo.CreateNoWindow = true;
            _p1b.StartInfo.RedirectStandardOutput = true;
            string arg3a = "interface ip set dns name=" + "\"" + ClientParam._vpn_bridge_name + "\"" + " " + "static" + " " + ClientParam._vpn_Local_bridge_dns;
            _p1b.StartInfo.Arguments = arg3a;
            try
            {
                _p1b.Start();
                _p1b.WaitForExit(3000);
                string infostring = _p1b.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1b.Close();
            }
            catch { }
        }
        public static void _LocalBridge_Set169()
        {
            Process _p1c = new Process();
            _p1c.StartInfo.FileName = "netsh.exe";
            _p1c.StartInfo.UseShellExecute = false;
            _p1c.StartInfo.CreateNoWindow = true;
            _p1c.StartInfo.RedirectStandardOutput = true;
            string arg3b = "interface ip add address name=" + "\"" + ClientParam._vpn_bridge_name + "\"" + " " + ClientParam._vpn_bridge_169ip + " " + ClientParam._vpn_bridge_169mask;
            _p1c.StartInfo.Arguments = arg3b;
            try
            {
                _p1c.Start();
                _p1c.WaitForExit(3000);
                string infostring = _p1c.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1c.Close();
            }
            catch { }
        }
        public static void _LocalBridge_SetDHCP()
        {
            Process _p1d = new Process();
            _p1d.StartInfo.FileName = "netsh.exe";
            _p1d.StartInfo.UseShellExecute = false;
            _p1d.StartInfo.CreateNoWindow = true;
            _p1d.StartInfo.RedirectStandardOutput = true;
            string arg3c = "interface ip set address name=" + "\"" + ClientParam._vpn_bridge_name + "\"" + " " + "dhcp";
            _p1d.StartInfo.Arguments = arg3c;
            try
            {
                _p1d.Start();
                _p1d.WaitForExit(3000);
                string infostring = _p1d.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1d.Close();
            }
            catch { }
            return;
        }
        public static void _SetLocalBridgeDNS_DHCP()
        {
            Process _p1e = new Process();
            _p1e.StartInfo.FileName = "netsh.exe";
            _p1e.StartInfo.UseShellExecute = false;
            _p1e.StartInfo.CreateNoWindow = true;
            _p1e.StartInfo.RedirectStandardOutput = true;
            string arg4a = "interface ip set dns name=" + "\"" + ClientParam._vpn_bridge_name + "\"" + " " + "dhcp"; // + " " + ClientParam._vpn_Local_bridge_dns;
            _p1e.StartInfo.Arguments = arg4a;
            try
            {
                _p1e.Start();
                _p1e.WaitForExit(3000);
                string infostring = _p1e.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1e.Close();
            }
            catch { }
        }
    }
}
