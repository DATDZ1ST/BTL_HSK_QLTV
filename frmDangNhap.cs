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
    public partial class frmDangNhap : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";       
        string connectionString = "Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load tài khoản và mật khẩu đã lưu nếu có
            txtTaiKhoan.Text = Properties.Settings.Default.taiKhoan;
            txtMatKhau.Text = Properties.Settings.Default.matKhau;

            if (!string.IsNullOrEmpty(txtTaiKhoan.Text) && !string.IsNullOrEmpty(txtMatKhau.Text))
            {
                chk_save.Checked = true;
            }
        }

        private void tb_tai_khoan_TextChanged(object sender, EventArgs e)
        {
            chk_save.Checked = false;
        }

        private void tb_mat_khau_TextChanged(object sender, EventArgs e)
        {
            chk_save.Checked = false;
        }

        private void btn_dang_nhap_Click(object sender, EventArgs e)
        {
            //string username = txtTaiKhoan.Text.Trim();
            //string password = txtMatKhau.Text.Trim();

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //{
            //    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();

            //        // Câu truy vấn kiểm tra tài khoản và mật khẩu
            //        string sql = "SELECT * FROM TaiKhoan WHERE sUserName = @user AND sPassWord = @pass";

            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        cmd.Parameters.AddWithValue("@user", username);
            //        cmd.Parameters.AddWithValue("@pass", password);

            //        SqlDataReader reader = cmd.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            reader.Read();
            //            string maNV = reader["sMaNV"].ToString();
            //            bool quyen = Convert.ToBoolean(reader["bQuyen"]);

            //            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            // TODO: Mở form chính hoặc chuyển tiếp
            //            // Ví dụ: new MainForm(maNV, quyen).Show(); this.Hide();
            //            // Ẩn form đăng nhập và mở frmMenu
            //            this.Hide(); // Ẩn form đăng nhập

            //            frmMenu frm = new frmMenu();
            //            frm.FormClosed += (s, args) => this.Close(); // Khi frmMenu đóng thì thoát chương trình
            //            frm.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * FROM TaiKhoan WHERE sUserName = @user AND sPassWord = @pass";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string maNV = reader["sMaNV"].ToString();
                        bool quyen = Convert.ToBoolean(reader["bQuyen"]);

                        // LƯU nếu được chọn
                        if (chk_save.Checked)
                        {
                            Properties.Settings.Default.taiKhoan = username;
                            Properties.Settings.Default.matKhau = password;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.Reset();
                        }
                        Properties.Settings.Default.username = maNV;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        frmMenu frm = new frmMenu();
                        frm.FormClosed += (s, args) => this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chk_save_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_save.Checked)
            {
                Properties.Settings.Default.Reset();
            }
        }
    }
}
