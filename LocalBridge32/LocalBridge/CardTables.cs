using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace LocalBridge
{
    public class CardTables
    {
        [DisplayName("flag")]
        public static int flag
        { get; set; }
        [DisplayName("Hub Name")]
        public static string _Hub_name
        { get; set; }
        [DisplayName("Hub Status")]
        public static string _Hub_status
        { get; set; }
        [DisplayName("Hub Type")]
        public static string _Hub_type
        { get; set; }
        [DisplayName("Cascade Setting Name")]
        public static string _Cascade_Setting_Name
        { get; set; }
        [DisplayName("Cascade Status")]
        public static string _Cascade_Status
        { get; set; }
        [DisplayName("Destination VPN Server")]
        public static string _Destination_VPN_Server
        { get; set; }
        [DisplayName("Card Number")]
        public string _card_nbr
        { get; set; }
        [DisplayName("New Card Number")]
        public string _new_card_nbr
        { get; set; }
        [DisplayName("Bridge Network Card Name")]
        public static string _bridge_net_card_name
        { get; set; }
        [DisplayName("Bridge New Card Name")]
        public string _new_bridge_net_card_name
        { get; set; }
        [DisplayName("Arg String")]
        public static string _arg_strg
        { get; set; }
        [DisplayName("Service Exists")]
        public static string _service_exists_
        { get; set; }
        [DisplayName("Local Bridge Interface")]
        public static string _local_bridge_interface_
        { get; set; }
        [DisplayName("NetCards")]
        public static List<string> _netcards
        { get; set; }
    }
}
