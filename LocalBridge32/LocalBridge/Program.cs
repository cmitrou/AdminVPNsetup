using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp";
             if (Directory.Exists(path)) { return; } else { Directory.CreateDirectory(path); };
            ServiceControl._Start_sevpnservice();
            DeviceList._GetfLocalBridgeDeviceList();
            DeviceList._Capable_cards();
            DeviceList._Save_LocalBridge();
            DeviceList._Print_Local_Bridge();
            LocalBridgeChange._localbridgechange();
            ServiceControl._Stop_sevpnservice();
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(path);

        }
    }
}
