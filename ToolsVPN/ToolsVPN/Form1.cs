using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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



            vpnValues._vpn_host = Resources.Server;
            vpnValues._vpn_host_port = Resources.Port;
            vpnValues._vpn_hub_name = Resources.vpn_hub;
            vpnValues._ExecDir = Resources.ExecDir;
            vpnValues._vpnbridge_exe = Resources.vpnbridge_exe;
            vpnValues._vpncmd_exe = Resources.vpncmd_exe;
            vpnValues._tmp_dir = Resources.tmp_dir;
            vpnValues._cascdade_connection_name = Resources.CascadeConnectionName;
            vpnValues._cascade_connection_create = Resources.CascadeConnectionCreate;
            vpnValues._local_host_name = Resources.LocalServer;
            vpnValues._local_host_port = Resources.LocalHostPort;
            vpnValues._local_hub_name = Resources.LocalHubName;
            vpnValues._local_host_server_password = Resources.LocalServerPassword;
            HostName.Text = vpnValues._vpn_host;
            Port.Text = vpnValues._vpn_host_port;
            User.Text = null;          
            Pass.Text = null;
            string path = vpnValues._tmp_dir;
            //    if (Directory.Exists(path)) { return; } else { Directory.CreateDirectory(path); };
            Directory.CreateDirectory(path);
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string settings_path = path1 + "\\UserSettings.txt";
            if (File.Exists(settings_path))
            {
               
                SettingsDT.ConvertToDataTable(settings_path, 9);
                HostName.Text = vpnValues._vpn_host;
                Port.Text = vpnValues._vpn_host_port;
                User.Text = vpnValues._vpn_user;
                Pass.Text = vpnValues._vpn_user_pass;
                _connect_button.Focus();
            };
            
            User.Select();
           

        }
        public static void _checSettings()
        {
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string settings_path = path1 + "\\UserSettings.txt";
            if (File.Exists(settings_path))
            {

                SettingsDT.ConvertToDataTable(settings_path, 9);
                HostVPN.Text = vpnValues._vpn_host;
                Port.Text = vpnValues._vpn_host_port;
                User.Text = vpnValues._vpn_user;
                Pass.Text = vpnValues._vpn_user_pass;
                _connect_button.Focus();
            }
            return;
        }




        private void ToolsVPN_Load(object sender, EventArgs e)
        {

        }

        private void _connect_button_MouseClick(object sender, MouseEventArgs e)
        {
            CheckInputValues._check_input(User.Text, Pass.Text);
            string val = "Connect To \n" + vpnValues._vpn_host + "\n" + vpnValues._vpn_host_port + "\n" + "with user name \n"+ vpnValues._vpn_user + "@" + vpnValues._vpn_hub_name;
            string cap = "Values To Connect ";           
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(val, cap, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                PrepareToConnect._init();
             //   PrepareToConnect._Start_sevpnservice();
                vpnValues._vpn_host = HostName.Text;
                vpnValues._vpn_host_port = Port.Text;

                vpnValues._cascade_connection_create = Resources.CascadeConnectionCreate;
                PrepareToConnect._Create_Cascade_connection();
                System.Threading.Thread.Sleep(500);
                PrepareToConnect._Check_Cascade_setup();
                System.Threading.Thread.Sleep(500);
                PrepareToConnect._Cascade_conx_start();
                CascadeStat._GetConnStatus(vpnValues._cascdade_connection_name);
                MessageBox.Show(vpnValues._cascade_connection_status);
                System.Threading.Thread.Sleep(500);
                button2.Focus();
                this.WindowState = FormWindowState.Minimized;
                PrepareToConnect._init();

            }


            
        }

        private void ToolsVPN_Load_1(object sender, EventArgs e)
        {

        }

        private void HostName_TextChanged(object sender, EventArgs e)
        {
            vpnValues._vpn_host = HostName.Text;

        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
            vpnValues._vpn_host_port = Port.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrepareToConnect._Check_Cascade_setup();
            PrepareToConnect._Cascade_conx_stop();
            
            System.Threading.Thread.Sleep(500);
            PrepareToConnect._Delete_cascade_connection();
            System.Threading.Thread.Sleep(1000);
            PrepareToConnect._Stop_sevpnservice();
            string path = vpnValues._tmp_dir;
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
            Close();

        }


        
    }
}
