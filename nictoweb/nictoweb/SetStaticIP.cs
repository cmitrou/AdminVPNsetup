using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nictoweb
{
    public class SetStaticIP
    {
       public static void _SetStatic()
        {
            Process _p1 = new Process();
            _p1.StartInfo.FileName = "netsh.exe";
            _p1.StartInfo.UseShellExecute = false;
            _p1.StartInfo.CreateNoWindow = true;
            _p1.StartInfo.RedirectStandardOutput = true;
            string arg2 = Class1._my_ip + " " + "255.255.255.0" + " " + Class1._getway + " " + "1";
            string arg4 = "interface ip set address name=" + "\"" + Class1._nic_name + "\"" + " " + "static" + " ";
            string arg3 = arg4 + arg2;
            _p1.StartInfo.Arguments = arg3;
            try
            {
                _p1.Start();
                _p1.WaitForExit(3000);
                string infostring = _p1.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p1.Close();
            }
            catch { }

        }
        public static void _SetStaticDNS()
        {
            Process _p2 = new Process();
            _p2.StartInfo.FileName = "netsh.exe";
            _p2.StartInfo.UseShellExecute = false;
            _p2.StartInfo.CreateNoWindow = true;
            _p2.StartInfo.RedirectStandardOutput = true;
            string arg2 = "interface ip set dns name=" + "\"" + Class1._nic_name + "\"" + " " + "static" + " " + ClientParam._vpn_dns;
            _p2.StartInfo.Arguments = arg2;
            try
            {
                _p2.Start();
                _p2.WaitForExit(3000);
                string infostring = _p2.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p2.Close();
            }
            catch { }
            // _p2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        }
        public static void _SetAdditionalIP()
        {
            Process _p3 = new Process();
            _p3.StartInfo.FileName = "netsh.exe";
            _p3.StartInfo.UseShellExecute = false;
            _p3.StartInfo.CreateNoWindow = true;
            _p3.StartInfo.RedirectStandardOutput = true;
            string arg5 = " " + "interface ip add address name=" + "\"" + Class1._nic_name + "\"" + " "
                + ClientParam._vpn_add_IP + " " + ClientParam._vpn_add_IP_mask + " " + "SkipAsSource=true";
            _p3.StartInfo.Arguments = arg5;
            try
            {
                _p3.Start();
                _p3.WaitForExit(3000);
                string infostring = _p3.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p3.Close();
            
            }
            catch
            { }
        }
        public static void _DeleteAdditionalIP()
        {
            Process _p4 = new Process();
            _p4.StartInfo.FileName = "netsh.exe";
            _p4.StartInfo.UseShellExecute = false;
            _p4.StartInfo.CreateNoWindow = true;
            _p4.StartInfo.RedirectStandardOutput = true;
            string arg6 = " " + "interface ip delete address name=" + "\"" + Class1._nic_name + "\"" + " "
              + "addr="  + ClientParam._vpn_add_IP; // + " " + ClientParam._vpn_add_IP_mask;
            _p4.StartInfo.Arguments = arg6;
            try
            {
                _p4.Start();
                _p4.WaitForExit(3000);
                string infostring = _p4.StandardOutput.ReadToEnd();
                ClientParam._infostring = infostring;
                _p4.Close();
            }
            catch
            { }
        }
    }
}
