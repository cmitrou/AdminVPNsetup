﻿using System.Management.Automation;
using System.Threading;

namespace NewBridgeClient
{
    public class Protocols
    {
        public static void _cmd_disable_all()
        {
            // NicInfo._brdgeNicName();
            using (PowerShell _psc = PowerShell.Create())
            {
                _psc.AddScript("param($param1) $d = Disable-NetAdapterBinding -Name " + "\"" + Data._bridgeWindowsname + "\"" + " -AllBindings" + " -AsJob");
                _psc.AddParameter("param1");
                _psc.Invoke();
            }
            //  Thread.Sleep(5000);
            //  return;
        }

        public static void _cmd_enable_all()
        {
            // NicInfo._brdgeNicName();
            using (PowerShell _psc = PowerShell.Create())
            {
                _psc.AddScript("param($param1) $d = Enable-NetAdapterBinding -Name " + "\"" + Data._bridgeWindowsname + "\"" + " -AllBindings" + " -AsJob");
                _psc.AddParameter("param1");
                _psc.Invoke();
            }
            //  return;
        }

        public static void _cmd_enable_vpn()
        {
            //  NicInfo._brdgeNicName();
            using (PowerShell _psc = PowerShell.Create())
            {
                //  _psc.AddScript("param($param1) $d = Enable-NetAdapterBinding -Name " + "\"Ethernet 4\"" + " -ComponentID SeLow");
                _psc.AddScript("param($param1) $d = Enable-NetAdapterBinding -Name " + "\"" + Data._bridgeWindowsname + "\"" + " -ComponentID SeLow");
                _psc.AddParameter("param1");
                _psc.Invoke();
            }
            //  return;
        }

        public static void _cmd_enable_bindings()
        {
            int v;
            using (PowerShell _psc = PowerShell.Create())
            {
                _psc.AddScript("param($param1) $d = Enable-NetAdapterBinding -Name Ethernet* -Allbindings");
                _psc.AddParameter("param1");
                _psc.Invoke();
            }
            Thread.Sleep(5000);
            using (PowerShell _psc = PowerShell.Create())
            {
                _psc.AddScript("param($param1) $d = Disable-NetAdapterBinding -Name Ethernet* -ComponentID ms_tcpip6");
                _psc.AddParameter("param1");
                _psc.Invoke();
            }
        }
    }
}