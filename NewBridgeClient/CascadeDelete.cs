using System.Threading;

namespace NewBridgeClient
{
    internal class CascadeDelete
    {
        public static void _cascadeDelete()
        {
            _cmd _cd1 = new _cmd();
            _cd1.Execmd("localhost:5555", "server", "CascadeDelete ", Data.SettingName, " /AdminHub:Bridge /Password:pirkon12");
            Thread.Sleep(1000);
        }
    }
}