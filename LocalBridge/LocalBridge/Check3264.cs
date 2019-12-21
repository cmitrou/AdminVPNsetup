using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBridge
{
    public class Check3264
    {
        public static void _setEnv()           
        {
            if (System.Environment.Is64BitOperatingSystem)
            {
                Variables.xFlag = "64";
                Variables.vpncmd = "vpncmd_x64.exe";
                Variables.vpnbridge = "vpbridge_x64.exe";
            }
            else
            {
                Variables.xFlag = "32";
                Variables.vpncmd = "vpncmd.exe";
                Variables.vpnbridge = "vpnbridge.exe";                
            }
        }
    }
}
