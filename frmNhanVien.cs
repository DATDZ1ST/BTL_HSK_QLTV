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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private int sMaNV = 0; // Biến toàn cục để lưu mã nhân viên
        private string currentmaNV = string.Empty; // Biến để lưu mã nhân viên hiện tại khi sửa
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cbGT.Items.Add("Nam");
            cbGT.Items.Add("Nữ");
            cbGT.SelectedIndex = 0; // Mặc định chọn "Nam"
            LoadData();
        }
        private void resetFields()
        {
            txtHT.Text = string.Empty;
            dtpNS.Value = DateTime.Now; // Đặt lại ngày sinh về ngày hiện tại
            cbGT.SelectedIndex = 0; // Đặt lại giới tính về "Nam"
            txtSDT.Text = string.Empty;
            txtDC.Text = string.Empty;
            currentmaNV = string.Empty; // Reset mã nhân viên hiện tại
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT sMaNV , sTenNV, dNgaySinh , sGioiTinh , sSdt , sDiaChi FROM NHANVIEN";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoten = txtHT.Text.Trim();
            string ngaysinh = dtpNS.Value.ToString("dd/MM/yyyy");
            string gioitinh = cbGT.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diachi = txtDC.Text.Trim();

            if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM NHANVIEN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        sMaNV = (int)cmd.ExecuteScalar(); // Lấy số lượng nhân viên hiện tại
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO NHANVIEN (sMaNV , sTenNV, dNgaySinh , sGioiTinh , sSdt , sDiaChi)  VALUES (@sMaNV , @HoTen, @NgaySinh, @GioiTinh, @SDT, @DiaChi)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaNV","NV" + sMaNV++);
                        cmd.Parameters.AddWithValue("@HoTen", hoten);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        cmd.Parameters.AddWithValue("@DiaChi", diachi);
                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetFields(); // Reset các trường nhập liệu
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE NHANVIEN SET sTenNV = @HoTen, dNgaySinh = @NgaySinh, sGioiTinh = @GioiTinh, sSdt = @SDT, sDiaChi = @DiaChi WHERE sMaNV = @sMaNV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaNV", currentmaNV);
                        cmd.Parameters.AddWithValue("@HoTen", txtHT.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@GioiTinh", cbGT.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text.Trim());
                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetFields(); // Reset các trường nhập liệu
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHT.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            cbGT.SelectedIndex = 0; // Đặt lại giới tính về "Nam"
            dtpNS.Value = DateTime.Now; // Đặt lại ngày sinh về ngày hiện tại
            if (e.RowIndex >= 0 && e.RowIndex < dgvNV.Rows.Count)
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                sMaNV = Convert.ToInt32(row.Cells["sMaNV"].Value);
                txtHT.Text = row.Cells["sTenNV"].Value.ToString();
                dtpNS.Value = Convert.ToDateTime(row.Cells["dNgaySinh"].Value);
                cbGT.SelectedItem = row.Cells["sGioiTinh"].Value.ToString();
                txtSDT.Text = row.Cells["sSdt"].Value.ToString();
                txtDC.Text = row.Cells["sDiaChi"].Value.ToString();
                currentmaNV = row.Cells["sMaNV"].Value.ToString(); // Lưu mã nhân viên hiện tại
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM NHANVIEN WHERE sMaNV = @sMaNV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaNV", currentmaNV);
                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetFields(); // Reset các trường nhập liệu
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string timkiem = txtHT.Text.Trim();
            if (string.IsNullOrEmpty(timkiem))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT sMaNV, sTenNV, dNgaySinh, sGioiTinh, sSdt, sDiaChi FROM NHANVIEN WHERE sTenNV = @TimKiem";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TimKiem", timkiem);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgvNV.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT sMaNV, sTenNV, dNgaySinh, sGioiTinh, sSdt, sDiaChi FROM NHANVIEN";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptNhanVien innv = new rptNhanVien();
                    innv.SetDataSource(dt);
                    InNhanVien inNhanVien = new InNhanVien();
                    inNhanVien.crystalReportViewer1.ReportSource = innv;
                    inNhanVien.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
