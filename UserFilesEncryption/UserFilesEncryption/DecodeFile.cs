using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace UserFilesEncryption
{
    class DecodeFile
    {
        public static string resultS { get; set; }
        public static byte[] DecFile { get; set; }
        public static string _DecTxt { get; set; }
        public static void DecryptFile(string filePath)
        {
            const string DecrFolder = @"c:\VPN_Users\Decrypt\";
            System.IO.Directory.CreateDirectory(DecrFolder);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "UserFilesEncryption.PrivateKey.xml";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    resultS = result;
                }
                byte[] ba = Encoding.Unicode.GetBytes(resultS);
                MemoryStream _ms = new MemoryStream(ba);
                {
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    RSAParameters privKey = (RSAParameters)xs.Deserialize(_ms);
                    csp.ImportParameters(privKey);
                }
                string encryptedText;
                using (StreamReader reader = new StreamReader(filePath)) { encryptedText = reader.ReadToEnd(); }
                byte[] bytesCipherText = Convert.FromBase64String(encryptedText);
                //decrypt and strip pkcs#1.5 padding
                byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);
                //get our original plainText back...
                int startFileName = filePath.LastIndexOf("\\") + 1;
                string outFile = DecrFolder + filePath.Substring(startFileName, filePath.LastIndexOf(".") - startFileName) + ".txt";
                DecFile = bytesPlainTextData;
                _DecTxt = System.Text.Encoding.UTF8.GetString(bytesPlainTextData);
                byte[] Buffer = bytesPlainTextData;
                File.WriteAllBytes(outFile, bytesPlainTextData);
                csp.PersistKeyInCsp = false;
             //   ConvertToDataTable(_DecTxt, 2);
            }
        }
        public static DataTable ConvertToDataTable(string path, int numofcolumns)
        {
            DataTable tbl = new DataTable();
            for (int col = 0; col < numofcolumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
            string[] _str_sep = new string[] { "\r\n" };
            string[] lines = path.Split(_str_sep, StringSplitOptions.None);
            foreach (string line in lines)
            {
                var cols = line.Split(':');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < 2; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);

            }
            Console.WriteLine(tbl.Rows[5][1].ToString());
            return tbl;
        }
    }
}