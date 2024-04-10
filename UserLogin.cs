using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireBaseLib;
namespace AutoGenerateCertificate
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        public async void DataFromCloud()
        {
            Cursor.Current = Cursors.WaitCursor;
            var fb = FireBaseDB.init(FBConfig.url);
            UserPojo obj = new UserPojo();

            obj.Username = textBox1.Text;
            obj.Password = textBox2.Text;
            var fbdata = await fb.Child("UserInfo").OnceAsync<UserPojo>();
            int id = 0;
            Utils.logflg = 0;
            foreach (var data in fbdata)
            {
                UserPojo rg = new UserPojo();
                rg.Username = data.Object.Username;
                rg.Password = data.Object.Password;

                if (rg.Username == textBox1.Text && rg.Password == textBox2.Text)
                {
                    id = 1;
                    GlobalConfig globalConfig= GlobalConfig.getInstance();
                    globalConfig.User = rg.Username;
                    Utils.logflg = 1;
                    MessageBox.Show("Login done successfully");
                    
                    this.Close();
                    return;
                }
            }
            if (id == 0)
            {
                MessageBox.Show("Invalid User");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataFromCloud();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
