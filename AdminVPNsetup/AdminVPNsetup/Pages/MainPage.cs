using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminVPNsetup.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(EasyConsole.Program menuprog) : base("Main Page",menuprog,
            new Option("VPN Server Bridge Setup Check", () => menuprog.NavigateTo<Page1>()),
            new Option("Bridge Capable Network Cards", () => AdminVPNsetup.Program._PrintBridgeCapableList()),
            new Option("Input", () => menuprog.NavigateTo<InputPage>()))
        { }   
    }
}
