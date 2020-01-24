using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace UserFilesEncryption
{
    class EncodeFile
    {
        public static string _sFilePAth { get; set; }
        public static string _resultS { get; set; }
        public static void EncryptFile(string filePath)
           
        {
            const string EncrFolder = @"c:\VPN_Users\Encrypt\";
            const string SrcFolder = @"c:\VPN_Users\docs\";
           
            System.IO.Directory.CreateDirectory(EncrFolder);
            Directory.CreateDirectory(SrcFolder);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UserFilesEncryption.PublicKey.xml";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                _resultS = result;
            }
            byte[] ba1 = Encoding.Unicode.GetBytes(_resultS);
            MemoryStream _ms = new MemoryStream(ba1);
            //get the object back from the stream
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters((RSAParameters)xs.Deserialize(_ms));
            byte[] bytesPlainTextData = File.ReadAllBytes(filePath);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
            //we might want a string representation of our cypher text... base64 will do
            string encryptedText = Convert.ToBase64String(bytesCipherText);
            int startFileName = filePath.LastIndexOf("\\") + 1;
           
            string outFile = EncrFolder + filePath.Substring(startFileName, filePath.LastIndexOf(".") - startFileName) + ".enc";
            string _File1 = filePath.Substring(startFileName, filePath.LastIndexOf(".") - startFileName) + ".enc";
            EncodeFile._sFilePAth = _File1;

           File.WriteAllText(outFile, encryptedText);
            csp.PersistKeyInCsp = false;
        }
    }
}
