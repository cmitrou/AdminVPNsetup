using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace ConsoleApp1
{
    internal class Program
    {
        private static string json;

      

      private void P()
        {

            
            JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
            

       
            string path3 = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var directory = System.IO.Path.GetDirectoryName(path3);
            string path4 = directory + "\\out.xml";
            string uriPath = path4;
            string localPath = new System.Uri(uriPath).LocalPath;
            File.WriteAllText(localPath, json);
        
        }
    }
}