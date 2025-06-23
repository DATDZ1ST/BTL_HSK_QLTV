namespace BTL_HSK_QLTV
{
    partial class frmPhieuPhat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtMaPhieuTra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIn_TongTienPhatMax = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnIn_SLMaPT = new System.Windows.Forms.Button();
            this.btnIn_TongTienPhatTheoThang = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvPhieuPhat = new System.Windows.Forms.DataGridView();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtMaTTS = new System.Windows.Forms.TextBox();
            this.txtMaPhieuPhat = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(798, 38);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(127, 36);
            this.btnLamMoi.TabIndex = 51;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtMaPhieuTra
            // 
            this.txtMaPhieuTra.Location = new System.Drawing.Point(209, 81);
            this.txtMaPhieuTra.Name = "txtMaPhieuTra";
            this.txtMaPhieuTra.Size = new System.Drawing.Size(200, 22);
            this.txtMaPhieuTra.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 49;
            this.label9.Text = "Mã phiếu phạt";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(638, 42);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(131, 22);
            this.txtTimKiem.TabIndex = 48;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(570, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 47;
            this.label8.Text = "Tìm kiếm";
            // 
            // btnIn_TongTienPhatMax
            // 
            this.btnIn_TongTienPhatMax.Location = new System.Drawing.Point(756, 229);
            this.btnIn_TongTienPhatMax.Name = "btnIn_TongTienPhatMax";
            this.btnIn_TongTienPhatMax.Size = new System.Drawing.Size(127, 50);
            this.btnIn_TongTienPhatMax.TabIndex = 46;
            this.btnIn_TongTienPhatMax.Text = "In theo số tiền phạt lớn nhất";
            this.btnIn_TongTienPhatMax.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(756, 91);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(127, 50);
            this.btnSua.TabIndex = 45;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(570, 160);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(127, 50);
            this.btnXoa.TabIndex = 44;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnIn_SLMaPT
            // 
            this.btnIn_SLMaPT.Location = new System.Drawing.Point(756, 160);
            this.btnIn_SLMaPT.Name = "btnIn_SLMaPT";
            this.btnIn_SLMaPT.Size = new System.Drawing.Size(127, 50);
            this.btnIn_SLMaPT.TabIndex = 43;
            this.btnIn_SLMaPT.Text = "In sl mã Phiếu trả";
            this.btnIn_SLMaPT.UseVisualStyleBackColor = true;
            this.btnIn_SLMaPT.Click += new System.EventHandler(this.btnIn_SLMaPT_Click);
            // 
            // btnIn_TongTienPhatTheoThang
            // 
            this.btnIn_TongTienPhatTheoThang.Location = new System.Drawing.Point(570, 229);
            this.btnIn_TongTienPhatTheoThang.Name = "btnIn_TongTienPhatTheoThang";
            this.btnIn_TongTienPhatTheoThang.Size = new System.Drawing.Size(127, 50);
            this.btnIn_TongTienPhatTheoThang.TabIndex = 42;
            this.btnIn_TongTienPhatTheoThang.Text = "In Tổng số tiền phạt theo tháng";
            this.btnIn_TongTienPhatTheoThang.UseVisualStyleBackColor = true;
            this.btnIn_TongTienPhatTheoThang.Click += new System.EventHandler(this.btnIn_TongTienPhatTheoThang_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(570, 91);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(127, 50);
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvPhieuPhat
            // 
            this.dgvPhieuPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuPhat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhieuPhat.Location = new System.Drawing.Point(0, 344);
            this.dgvPhieuPhat.Name = "dgvPhieuPhat";
            this.dgvPhieuPhat.RowHeadersWidth = 51;
            this.dgvPhieuPhat.RowTemplate.Height = 24;
            this.dgvPhieuPhat.Size = new System.Drawing.Size(1033, 226);
            this.dgvPhieuPhat.TabIndex = 40;
            this.dgvPhieuPhat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuPhat_CellClick);
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(209, 167);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(200, 22);
            this.txtTienPhat.TabIndex = 37;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(209, 209);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 22);
            this.txtGhiChu.TabIndex = 36;
            // 
            // txtMaTTS
            // 
            this.txtMaTTS.Location = new System.Drawing.Point(209, 129);
            this.txtMaTTS.Name = "txtMaTTS";
            this.txtMaTTS.Size = new System.Drawing.Size(200, 22);
            this.txtMaTTS.TabIndex = 35;
            // 
            // txtMaPhieuPhat
            // 
            this.txtMaPhieuPhat.Enabled = false;
            this.txtMaPhieuPhat.Location = new System.Drawing.Point(209, 38);
            this.txtMaPhieuPhat.Name = "txtMaPhieuPhat";
            this.txtMaPhieuPhat.Size = new System.Drawing.Size(200, 22);
            this.txtMaPhieuPhat.TabIndex = 34;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(209, 253);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(200, 22);
            this.txtTrangThai.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Tiền phạt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mã tình trạng sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Trạng thái";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã phiếu trả";
            // 
            // frmPhieuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 570);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.txtMaPhieuTra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnIn_TongTienPhatMax);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnIn_SLMaPT);
            this.Controls.Add(this.btnIn_TongTienPhatTheoThang);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvPhieuPhat);
            this.Controls.Add(this.txtTienPhat);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtMaTTS);
            this.Controls.Add(this.txtMaPhieuPhat);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPhieuPhat";
            this.Text = "frmPhieuPhat";
            this.Load += new System.EventHandler(this.frmPhieuPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtMaPhieuTra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnIn_TongTienPhatMax;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnIn_SLMaPT;
        private System.Windows.Forms.Button btnIn_TongTienPhatTheoThang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvPhieuPhat;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtMaTTS;
        private System.Windows.Forms.TextBox txtMaPhieuPhat;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}