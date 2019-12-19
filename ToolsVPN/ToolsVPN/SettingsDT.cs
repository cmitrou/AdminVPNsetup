using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsVPN
{
    class SettingsDT
    {
        public static DataTable ConvertToDataTable(string path, int numofcolumns)
        {
            DataTable tbl = new DataTable();
            for (int col = 0; col < numofcolumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
            string[] lines = System.IO.File.ReadAllLines(path);
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
            vpnValues._vpn_host = tbl.Rows[0][1].ToString();
            vpnValues._vpn_host_port = tbl.Rows[1][1].ToString();
            vpnValues._vpn_hub_name = tbl.Rows[2][1].ToString();
            vpnValues._vpn_user = tbl.Rows[3][1].ToString();
            vpnValues._vpn_user_pass = tbl.Rows[4][1].ToString();
            return tbl;
        }
        
    }
}
