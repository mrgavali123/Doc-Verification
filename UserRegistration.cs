using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Windows.Forms;
using FireBaseLib;
namespace AutoGenerateCertificate
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void User_Pojo()
        {
            Cursor.Current = Cursors.WaitCursor;
            FirebaseClient fb =FireBaseDB.init(FBConfig.url);
            UserPojo obj = new UserPojo();
            obj.Username = textBox1.Text;
            obj.Password = textBox2.Text;
            try
            {
                await fb.Child("UserInfo").PostAsync(obj);
                MessageBox.Show("Registration Done Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            Cursor.Current = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            User_Pojo();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
