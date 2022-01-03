using System;
using SoftEtherApi;

namespace softetherapitest
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = "139.162.142.110";
            ushort port = 443;
            var pw = "Pirkon1612-/";

            var hubName = "ManRem";
            var userName = "Administrator";

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
            }
        }
    }
}
