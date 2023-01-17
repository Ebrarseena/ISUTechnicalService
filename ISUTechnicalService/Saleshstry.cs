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
    public partial class Saleshstry : Form
    {
        Model2 model = new Model2(); 
        int indexRow;
        int select = 0;
        public Saleshstry()
        {
            InitializeComponent();
            List<SalesHistory> sale = model.SalesHistory.ToList();
            dataGridView1.DataSource = sale;
            timer1.Start();
        }

        private void fill()
        {
            List<SalesHistory> sales = model.SalesHistory.ToList();
            dataGridView1.DataSource = sales;
        }

        private void btncreate_Click(object sender, EventArgs e)
        {

            SalesHistory sale = new SalesHistory();
            sale.TC = txtIdentity.Text;
            sale.Name = txtName.Text;
            sale.Surname = txtSurname.Text;
            sale.Email = txtEmail.Text;
            sale.Phone = maskedTextBox1.Text;
            sale.Process = txtPrice.Text;
            sale.Price = Convert.ToDouble(txtPrice.Text);
            sale.Date = dateTimePicker1.MinDate;
            model.SalesHistory.Add(sale);
            model.SaveChanges();

            List<SalesHistory> sales = model.SalesHistory.ToList();  //List oluşturuldu
            dataGridView1.DataSource = sale;
            MessageBox.Show("Adding process took place!");
            txtIdentity.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            maskedTextBox1.Clear();
            txtProcess.Clear();
            txtPrice.Clear();
            dateTimePicker1.ResetText();
            fill();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];

            newDataRow.Cells[1].Value = txtIdentity.Text;
            newDataRow.Cells[2].Value = txtName.Text;
            newDataRow.Cells[3].Value = txtSurname.Text;
            newDataRow.Cells[4].Value = txtEmail.Text;
            newDataRow.Cells[5].Value = maskedTextBox1.Text;
            newDataRow.Cells[6].Value = txtProcess.Text;
            newDataRow.Cells[7].Value = txtPrice.Text;
            newDataRow.Cells[8].Value = dateTimePicker1.Checked;
            MessageBox.Show("Successfully updated!");
            txtIdentity.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            maskedTextBox1.Clear();
            txtProcess.Clear();
            txtPrice.Clear();
            dateTimePicker1.ResetText();
            model.SaveChanges();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SalesHistory product = model.SalesHistory.FirstOrDefault(x => x.ID == select);
            model.SalesHistory.Remove(product);
            model.SaveChanges();
            MessageBox.Show("Deletion completed");
            fill();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Çift tıklamada griddeki verileri textboxa taşır
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtIdentity.Text = row.Cells[1].Value.ToString();
            txtName.Text = row.Cells[2].Value.ToString();
            txtSurname.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            maskedTextBox1.Text = row.Cells[5].Value.ToString();
            txtProcess.Text = row.Cells[6].Value.ToString();
            txtPrice.Text = row.Cells[6].Value.ToString();
            dateTimePicker1.Text = row.Cells[6].Value.ToString();
            model.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.SelectedCells[0].Value.ToString();
            select = Convert.ToInt32(value);
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

        private void txtProcess_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application(); // Excel uygulaması oluşturur
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing); // Yeni workbook oluşturur
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null; // Oluşturulan woorkbook da excel sayfası oluşturur
            app.Visible = true;
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview"; // Çalışma sayfasının isimlendirilmesi
            // Başlık kısmını Excel'de depola
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++) // Her satır ve sütun değerini excel sayfasına kaydeder
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            app.Quit();
        }
    }
}
