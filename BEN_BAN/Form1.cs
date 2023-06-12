using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_NGAN_HANG
{
    public partial class Form1 : Form
    {
        Client CLIENT = new Client();
        Server SERVER = new Server();   
        public Form1()
        {
            InitializeComponent();
        }

        private void client_Click(object sender, EventArgs e)
        {
            SERVER.stop_Click(null, EventArgs.Empty);
            this.body.Controls.Clear();
            this.Text = "CLIENT";
            this.body.Controls.Add(CLIENT);
        }

        private void server_Click(object sender, EventArgs e)
        {
            CLIENT.stop_Click(null, EventArgs.Empty);
            this.body.Controls.Clear();
            this.Text = "SERVER";
            this.body.Controls.Add(SERVER);
        }
    }
}
