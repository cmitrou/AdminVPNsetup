using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp2
{
    public class Path_of_files
    {
       
        public static string path1 = Assembly.GetExecutingAssembly().Location;

        static string Directory  = System.IO.Path.GetDirectoryName(path1);
        static string cvsfiletoread = Directory + "\\Data.csv";
        static string uriPath2read = cvsfiletoread;
        public static string filepathetoread = new System.Uri(uriPath2read).LocalPath;

        static string jsonfiletowrite = Directory + "\\out.xml";
        static string uriPath2write = jsonfiletowrite;
        public static string jsonfilepathtowrite = new System.Uri(uriPath2write).LocalPath;

        static string v06 = Directory + "\\DataPackageListV06.xml";
        static string uriPathV06 = v06;
        public static string v06pathtowrite = new System.Uri(uriPathV06).LocalPath;
        }
   }
