using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISUTechnicalService
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {

        }

        private void txtIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtıdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Model2 model = new Model2();
            Customerİnfo customer = new Customerİnfo();

            customer.TC = txtIdentity.Text;
            customer.Name = txtName.Text;
            customer.Surname = txtSurname.Text;
            customer.Email = txtEmail.Text;
            customer.Phone = maskedTextBox1.Text;
            model.Customerİnfo.Add(customer);
            model.SaveChanges();
            MessageBox.Show("Payment process completed successfully!");
            txtIdentity.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            maskedTextBox1.Clear();
            txtProcess.Clear();
            txtPrice.Clear();
            datePicker.ResetText();

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Model2 model = new Model2();
            string gelenTc = txtIdentity.Text;
            Customerİnfo customer = model.Customerİnfo.Where(x => x.TC == gelenTc).FirstOrDefault();
            Deviceİnfo trouble = new Deviceİnfo();
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtSurname.Text = customer.Surname;
                txtEmail.Text = customer.Email;
                maskedTextBox1.Text = customer.Phone;
                txtProcess.Text = trouble.Trouble;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
