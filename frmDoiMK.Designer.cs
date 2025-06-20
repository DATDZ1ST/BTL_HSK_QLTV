namespace BTL_HSK_QLTV
{
    partial class frmDoiMK
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Nhap_MK_Moi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MK_Moi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Doi_MK = new System.Windows.Forms.Button();
            this.txt_TenTK = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Nhap_MK_Moi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_MK_Moi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Doi_MK);
            this.groupBox1.Controls.Add(this.txt_TenTK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhập lại mật khẩu mới";
            // 
            // txt_Nhap_MK_Moi
            // 
            this.txt_Nhap_MK_Moi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Nhap_MK_Moi.Location = new System.Drawing.Point(374, 215);
            this.txt_Nhap_MK_Moi.Name = "txt_Nhap_MK_Moi";
            this.txt_Nhap_MK_Moi.Size = new System.Drawing.Size(255, 22);
            this.txt_Nhap_MK_Moi.TabIndex = 3;
            this.txt_Nhap_MK_Moi.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txt_MK_Moi
            // 
            this.txt_MK_Moi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_MK_Moi.Location = new System.Drawing.Point(374, 159);
            this.txt_MK_Moi.Name = "txt_MK_Moi";
            this.txt_MK_Moi.Size = new System.Drawing.Size(255, 22);
            this.txt_MK_Moi.TabIndex = 2;
            this.txt_MK_Moi.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // btn_Doi_MK
            // 
            this.btn_Doi_MK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Doi_MK.Location = new System.Drawing.Point(374, 293);
            this.btn_Doi_MK.Name = "btn_Doi_MK";
            this.btn_Doi_MK.Size = new System.Drawing.Size(139, 38);
            this.btn_Doi_MK.TabIndex = 4;
            this.btn_Doi_MK.Text = "Đổi mật khẩu";
            this.btn_Doi_MK.UseVisualStyleBackColor = true;
            this.btn_Doi_MK.Click += new System.EventHandler(this.btn_Doi_MK_Click);
            // 
            // txt_TenTK
            // 
            this.txt_TenTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_TenTK.Location = new System.Drawing.Point(374, 111);
            this.txt_TenTK.Name = "txt_TenTK";
            this.txt_TenTK.Size = new System.Drawing.Size(255, 22);
            this.txt_TenTK.TabIndex = 1;
            // 
            // frmDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDoiMK";
            this.Text = "frmDoiMK";
            this.Load += new System.EventHandler(this.frmDoiMK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Nhap_MK_Moi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MK_Moi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Doi_MK;
        private System.Windows.Forms.TextBox txt_TenTK;
    }
}