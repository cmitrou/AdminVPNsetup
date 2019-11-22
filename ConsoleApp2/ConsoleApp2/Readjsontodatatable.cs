using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMW_ISPI_NEXT_License_maker;
namespace ConsoleApp2
{
    class Readjsontodatatable
    {
        private static DataSet ds2;

        public static void ReadJsonToTable()
        {
            StreamReader read = new StreamReader(Path_of_files.jsonfilepathtowrite);
            string json1 = read.ReadToEnd();
            // DataTable Read_csv_to_Packages. = (DataTable)JsonConvert.DeserializeObject(json1, (typeof(DataTable)));
            var welcome = PkgV06.FromJson(json1);
            //  ds2 = new DataSet();
            //  ds2.DataSetName = ("ds2");

            //  DataTable package = new DataTable("package");
            //  ds2.Tables.Add("package");
            //  package = (DataTable)JsonConvert.DeserializeObject(json1, (typeof(DataTable)));
            // string Result1 = JsonConvert.SerializeObject(ds2, Formatting.Indented);
            var Result1 = JsonConvert.SerializeObject(welcome, Formatting.Indented);
            File.WriteAllText(Path_of_files.v06pathtowrite, Result1);


        }
    }
}
