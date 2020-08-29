using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
namespace NetWorkRoutines
{
    class NicInfo
    {
        public static void ShowInterfaceSummary()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                string nic_mac = adapter.GetPhysicalAddress().ToString();
                if (nic_mac == Class1._nic_mac)
                {
                    Class1._nic_name = adapter.Name;
                    Class1._nic_descr = adapter.Description;
                    Class1._nic_type = adapter.NetworkInterfaceType.ToString();
                    Class1._nic_dhcp = adapter.GetIPProperties().GetIPv4Properties().IsDhcpEnabled;
                }
            }
            return;
        }
        public static void _brdgeNicName()
        {
            //string nic_Descr = string.Empty;
            string patern = "[(ID=]+\\d+[)|]+[Operating]+g";
            string repl = "";
            Regex rgx = new Regex(patern);
            string input = Variables._lcl_bridge;
            string result = rgx.Replace(input, repl).Trim();
            // Console.WriteLine(result);
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                string _rt1 = adapter.Description.Trim();
                string _rt2 = adapter.Name.Trim();
                string _rt3 = adapter.Id;
                //    Console.WriteLine(_rt1 + " " + _rt2 + " " + _rt3);
                ;
                if (_rt1 == result)

                {
                    ClientParam._vpn_bridge_name = adapter.Name.ToString();
                    ClientParam._vpn_localbridge_dhcp_flag = adapter.GetIPProperties().GetIPv4Properties().IsDhcpEnabled;
                    //   Console.WriteLine(" 111   "+adapter.Name.ToString());
                }
            }
            return;
        }
        public static void _nicList()
        {
            string patern = "[(ID=]+\\d+[)|]+[Operating]+g";
            string repl = "";
            Regex rgx = new Regex(patern);
            string input = Variables._lcl_bridge;
            string result = rgx.Replace(input, repl).Trim();
            List<string> values = new List<String>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                values.Add(nic.Description);
                values.Add(nic.Name);
                values.Add(nic.GetIPProperties().GetIPv4Properties().IsDhcpEnabled.ToString());
            }
            int i;
            for (i = 0; i < values.Count; i++)
            {
                //  Console.WriteLine(values[i]);
                if (values[i].Equals(result))
                {
                    ClientParam._vpn_bridge_name = values[i + 1]; ClientParam._vpn_localbridge_dhcp_flag1 = values[i + 2];
                }
            }
            return;
        }
        public static void _nicDns()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                if (dnsServers.Count > 0)
                {
                    // store them (adapter.Description)
                    foreach (IPAddress dns in dnsServers)

                    {
                        dns.ToString();

                    }

                }
            }
        }
        public static void _lclBridConnected()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.Name == ClientParam._vpn_bridge_name)
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            using (client.OpenRead("http://www.google.com/"))
                            {
                                ClientParam._vpn_connected = true;
                            }
                        }
                    }
                    catch
                    {
                        ClientParam._vpn_connected = false;
                    }

                }

            }
            return;
        }
    }
}
