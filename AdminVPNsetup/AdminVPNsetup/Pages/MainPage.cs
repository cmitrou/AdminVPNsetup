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
            new Option("Bridge Setup Check", () => AdminVPNsetup.Program._Check_Installation()),
            new Option("Bridge Capable Network Cards", () => AdminVPNsetup.Program._PrintBridgeCapableList()),
            new Option("Input", () => menuprog.NavigateTo<InputPage>()))
        { }   
    }
}
