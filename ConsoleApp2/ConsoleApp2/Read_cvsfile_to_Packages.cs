using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace ConsoleApp2
{
    class Read_cvsfile_to_Packages
    {
        public static DataSet ds1;
        public static void readcvsfile()
        {
            // List<string> PfCsv = new List<string>();
            // List<Packages_to_V06> pkg = new List<Packages_to_V06>();
            // object value;
            string path = Path_of_files.filepathetoread;
            Read_cvsfile_to_Packages.ds1 = new DataSet();
            Read_cvsfile_to_Packages.ds1.DataSetName = "ds1";
           
            DataTable package = new DataTable("package");
            Read_cvsfile_to_Packages.ds1.Tables.Add(package);
            
            using (StreamReader sr = new StreamReader(path))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    package.Columns.Add(header);

                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = package.NewRow();
                    for (int i =0; i< headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    package.Rows.Add(dr); 
                }
                return;
            }
            
        }
    }
}