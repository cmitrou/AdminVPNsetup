using System;
using System.Data;

namespace NewBridgeClient
{
    internal class BridgeDeviceList
    {
        public static DataTable bridgedevicelist()
        {
            VPNcmd _gcl = new VPNcmd();
            string _list = _gcl.ExecuteCommand("localhost:5555", "server", "bridgedevicelist", "", " /Password:pirkon12");
            var _list1 = _list.TrimEnd() + '\n';
            string[] lines = _list1.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] fields;
            fields = lines[0].Split(new char[] { ',' });
            int cols = fields.GetLength(0);
            DataTable bl = new DataTable();
            for (int i = 0; i < cols; i++)
                bl.Columns.Add(fields[i], typeof(string));
            DataRow row;
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                fields = lines[i].Split(new char[] { ',' });
                row = bl.NewRow();
                for (int f = 0; f < cols; f++)
                    row[f] = fields[f];
                bl.Rows.Add(row);
            }
            return bl;
        }
    }
}