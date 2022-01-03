using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftEtherApi;

namespace NewBridgeClient
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public static void getUsers()
        {
            var ip = "139.162.142.110";
            ushort port = 8789;
            var pw = "Pirkon1612-/";
            var hubName = "ManRem";
            var userName = "Manolis";
            using (var softEther = new SoftEther(ip, port))
            {
                var connectResult = softEther.Connect();
                if (!connectResult.Valid())
                {
                    return;
                }
                var authResult = softEther.Authenticate(pw);
                if (!authResult.Valid()) { return; }
                var user = softEther.HubApi.GetUser(hubName, userName);
                var hbUL = softEther.HubApi.GetUserList(hubName);
                int i; int c = hbUL.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    string v = (i + 1).ToString();
                    string v1 = hbUL[i].Name.ToString()+ ":" + hbUL[i].LastLoginTime.ToString();
                    List<string> res = v1.Split(new char[] { ':' }).ToList();

                }

                // List<string> result = names.Split(',').ToList();

                //var user = softEther.HubApi.GetUser(hubName, userName);
                // hbUL[i].Name



            }
        }
    }
}

