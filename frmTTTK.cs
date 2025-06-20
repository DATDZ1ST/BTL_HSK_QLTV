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
    public partial class frmTTTK : Form
    {
        string connectionString = "Data Source=DESKTOP-U2R6F9P\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
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

                        lblTen.Text = "Xin chào: " + row["sTenNV"].ToString();
                        txtMaNV.Text = row["sMaNV"].ToString();
                        txtTenNV.Text = row["sTenNV"].ToString();

                        string gioiTinh = row["sGioiTinh"].ToString();
                        rad_nam.Checked = gioiTinh == "Nam";
                        rad_nu.Checked = gioiTinh == "Nữ";

                        txtDiaChi.Text = row["sDiaChi"].ToString();
                        txtSDT.Text = row["sSdt"].ToString();

                        if (DateTime.TryParse(row["dNgaySinh"].ToString(), out DateTime ngaySinh))
                        {
                            dtp_ngay_sinh.Value = ngaySinh;
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_cap_nhat_Click(object sender, EventArgs e)
        {

            
        }
    }
}
