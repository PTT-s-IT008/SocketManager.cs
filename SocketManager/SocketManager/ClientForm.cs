using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketManager
{
    public partial class ClientForm : Form
    {
        Client client = new Client();
        public ClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.username = usernameBox.Text;
            client.IP = IPBox.Text;

            client.Initialize();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void ClientForm_Shown(object sender, EventArgs e)
        {
            IPBox.Text = DataSerialization.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
        }
    }
}

