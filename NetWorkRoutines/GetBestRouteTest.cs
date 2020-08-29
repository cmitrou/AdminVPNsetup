using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace NetWorkRoutines
{
    class GetBestRouteTest
    {
        static class NativeMethods
        {
            [DllImport("Iphlpapi.dll", SetLastError = true)]
            internal extern static Int32 GetBestRoute(
              UInt32 dwDestAddr,
              UInt32 dwSourceAddr,
              IntPtr /*PMIB_IPFORWARDROW*/ pBestRoute);
            [DllImport("Iphlpapi", SetLastError = true)]
            internal extern static Int32 GetBestRoute(
              UInt32 dwDestAddr,
              UInt32 dwSourceAddr,
              out MIB_IPFORWARDROW pBestRoute);

            internal struct MIB_IPFORWARDROW
            {
                internal int dwForwardDest;
                internal int dwForwardMask;
                internal int dwForwardPolicy;
                internal int dwForwardNextHop;
                internal int dwForwardIfIndex;
                internal int dwForwardType;
                internal int dwForwardProto;
                internal int dwForwardAge;
                internal int dwForwardNextHopAS;
                internal int dwForwardMetric1;
                internal int dwForwardMetric2;
                internal int dwForwardMetric3;
                internal int dwForwardMetric4;
                internal int dwForwardMetric5;
            }

            [DllImport("Iphlpapi", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.U4)]
            internal extern static Int32 GetBestInterfaceEx(
              byte[] socketAddress,
              out Int32 pdwBestIfIndex);

        }

        public void Test()
        {
            IPAddress dst, result;
            int ifIndex;
            PhysicalAddress macAddr;
            dst = IPAddress.Parse("8.8.8.8");
            result = GetBestRoute(dst);
            ifIndex = GetBestInterface(dst);
            macAddr = foo(ifIndex);
            Class1._nic_mac = macAddr.ToString();
            Class1._nic_idx = ifIndex.ToString();
            Class1._getway = result.ToString();
            while (true)
            {
                //   Console.Write("> ");
                var line = "";
                // Console.ReadLine();
                if (string.IsNullOrEmpty(line)) { break; }
                dst = IPAddress.Parse(line);
                result = GetBestRoute(dst);
                ifIndex = GetBestInterface(dst);
                macAddr = foo(ifIndex);
            }
        }

        private PhysicalAddress foo(int ifIndex)
        {
            var q = from ni in NetworkInterface.GetAllNetworkInterfaces()
                    where ni.GetIPProperties().GetIPv4Properties().Index == ifIndex
                        || ni.GetIPProperties().GetIPv4Properties().Index == ifIndex
                    select ni;
            var rslt = q.First();
            var macAddr = rslt.GetPhysicalAddress();
            return macAddr;
        }

        public IPAddress GetBestRoute(IPAddress destination)
        {
            if (destination.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                throw new ArgumentException("Address must be IPv4.");
            var arr = destination.GetAddressBytes();
            var ipInt = BitConverter.ToUInt32(arr, 0);
            NativeMethods.MIB_IPFORWARDROW row;
            var ret = NativeMethods.GetBestRoute(ipInt, 0, out row);
            if (ret != 0)
                throw new Win32Exception();
            var nextHop = IPAddressFromInt(row.dwForwardNextHop);
            var dest = IPAddressFromInt(row.dwForwardDest);
            var mask = IPAddressFromInt(row.dwForwardMask);
            var proto = row.dwForwardProto;
            var ifIndex = row.dwForwardIfIndex;
            return nextHop;
        }

        int GetBestInterface(IPAddress destination)
        {
            var ep = new IPEndPoint(destination, 0);
            var sa = ep.Serialize();
            var arrSa = CopyArray(sa);
            int ifIndex;
            var ret = NativeMethods.GetBestInterfaceEx(arrSa, out ifIndex);
            if (ret != 0)
                throw new Win32Exception();
            return ifIndex;
        }

        private byte[] CopyArray(SocketAddress sa)
        {
            var arr = new byte[sa.Size];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = sa[i];
            }
            return arr;
        }

        private IPAddress IPAddressFromInt(int p)
        {

            string Hex = p.ToString("X16");
            var t = long.Parse(Hex, System.Globalization.NumberStyles.HexNumber);
            return IPAddressFromInt(t);
        }

        private IPAddress IPAddressFromInt(long p2)
        {
            return new IPAddress(p2);
        }
    }
}
