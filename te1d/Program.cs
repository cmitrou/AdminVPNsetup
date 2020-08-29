using Microsoft.SqlServer.Server;
using SoftEther.VPNServerRpc;
using System;
using System.IO;

namespace te1d
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            VPNRPCTest _r = new VPNRPCTest();
            _r.Test_GetServerInfo();
        }

        private class VPNRPCTest
        {
            private VpnServerRpc api;

            private Random rand = new Random();

            private string hub_name = "TEST";

            public VPNRPCTest()
            {
                api = new VpnServerRpc("192.168.97.112", 443, "pirkon12", "");       // Speficy your VPN Server's password here.
            }

            public void Test_GetServerInfo()
            {
                Console.WriteLine("Begin: Test_GetServerInfo");

                VpnRpcServerInfo info = api.GetServerInfo();
                string v = print_object(info);
            }
        }

        public static string print_object(object obj)
        {
            var setting = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error,
            };
            string g = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, setting);
            string path = @"c:\temp\rslt.txt";
         //   StreamWriter writer = new StreamWriter(path);
            File.WriteAllText(path,g);
            return g;
        }
    }
}