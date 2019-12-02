using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace AdminVPNsetup.Pages
{
    class Page1 : MenuPage
    {

        public Page1(EasyConsole.Program menuprog1)
            : base("Check VPN Setup", menuprog1,
                  new Option("Check VPN Install Direectory ", () => AdminVPNsetup.Program._is_Directory_exists()),
                  new Option("Check VPN Sub Directories ", () => AdminVPNsetup.Program._is_SubDirectory_exists()),
                  new Option("Check Service Install", () => AdminVPNsetup.Program._is_Service_installed()),
                  new Option("Check Bridge Service Start Up Mode", () => AdminVPNsetup.Program._Bridge_service_condition()),
                  new Option("Check Bridge Service Condition", () => AdminVPNsetup.Program._BridgeServiceCondition()),
                  new Option("Check Bridge Hub", () => Console.WriteLine("Hub bridge")),
                  new Option("Check Network Cards", () => AdminVPNsetup.CheckInstall._Print_Local_Bridge()),
                  new Option("Check if Cascade connection is setup", () => Console.WriteLine("Cascade connection")))
                   
        { }
            public override void Display()
        {
            base.Display();
            Input.ReadString("Press (Enter) to navigate home");
            Program.NavigateTo<Page1>();
        }

    }
    
}

