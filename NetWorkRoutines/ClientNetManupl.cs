using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkRoutines
{
    class ClientNetManupl
    {
        public static void _clientNetManpl()
        {
            //  ClientParam._vpn_ip = "192.168.1.100";
            //  ClientParam._vpn_ip_mask = "255.255.255.0";
            //  ClientParam._vpn_dns = "8.8.8.8";
            //   ClientParam._vpn_add_IP = "192.168.1.166";
            //   ClientParam._vpn_add_IP_mask = "255.255.255.0";
            GetBestRouteTest test = new GetBestRouteTest();
            test.Test();
            Class1._my_ip = RetrIPMAC.GetLocalIPAddress();
            NicInfo.ShowInterfaceSummary();
            if (Class1._nic_dhcp)
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
        }
}
