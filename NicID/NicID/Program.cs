using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NicID
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowInterfaceSummeary();
        }
        public static void ShowInterfaceSummeary()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                string nic_mac = adapter.GetPhysicalAddress().ToString();
                string brdg = "0015179EB045";
                if( nic_mac == brdg)
                {
                    Console.WriteLine(adapter.Name);
                    Console.WriteLine(adapter.Description);
                    Console.WriteLine(adapter.Id);
                    Console.WriteLine(adapter.GetHashCode());
                    // Console.ReadKey();
                    string temp = adapter.Id;
                    string guid2 = temp.ToUpper().TrimStart().TrimEnd();
                    string guid3 = Regex.Replace(guid2, "[{}-]", "");
                    // var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(guid3));
                    SHA1 _hs = new SHA1CryptoServiceProvider();
                    var hash = _hs.ComputeHash(Encoding.UTF8.GetBytes(guid2));
                    string hash_guid1 = string.Concat(hash.Select(b => b.ToString("X2")));
                    Console.WriteLine(guid2);
                   
                    
                    byte[] rev = hash.Reverse().ToArray();
                    string _rev = string.Concat(rev.Select(b => b.ToString("X2")));

                    Console.WriteLine("Normal order hash hash_guid :  " + hash_guid1);
                    Console.WriteLine("Reverce Hash rev _rev :   " + _rev);

                    UInt32 f = BitConverter.ToUInt32(hash, 0);
                    UInt32 r = BitConverter.ToUInt32(rev, 0);
                    Console.WriteLine("Bitconverter of hash:  " + f);
                    Console.WriteLine("Bitconverter of  rev:  " + r);
                    UInt32 g = ReverseBytes(f);
                    Console.WriteLine("ReverseByte of f hash: " + g);
                    string res = g.ToString().PadLeft(10, '0');
                    Console.WriteLine(res);
                    Console.WriteLine("["+adapter.Name+"]"+adapter.Description + " " + "(ID=" + res + ")");

                    
                    int e = BitConverter.ToInt32(rev, 0);
                    int i = BitConverter.ToInt32(hash, 0);
                    
                    Console.WriteLine(e);
                    Console.WriteLine(i);
                    UInt32 _e = Convert.ToUInt32(e);
                    Console.WriteLine(_e);
                 //   if (BitConverter.IsLittleEndian) // Array.Reverse(rev);
                    
                    UInt32 y = Convert.ToUInt32(e);
                  //  UInt32 d = Convert.ToUInt32(i);
                   
                    Console.ReadKey();
                    uint rvH32 = ReverseBytes(y);
                  //  uint rviH32 = ReverseBytes(d);
                    Console.WriteLine(rvH32);
                  //  Console.WriteLine(rviH32); 
                    Console.ReadKey();
                }

            }
            
        }
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }
        public static UInt64 ReverseBytes(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }
    }

}
