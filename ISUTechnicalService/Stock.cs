﻿using System;
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
        Model1 model = new Model1();
        int indexRow;
        int select = 0;
        public Stock()
        {
            InitializeComponent();
            List<StockTracking> stock = model.StockTracking.ToList();
            dataGridView1.DataSource = stock;
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

    }
}
