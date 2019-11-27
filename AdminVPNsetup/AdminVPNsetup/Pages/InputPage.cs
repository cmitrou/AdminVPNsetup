using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminVPNsetup.Pages;
using EasyConsole;

namespace AdminVPNsetup.Pages
{
    class InputPage : Page
    {
        public InputPage(EasyConsole.Program menuprog)
            : base("Input",menuprog)
        {
        }
        public override void  Display()
        {
            base.Display();
            Input.ReadString("Press [ENTER] to navigate home");
            Program.NavigateHome();
        }
    }
    
}