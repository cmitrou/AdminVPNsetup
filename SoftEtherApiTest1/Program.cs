using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftEtherApi;

namespace SoftEtherApiTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = "139.162.142.110";
            ushort port = 443;
            var pw = "Pirkon1612-/";

            var hubName = "ManRem";
            var userName = "Manolis";
            List<string[]> results = new List<string[]>();
            using (var softEther = new SoftEther(ip, port))
            {
                var connectResult = softEther.Connect();
                if (!connectResult.Valid())
                {
                    Console.WriteLine(connectResult.Error);
                    return;
                }

                var authResult = softEther.Authenticate(pw);
                if (!authResult.Valid())
                {
                    Console.WriteLine(authResult.Error);
                    return;
                }

                var user = softEther.HubApi.GetUser(hubName, userName);
                Console.WriteLine(user.Valid() ? "Success" : user.Error.ToString());
                
                var hbUL = softEther.HubApi.GetUserList(hubName);
                int i; int c = hbUL.Count;
                for (i = 0; i <= c-1; i++ ) {
                    Console.WriteLine((i+1).ToString() + ":"+ hbUL[i].Name
                        .ToString() + ":"+ hbUL[i].GroupName.ToString());

                    string v1 = hbUL[i].Name.ToString() + ";" + hbUL[i].LastLoginTime.ToString();
                    string v2 = hbUL[i].Realname.ToString();
                    results.Add(new string[] { v1});
                   // results.Add(v2);
                }


                Console.ReadKey();
            }
        }
    }
}
