namespace NewBridgeClient
{
    internal class OsCheck
    {
        public static void _setEnv()
        {
            if (System.Environment.Is64BitOperatingSystem)
            {
                Data.xFlag = "64";
                Data._vpncmd_exe = "vpncmd_x64.exe";
                Data._vpnbridge_exe = "vpbridge_x64.exe";
            }
            else
            {
                Data.xFlag = "32";
                Data._vpncmd_exe = "vpncmd.exe";
                Data._vpnbridge_exe = "vpnbridge.exe";
            }
        }
    }
}