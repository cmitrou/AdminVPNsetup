using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NewBridgeClient
{
    public partial class SetupProfileForm : Form
    {
        public SetupProfileForm()
        {
            InitializeComponent();
            if (Data._mode == "Setup")
            {
                profileDataShow();
                if (Data.bridgeExists)
                {
                    comboBox1.Text = Data.bridgelist[1].ToString();
                    // GetEnteredDataAsNewProfile();
                }

                //BridgeDevicelist();
                //FillprofileData();
            }
            if (Data._mode == "Edit")
            {
                FillprofileData();
                if (Data.bridgeExists)
                {
                    comboBox1.Text = Data.bridgelist[1].ToString();

                    // GetEnteredDataAsNewProfile();
                }
                else
                {
                    BridgeDevicelist();
                }
            }
            //  profileDataShow();
        }

        private void GetEnteredDataAsNewProfile()
        {
            if (String.IsNullOrEmpty(Data.NewProfileServerName) || String.IsNullOrEmpty(Data.NewProfileServerPort)
                || String.IsNullOrEmpty(Data.NewProfileServerHub) || String.IsNullOrEmpty(Data.NewProfileSettingName)
                || String.IsNullOrEmpty(Data.NewProfileUserName) || String.IsNullOrEmpty(Data.NewPofileUserPassw))
            {
                MessageBox.Show("Please Enter All Information");
                return;
            }
            CascadeCreate.cascadeCreate();
            cascadelist();
        }

        private void cascadelist()
        {
            DataTable fr = GetCascadeList._getcascadelist();
            //  dataSet1.Tables.Add(fr);
            Data.profileNames = new List<string>();
            for (int i = 0; i <= fr.Rows.Count - 1; i++)
            {
                Data.profileNames.Add(fr.Rows[i]["Setting Name"].ToString());
            }
        }

        private void profileDataShow()
        {
            ServerNameBox.Text = "";
            ServerPortBox.Text = "";
            ServerHubBox.Text = "";
            UserLoginNameBox.Text = "";
        }

        private void FillprofileData()
        {
            ServerNameBox.Text = Data.selectedProfileData[0];
            ServerPortBox.Text = Data.selectedProfileData[1];
            ServerHubBox.Text = Data.selectedProfileData[2];
            UserLoginNameBox.Text = Data.selectedProfileData[3];
        }

        private void BridgeDevicelist()
        {
            DataTable _bl = BridgeDeviceList.bridgedevicelist();
            List<string> _dvl = new List<string>();
            for (int i = 0; i <= _bl.Rows.Count - 1; i++)
            {
                _dvl.Add(_bl.Rows[i][0].ToString());
                comboBox1.Items.Add(_dvl[i].ToString());
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ProfilePanelLabel.Text == "Profile Setup")
            {
                // put new setting name --> add new profile
                _getDatafomTextBox1();
                GetEnteredDataAsNewProfile();  ////  change
                Data.profileNames.Clear();
                cascadelist();
                Form1 frm1 = new Form1();
                frm1.Activate();
                frm1.Refresh();
                frm1.ProfileNameBox.Items.Clear();
                Dispose();
            }
            if (Data._mode == "Edit")
            {
                CascadeDelete._cascadeDelete();
                _getDatafomTextBox1();
                GetEnteredDataAsNewProfile();
                // get setting name --> delete --> add with the same name

                Dispose();
            }
            if (Data._mode == "Delete")
            {
                CascadeDelete._cascadeDelete();
            }
        }

        private void ServerPortBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void _getDatafomTextBox()
        {
           Data.ServerName = ServerNameBox.Text;
            //  Data.ServerPort = Convert.ToInt32(ServerPortBox.Text);
            Data.ServerHub = ServerHubBox.Text;
            Data._userName = UserLoginPassword.Text;
            Data._userPasw = UserLoginPassword.Text;
            Form1._srvN = Data.ServerName; 
        }

        private void _getDatafomTextBox1()
        {
            // ServerNameBox.Text = "139.162.142.110/tcp";
            ServerNameBox.Text = Data.MainClientServer;
            Data.ServerName = ServerNameBox.Text;
            //  Data.ServerPort = Convert.ToInt32(ServerPortBox.Text);

            //ServerHubBox.Text = "ManRem";
            ServerHubBox.Text = Data.MainClientHub;
            Data.ServerHub = ServerHubBox.Text;

            //ServerPortBox.Text = "8789";
            ServerPortBox.Text = Data.MainClientHubPort;
            Data.NewProfileServerPort = ServerPortBox.Text;

            Data._userName = UserLoginPassword.Text;
            Data._userPasw = UserLoginPassword.Text;
            Form1._srvN = Data.ServerName;
        }


        private void SetupProfileForm_Load(object sender, EventArgs e)
        {
            CheckTextBoxes(this);
        }

        private void CheckTextBoxes(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.TextChanged += new EventHandler(tb_TextChanged);
                }
                else
                {
                    CheckTextBoxes(ctrl);
                }
            }
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            //  ServerGroupBox.Tag = "changed";
            //MessageBox.Show("Server Data changed. Do you want to use the new values?");
        }

        private void LocalBridgeChangeLabel_CheckedChanged(object sender, EventArgs e)
        {
            LocalBridgeForm Lpf = new LocalBridgeForm();
            Lpf.Show();
            Hide();
            Dispose();
        }

        private void ServerNameBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewProfileServerName = ServerNameBox.Text;
        }

        private void ServerPortBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewProfileServerPort = ServerPortBox.Text;
        }

        private void ServerHubBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewProfileServerHub = ServerHubBox.Text;
        }

        private void UserLoginNameBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewProfileUserName = UserLoginNameBox.Text;
        }

        private void UserPasswordBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewPofileUserPassw = UserPassBox.Text;
        }

        private void ProfileNameBox_TextChanged(object sender, EventArgs e)
        {
            Data.NewProfileSettingName = ProfileNameBox.Text;
        }

        private void SetupProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}