using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LegacyLibrary.ProjectCode;

namespace LegacyLibrary
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectCode.User ss = new User();
            User.validusers = new List<User>();
            //we wont need this if we connected it to the database
            User.validusers.Add(new User("sad", "hello"));
            User found = User.validusers.Find(u => u.Login(txtUsername.Text, txtPassword.Text));

            if (found != null)
            {
                MessageBox.Show("Successfull Login!");
            }
            else
            {
                    MessageBox.Show("Invalid username or password. Login failed.");
            }
           

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
