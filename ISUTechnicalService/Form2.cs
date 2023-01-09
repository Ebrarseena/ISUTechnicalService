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
        public DeviceTroubleRecord()
        {
            InitializeComponent();
        }

        private void DeviceTroubleRecord_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongDateString();
        }
    }
}
