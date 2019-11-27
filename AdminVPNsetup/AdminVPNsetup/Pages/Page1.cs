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
        public Page1(EasyConsole.Program program) : base("Page1", program)
        {
        }
        public override void Display()
        {
            base.Display();
            Output.WriteLine("Hello from Page 1Ai");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
