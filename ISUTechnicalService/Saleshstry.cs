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
    public partial class Saleshstry : Form
    {
        Model1 model = new Model1();
        int indexRow;
        int select = 0;
        public Saleshstry()
        {
            InitializeComponent();
            List<SalesHistory> sale = model.SalesHistory.ToList();
            dataGridView1.DataSource = sale;
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

            List<SalesHistory> sales = model.SalesHistory.ToList();
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
            fill();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
