using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Utils.About;
using DevExpress.XtraEditors.Repository;
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

        Model2 model = new Model2(); // SOR
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

        private void btncreate_Click(object sender, EventArgs e)  
        {
            try
            {
                Model2 models = new Model2();
                Deviceİnfo deviceinfo = new Deviceİnfo();  // Nesne oluşturulur
                deviceinfo.Brand = txtBrand.Text;          // Databasede bulunan brand ile formdaki txtBrand verisinin eşit olduğunu bildirir.
                deviceinfo.Model = txtModel.Text;
                deviceinfo.Trouble = txtTrouble.Text;
                deviceinfo.Status = radioButton1.Checked;
                deviceinfo.Price = Convert.ToDouble(txtPrice.Text);
                deviceinfo.Date = DateTime.Now;
                deviceinfo.Name = txtName.Text;
                deviceinfo.Surname = txtSurname.Text;
                deviceinfo.Phone = maskedTextBox1.Text;
                deviceinfo.TC = txtTC.Text;
                deviceinfo.Email = txtMail.Text;
                models.Deviceİnfo.Add(deviceinfo);
                models.SaveChanges();

                List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
                dataGridView1.DataSource = deviceinfo;
                MessageBox.Show("Adding process took place!");  //Verilecek mesaj
                txtBrand.Clear();       //Textboxlar temizlenir
                txtModel.Clear();
                txtTrouble.Clear();
                txtPrice.Clear();
                radioButton1.ResetText();   
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

            newDataRow.Cells[1].Value = txtBrand.Text;
            newDataRow.Cells[2].Value = txtModel.Text;
            newDataRow.Cells[3].Value = txtTrouble.Text;
            newDataRow.Cells[4].Value = radioButton1.Checked;
            newDataRow.Cells[5].Value = txtPrice.Text;
            newDataRow.Cells[6].Value = pickerDate.Text;
            MessageBox.Show("Successfully updated!");
            txtBrand.Clear();
            txtModel.Clear();
            txtTrouble.Clear();
            radioButton1.ResetText();
            txtPrice.Clear();
            pickerDate.ResetText();
            model.SaveChanges();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Deviceİnfo device = model.Deviceİnfo.FirstOrDefault(x => x.ID == select);
            model.Deviceİnfo.Remove(device);
            model.SaveChanges();
            MessageBox.Show("Deletion completed!");
            fill();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtBrand.Text = row.Cells[1].Value.ToString();
            txtModel.Text = row.Cells[2].Value.ToString();
            txtTrouble.Text = row.Cells[3].Value.ToString();
            radioButton1.Text = row.Cells[4].Value.ToString();
            txtPrice.Text = row.Cells[5].Value.ToString();
            pickerDate.Text = row.Cells[6].Value.ToString();
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
    }
    }

