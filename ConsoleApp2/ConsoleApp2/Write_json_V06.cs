using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data;

namespace ConsoleApp2
{
    class Write_json_V06
    {
        public static void writepackagejson()
            {
            string path1 = Path_of_files.jsonfilepathtowrite;
            DataColumn priority = Read_cvsfile_to_Packages.ds1.Tables["package"].Columns.Add("priority", typeof(string));
            foreach (DataRow row in Read_cvsfile_to_Packages.ds1.Tables["package"].Rows)
            {
                row["priority"] = "1";
            }
            string Result;
            Result = JsonConvert.SerializeObject(Read_cvsfile_to_Packages.ds1);
            File.WriteAllText(path1, Result);
            

    }
    }
}
