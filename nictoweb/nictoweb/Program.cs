using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace nictoweb
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientParam._vpn_ip = "192.168.1.100";
            ClientParam._vpn_ip_mask = "255.255.255.0";
            ClientParam._vpn_dns = "8.8.8.8";
            ClientParam._vpn_add_IP = "192.168.1.166";
            ClientParam._vpn_add_IP_mask = "255.255.255.0";
            GetBestRouteTest test = new GetBestRouteTest();
            test.Test();
            Class1._my_ip = RetrIPMAC.GetLocalIPAddress();           
            // Class1._nic_mac = RetrIPMAC.GetMacAddress().ToString();
            //Dictionary<IPAddress, PhysicalAddress> all = RetrIPMAC.GetAllDevicesOnLAN();
            //foreach (KeyValuePair<IPAddress,PhysicalAddress> kvp in all)
            //{
            //    Console.WriteLine("IP: {0}\n MAC {1}", kvp.Key, kvp.Value);
            //    Class1._my_ip = kvp.Key.ToString();
            // }
            //Console.ReadKey();
            NicInfo.ShowInterfaceSummary();
           // Class1._my_ip = RetrIPMAC.GetIPAddress().ToString();
            //Console.WriteLine(Class1._nic_type);
            //Console.WriteLine(Class1._nic_name);
            //Console.WriteLine(Class1._nic_descr);
            //Console.WriteLine(Class1._nic_mac);
            //Console.WriteLine(Class1._nic_idx);
            //Console.WriteLine(Class1._my_ip);
            //Console.WriteLine(Class1._getway);
            if(Class1._nic_dhcp)
            {
            //  Console.WriteLine("DHCP");
                SetStaticIP._SetStatic();
                SetStaticIP._SetStaticDNS();
                SetStaticIP._SetAdditionalIP();
            }
            else
            {
            //    Console.WriteLine("Static");
                SetStaticIP._SetAdditionalIP();
            }
           // SetStaticIP._SetStatic();
           //  Console.Read();
           // SetStaticIP._DeleteAdditionalIP();
        }
    }
}
