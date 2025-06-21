namespace BTL_HSK_QLTV
{
    partial class frmGioiThieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGioiThieu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFB = new System.Windows.Forms.Button();
            this.btnZL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 133);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(181, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phản hồi với tác giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 222);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(227, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rèn luyện thêm kiến thức";
            // 
            // btnFB
            // 
            this.btnFB.Image = ((System.Drawing.Image)(resources.GetObject("btnFB.Image")));
            this.btnFB.Location = new System.Drawing.Point(464, 118);
            this.btnFB.Name = "btnFB";
            this.btnFB.Size = new System.Drawing.Size(75, 52);
            this.btnFB.TabIndex = 3;
            this.btnFB.UseVisualStyleBackColor = true;
            this.btnFB.Click += new System.EventHandler(this.btnFB_Click);
            // 
            // btnZL
            // 
            this.btnZL.Image = ((System.Drawing.Image)(resources.GetObject("btnZL.Image")));
            this.btnZL.Location = new System.Drawing.Point(464, 207);
            this.btnZL.Name = "btnZL";
            this.btnZL.Size = new System.Drawing.Size(75, 52);
            this.btnZL.TabIndex = 4;
            this.btnZL.UseVisualStyleBackColor = true;
            this.btnZL.Click += new System.EventHandler(this.btnZL_Click);
            // 
            // frmGioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnZL);
            this.Controls.Add(this.btnFB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmGioiThieu";
            this.Text = "frmGioiThieu";
            this.Load += new System.EventHandler(this.frmGioiThieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFB;
        private System.Windows.Forms.Button btnZL;
    }
}