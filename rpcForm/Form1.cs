using SoftEther.VPNServerRpc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpcForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _fill();
        }

        public static string g1 { get; set; }
        public static string g2 { get; set; }
        public  List<List<List<string>>> g3 { get; set; }

        private async Task<string> test()
        {
            VpnServerRpc api;
            api = new VpnServerRpc("192.168.97.112", 5555, "pirkon12", "");
            // async Task<VpnRpcEnumEth> devlist => await api.EnumEthernet();
            return await Task.Run<string>(() =>
            {
             
                var DeviceList = new List<DevList>();
                // 
                VpnRpcEnumEth devlist = api.EnumEthernet();
                for (int i = 0; i < devlist.EthList.Count(); i++)
                {
                    string h1 = devlist.EthList[i].DeviceName_str.ToString();
                    string p1 = devlist.EthList[i].NetworkConnectionName_utf.ToString();           //.EthList[i].NetworkConnectionName_utf.ToString();
                    DeviceList.Add(new DevList { Device = h1 });
                    DeviceList.Add(new DevList { NetName = p1 });
                 
                };
                // string g = devlist.EthList[0].NetworkConnectionName_utf.ToString();
                //  string h = devlist.EthList[0].DeviceName_str.ToString();

                // g1 = g.ToString();
                // g2 = h.ToString();
                // textBox1.Text = h.ToString();
                return g1;
            }).ConfigureAwait(false);
            
        }

        
        private void _fill()
        {
           var x = test().Result;
          var dvl = new List<DevList>().ToString();
            for (int i = 0; i < dvl.Count(); i++)
            {
                listBox1.Items.Add(dvl[i]);
            }
            
        }

   
        public  class DevList
        {
            public   string Device { get; set; }
            public string NetName { get; set; }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}