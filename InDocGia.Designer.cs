namespace BTL_HSK_QLTV
{
    partial class InDocGia
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
            this.rptViewDocGia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptViewDocGia
            // 
            this.rptViewDocGia.ActiveViewIndex = -1;
            this.rptViewDocGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewDocGia.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewDocGia.Location = new System.Drawing.Point(0, 0);
            this.rptViewDocGia.Name = "rptViewDocGia";
            this.rptViewDocGia.Size = new System.Drawing.Size(800, 450);
            this.rptViewDocGia.TabIndex = 0;
            this.rptViewDocGia.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // InDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptViewDocGia);
            this.Name = "InDocGia";
            this.Text = "InDocGia";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewDocGia;
    }
}