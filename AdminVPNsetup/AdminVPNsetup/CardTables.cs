using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace AdminVPNsetup
{
    public class CardTables
    {
        [DisplayName("flag")]
        public static int flag
        { get; set; }
        [DisplayName("Hub Name")]
        public string _Hub_name
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
    }
}
