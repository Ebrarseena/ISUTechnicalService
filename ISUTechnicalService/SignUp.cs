﻿using System;
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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            timer1.Start();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }

        private void btnComplete_Click(object sender, EventArgs e)
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
            MessageBox.Show("Registration successfully created!");
            this.Hide();
            LOGİN login = new LOGİN();
            login.Show();

        }
    }
}
