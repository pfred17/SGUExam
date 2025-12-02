namespace GUI.Forms.nhomhocphan
{
    partial class UC_NhomHocPhanItem
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
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnThoat = new Guna.UI2.WinForms.Guna2Button();
            colorStrip = new Guna.UI2.WinForms.Guna2Panel();
            btnDetails = new Guna.UI2.WinForms.Guna2Button();
            lblTenNhom = new Label();
            lblThoiGian = new Label();
            lblTenMonHoc = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.Transparent;
            pnlMain.Controls.Add(btnThoat);
            pnlMain.Controls.Add(colorStrip);
            pnlMain.Controls.Add(btnDetails);
            pnlMain.Controls.Add(lblTenNhom);
            pnlMain.Controls.Add(lblThoiGian);
            pnlMain.Controls.Add(lblTenMonHoc);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.White;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Radius = 12;
            pnlMain.ShadowColor = Color.Black;
            pnlMain.ShadowDepth = 20;
            pnlMain.ShadowShift = 4;
            pnlMain.Size = new Size(260, 160);
            pnlMain.TabIndex = 0;
            // 
            // btnThoat
            // 
            btnThoat.BorderRadius = 15;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.CustomizableEdges = customizableEdges1;
            btnThoat.DisabledState.BorderColor = Color.DarkGray;
            btnThoat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThoat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThoat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThoat.FillColor = Color.Transparent;
            btnThoat.Font = new Font("Segoe UI", 9F);
            btnThoat.ForeColor = Color.White;
            btnThoat.HoverState.FillColor = Color.FromArgb(255, 230, 230);
            btnThoat.Image = Properties.Resources.icon_phanquyencaidat;
            btnThoat.ImageSize = new Size(18, 18);
            btnThoat.Location = new Point(220, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThoat.Size = new Size(30, 30);
            btnThoat.TabIndex = 6;
            // 
            // colorStrip
            // 
            colorStrip.BorderRadius = 2;
            colorStrip.CustomizableEdges = customizableEdges3;
            colorStrip.FillColor = Color.FromArgb(94, 148, 255);
            colorStrip.Location = new Point(18, 22);
            colorStrip.Name = "colorStrip";
            colorStrip.ShadowDecoration.CustomizableEdges = customizableEdges4;
            colorStrip.Size = new Size(5, 45);
            colorStrip.TabIndex = 5;
            // 
            // btnDetails
            // 
            btnDetails.BorderRadius = 8;
            btnDetails.Cursor = Cursors.Hand;
            btnDetails.CustomizableEdges = customizableEdges5;
            btnDetails.DisabledState.BorderColor = Color.DarkGray;
            btnDetails.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDetails.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDetails.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDetails.FillColor = Color.FromArgb(240, 245, 255);
            btnDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDetails.ForeColor = Color.FromArgb(94, 148, 255);
            btnDetails.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            btnDetails.HoverState.ForeColor = Color.White;
            btnDetails.Location = new Point(145, 115);
            btnDetails.Name = "btnDetails";
            btnDetails.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDetails.Size = new Size(100, 35);
            btnDetails.TabIndex = 4;
            btnDetails.Text = "Chi tiết";
            btnDetails.Click += btnDetails_Click;
            // 
            // lblTenNhom
            // 
            lblTenNhom.AutoSize = true;
            lblTenNhom.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTenNhom.ForeColor = Color.FromArgb(100, 100, 120);
            lblTenNhom.Location = new Point(28, 95);
            lblTenNhom.Name = "lblTenNhom";
            lblTenNhom.Size = new Size(90, 20);
            lblTenNhom.TabIndex = 3;
            lblTenNhom.Text = "Nhóm: 01CL";
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoSize = true;
            lblThoiGian.Font = new Font("Segoe UI", 8.5F);
            lblThoiGian.ForeColor = Color.Gray;
            lblThoiGian.Location = new Point(28, 75);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(121, 20);
            lblThoiGian.TabIndex = 2;
            lblThoiGian.Text = "HK1 - 2024/2025";
            // 
            // lblTenMonHoc
            // 
            lblTenMonHoc.AutoEllipsis = true;
            lblTenMonHoc.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTenMonHoc.ForeColor = Color.FromArgb(30, 30, 45);
            lblTenMonHoc.Location = new Point(28, 20);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Size = new Size(185, 50);
            lblTenMonHoc.TabIndex = 1;
            lblTenMonHoc.Text = "Lập trình trên Windows";
            lblTenMonHoc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UC_NhomHocPhanItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlMain);
            Margin = new Padding(10);
            Name = "UC_NhomHocPhanItem";
            Size = new Size(260, 160);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }
        // Khai báo biến (Thêm vào class, bên ngoài hàm InitializeComponent)
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlMain;
        private System.Windows.Forms.Label lblTenMonHoc;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblTenNhom;
        private Guna.UI2.WinForms.Guna2Button btnDetails;
        private Guna.UI2.WinForms.Guna2Panel colorStrip;
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        private Guna.UI2.WinForms.Guna2Button btnThoat;
    }
}
