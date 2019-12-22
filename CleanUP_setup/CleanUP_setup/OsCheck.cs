using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Os Check if 32bit or 64bit
namespace CleanUP_setup
{
    class OsCheck
    {
        public static void _setEnv()
        {
            if (System.Environment.Is64BitOperatingSystem)
            {
                Vars.Variables.xFlag = "64";
                Vars.Variables.vpncmd = "vpncmd_x64.exe";
                Vars.Variables.vpnbridge = "vpbridge_x64.exe";
            }
            else
            {
                Vars.Variables.xFlag = "32";
                Vars.Variables.vpncmd = "vpncmd.exe";
                Vars.Variables.vpnbridge = "vpnbridge.exe";
            }
        }
    }
}
