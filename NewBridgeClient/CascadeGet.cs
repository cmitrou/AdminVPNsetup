using System;
using System.Data;

namespace NewBridgeClient
{
    internal class CascadeGet
    {
        public static DataTable GetCascadeProfile()
        {
            VPNcmd _gcl = new VPNcmd();
            string param = "CascadeGet " + Data.SettingName;
            string _list = _gcl.ExecuteCommand("localhost:5555", "server", param, "", " /Password:pirkon12 /adminhub:bridge");
            var _list1 = _list.TrimEnd() + '\n';
            string[] lines = _list1.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] fields;
            fields = lines[0].Split(new char[] { ',' });
            int cols = fields.GetLength(0);
            DataTable cg = new DataTable();
            for (int i = 0; i < cols; i++)
                cg.Columns.Add(fields[i], typeof(string));
            DataRow row;
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                fields = lines[i].Split(new char[] { ',' });
                row = cg.NewRow();
                for (int f = 0; f < cols; f++)
                    row[f] = fields[f];
                cg.Rows.Add(row);
            }
            return cg;
        }
    }
}