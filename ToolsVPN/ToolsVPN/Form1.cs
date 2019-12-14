using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsVPN.Properties;

namespace ToolsVPN
{
    public partial class ToolsVPN : Form
    {
       
        public ToolsVPN()
        {
            InitializeComponent();
            HostName.Text = Resources.Server;
            Port.Text = Resources.Port;
            string _user = User.Text;
            string _pass = Pass.Text;
            User.Text = null;
            Pass = null;
           
        }





        private void ToolsVPN_Load(object sender, EventArgs e)
        {

        }

        private void _connect_button_MouseClick(object sender, MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(User.Text) || (String.IsNullOrEmpty(Pass.Text)))
            {
                MessageBox.Show("Please Enter Correct UserName and Password");
            };
        }
    }
}
