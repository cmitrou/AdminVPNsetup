using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Powershell
{
    class Program
    {
        static void Main(string[] args)
        {

            using (PowerShell _ps = PowerShell.Create())
            {
                _ps.AddCommand("Get-NetAdapterBinding");
                //_ps.AddArgument(Name + "Ethernet 4 " + "AllBindings");
                 _ps.AddParameter("Name", "Ethernet 4");
                //  ps.AddParameter("DisplayName", "Internet Protocol Version 4 (TCP/IPv4)");
                //_ps.Invoke();
                  Collection<PSObject> PSoutout  = _ps.Invoke();
                // var res = _ps.Invoke();
                var list = new List<string>();
                foreach (PSObject outItem in PSoutout)
                {
                    if(outItem != null)
                    {
                      //  Console.WriteLine(outItem);
                        Console.WriteLine(outItem.Properties["ComponentID"].Value + " " + outItem.Properties["Enabled"].Value);
                        //   Console.WriteLine(outItem.BaseObject.ToString() + "\n");
                        list.Add(outItem.Properties["ComponentID"].Value + " " + outItem.Properties["Enabled"].Value);
                    }
                }
            }
            
            System.Console.WriteLine("Hit any key to exit.");
            System.Console.ReadKey();

        }
    }
}
