using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using softRpcCalls;
using System.Net.Http;

namespace te1c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Task.Run(()=> sentto());
        }
        public void sentto()
        {
            Class1.SoftTest _t = new Class1.SoftTest();
            _t.GetServerInfo();
        }
    }
}
