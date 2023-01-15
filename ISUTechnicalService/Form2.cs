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

        Model1 model = new Model1();
        int indexRow;
        int select = 0;
        public DeviceTroubleRecord()
        {
            InitializeComponent();
            List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
            dataGridView1.DataSource = deviceinfos;
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

            Deviceİnfo deviceinfo = new Deviceİnfo();
            deviceinfo.Brand = txtBrand.Text;
            deviceinfo.Model = txtModel.Text;
            deviceinfo.Trouble = txtTrouble.Text;
            deviceinfo.Status = radioButton1.Checked;
            deviceinfo.Price = Convert.ToDouble(txtPrice.Text);
            deviceinfo.Date = pickerDate.MinDate;
            model.Deviceİnfo.Add(deviceinfo);
            model.SaveChanges();

            List<Deviceİnfo> deviceinfos = model.Deviceİnfo.ToList();
            dataGridView1.DataSource = deviceinfo;
            MessageBox.Show("Adding process took place!");
            txtBrand.Clear();
            txtModel.Clear();
            txtTrouble.Clear();
            txtPrice.Clear();
            radioButton1.ResetText();   //Resettext
            pickerDate.ResetText();
            fill();
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

        }
    }
    }

