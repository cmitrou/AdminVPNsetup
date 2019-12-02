using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyConsole;

namespace AdminVPNsetup
{
    class VPNsetupMenu : EasyConsole.Program
    {
        public VPNsetupMenu() : base ("Local Bridge for VPN Conection" , breadcrumbHeader: true)
        {
            AddPage(new Pages.MainPage(this));
            AddPage(new Pages.Page1(this));
            AddPage(new Pages.InputPage(this));
            SetPage<Pages.MainPage>();
        }
       
    }
}
