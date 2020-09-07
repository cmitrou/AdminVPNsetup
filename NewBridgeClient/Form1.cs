using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Management.Automation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NewBridgeClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            InitializeComponent();
            Data.AppRunDir = "C:\\Program Files\\BridgeClient\\"; //AppDomain.CurrentDomain.BaseDirectory;
            InitBridge();
            // GetCascadeList._getcascadelist();
            cascadelist();
        }

        private void cascadelist()       
        {
            DataTable fr = GetCascadeList._getcascadelist();
            dataSet1.Tables.Add(fr);
            Data.profileNames = new List<string>();
            for (int i = 0; i <= fr.Rows.Count - 1; i++)
            {
                Data.profileNames.Add(fr.Rows[i]["Setting Name"].ToString());
                ProfileNameBox.Items.Add(Data.profileNames[i]);
            }
        }

        private void _cascadeStatus()
        {
            DataTable ccs = GetCascadeList._getcascadelist();
            Data._cascadeStatus = new List<string>();
            for (int i = 0; i <= ccs.Rows.Count - 1; i++)
            {
                if (ccs.Rows[i]["Setting Name"].ToString().Contains(Data.SettingName))
                {
                    Data._cascadeStatus.Add(ccs.Rows[i]["Status"].ToString());

                }
            }
            for (int d = 0; d <= Data._cascadeStatus.Count - 1; d++)
            {
                if (Data._cascadeStatus[d].Contains("Online (Established)"))
                {
                    Data._cscdC = true;
                }
                else
                {
                    Data._cscdC = false;
                }
            }
        }

        private void InitBridge()
        {
            if (sevpnbridge.Status.ToString() == "Stopped")
            {
                try
                {
                    sevpnbridge.Start();
                    ServicesCond.vpnServ = true;
                }
                catch
                {
                    MessageBox.Show("Could not start bridge process",
                    "Process failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sevpnbridge.Close();
                }
            }
            _checkforLocalbridge();
            if (!Data.bridgeExists)
            {
                LocalBridgeForm Lpf = new LocalBridgeForm();
                Lpf.Show();
            }


            return;
        }

        public static object ServerAlive { get; internal set; }
        public static string _srvN { get; internal set; }

        private void _checkforLocalbridge()
        {
            DataTable _bl1 = BridgeList.bridgeList();
            Data.bridgelist = new List<string>();
            for (int i = 0; i <= _bl1.Rows.Count - 1; i++)
            {
                Data.bridgelist.Add(_bl1.Rows[i][2].ToString());

                // comboBox1.Items.Add(Data.bridgelist[i]);  <-----this was on seceond form
            }

            if (Data.bridgelist.Count > 1)
            {
                Data.bridgeExists = true;
                NetworkConnection.Text = Data._bridgeWindowsname;
                return;
            }
            else
            {
                Data.bridgeExists = false;
            }
        }

        private void setupProgileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data._mode = "Setup";
            SetupProfileForm Spf = new SetupProfileForm();

            Spf.Show();
        }

        private void ProfileNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProfileNameBox.SelectedItem == null) return;
            Data.SettingName = ProfileNameBox.SelectedItem.ToString();

            DataTable _cg = CascadeGet.GetCascadeProfile();
            dataSet1.Tables.Add(_cg);
            Data.selectedProfileData = new List<string>();
            Data.selectedProfileData.Add(_cg.Rows[2][1].ToString());
            Data.selectedProfileData.Add(_cg.Rows[3][1].ToString());
            Data.selectedProfileData.Add(_cg.Rows[4][1].ToString());
            Data.selectedProfileData.Add(_cg.Rows[9][1].ToString());
            UserNameBox.Text = Data.selectedProfileData[3];
            Data.user = Data.selectedProfileData[3];
            ServerNameBox.Text = Data.selectedProfileData[0];
            string _srv = Data.selectedProfileData[0];
            if (_srv.Contains("/tcp"))
            {
                string trimmer = "/tcp";
                string _s1 = _srv.Substring(0, _srv.Length - trimmer.Length);
                // Regex.Replace(_srv, @"(\A|\s+)\tcp\s*\Z", "", RegexOptions.IgnoreCase).Trim();
                int _srvp = Int16.Parse(Data.selectedProfileData[1]);

                if ((CheckRemoteServer.PingHost(_s1, _srvp)))
                {
                    textBox1.BackColor = Color.Green;
                    
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                }
            }
            if (Data.user.EndsWith("D"))
            {
                NicInfo._brdgeNicName();
                inter_ip.Enabled = true;
                NetworkConnection.Text = Data._bridgeWindowsname;
                

            }
            else
            {
                NetworkConnection.Text = Data._bridgeWindowsname;
                inter_ip.Enabled = true;

            }
         //   Protocols._cmd_disable_all();
         //   Protocols._cmd_enable_vpn();
           // return;
            // Data.ServerName = Data.selectedProfileData[0];
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data._mode = "Edit";
            SetupProfileForm Spf = new SetupProfileForm();
            Spf.ProfileNameBox.Text = Data.SettingName;
            Spf.ProfilePanelLabel.Text = " Edit Profile";

            Spf.Show();
            cascadelist();
            ProfileNameBox.ResetText();
            UserNameBox.Text = "";
            ServerNameBox.Text = "";
        }

        private void ProfileNameBox_Enter(object sender, EventArgs e)
        {
            Data.profileNames.Clear();
            ProfileNameBox.Items.Clear();

            cascadelist();
            ProfileNameBox.ResetText();
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to delete profile?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                CascadeDelete._cascadeDelete();
                Data.profileNames.Clear();
                ProfileNameBox.Items.Clear();
                cascadelist();
                ProfileNameBox.ResetText();
                UserNameBox.Text = "";
                ServerNameBox.Text = "";
            }
            else return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // OsCheck._setEnv(); Moved to Program
           // inter_ip.Enabled = false;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Data._localbridgevpnmask = "255.255.255.0";
            NicInfo._brdgeNicName();
            NetworkConnection.Text = Data._bridgeWindowsname;
            if (UserNameBox.Text.EndsWith("D"))
            {
                Data.DhcpMode = true;
                MessageBox.Show("You are in DHCP mode. Please make sure to give a" + "\n" + "free IP of your network to remote connecting party");
                inter_ip.Enabled = true;
            }
            else
            {
                Data._localbridgevpnmask = "255.255.0.0";
                inter_ip.Enabled = true;
            }
            //if (inter_ip.Text != null)
            //{
            //    NicInfo._brdgeNicName();
            //    NetworkConnection.Text = Data._bridgeWindowsname;
            //    if (Data.netnamefound)
            //    {
            //        NetworkConnection.Text = Data._bridgeWindowsname;
            //        if (inter_ip.Text.Contains("169.254"))
            //        { Data._localbridgevpnmask = "255.255.0.0"; }
            //        else
            //        { Data._localbridgevpnmask = "255.255.255.0"; }
            //        Data._localbridgevpnip = inter_ip.Text;
            //        //     NicInfo._startwithDhcpON();
            //    }
            //    else
            //    {
            //        MessageBox.Show("This network  card is not supported at the moment." + "\n" +
            //                        "Please enter IP & Subnet Manualy after connection!" + "\n" +
            //                        "   " + inter_ip.Text + "  " + Data._localbridgevpnmask);
            //    }
            //    if (UserNameBox.Text.EndsWith("D"))
            //    {
            //        Data.DhcpMode = true;
            //        MessageBox.Show("You are in DHCP mode. Please make sure to give a" + "\n" + "free IP of your network to remote connecting party");
            //    }
                //if (Data.DhcpMode)
                //{
                //    Protocols._cmd_disable_all();
                //    Protocols._cmd_enable_vpn();
                //}
         //  }
            _cmd _cc1 = new _cmd();
            _cc1.Execmd("localhost:5555", "server", "CascadeOnline ", Data.SettingName, " /AdminHub:Bridge /Password:pirkon12"); ;
            Thread.Sleep(1000);
            Data._localbridgevpnip = inter_ip.Text;
            if(String.IsNullOrEmpty(Data._localbridgevpnip))
            {
                NicInfo.SetDHCP(Data._bridgeWindowsname);
            }
            else
            {
                NicInfo.SetIpAddress(Data._bridgeWindowsname, Data._localbridgevpnip, Data._localbridgevpnmask);
            }
           // NicInfo.SetIpAddress(Data._bridgeWindowsname, Data._localbridgevpnip, Data._localbridgevpnmask);
            Thread.Sleep(1000);
            // NicInfo._setLocalBridgeStatic();
            _cascadeStatus();
            if (Data._cscdC)
            {
                textBox2.BackColor = Color.Green;
                ConnectButoon.Enabled = false;
                menuToolStripMenuItem.Enabled = false;
                DisconnectButton.Enabled = true;
                if (inter_ip.Text != null)
                {
                    Data._localbridgeIP = inter_ip.Text;
                }
            }
            else
            {
                textBox2.BackColor = Color.Red;
                ConnectButoon.Enabled = true;
                DisconnectButton.Enabled = false;
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            
            if (Data.SettingName == null) { MessageBox.Show("I am not connected anywhere! R u Blind?"); return; };
            _cmd _cD = new _cmd();
            _cD.Execmd("localhost:5555", "server", " CascadeOffline ", Data.SettingName, " /AdminHub:Bridge /Password:pirkon12");
            Thread.Sleep(2000);
            _cascadeStatus();
            if (!Data._cscdC)
            {
                NetworkConnection.Text = " ";
                inter_ip.Text = " ";
                textBox2.BackColor = Color.Red;
                ConnectButoon.Enabled = true;
                DisconnectButton.Enabled = false;
                menuToolStripMenuItem.Enabled = true;
                //  Protocols._cmd_enable_bindings();
                //   Protocols._cmd_enable_all();
                NicInfo.SetDHCP(Data._bridgeWindowsname);
                //  NicInfo._startwithDhcpON();

                Thread.Sleep(3000);
                MessageBox.Show("The program is closing. Thanks for using it");
                System.Environment.Exit(0);
            }
            else
            {
                textBox2.BackColor = Color.Green;
                ConnectButoon.Enabled = false;
                DisconnectButton.Enabled = true;
            }
        }
    }
}