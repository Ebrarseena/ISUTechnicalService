using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ISUTechnicalService
{
    public partial class Stock : Form
    {
        Model2 model = new Model2();
        int indexRow;
        int select = 0;
        public Stock()
        {
            InitializeComponent();
            List<StockTracking> stock = model.StockTracking.ToList();
            dataGridView1.DataSource = stock;
            timer1.Start();
        }

        private void fill()
        {
            List<StockTracking> stocks = model.StockTracking.ToList();
            dataGridView1.DataSource = stocks;
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            StockTracking stock = new StockTracking();
            stock.Category = txtCategory.Text;
            stock.Brand = txtBrand.Text;
            stock.Model = txtModel.Text;
            stock.Price = Convert.ToDouble(txtPrice.Text);
            stock.Stock = Convert.ToInt32(txtPrice.Text); //SOR
            model.StockTracking.Add(stock);
            model.SaveChanges();

            List<StockTracking> stocks = model.StockTracking.ToList();
            dataGridView1.DataSource = stock;
            MessageBox.Show("Adding process took place!");
            txtCategory.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            fill();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];

            newDataRow.Cells[1].Value = txtCategory.Text;
            newDataRow.Cells[2].Value = txtBrand.Text;
            newDataRow.Cells[3].Value = txtModel.Text;
            newDataRow.Cells[4].Value = txtPrice.Text;
            newDataRow.Cells[5].Value = txtStock.Text;
            MessageBox.Show("Successfully updated!");
            txtCategory.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            model.SaveChanges();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            StockTracking stock = model.StockTracking.FirstOrDefault(x => x.ID == select);
            model.StockTracking.Remove(stock);
            model.SaveChanges();
            MessageBox.Show("Deletion completed");
            fill();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtCategory.Text = row.Cells[1].Value.ToString();
            txtBrand.Text = row.Cells[2].Value.ToString();
            txtModel.Text = row.Cells[3].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
            txtStock.Text = row.Cells[5].Value.ToString();
            model.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.SelectedCells[0].Value.ToString();
            select = Convert.ToInt32(value);
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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
