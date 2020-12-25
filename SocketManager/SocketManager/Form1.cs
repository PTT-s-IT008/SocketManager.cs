using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketManager
{
    public partial class Form1 : Form
    {
        #region Properties
        SocketManager socket;

        #endregion
        public Form1()
        {
            InitializeComponent();
            socket = new SocketManager();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formClient = new ClientForm();

            formClient.Closed += (s, args) => this.Show();
            formClient.Show();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            var formServer = new ServerForm();

            formServer.Closed += (s, args) => this.Show();
            formServer.Show();
        }
    }
}
