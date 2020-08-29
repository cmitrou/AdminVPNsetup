using SoftEther.VPNServerRpc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Security;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;

namespace softRpcCalls
{
    public class Class1
    {
        public class SoftTest
        {
            VpnServerRpc api;
            string Hub_name = "RMT";
            public SoftTest()
            {
                api = new VpnServerRpc("192.168.97.112", 443, "pirkon12,", "");
            }
            public void GetServerInfo()
            {
                VpnRpcServerInfo info = api.GetServerInfo();

                string _a1 = RJson(info);
                _save(_a1, "te1.txt");

                //return info;
            }

            public string RJson(object obj)
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error,
                };
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, settings);
               // _save(str, "te1.txt");
                return str;
            }

            public void  _save(string a1, string name)
            {
                string path = @"c:\temp\";
                string fname = name;
                string full = path + fname;
                File.WriteAllText(full, a1);
                

            }


        }
    }
}
