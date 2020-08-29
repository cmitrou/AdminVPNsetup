using System.Net.Sockets;

namespace NewBridgeClient
{
    internal class CheckRemoteServer
    {
        public static bool PingHost(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                Form1.ServerAlive = ("Error pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
                return false;
            }
        }
    }
}