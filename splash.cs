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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 10;
            if(panel1.Width >= 950)
            {
                timer1.Stop();
              //  FrmSelect rg = new FrmSelect();
                //rg.Show();
                this.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
