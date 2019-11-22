using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Read_cvsfile_to_Packages.readcvsfile();
        //    List<V06_json> pkg  = new List<V06_json>((Read_cvsfile_to_Packages.ds1.Tables[]).Rows.Count);
            Write_json_V06.writepackagejson();
            Readjsontodatatable.ReadJsonToTable();
        }
    }
}
