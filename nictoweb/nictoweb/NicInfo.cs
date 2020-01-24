using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace nictoweb
{
    public class NicInfo
    {
        public static void ShowInterfaceSummary()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                string nic_mac = adapter.GetPhysicalAddress().ToString();
                if(nic_mac == Class1._nic_mac)
                {                  
                    Class1._nic_name = adapter.Name;
                    Class1._nic_descr = adapter.Description;
                    Class1._nic_type = adapter.NetworkInterfaceType.ToString();
                    Class1._nic_dhcp = adapter.GetIPProperties().GetIPv4Properties().IsDhcpEnabled;
                }
            }
         //   Console.WriteLine();
        }
    }
}
