using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Check3264._setEnv();
            string path = @"c:\temp";
            Directory.CreateDirectory(path); 
            ServiceControl._Start_sevpnservice();
            DeviceList._GetfLocalBridgeDeviceList();
            DeviceList._Capable_cards();
            DeviceList._Save_LocalBridge();
            DeviceList._Print_Local_Bridge();
            LocalBridgeChange._localbridgechange();          
            ServiceControl._Stop_sevpnservice();
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(path);
        }
        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
