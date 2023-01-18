﻿using Microsoft.Office.Interop.Excel;
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

        //private void fill()
        //{
        //    List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
        //    dataGridView1.DataSource = deviceinfos;
        //}

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Model2 model = new Model2();
            string Tcidentity = txtIdentity.Text;

            Deviceİnfo info = model.Deviceİnfo.Where(x => x.TC == Tcidentity).FirstOrDefault();
            if( info != null)
            {
                info.Payment = true;
            }
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
            Model2 model = new Model2();   //SORRRRRR
            string gelenTc = txtIdentity.Text;
            Customerİnfo customer = model.Customerİnfo.Where(x => x.TC == gelenTc).FirstOrDefault();
            Deviceİnfo trouble = new Deviceİnfo();
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtSurname.Text = customer.Surname;
                txtEmail.Text = customer.Email;
                maskedTextBox1.Text = customer.Phone;
                txtPrice.Text = trouble.Price.ToString();
                txtProcess.Text = trouble.Trouble;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty && txtıdentity.Text != string.Empty)
            {
                Model2 model = new Model2();
                string gelenTc = txtıdentity.Text;
                int gelenID = Convert.ToInt32(txtID.Text);
                Deviceİnfo deviceİnfo = model.Deviceİnfo.Where(x => x.TC == gelenTc && x.ID == gelenID).FirstOrDefault(); //LİNQ SORGUSU KULLANILDI (Temel sorgularından birisi olan where sorgusu ile)
                if (deviceİnfo != null)                                                                   //Bir tane veri çekileceği için FirstOrDefault kullanıldı aksi taktirde list kullanılacaktı
                {
                    if (deviceİnfo.Status == true)
                    {
                        txtStatus.Text = "Prepared";
                    }
                    else
                    {
                        txtStatus.Text = "On Hold";
                    }
                }
            }
        }


    }
}
