using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreams
{
    public partial class Login : Form
    {
        string name = "admin";
        string pass = "123";
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==name && textBox2.Text==pass)
            {
                LoginForm ob = new LoginForm();
         
                ob.Show();
                this.Hide();
                

            }
        }
    }
}
