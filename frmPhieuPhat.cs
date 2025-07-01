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
    public partial class frmPhieuPhat : Form
    {
        String connectionString = "Data Source=DESKTOP-U2R6F9P\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public frmPhieuPhat()
        {
            InitializeComponent();
        }

        private void frmPhieuPhat_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP (1000) sMaPhieuPhat, sMaPhieuTra , iMaTinhTrangSach, fTienPhat, sGhiChu, sTrangThai FROM PHIEUPHAT";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhieuPhat.DataSource = dt;
            }
        }

        private void dgvPhieuPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuPhat.Rows[e.RowIndex];
                txtMaPhieuPhat.Text = row.Cells["sMaPhieuPhat"].Value.ToString();
                txtMaPhieuTra.Text = row.Cells["sMaPhieuTra"].Value.ToString();
                txtMaTTS.Text = row.Cells["iMaTinhTrangSach"].Value.ToString();
                txtTienPhat.Text = row.Cells["fTienPhat"].Value.ToString();
                txtGhiChu.Text = row.Cells["sGhiChu"].Value.ToString();
                txtTrangThai.Text = row.Cells["sTrangThai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO PHIEUPHAT 
                             (sMaPhieuPhat, sMaPhieuTra , iMaTinhTrangSach, fTienPhat, sGhiChu, sTrangThai) 
                             VALUES 
                             (@sMaPhieuPhat, @sMaPhieuTra, @iMaTinhTrangSach, @fTienPhat, @sGhiChu, @sTrangThai)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuPhat", txtMaPhieuPhat.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuTra", txtMaPhieuTra.Text.Trim());
                    cmd.Parameters.AddWithValue("@iMaTinhTrangSach", txtMaTTS.Text.Trim());
                    cmd.Parameters.AddWithValue("@fTienPhat", txtTienPhat.Text.Trim());
                    cmd.Parameters.AddWithValue("@sGhiChu", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@sTrangThai", txtTrangThai.Text.Trim());
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phiếu phạt thành công!");
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
            txtMaPhieuPhat.Clear();
            txtMaPhieuTra.Clear();
            txtMaTTS.Clear();
            txtTienPhat.Clear();
            txtGhiChu.Clear();
            txtTrangThai.Clear();
        }

        private bool CheckRequired()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuPhat.Text) ||
                string.IsNullOrWhiteSpace(txtMaPhieuTra.Text) 
                )
            {
                MessageBox.Show("Vui lòng nhập tối thiểu Mã Phiếu phạt + Mã phiếu trả!",
                                "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!CheckRequired()) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa phiếu phạt [{txtMaPhieuPhat.Text}]?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM PHIEUPHAT WHERE sMaPhieuPhat = @sMaPhieuPhat";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuPhat", txtMaPhieuPhat.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadData();         // refresh dgv
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
                    string sql = @"UPDATE PHIEUPHAT
                           SET 
                               sMaPhieuTra      = @sMaPhieuTra,
                               iMaTinhTrangSach = @iMaTinhTrangSach,
                               fTienPhat        = @fTienPhat,
                               sGhiChu          = @sGhiChu,
                               sTrangThai       = @sTrangThai
                           WHERE sMaPhieuPhat   = @sMaPhieuPhat";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaPhieuPhat", txtMaPhieuPhat.Text.Trim());
                    cmd.Parameters.AddWithValue("@sMaPhieuTra", txtMaPhieuTra.Text.Trim());
                    cmd.Parameters.AddWithValue("@iMaTinhTrangSach", txtMaTTS.Text.Trim());
                    cmd.Parameters.AddWithValue("@fTienPhat", txtTienPhat.Text.Trim());
                    cmd.Parameters.AddWithValue("@sGhiChu", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@sTrangThai", txtMaTTS.Text.Trim());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu phạt để cập nhật!", "Thông báo",
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
            txtMaPhieuPhat.Focus();
            txtMaPhieuPhat.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM PHIEUPHAT where sMaPhieuPhat  LIKE @keyword or sMaPhieuTra  LIKE @keyword or iMaTinhTrangSach  LIKE @keyword or fTienPhat  LIKE @keyword or sGhiChu  LIKE @keyword or sTrangThai  LIKE @keyword ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPhieuPhat.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnIn_SLMaPT_Click(object sender, EventArgs e)
        {
            string sMaPhieuTra = txtMaPhieuTra.Text.Trim();
            if (string.IsNullOrEmpty(sMaPhieuTra))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu trả để in.");
                return;
            }

            try
            {
                ReportDocument report = new rptInTheoSLMaPT();
                report.SetParameterValue("@sMaPhieuTra", sMaPhieuTra);

                frmBaoCao f = new frmBaoCao();
                f.Report = report;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        private void btnIn_TongTienPhatTheoThang_Click(object sender, EventArgs e)
        {
            string sMaPhieuTra = txtMaPhieuTra.Text.Trim();
            if (string.IsNullOrEmpty(sMaPhieuTra))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu trả để in.");
                return;
            }

            try
            {
                ReportDocument report = new rptTongTienPhat();
                report.SetParameterValue("@sMaPhieuTra", sMaPhieuTra);

                frmBaoCao f = new frmBaoCao();
                f.Report = report;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        private void btnIn_TongTienPhatMax_Click(object sender, EventArgs e)
        {
            //string sMaPhieuPhat = txtMaPhieuPhat.Text.Trim();
            //if (string.IsNullOrEmpty(sMaPhieuPhat))
            //{
            //    MessageBox.Show("Vui lòng nhập mã phiếu phạt để in.");
            //    return;
            //}

            try
            {
                ReportDocument report = new rptInTienPhatTheoMaPTMax();
                //report.SetParameterValue("@sMaPhieuPhat", sMaPhieuPhat);

                frmBaoCao f = new frmBaoCao();
                f.Report = report;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }
    }
}
