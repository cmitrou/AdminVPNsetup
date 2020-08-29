using System;
using System.Net.NetworkInformation;
using SoftEther.VPNServerRpc;
namespace rpccalls
{
    class VPNRPCTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            _Devlist();
        }

        


        public  static void _Devlist()
        {
            VpnServerRpc api;
            api = new VpnServerRpc("127.0.0.1", 5555, "pirkon12", "");
            Console.WriteLine("Begin: Test_EnumEthernet");

            VpnRpcEnumEth out_rpc_enum_eth = api.EnumEthernet();
            VpnRpcEnumLocalBridge b = api.EnumLocalBridge();

            print_object(out_rpc_enum_eth);
            Console.WriteLine("/n");
            print_object(b);
            Console.WriteLine("End: Test_EnumEthernet");
            Console.WriteLine("-----");
            Console.WriteLine();
            Console.WriteLine("End: Test_Test");
            Console.WriteLine("-----");
            Console.WriteLine();
            DisplayDnsConfiguration();

        }
        static void print_object(object obj)
        {
            var setting = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error,
            };
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, setting);
            Console.WriteLine(str);
        }
        public static void DisplayDnsConfiguration()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(adapter.Id);
                Console.WriteLine(adapter.Name);
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i< bytes.Length; i++ )
                {
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
;
                }

               
                
            }
            Console.WriteLine();
        }
    }
}


