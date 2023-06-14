using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_TRUNG_GIAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void client_Click(object sender, EventArgs e)
        {
            this.body.Controls.Clear();
            this.Text = "CLIENT";
            this.body.Controls.Add(new Client());
        }

        private void server_Click(object sender, EventArgs e)
        {
            this.body.Controls.Clear();
            this.Text = "SERVER";
            this.body.Controls.Add(new Server());
        }
    }
}
