using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmPhieuTra : Form
    {
        String connectionString = "Data Source=DESKTOP-U2R6F9P\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public frmPhieuTra()
        {
            InitializeComponent();
        }

        private void frmPhieuTra_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP (1000) [sMaPhieuTra], [sMaSach], [sMaPhieuMuon], [sMaNV], [dNgayTra], [sMaDG], [iMaTinhTrangSach], [sMaPhieuPhat] FROM PHIEUTRASACH";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhieuTra.DataSource = dt;
            }
        }

        private void dgvPhieuTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPhieuTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuTra.Rows[e.RowIndex];
                txtMaPhieuTra.Text = row.Cells["sMaPhieuTra"].Value.ToString();
                txtMaPhieuTra.Enabled=false;
                txtMaSach.Text = row.Cells["sMaSach"].Value.ToString();
                txtMaPhieuMuon.Text = row.Cells["sMaPhieuMuon"].Value.ToString();
                txtMaNV.Text = row.Cells["sMaNV"].Value.ToString();

                if (DateTime.TryParse(row.Cells["dNgayTra"].Value.ToString(), out DateTime ngayTra))
                    dtpNgayTra.Value = ngayTra;

                txtMaDG.Text = row.Cells["sMaDG"].Value.ToString();
                txtMaTTS.Text = row.Cells["iMaTinhTrangSach"].Value.ToString();
                txtMaPhieuPhat.Text = row.Cells["sMaPhieuPhat"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO PHIEUTRASACH 
                             (sMaPhieuTra, sMaSach, sMaPhieuMuon, sMaNV, dNgayTra, sMaDG, iMaTinhTrangSach, sMaPhieuPhat) 
                             VALUES 
                             (@sMaPhieuTra, @sMaSach, @sMaPhieuMuon, @sMaNV, @dNgayTra, @sMaDG, @iMaTinhTrangSach, @sMaPhieuPhat)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuTra", txtMaPhieuTra.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaSach", txtMaSach.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuMuon", txtMaPhieuMuon.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@dNgayTra", dtpNgayTra.Value);
                    cmd.Parameters.AddWithValue("@sMaDG", txtMaDG.Text.Trim());
                    cmd.Parameters.AddWithValue("@iMaTinhTrangSach", txtMaTTS.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuPhat", txtMaPhieuPhat.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phiếu trả thành công!");
                        LoadData(); 
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            txtMaPhieuTra.Clear();
            txtMaSach.Clear();
            txtMaPhieuMuon.Clear();
            txtMaNV.Clear();
            txtMaDG.Clear();
            txtMaTTS.Clear();
            txtMaPhieuPhat.Clear();
            dtpNgayTra.Value = DateTime.Today;
        }

        private bool CheckRequired()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuTra.Text) ||
                string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtMaPhieuMuon.Text))
            {
                MessageBox.Show("Vui lòng nhập tối thiểu Mã Phiếu Trả + Mã Sách + Mã Phiếu Mượn!",
                                "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!CheckRequired()) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa phiếu trả [{txtMaPhieuTra.Text}]?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM PHIEUTRASACH WHERE sMaPhieuTra = @sMaPhieuTra";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuTra", txtMaPhieuTra.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadData();       
                        ClearFields();       // dọn sạch ô nhập
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã phiếu trả để xóa!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!CheckRequired()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE PHIEUTRASACH
                           SET sMaSach           = @sMaSach,
                               sMaPhieuMuon      = @sMaPhieuMuon,
                               sMaNV             = @sMaNV,
                               dNgayTra          = @dNgayTra,
                               sMaDG             = @sMaDG,
                               iMaTinhTrangSach  = @iMaTinhTrangSach,
                               sMaPhieuPhat      = @sMaPhieuPhat
                           WHERE sMaPhieuTra     = @sMaPhieuTra";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuTra", txtMaPhieuTra.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaSach", txtMaSach.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuMuon", txtMaPhieuMuon.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@dNgayTra", dtpNgayTra.Value);
                    cmd.Parameters.AddWithValue("@sMaDG", txtMaDG.Text.Trim());
                    cmd.Parameters.AddWithValue("@iMaTinhTrangSach", txtMaTTS.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuPhat", txtMaPhieuPhat.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu trả để cập nhật!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtMaPhieuTra.Focus();
            txtMaPhieuTra.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM PHIEUTRASACH where sMaPhieuTra  LIKE @keyword or sMaSach  LIKE @keyword or sMaPhieuMuon  LIKE @keyword or sMaNV  LIKE @keyword or dNgayTra  LIKE @keyword or sMaDG  LIKE @keyword or iMaTinhTrangSach  LIKE @keyword or sMaPhieuPhat  LIKE @keyword";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPhieuTra.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnIn_SLMaNV_Click(object sender, EventArgs e)
        {
            string sMaNV = txtMaNV.Text.Trim();
            if (string.IsNullOrEmpty(sMaNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để in.");
                return;
            }

            try
            {
                ReportDocument report = new rptInTheoSLMNV();
                report.SetParameterValue("@sMaNV", sMaNV);

                frmBaoCao f = new frmBaoCao();
                f.Report = report; 
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        private void btnIn_SLMaTTS_Click(object sender, EventArgs e)
        {
            string iMaTinhTrangSach = txtMaTTS.Text.Trim();
            if (string.IsNullOrEmpty(iMaTinhTrangSach))
            {
                MessageBox.Show("Vui lòng nhập mã tình trạng sách để in.");
                return;
            }

            try
            {
                ReportDocument report = new prtThongKeTheoMaTTS();
                report.SetParameterValue("@iMaTinhTrangSach", iMaTinhTrangSach);

                frmBaoCao f = new frmBaoCao();
                f.Report = report;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        private void btnIn_SLMaSach_Click(object sender, EventArgs e)
        {
            string sMaSach = txtMaSach.Text.Trim();
            if (string.IsNullOrEmpty(sMaSach))
            {
                MessageBox.Show("Vui lòng nhập mã sách để in.");
                return;
            }

            try
            {
                ReportDocument report = new prtThongKeTheoMaSach();
                report.SetParameterValue("@sMaSach", sMaSach);

                frmBaoCao f = new frmBaoCao();
                f.Report = report;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
