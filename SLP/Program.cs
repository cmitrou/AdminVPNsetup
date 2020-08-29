using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlpSharp;
using slp
namespace SLP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var slp = new SlpClient(String.Empty))
            {
                Console.WriteLine("SLP Opened");
                  slp.Find("inbtest:inb.http", new string[0],
          delegate (string url, UInt16 lifetime)
          {
              // found a service
              Console.WriteLine("found {0}, lifetime = {1}", url, lifetime);
          });
            }
        }
    }
}
