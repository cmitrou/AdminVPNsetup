using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsVPN
{
    public class CheckInputValues
    {
        public static string _check_input(string _inp_user, string _inp_pass)
        {
            if (String.IsNullOrEmpty(_inp_user) | String.IsNullOrEmpty(_inp_pass))
            {
                MessageBox.Show("Please Enter UserName and PassWord");
                return "";
            }
            else
            {
                vpnValues._vpn_user = _inp_user;
                vpnValues._vpn_user_pass = _inp_pass;
                return "Values_Entered";
            }
 
        }
    }
}
