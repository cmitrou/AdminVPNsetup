using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NewBridgeClient
{
    public partial class LocalBridgeForm : Form
    {
        public LocalBridgeForm()
        {
            InitializeComponent();
            L_HubNameBox.Text = "BRIDGE";
            _LocalBridge();
            if (Data.bridgeExists) { AddLocalBridgeButton.Enabled = false; };
        }

        private void _LocalBridge()
        {
            _checkforLocalbridge1();
            DataTable _bdl = BridgeDeviceList.bridgedevicelist();
            List<string> _bdvl = new List<string>();
            // _bdvl.Clear();
            for (int i = 0; i <= _bdl.Rows.Count - 1; i++)
            {
                _bdvl.Add(_bdl.Rows[i][0].ToString());
                AvailableInterfaces.Items.Add(_bdvl[i].ToString());
            }
            if (Data.bridgelist.Count == 1)
            {
                L_LocalBridgeBox.Text = "";
                return;
            }
            else
            {
                L_LocalBridgeBox.Text = Data.bridgelist[1];
                //  L_HubNameBox.Text = "BRIDGE";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data._localbridgevpnmask = "255.255.255.0";
            
            
            Dispose();
        }

        private void _checkforLocalbridge1()
        {
            DataTable _bl1 = BridgeList.bridgeList();
            Data.bridgelist = new List<string>();
            // _bl1.Clear();

            for (int i = 0; i <= _bl1.Rows.Count - 1; i++)
            {
                Data.bridgelist.Add(_bl1.Rows[i][2].ToString());
                // comboBox1.Items.Add(Data.bridgelist[i]);  <-----this was on seceond form
            }
            if (Data.bridgelist.Count > 1) { Data.bridgeExists = true; } else { Data.bridgeExists = false; }
            if (Data.bridgeExists) { AddLocalBridgeButton.Enabled = false; };
            if (!Data.bridgeExists) { AddLocalBridgeButton.Enabled = true; };
            return;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < AvailableInterfaces.Items.Count; ++ix)
                if (ix != e.Index)
                {
                    AvailableInterfaces.SetItemChecked(ix, false);
                }
                else
                {
                    L_LocalBridgeBox.Text = AvailableInterfaces.Items[ix].ToString();
                }
        }

        private void DeleteLocalBridgeButton_Click(object sender, EventArgs e)
        {
            // delete Local Bridge
            _cmd _fr = new _cmd();
            string _esc = "\"" + L_LocalBridgeBox.Text + "\"";
            // _fr.Execmd("localhost:5555", "server", " /Password:pirkon12","BridgeDelete", "Bridge /Device:" + "\"" + L_LocalBridgeBox.Text + "\"");
            _fr.Execmd("localhost:5555", "server", " BridgeDelete", " Bridge /Device:" + "\"" + L_LocalBridgeBox.Text + "\"", " /Password:pirkon12");
            MessageBox.Show("Loacl Bridge Deleted. Please add one");
            BridgeList.bridgeList();
            AvailableInterfaces.Items.Clear();

            AvailableInterfaces.SelectedItems.Clear();
            for (int i = 0; i < AvailableInterfaces.CheckedItems.Count; i++)
            {
                AvailableInterfaces.SetItemChecked(AvailableInterfaces.CheckedIndices[i], false);
            }
            _LocalBridge();
        }

        private void AddLocalBridgeButton_Click(object sender, EventArgs e)
        {
            _cmd _fr = new _cmd();
            string _esc = "\"" + L_LocalBridgeBox.Text + "\"";
            // _fr.Execmd("localhost:5555", "server", " /Password:pirkon12","BridgeDelete", "Bridge /Device:" + "\"" + L_LocalBridgeBox.Text + "\"");
            _fr.Execmd("localhost:5555", "server", " BridgeCreate", " Bridge /Device:" + "\"" + L_LocalBridgeBox.Text + "\"", " /Password:pirkon12");
            MessageBox.Show("Local Bridge Added.");
            BridgeList.bridgeList();
            AvailableInterfaces.Items.Clear();
            AvailableInterfaces.SelectedItems.Clear();
            for (int i = 0; i < AvailableInterfaces.CheckedItems.Count; i++)
            {
                AvailableInterfaces.SetItemChecked(AvailableInterfaces.CheckedIndices[i], false);
            }

            // AvailableInterfaces.SetItemChecked(AvailableInterfaces.CheckedIndices[0], false);
            _LocalBridge();
        }

        private void LocalBridgeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}