using System.Threading;

namespace NewBridgeClient
{
    internal class CascadeCreate
    {
        public static void cascadeCreate()
        {
            _cmd _cc = new _cmd();
            _cc.Execmd("localhost:5555", "server", " CascadeCreate", Data.NewProfileSettingName + " /SERVER:" + Data.NewProfileServerName + ":" + Data.NewProfileServerPort +
                " " + "/HUB:" + Data.NewProfileServerHub + " " + "/USERNAME:" + Data.NewProfileUserName, " /AdminHub:Bridge /Password:pirkon12");
            Thread.Sleep(2000);
            _cmd _cc1 = new _cmd();
            _cc1.Execmd("localhost:5555", "server", " CascadePasswordSet ", Data.NewProfileSettingName + " /PASSWORD:"
                + Data.NewPofileUserPassw + " /TYPE:standard", "  /AdminHub:Bridge /Password:pirkon12  ");
            Thread.Sleep(1000);
        }
    }
}