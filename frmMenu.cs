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
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHome f = new frmHome();
            addForm(f);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmHome f = new frmHome();
            addForm(f);
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTTK f = new frmTTTK();
            addForm(f);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK f = new frmDoiMK();
            addForm(f);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đổi tài khoản không?", "Đổi tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide(); //Ẩn form hiện tại
                frmDangNhap f = new frmDangNhap();
                f.ShowDialog(); //Hiển thị màn hình đăng nhập
                this.Show(); //quay lại menu sau khi đăng nhập
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chứ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu f = new frmGioiThieu();
            addForm(f);
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTra f = new frmPhieuTra();
            addForm(f);
        }

        private void phạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuPhat f = new frmPhieuPhat();
            addForm(f);
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSach f = new frmSach();  
            addForm(f);
        }
    }
}
