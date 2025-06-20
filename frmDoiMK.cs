using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_QLTV
{
    public partial class frmDoiMK : Form
    {
        String connectionString = "Data Source=DESKTOP-U2R6F9P\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void frmDoiMK_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Doi_MK_Click(object sender, EventArgs e)
        {
            string tenTK = txt_TenTK.Text.Trim();
            string mkMoi = txt_MK_Moi.Text.Trim();
            string nhapLaiMK = txt_Nhap_MK_Moi.Text.Trim();

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(nhapLaiMK))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mkMoi != nhapLaiMK)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkUserSql = "SELECT COUNT(*) FROM TaiKhoan WHERE sUserName = @user";
                    SqlCommand checkCmd = new SqlCommand(checkUserSql, conn);
                    checkCmd.Parameters.AddWithValue("@user", tenTK);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE TaiKhoan SET sPassWord = @newPass WHERE sUserName = @user";
                    SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                    updateCmd.Parameters.AddWithValue("@newPass", mkMoi);
                    updateCmd.Parameters.AddWithValue("@user", tenTK);

                    int rows = updateCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_TenTK.Clear();
                        txt_MK_Moi.Clear();
                        txt_Nhap_MK_Moi.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
