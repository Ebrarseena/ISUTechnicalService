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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        DeviceTroubleRecord fr1; //nesne oluşturuyoruz
        private void btndevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null) //Daha önce çağırılmadıysa
            {
                fr1 = new DeviceTroubleRecord(); //Artık yapıcı bir metot
                fr1.MdiParent = this; //Fr1 formunun mdi üzerinde açılması için
                fr1.Show();
            }
        }
    }
}
