using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISUTechnicalService
{
    public partial class LOGİN : Form
    {
        Model2 model = new Model2();
        public LOGİN()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (model.AdminPanel.Any(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text))
            {
                this.Hide();
                MessageBox.Show("Login Successful!\n\nWelcome");
                DeviceTroubleRecord form2 = new DeviceTroubleRecord();
                form2.Show();
                txtUsername.Clear();
                txtPassword.Clear();
            }

            else if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
            }

            else
            {
                MessageBox.Show("The user name or password entered is incorrect \n\t\tPlease try again.");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void chcboxpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chcboxpassword.Checked)
            {

                txtPassword.PasswordChar = '\0';
            }

            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
        private void LOGİN_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp up = new SignUp();
            up.Show();
        }

        private void LOGİN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
