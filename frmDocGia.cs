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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
        {
            InitializeComponent();
        }
        string connecting = "Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private static int ma = 0;
        private string currentMaDG = "";
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            cbGT.Items.Add("Nam");
            cbGT.Items.Add("Nữ");
            cbGT.Items.Add("Khác");
            cbGT.SelectedIndex = 0; 
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    conn.Open();
                    string query = "SELECT sMaDG,sTenDG,dNgaySinh,sGioiTinh,sDiaChi,sSdt FROM DocGia";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDocGia.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ResetFields()
        {
            txtHT.Clear();
            txtDC.Clear();
            txtSDT.Clear();
            dtpNS.Value = DateTime.Now;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connecting))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT sMaDG, sTenDG, dNgaySinh, sGioiTinh, sDiaChi, sSdt FROM DocGia", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    rptDocGia report = new rptDocGia();
                    report.SetDataSource(dt);
                    InDocGia inDocGiaForm = new InDocGia();
                    inDocGiaForm.rptViewDocGia.ReportSource = report;
                    inDocGiaForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoten = txtHT.Text.Trim();
            string ngaysinh = dtpNS.Value.ToString("dd/MM/yyyy");
            string gioitinh = cbGT.Text.Trim();
            string diachi = txtDC.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if(string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(ngaysinh) || string.IsNullOrEmpty(gioitinh) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt) || sdt.Length !=10)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kiểm tra xem mã độc giả đã tồn tại hay chưa
            try
            {
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM DocGia WHERE sTenDG = @TenDG AND sSdt = @Sdt";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@TenDG", hoten);
                    checkCmd.Parameters.AddWithValue("@Sdt", sdt);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Độc giả đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetFields();
                        LoadData();
                        return;
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
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    conn.Open();
                    string query = "INSERT INTO DocGia (sMaDG, sTenDG, dNgaySinh, sGioiTinh, sDiaChi, sSdt) VALUES (@ma, @TenDG, @NgaySinh, @GioiTinh, @DiaChi, @Sdt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ma", ma++.ToString()); // Tăng mã độc giả tự động
                    cmd.Parameters.AddWithValue("@TenDG", hoten);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@Sdt", sdt);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm độc giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm độc giả thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHT.Clear();
            txtDC.Clear();
            txtSDT.Clear();
            dtpNS.Value = DateTime.Now;
            if (e.RowIndex >= 0 && e.RowIndex < dgvDocGia.Rows.Count)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];
                txtHT.Text = row.Cells["sTenDG"].Value.ToString();
                dtpNS.Value = Convert.ToDateTime(row.Cells["dNgaySinh"].Value);
                cbGT.Text = row.Cells["sGioiTinh"].Value.ToString();
                txtDC.Text = row.Cells["sDiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["sSdt"].Value.ToString();
                currentMaDG = row.Cells["sMaDG"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHT.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connecting))
                    {
                        conn.Open();
                        string query = "DELETE FROM DocGia WHERE sTenDG = @TenDG AND sSdt = @Sdt";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenDG", txtHT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sdt", txtSDT.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa độc giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetFields();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy độc giả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaDG))
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string hoten = txtHT.Text.Trim();
            string ngaysinh = dtpNS.Value.ToString("dd/MM/yyyy");
            string gioitinh = cbGT.Text.Trim();
            string diachi = txtDC.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(ngaysinh) || string.IsNullOrEmpty(gioitinh) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt) || sdt.Length != 10)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    conn.Open();
                    string query = "UPDATE DocGia SET sTenDG = @TenDG, dNgaySinh = @NgaySinh, sGioiTinh = @GioiTinh, sDiaChi = @DiaChi, sSdt = @Sdt WHERE sMaDG = @MaDG";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDG", currentMaDG);
                    cmd.Parameters.AddWithValue("@TenDG", hoten);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                    cmd.Parameters.AddWithValue("@DiaChi", diachi);
                    cmd.Parameters.AddWithValue("@Sdt", sdt);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa thông tin độc giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin độc giả thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string searchValue = txtHT.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    conn.Open();
                    string query = "SELECT sMaDG, sTenDG, dNgaySinh, sGioiTinh, sDiaChi, sSdt FROM DocGia WHERE sTenDG = @searchValue";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgvDocGia.DataSource = dt;
                        dgvDocGia.Columns["sMaDG"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy độc giả với tên: " + searchValue, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        LoadData(); // Hiển thị lại toàn bộ dữ liệu nếu không tìm thấy
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
