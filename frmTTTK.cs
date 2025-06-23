using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_QLTV
{
    public partial class frmTTTK : Form
    {
        String connectionString = "Data Source=DESKTOP-U2R6F9P\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public frmTTTK()
        {
            InitializeComponent();
        }

        private void frmTTTK_Load(object sender, EventArgs e)
        {
            string username = Properties.Settings.Default.username;
            LoadNhanVien(username);
        }
        private void LoadNhanVien(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT sMaNV, sTenNV, sGioiTinh, sDiaChi, sSdt, dNgaySinh FROM NHANVIEN WHERE sMaNV = @maNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        lbl_Ten.Text = "Xin chào: " + row["sTenNV"].ToString();
                        txt_MaNV.Text = row["sMaNV"].ToString();
                        txt_TenNV.Text = row["sTenNV"].ToString();

                        string gioiTinh = row["sGioiTinh"].ToString();
                        rad_nam.Checked = gioiTinh == "Nam";
                        rad_nu.Checked = gioiTinh == "Nữ";

                        txt_DiaChi.Text = row["sDiaChi"].ToString();
                        txt_SDT.Text = row["sSdt"].ToString();

                        if (DateTime.TryParse(row["dNgaySinh"].ToString(), out DateTime ngaySinh))
                        {
                            dtp_Ngay_Sinh.Value = ngaySinh;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_Cap_Nhat_Click(object sender, EventArgs e)
        {
            string maNV = txt_MaNV.Text.Trim();
            string tenNV = txt_TenNV.Text.Trim();
            string gioiTinh = rad_nam.Checked ? "Nam" : "Nữ";
            string diaChi = txt_DiaChi.Text.Trim();
            string sdt = txt_SDT.Text.Trim();
            DateTime ngaySinh = dtp_Ngay_Sinh.Value;

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                UPDATE NHANVIEN
                SET sTenNV = @tenNV,
                    sGioiTinh = @gioiTinh,
                    sDiaChi = @diaChi,
                    sSdt = @sdt,
                    dNgaySinh = @ngaySinh
                WHERE sMaNV = @maNV";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenNV", tenNV);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@diaChi", diaChi);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    if (!Regex.IsMatch(sdt, @"^0\d{9,10}$"))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@maNV", maNV);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_Ten.Text = tenNV;
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
