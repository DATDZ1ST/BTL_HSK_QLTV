using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_QLTV
{
    public partial class frmBaoCao : Form
    {
        public ReportDocument Report { get; set; }
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
        
                crystalReportViewer1.ReportSource = Report;
                crystalReportViewer1.Refresh();
            
        }
    }
}
