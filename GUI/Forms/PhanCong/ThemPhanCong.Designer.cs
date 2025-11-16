namespace GUI.forms.PhanCong
{
    partial class ThemPhanCong
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnHeader = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lblTheoGiangVien = new Label();
            lblTheoMonHoc = new Label();
            lblClose = new Label();
            pnMain = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(lblTheoGiangVien);
            pnHeader.Controls.Add(lblTheoMonHoc);
            pnHeader.Controls.Add(lblClose);
            pnHeader.CustomizableEdges = customizableEdges1;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnHeader.Size = new Size(750, 40);
            pnHeader.TabIndex = 0;
            // 
            // lblTheoGiangVien
            // 
            lblTheoGiangVien.AutoSize = true;
            lblTheoGiangVien.BackColor = Color.Transparent;
            lblTheoGiangVien.Cursor = Cursors.Hand;
            lblTheoGiangVien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTheoGiangVien.Location = new Point(9, 11);
            lblTheoGiangVien.Name = "lblTheoGiangVien";
            lblTheoGiangVien.Size = new Size(120, 21);
            lblTheoGiangVien.TabIndex = 2;
            lblTheoGiangVien.Text = "Theo giảng viên";
            lblTheoGiangVien.Click += lblTheoGiangVien_Click;
            // 
            // lblTheoMonHoc
            // 
            lblTheoMonHoc.AutoSize = true;
            lblTheoMonHoc.BackColor = Color.Transparent;
            lblTheoMonHoc.Cursor = Cursors.Hand;
            lblTheoMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTheoMonHoc.Location = new Point(150, 11);
            lblTheoMonHoc.Name = "lblTheoMonHoc";
            lblTheoMonHoc.Size = new Size(109, 21);
            lblTheoMonHoc.TabIndex = 3;
            lblTheoMonHoc.Text = "Theo môn học";
            lblTheoMonHoc.Click += lblTheoMonHoc_Click;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.BackColor = Color.Transparent;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClose.Location = new Point(720, 10);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(19, 21);
            lblClose.TabIndex = 4;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // pnMain
            // 
            pnMain.CustomizableEdges = customizableEdges3;
            pnMain.Location = new Point(0, 40);
            pnMain.Name = "pnMain";
            pnMain.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnMain.Size = new Size(750, 560);
            pnMain.TabIndex = 1;
            // 
            // ThemPhanCong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 600);
            Controls.Add(pnHeader);
            Controls.Add(pnMain);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemPhanCong";
            StartPosition = FormStartPosition.CenterScreen;
            Load += ThemPhanCong_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnHeader;
        private Label lblTheoGiangVien;
        private Label lblTheoMonHoc;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnMain;
        private Label lblClose;
    }
}