using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireBaseLib;
using Firebase.Database;
using Firebase.Database.Query;

namespace AutoGenerateCertificate
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Utils.logflg = 0;
            if (textBox1.Text=="admin"&&textBox2.Text=="pass")
            {
                MessageBox.Show("Login Done Successfully");
                GlobalConfig globalConfig = GlobalConfig.getInstance();
                globalConfig.User = "admin";
                Utils.logflg = 1;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Invalid User");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSelect fs = new FrmSelect();
            fs.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void getData()
        {
            FirebaseClient fb = FireBaseDB.init(FBConfig.url);
            var task=fb.Child("UserInfo").OnceAsync<UserPojo>();
            task.Wait();
            var fbdata = task.Result;
            int f = 0;
            foreach (var data in fbdata)
            {
                UserPojo rg = new UserPojo();
                rg.Username = data.Object.Username;
                rg.Password = data.Object.Password;

                if (rg.Username == textBox1.Text && rg.Password == textBox2.Text)
                {
                    f = 1;
                    Utils.logflg = 1;
                    GlobalConfig globalConfig = GlobalConfig.getInstance();
                    globalConfig.User = rg.Username;
                    MessageBox.Show("Login done successfully");
                    this.Close();

                }
            }
            if(f==0)
            {
                MessageBox.Show("Invalid User");
            }

        }
            private void button_WOC1_Click(object sender, EventArgs e)
        {
            Utils.logflg = 0;
            if (textBox1.Text == "admin" && textBox2.Text == "pass")
            {
                MessageBox.Show("Login Done Successfully");
                GlobalConfig globalConfig = GlobalConfig.getInstance();
                globalConfig.User = "admin";
                Utils.logflg = 1;
                this.Close();
                return;
            }
            else
            {
                getData();
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
