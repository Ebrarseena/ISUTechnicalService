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

        private void btnsales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Buy buy = new Buy();
            buy.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Saleshstry_Load(object sender, EventArgs e)
        {
            Model2 modell = new Model2();
            List<StockTracking> list = modell.StockTracking.ToList();
        }
    }
}
