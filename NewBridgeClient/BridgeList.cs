using System;
using System.Data;

namespace NewBridgeClient
{
    internal class BridgeList
    {
        public static DataTable bridgeList()
        {
            VPNcmd _gcl = new VPNcmd();
            string _list = _gcl.ExecuteCommand("localhost:5555", "server", "bridgelist", "", " /Password:pirkon12");
            var _list1 = _list.TrimEnd() + '\n';
            string[] lines = _list1.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] fields;
            fields = lines[0].Split(new char[] { ',' });
            int cols = fields.GetLength(0);
            DataTable bl1 = new DataTable();
            for (int i = 0; i < cols; i++)
                bl1.Columns.Add(fields[i], typeof(string));
            DataRow row;
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                fields = lines[i].Split(new char[] { ',' });
                row = bl1.NewRow();
                for (int f = 0; f < cols; f++)
                    row[f] = fields[f];
                bl1.Rows.Add(row);
            }

            return bl1;
        }

        public static string _lcl_bridge(string p)
        {
            VPNcmd_nCSV _lcb = new VPNcmd_nCSV();
            string _list = _lcb.ExecuteCommand("localhost:5555", "server", "bridgelist", "", " /Password:pirkon12");
            // var _list1 = _list.TrimEnd() + '\n';
            return _list;
        }
    }
}