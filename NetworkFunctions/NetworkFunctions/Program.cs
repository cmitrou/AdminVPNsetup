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
                netw_card = adapter.Description +" "+ adapter.Id;
                byte[] idbuffer = Encoding.UTF8.GetBytes(adapter.Id.Trim());
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(idbuffer);
                    var sb = new StringBuilder(hash.Length);
                    foreach (byte b1 in hash)
                    {

                        sb.Append(b1.ToString());
                    }
                   string crdid1 = sb.ToString();
                    string crdid = Encoding.UTF8.GetString(idbuffer, 0, idbuffer.Length);
                    Console.WriteLine("Hashed" , crdid1);
                }
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
