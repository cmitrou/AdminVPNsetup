using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft;


namespace NetworkFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            DetectNetworkAdapter();
        }
        static void DetectNetworkAdapter()
        {
            string netw_card;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine("Name: {0}", adapter.Name);
                Console.WriteLine("Name: {0}", adapter.Id);
                netw_card = adapter.Description + " " + adapter.Id;
                string crd_id = adapter.Id.Trim(new Char[] { '{', '}' });
                crd_id = (crd_id.Remove(8, 1).Remove(12, 1).Remove(16, 1).Remove(20, 1));
                Console.WriteLine(crd_id);

                //      //  byte[] idbuffer1 = Encoding.UTF8.GetBytes(adapter.Id.Trim());
                //      // using (SHA1Managed sha1 = new SHA1Managed().HashSize)
                //      int DATA_SIZE = 20;
                //      byte[] idbuffer1 = (Encoding.UTF8.GetBytes(crd_id));
                ////      idbuffer1 = new byte[DATA_SIZE];
                //      byte[] idbuffer =  new byte[DATA_SIZE];
                ////      idbuffer = idbuffer1;
                //      byte[] reslt;
                //      SHA1 sha = new SHA1CryptoServiceProvider();
                //      reslt = sha.ComputeHash(idbuffer1);
                // //     if (BitConverter.IsLittleEndian)
                //  //        Array.Reverse(reslt);
                //      Int32 i = BitConverter.ToInt32(reslt, 0);
                //      Console.WriteLine("int: {0}", i);
                ////     string crdid1 = sb.ToString();
                //     string crdid = Encoding.UTF8.GetString(reslt, 0, reslt.Length);
                //      Console.WriteLine(crdid.Trim());
                ////  }
                ///
                var data = Encoding.ASCII.GetBytes(crd_id);
                byte[] hasData = new SHA1Managed().ComputeHash(data);
                var hash = string.Empty;
                foreach (var b in hasData)
                    
                {
                    hash += b.ToString("X2");
                }
                Console.WriteLine(hash);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(hasData);
                    Int32 i = BitConverter.ToInt32(hasData, 0);
                Console.WriteLine("int: {0}", i);
                Console.WriteLine(netw_card);
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                Console.WriteLine();
                Console.ReadKey();
            }
        }
     ////   static string GenIdFromGuid(string input)
     ////   {
     ////       byte[] buffer = Encoding.UTF8.GetBytes(input);

     //       using (SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
     //       {
                
     //           var has1 = sha1.ComputeHash(buffer);
     //           var sb = new StringBuilder(hash.Length * 2);
     //           foreach (byte b1 in hash)
     //           {
     //               sb.Append(b.ToString("X2"));
     //           }
     //           return sb.ToString();
     //       }

       
    }
}
