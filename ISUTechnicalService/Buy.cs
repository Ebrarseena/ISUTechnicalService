using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Entity.Infrastructure;
using System.Reflection.Emit;

namespace ISUTechnicalService
{
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
            timer1.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongTimeString();
        }

        private void Buy_Load(object sender, EventArgs e)
        {

            ComboDoldur1();
            ComboDoldur2();
            ComboDoldur3();

            //cmboxCategory.DataBindings();b
        }

        public void ComboDoldur1()
        {
            Model2 models = new Model2();
            List<string> items = models.StockTracking.Select(x => x.Category).Distinct().ToList();
            cmboxCategory.DataSource = items;

        }

        public void ComboDoldur2()
        {
            Model2 models = new Model2();
            string Combo1Value = cmboxCategory.SelectedValue.ToString();
            List<string> items2 = models.StockTracking.Where(x=> x.Category == Combo1Value ).Select(x => x.Brand).Distinct().ToList();
            cmboxBrand.DataSource = items2;
        }

        public void ComboDoldur3()
        {
            Model2 models = new Model2();
            string Combo1Value = cmboxCategory.SelectedValue.ToString();
            string Combo2Value = cmboxBrand.SelectedValue.ToString();

            List<string> items3 = models.StockTracking.Where(x => x.Category == Combo1Value && x.Brand == Combo2Value).Select(x => x.Model).Distinct().ToList();
            cmboxModel.DataSource = items3;
        }

     

        private void cmboxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboDoldur2();
        }

        private void cmboxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboDoldur3();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Model2 models = new Model2();
            string Combo1Value = cmboxCategory.SelectedValue.ToString();
            string Combo2Value = cmboxBrand.SelectedValue.ToString();
            string Combo3Value = cmboxModel.SelectedValue.ToString();
            StockTracking stocks = models.StockTracking.Where(x => x.Category == Combo1Value && x.Brand == Combo2Value && x.Model == Combo3Value).FirstOrDefault();
            if(stocks != null)
            {
                stocks.Stock = stocks.Stock-int.Parse(txtQuantity.Text);
            }
            models.SaveChanges();

        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
            Stock form22 = new Stock();
            form22.Show();
        }
    }
}
