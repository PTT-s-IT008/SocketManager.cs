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
    public partial class ServerForm : Form
    {
        Server server = new Server();

        void printDebug(string s)
        {
            debugScreen.Text += s;
        }
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Shown(object sender, EventArgs e)
        {
            textBox1.Text = DataSerialization.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.toScreen = printDebug;
            server.CreateServer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.listRender();

            foreach(User user in server.userList)
            {
                server.sendDataThroughUsername(user.username, server.showUserList());
            }
        }
    }
}
