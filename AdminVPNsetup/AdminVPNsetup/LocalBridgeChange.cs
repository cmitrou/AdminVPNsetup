using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdminVPNsetup
{
    public class LocalBridgeChang
    {
        public static void localbridgechange()
        {
           // string Hub_name;
            string _tmp_file_card_list = "c:\\temp\\checked.txt";
            string _tmp_file_loc_bridge = "c:\\temp\\localbridge.txt";
            string[] cards_name = File.ReadAllLines(_tmp_file_card_list);
            string[] local_bridge = File.ReadAllLines(_tmp_file_loc_bridge);
            List<string> qwe = new List<string>(local_bridge);          
            List<string> cardx = new List<string>(cards_name);
            string Hub_name = null;
            for (int o = 0; o < qwe.Count; o++)
            {
                Console.WriteLine("Idx     Hub                            Device Name");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine(" "+ qwe[o].ToString());
                Console.WriteLine();
                Hub_name = qwe[o].ToString();
            }
            Console.WriteLine();
            Console.WriteLine("List of Capable Network Cards Available for Local Bridge Interface");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            int oi;
            for (int i = 0; i < cardx.Count; i++)
            {
                oi = i + 1;
                Console.WriteLine(oi.ToString()+ ". " +cardx[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if(Hub_name.ToString().Contains("NONE") == true)

            {
                Console.WriteLine("You Need to Setup Local Bridge Interface. Please avoid using WiFi cards if any");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please Choose from the above card(s) for Local Bidge Device");
                Console.WriteLine("   " + "ENTER Card:");

            }
            int bowl1 = 0;
            bowl1 = ReadChoise.choise();
            if (bowl1 >= 1 && bowl1 <= cardx.Count)
            {
                int card_chossen = bowl1 - 1;
                string crd_choosen = cardx[card_chossen].ToString();
                Console.WriteLine(".  " +crd_choosen);
                CardTables._bridge_net_card_name = crd_choosen;
                string directory = "c:\\Program Files\\VPN_Tools";
                string arg = "/c cd \"" + directory + "\" && vpncmd_x64.exe localhost:5555 /SERVER /PASSWORD:pirkon12 /CMD BridgeCreate BRIDGE /DEVICE:";
                arg += crd_choosen;
                CardTables._arg_strg = arg;
                LocalBridgeSetup.Lbds();

            }
            else
            {
                bowl1 = 0;
                Console.Clear();
                CardTables.flag = 0;
            }
            Console.ReadKey();
        }

        class  ReadChoise { 
            public static int choise () {
            int Bowl;
                string bowl = null;
                //  int bowl = 0;
                ConsoleKeyInfo UserInput = Console.ReadKey();
                if (char.IsDigit(UserInput.KeyChar))
                {
                    Bowl = int.Parse(UserInput.KeyChar.ToString());
                }
                else
                {
                    Bowl = -1;
                    Console.WriteLine("     Please enter correct choise");
                }
                return Bowl;
            }
       }

        class LocalBridgeSetup
        {
            public static void Lbds()
            {
               // string directory = "c:\\Program Files\\VPN_Tools";
                string arg = CardTables._arg_strg;
                Process _lbds = new Process();
                _lbds.StartInfo.FileName = "cmd.exe";
                _lbds.StartInfo.Arguments = arg;
                _lbds.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                _lbds.Start();
                _lbds.WaitForExit();
                _lbds.Close();
            }  
        }
    }

}    

    
