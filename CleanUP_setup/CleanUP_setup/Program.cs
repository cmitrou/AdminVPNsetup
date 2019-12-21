using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUP_setup
{
    class Program
    {
        static void Main(string[] args)
        {
            OsCheck._setEnv(); 
            string path = "c:\\Program Files\\VPN_Tools";
            if(Vars.Variables.xFlag == "64") { File.Delete(path + "\\vpncmd.exe"); File.Delete(path + "\\vpnbridge.exe"); }
            if(Vars.Variables.xFlag == "32") { File.Delete(path + "\\vpncmd_x64.exe"); File.Delete(path + "\\vpnbridge_x64.exe"); }
            return;
        }
    }
}
