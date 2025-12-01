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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnHeader = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lblTheoGiangVien = new Label();
            lblTheoMonHoc = new Label();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            pnMain = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(lblTheoGiangVien);
            pnHeader.Controls.Add(lblTheoMonHoc);
            pnHeader.Controls.Add(btnClose);
            pnHeader.CustomizableEdges = customizableEdges3;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.ShadowDecoration.CustomizableEdges = customizableEdges4;
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
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges1;
            btnClose.DefaultAutoSize = true;
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(700, 6);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClose.Size = new Size(38, 29);
            btnClose.TabIndex = 24;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // pnMain
            // 
            pnMain.CustomizableEdges = customizableEdges5;
            pnMain.Location = new Point(0, 40);
            pnMain.Name = "pnMain";
            pnMain.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnMain.Size = new Size(750, 560);
            pnMain.TabIndex = 1;
            // 
            // ThemPhanCong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
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
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}