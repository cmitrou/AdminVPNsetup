using System.Collections.Generic;

namespace NewBridgeClient
{
    public class Data
    {
        public static string AppRunDir { get; set; }
        public static string xFlag { get; set; }
        public static string _vpncmd_exe { get; set; }
        public static string _vpnbridge_exe { get; set; }
        public static string ServerName { get; set; }
        public static string _mode { get; set; }
        public static string ServerHub { get; set; }
        public static string _userName { get; set; }
        public static string _userPasw { get; set; }
        public static string SettingName { get; set; }
        public static List<string> profileNames { get; set; }
        public static List<string> selectedProfileData { get; set; }
        public static List<string> bridgelist { get; set; }
        public static bool bridgeExists { get; set; }
        public static string NewProfileServerName { get; set; }
        public static string NewProfileServerHub { get; set; }
        public static string NewProfileServerPort { get; set; }
        public static string NewProfileUserName { get; set; }
        public static string NewPofileUserPassw { get; set; }
        public static string NewProfileSettingName { get; set; }
        public static List<string> _cascadeStatus { get; set; }
        public static bool _cscdC { get; set; }
        public static string _tmp { get; set; }
        public static string _lcl_bridge { get; set; }
        public static string _bridgeWindowsname { get; set; }
        public static bool _localBridgeDHCPflag { get; set; }
        public static string _localbridgeIP { get; set; }
        public static string _infostring { get; set; }
        public static string _localbridgevpnip { get; set; }
        public static string _localbridgevpnmask { get; set; }
        public static bool netnamefound { get; set; }
    }
}