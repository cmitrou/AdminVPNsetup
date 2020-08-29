using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SoftEtherApi;
using SoftEtherApi.Infrastructure;
using SoftEtherApi.Model;

namespace WindowsFormsApp1
{
    class test
    {
        public static void Test()
        {
            var IP = "vpn203410648.softether.net";
            var pw = "12345";
            ushort port = 443;
            var hubName = "Tools";
            var userName = "chris";
            var network = "192.168.178.0";
            var networkSubnet = "255.255.255.0";

            {
                using (var softEther = new SoftEther(IP, port))

                {
                    var connectResult = softEther.Connect();
                    if (!connectResult.Valid())
                    {
                        string _V = "error";
                        return;
                    }
                    var authResult = softEther.Authenticate(pw);
                    if (!authResult.Valid())
                    {
                        string _V = "error";
                        return;
                    }
                    var natOnline = softEther.HubApi.EnableSecureNat(hubName);
                    var natOptions = softEther.HubApi.GetSecureNatOptions(hubName);
                    var pushRoutesResult = softEther.HubApi.SetSecureNatDhcpPushRoutes(hubName, new DhcpRouteCollection
                    {
                        {network, networkSubnet, natOptions.DhcpGatewayAddress.ToString()}
                    });
                    var deviceAclList = softEther.HubApi.SetAccessList(hubName, AccessListFactory.AllowDevicesOnly(
                        natOptions.DhcpGatewayAddress, natOptions.DhcpSubnetMask, new AccessDevice("192.168.178.240", "Server")));
                    var fritz = softEther.HubApi.AddAccessList(hubName, AccessListFactory.AccessToDevice(AccessListFactory.AllowDevicesPriority,
                    "FritzBox", IPAddress.Parse("192.168.178.1"), natOptions.DhcpGatewayAddress, natOptions.DhcpSubnetMask));
                }
            }
        }
    }
}
