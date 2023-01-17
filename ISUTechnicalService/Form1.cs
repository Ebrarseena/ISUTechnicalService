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
using Microsoft.Office.Interop.Excel;

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
            if (model.AdminPanel.Any(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text)) // Databasede bulunan AdminPanel tablosundaki verilerle textboxtaki veriler uyuştuğu taktirde if koşuluna girer
            {
                string name = txtUsername.Text;
                this.Hide();
                MessageBox.Show("Login Successful\n\nWelcome " +  name + "!");
                DeviceTroubleRecord form2 = new DeviceTroubleRecord();
                form2.Show();
                txtUsername.Clear();
                txtPassword.Clear();
            }

            else if (model.Customerİnfo.Any(x => x.TC == txtUsername.Text && x.Surname == txtPassword.Text)) // Databasede bulunan Customerİnfo tablosundaki verilerle textboxtaki veriler uyuştuğu taktirde bu koşula girer
            {
                string name = txtUsername.Text;
                this.Hide();
                MessageBox.Show("Login Successful\n\nWelcome " + name + "!");
                Transactions actions = new Transactions();
                actions.Show();
                txtUsername.Clear();
                txtPassword.Clear();
            }


            else if (txtUsername.Text == "" || txtPassword.Text == "")  // Textboxlardan bir tanesi boş kaldığı taktirde gireceği koşul
            {
                MessageBox.Show("Please fill all fields.");
            }

            else   //Verilerden herhangi birisi yanlış girildiği taktirde gireceği koşul
            {
                MessageBox.Show("The user name or password entered is incorrect \n\t\tPlease try again.");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void chcboxpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chcboxpassword.Checked)  //Checkbox işaretli ise açık şekilde işaretli değil ise password değerinin * şeklinde gözükmesini sağlar
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
            if (e.KeyChar == (char)Keys.Enter) //Enter ile giriş yapılmasını sağlar
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
            timer1.Start(); //Eklenen timer aracına start verir
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString(); // Timer aracının tarih göstereceğini belirtir
        }

        private void btnAppointment_Click(object sender, EventArgs e)  
        {
            SignUp up = new SignUp();           //Yönlendirilecek sayfayı belirtir
            up.Show(); 
        }
    }
}
