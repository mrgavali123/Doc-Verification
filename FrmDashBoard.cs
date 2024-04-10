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
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("inprogress");
            return;
            /*
            panel5.Controls.Clear();
            Internship_Joining frm = new Internship_Joining();

            // Set the TopLevel property of the form instance to false
            frm.TopLevel = false;

            // Set the Dock property of the form instance to Fill
            frm.Dock = DockStyle.Fill;

            // Add the form instance to the Controls collection of the Panel control
            panel5.Controls.Add(frm);

            // Show the form inside the Panel control
            frm.Show();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
              
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            if(GlobalConfig.getInstance().User=="admin")
            {
                //button_WOC1.Visible = true;
            }
            else
            {
                //button_WOC1.Visible = false;
            }
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Frm_Add_Bonafide ic = new Frm_Add_Bonafide();
            ic.TopLevel = false;
            ic.Dock = DockStyle.Fill;
            panel5.Controls.Add(ic);
            ic.Show();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Transfer_info ti = new Transfer_info();
            ti.TopLevel = false;
            ti.Dock = DockStyle.Fill;
            panel5.Controls.Add(ti);
            ti.Show();
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Frm_BonafideList li = new Frm_BonafideList();
            li.TopLevel = false;
            li.Dock = DockStyle.Fill;
            panel5.Controls.Add(li);
            li.Show();
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            List li = new List();
            li.TopLevel = false;
            li.Dock = DockStyle.Fill;
            panel5.Controls.Add(li);
            li.Show();
        }

        private void button_WOC3_Click_1(object sender, EventArgs e)
        {

            panel5.Controls.Clear();
            UserRegistration Ur = new UserRegistration();
            Ur.TopLevel = false;
            Ur.Dock = DockStyle.Fill;
            panel5.Controls.Add(Ur);
            Ur.Show();
        }

        private void button_WOC7_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Frm_TransferList Ur = new Frm_TransferList();
            Ur.TopLevel = false;
            Ur.Dock = DockStyle.Fill;
            panel5.Controls.Add(Ur);
            Ur.Show();
        }
    }
}
