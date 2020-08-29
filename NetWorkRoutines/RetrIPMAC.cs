using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace NetWorkRoutines
{
    public static class RetrIPMAC
    {

        static class NativeMethods
        {
            [DllImport("IpHlpApi.dll")]
            [return: MarshalAs(UnmanagedType.U4)]
            internal extern static int GetIpNetTable(IntPtr pIpNetTable,
               [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);
            const int ERROR_INSUFFICIENT_BUFFER = 122;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct MIB_IPNETROW
        {
            [MarshalAs(UnmanagedType.U4)]
            internal int dwIndex;
            [MarshalAs(UnmanagedType.U4)]
            internal int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac0;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac1;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac2;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac3;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac4;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac5;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac6;
            [MarshalAs(UnmanagedType.U1)]
            internal byte mac7;
            [MarshalAs(UnmanagedType.U4)]
            internal int dwAddr;
            [MarshalAs(UnmanagedType.U4)]
            internal int dwType;


        }

        public static Dictionary<IPAddress, PhysicalAddress> GetAllDevicesOnLAN()
        {
            Dictionary<IPAddress, PhysicalAddress> all = new Dictionary<IPAddress, PhysicalAddress>();
            all.Add(GetIPAddress(), GetMacAddress());
            int spaceForNetTable = 0;
            NativeMethods.GetIpNetTable(IntPtr.Zero, ref spaceForNetTable, false);
            IntPtr rawTable = IntPtr.Zero;
            try
            {
                rawTable = Marshal.AllocCoTaskMem(spaceForNetTable);
                int errorCode = NativeMethods.GetIpNetTable(rawTable, ref spaceForNetTable, false);
                if (errorCode != 0)
                {
                    throw new Exception(string.Format(
                     "Unable to retrieve network table. Error code {0}", errorCode));
                }
                int rowsCount = Marshal.ReadInt32(rawTable);
                IntPtr currentBuffer = new IntPtr(rawTable.ToInt64() + Marshal.SizeOf(typeof(Int32)));
                MIB_IPNETROW[] rows = new MIB_IPNETROW[rowsCount];
                for (int index = 0; index < rowsCount; index++)
                {
                    rows[index] = (MIB_IPNETROW)Marshal.PtrToStructure(new IntPtr(currentBuffer.ToInt64() +
                                                (index * Marshal.SizeOf(typeof(MIB_IPNETROW)))
                                               ),
                                                typeof(MIB_IPNETROW));
                }
                PhysicalAddress virtualMAC = new PhysicalAddress(new byte[] { 0, 0, 0, 0, 0, 0 });
                PhysicalAddress broadcastMAC = new PhysicalAddress(new byte[] { 255, 255, 255, 255, 255, 255 });
                foreach (MIB_IPNETROW row in rows)
                {
                    IPAddress ip = new IPAddress(BitConverter.GetBytes(row.dwAddr));
                    byte[] rawMAC = new byte[] { row.mac0, row.mac1, row.mac2, row.mac3, row.mac4, row.mac5 };
                    PhysicalAddress pa = new PhysicalAddress(rawMAC);
                    if (!pa.Equals(virtualMAC) && !pa.Equals(broadcastMAC) && !IsMulticast(ip))
                    {
                        if (!all.ContainsKey(ip))
                        {
                            all.Add(ip, pa);
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(rawTable);
            }
            return all;
        }

        public static IPAddress GetIPAddress()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress ip in addr)
            {
                if (!ip.IsIPv6LinkLocal)
                {
                    return (ip);
                }
            }
            return addr.Length > 0 ? addr[0] : null;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }


        private static bool IsMulticast(IPAddress ip)
        {
            bool result = true;
            if (!ip.IsIPv6Multicast)
            {
                byte highIP = ip.GetAddressBytes()[0];
                if (highIP < 224 || highIP > 239)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
