using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinishingSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceControl._Start_sevpnservice();
            System.Threading.Thread.Sleep(500);
            string path = @"C:\Program Files\VPN_Tools\";
            string path1 = @"C:\Program Files\VPN_Tools\initconfig\";
            string file = "vpn_bridge.config";
            ServiceControl._Stop_sevpnservice();
            System.Threading.Thread.Sleep(500);
            if (File.Exists(Path.Combine(path, file)))
                File.Delete(Path.Combine(path, file));
            File.Copy(path1 + file, path + file);
           

        }
    }
}
