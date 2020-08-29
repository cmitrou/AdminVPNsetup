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
            api = new VpnServerRpc("127.0.0.1", 5555, "pirkon12", "");
            // async Task<VpnRpcEnumEth> devlist => await api.EnumEthernet();
            return await Task.Run<string>(() =>
            {
             
                var DeviceList = new List<DevList>();
                List<string> g31 = new List<List<g3>>();
                VpnRpcEnumEth devlist = api.EnumEthernet();
                for (int i = 0; i < devlist.EthList.Count()-1; i++)
                {
                    string h = devlist.EthList[i].DeviceName_str.ToString();
                    string g = devlist.EthList[i].NetworkConnectionName_utf.ToString();
                    DeviceList.Add(new DevList { Device = h, NetName = g });
                    
                    
                   
                };
               


                //  string g = devlist.EthList[2].NetworkConnectionName_utf.ToString();
                //  string h = devlist.EthList[2].DeviceName_str.ToString();

                // g1 = g.ToString();
                // g2 = h.ToString();
                //  textBox1.Text = g1.ToString();
                return g1;
            });
            
        }

        private Task<string> test1() => test();

        public async void _fill()
        {
            await test1();
            var dvl = new List<DevList>();
            for (int i = 0; i < dvl.Count(); i++)
            {
                listBox1.Items.Add(dvl[i]);
            }
            
        }

   
        public class DevList
        {
            public  string Device { get; set; }
            public string NetName { get; set; }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}