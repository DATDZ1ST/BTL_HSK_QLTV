using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_QLTV
{
    public partial class frmGioiThieu : Form
    {
        public frmGioiThieu()
        {
            InitializeComponent();
        }

        private void frmGioiThieu_Load(object sender, EventArgs e)
        {

        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            string url = "https://www.facebook.com/share/1LccXnsJKd/?mibextid=wwXIfr";
            Process.Start(url);
        }

        private void btnZL_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/playlist?list=PLPt6-BtUI22qglZObJuYrxG8t3r-UP6WH";
            Process.Start(url);
        }
    }
}
