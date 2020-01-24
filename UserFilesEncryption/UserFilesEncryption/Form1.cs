using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace UserFilesEncryption
{
    public partial class VPN_UserSettingsFileEncDecr : Form
    {
        public VPN_UserSettingsFileEncDecr()
        {
            InitializeComponent();
        }

        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider rsa;
        

        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string EncrFolder = @"c:\VPN_Users\Encrypt\";
        const string DecrFolder = @"c:\VPN_Users\Decrypt\";
        const string SrcFolder = @"c:\VPN_Users\docs\";
    
        const string KeysFolder = @"c:\VPN_Users\RSA_keys";

        // Public key file
        const string PubKeyFile = @"c:\VPN_Users\RSA_keys\rsaPublicKey.txt";
        const string PrivateKeyFile = @"c:\VPN_Users\RSA_keys\rsaPrivateKey.txt";
        const string PubKeyFilexml = @"c:\VPN_Users\RSA_keys\rsaPublicKey.xml";
        const string PrivateKeyFilexml = @"c:\VPN_Users\RSA_keys\rsaPrivateKey.xml";
        
        // Key container name for
        // private/public key value pair.
        const string keyName = "VPN_Users01";
        
  

        private void btDecodeFile_Click(object sender, EventArgs e)
        {
            //if (rsa == null)
            //    MessageBox.Show("Key not set.");
            //else
            {
                // Display a dialog box to select the encrypted file.
                openFileDialog2.InitialDirectory = EncrFolder;
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog2.FileName;
                    if (fName != null)
                    {
                        FileInfo fi = new FileInfo(fName);
                        string name = fi.FullName;
                        //DecryptFile(name);
                        DecodeFile.DecryptFile(name);
                    }
                }
            }
        }


        private void btEncodeFile_Click(object sender, EventArgs e)
        {
            {
                //if (rsa == null)
                //    MessageBox.Show("Key not set.");
                //else
                {

                    // Display a dialog box to select a file to encrypt.
                    openFileDialog1.InitialDirectory = SrcFolder;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fName = openFileDialog1.FileName;
                        if (fName != null)
                        {
                            FileInfo fInfo = new FileInfo(fName);
                            // Pass the file name without the path.
                            string name = fInfo.FullName;
                            // EncryptFile(name);
                            EncodeFile.EncryptFile(name);
                        }
                    }
                }
            }
        }

      
    }

}
