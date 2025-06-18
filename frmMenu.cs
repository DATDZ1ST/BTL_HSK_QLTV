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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private void addForm(Form f)
        {
            this.panelContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panelContent.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmHome f = new frmHome();
            addForm(f);

        }

        private void InforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTTK f = new frmTTTK();
            addForm(f);
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát", "Thoát chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHome f = new frmHome();
            addForm(f);
        }

        private void HDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu f = new frmGioiThieu();
            addForm(f);
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTTK t = new frmTTTK();
            addForm(t);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thoát chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu f = new frmGioiThieu();
            addForm(f);
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            addForm(frm);
        }
    }
}
