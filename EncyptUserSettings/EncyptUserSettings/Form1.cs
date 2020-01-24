using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EncyptUserSettings
{
    public partial class Form1 : Form
    {
        byte[] abc;
        byte[,] table;
        public Form1()
        {
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            if(od.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = od.FileName;
            }
        }

        private void rbEncypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEncypt.Checked)
            {
                rbDecrypt.Checked = false;
            }
        }

        private void rbDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDecrypt.Checked)
            {
                rbEncypt.Checked = false;
            }
        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbEncypt.Checked = true;
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);
            table = new byte[256, 256];
            for (int i=0; i <256; i++)
                for(int j=0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }
        }

        private void btStart_Click(object sender, EventArgs e)
        {

            // Check input values
            if (!File.Exists(tbPath.Text))
            {
                MessageBox.Show("File does not exist.");
                return;
            }
            if (String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Password empty. Please enter your password");
                return;
            }

            // Get file content and key for encrypt/decrypt
            try
            {
                byte[] fileContent = File.ReadAllBytes(tbPath.Text);
                byte[] passwordTmp = Encoding.ASCII.GetBytes(tbPassword.Text);
                byte[] keys = new byte[fileContent.Length];
                for (int i = 0; i < fileContent.Length; i++)
                    keys[i] = passwordTmp[i % passwordTmp.Length];

                // Encrypt
                byte[] result = new byte[fileContent.Length];

                if (rbEncypt.Checked)
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        result[i] = table[keyIndex, valueIndex];
                    }
                }
                // Decrypt
                else
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (table[keyIndex, j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        result[i] = abc[valueIndex];
                    }
                }

                // Save result to new file with the same extension
                String fileExt = Path.GetExtension(tbPath.Text);
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sd.FileName, result);
                }
            }
            catch
            {
                MessageBox.Show("File is in use Close other program is using this file and try again.");
                return;
                }
        
        }
    }
}
