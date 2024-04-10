using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGenerateCertificate
{
    public partial class FrmSelect : Form
    {
        public FrmSelect()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            Utils.formno = 2;
            this.Close();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            //UserLogin ur = new UserLogin();
            // ur.Show();
            Utils.formno = 1;
            this.Close();
        }

        private void FrmSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
