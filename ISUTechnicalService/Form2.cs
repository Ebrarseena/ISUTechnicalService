using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Utils.About;
using DevExpress.XtraEditors.Repository;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ISUTechnicalService
{
    public partial class DeviceTroubleRecord : Form
    {

        Model2 model = new Model2();
        int indexRow;
        int select = 0;
        public DeviceTroubleRecord()
        {
            InitializeComponent();
            List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList(); //Birden fazla device kaydı çekileceği için List oluşturulur
            dataGridView1.DataSource = deviceinfos;
            timer1.Start();
        }

        private void fill()
        {
            List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
            dataGridView1.DataSource = deviceinfos;
        }

        private void DeviceTroubleRecord_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private void btncreate_Click(object sender, EventArgs e)  
        {
            try
            {
                Model2 models = new Model2();
                Deviceİnfo deviceinfo = new Deviceİnfo();  // Nesne oluşturulur
                deviceinfo.Brand = txtBrand.Text;          // Databasede bulunan brand ile formdaki txtBrand verisinin eşit olduğunu bildirir.
                deviceinfo.Model = txtModel.Text;
                deviceinfo.Trouble = txtTrouble.Text;
                deviceinfo.Price = Convert.ToSingle(txtPrice.Text);
                deviceinfo.Status = rdioComplete.Checked;
                deviceinfo.Payment = rdioPayment.Checked;
                deviceinfo.Date = DateTime.Now;
                deviceinfo.Delivery = DateTime.Now;
                deviceinfo.Name = txtName.Text;
                deviceinfo.Surname = txtSurname.Text;
                deviceinfo.Phone = maskedTextBox1.Text;
                deviceinfo.TC = txtTC.Text;
                deviceinfo.Email = Base64Decode(txtMail.Text);
                models.Deviceİnfo.Add(deviceinfo);
                models.SaveChanges();

                List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
                dataGridView1.DataSource = deviceinfo;
                MessageBox.Show("Adding process took place!");  //Verilecek mesaj
                txtBrand.Clear();       //Textboxlar temizlenir
                txtModel.Clear();
                txtTrouble.Clear();
                rdioPayment.ResetText();
                rdioComplete.ResetText();   
                pickerDate.ResetText();
                fill();
            }

             catch (Exception exs)
            {
                string hata = exs.Message;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];

            newDataRow.Cells[6].Value = txtBrand.Text;
            newDataRow.Cells[7].Value = txtModel.Text;
            newDataRow.Cells[8].Value = txtTrouble.Text;
            newDataRow.Cells[9].Value = txtPrice.Text;
            newDataRow.Cells[10].Value = rdioComplete.Checked;
            newDataRow.Cells[11].Value = rdioPayment.Checked;
            newDataRow.Cells[12].Value = pickerDate.Text;
            MessageBox.Show("Successfully updated!");
            txtBrand.Clear();
            txtModel.Clear();
            txtTrouble.Clear();
            rdioComplete.ResetText();
            rdioPayment.ResetText();
            pickerDate.ResetText();
            model.SaveChanges();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Deviceİnfo device = model.Deviceİnfo.FirstOrDefault(x => x.ID == select);
            model.Deviceİnfo.Remove(device);
            model.SaveChanges();
            fill();
            MessageBox.Show("Deletion completed!");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)   
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtSurname.Text = row.Cells["Surname"].Value.ToString();
            txtMail.Text = row.Cells["Email"].Value.ToString();
            maskedTextBox1.Text = row.Cells["Phone"].Value.ToString();
            txtBrand.Text = row.Cells["Brand"].Value.ToString();
            txtModel.Text = row.Cells["Model"].Value.ToString();
            txtPrice.Text = row.Cells["Price"].Value.ToString();
            txtTrouble.Text = row.Cells["Trouble"].Value.ToString();
            groupBox1.Text = row.Cells["Status"].Value.ToString();
            groupBox2.Text = row.Cells["Payment"].Value.ToString();
            pickerDate.Text = row.Cells["Date"].Value.ToString();
            pickerDate2.Text = row.Cells["Delivery"].Value.ToString();
            model.SaveChanges();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.SelectedCells[0].Value.ToString();
            select = Convert.ToInt32(value);
        }

        private void btnexcel_Click(object sender, EventArgs e)  
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

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)  
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);   // Textboxa sadece sayı girilebilir
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)       // Textboxa sadece harf girilebilir
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtTrouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btntransfer_Click(object sender, EventArgs e)
        {
            Model2 model = new Model2();
            string gelenTc = txtTC.Text;
            Customerİnfo customer = model.Customerİnfo.Where(x => x.TC == gelenTc).FirstOrDefault(); //LİNQ SORGUSU KULLANILDI (Temel sorgularından birisi olan where sorgusu ile)
            if (customer != null)                                                                   //Bir tane veri çekileceği için FirstOrDefault kullanıldı aksi taktirde list kullanılacaktı
            {
                txtName.Text = customer.Name;
                txtSurname.Text = customer.Surname;
                txtMail.Text = customer.Email;
                maskedTextBox1.Text = customer.Phone;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            fill();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock stock = new Stock();
            stock.Show();
        }

        }

    }


