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

            this.pnlMain = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.colorStrip = new Guna.UI2.WinForms.Guna2Panel();
            this.btnJoin = new Guna.UI2.WinForms.Guna2Button();
            this.lblTenNhom = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblTenMonHoc = new System.Windows.Forms.Label();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain (Khung thẻ chính)
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.btnThoat);
            this.pnlMain.Controls.Add(this.colorStrip);
            this.pnlMain.Controls.Add(this.btnJoin);
            this.pnlMain.Controls.Add(this.lblTenNhom);
            this.pnlMain.Controls.Add(this.lblThoiGian);
            this.pnlMain.Controls.Add(this.lblTenMonHoc);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Radius = 12; 
            this.pnlMain.ShadowColor = System.Drawing.Color.Black;
            this.pnlMain.ShadowDepth = 20; 
            this.pnlMain.ShadowShift = 4;
            this.pnlMain.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Surrounded;
            this.pnlMain.Size = new System.Drawing.Size(260, 160);
            this.pnlMain.TabIndex = 0;

            // 
            // colorStrip (Dải màu trang trí bên trái)
            // 
            this.colorStrip.BorderRadius = 2; 
            this.colorStrip.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.colorStrip.CustomizableEdges = customizableEdges1;
            this.colorStrip.Location = new System.Drawing.Point(18, 22);
            this.colorStrip.Name = "colorStrip";
            this.colorStrip.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.colorStrip.Size = new System.Drawing.Size(5, 45); 
            this.colorStrip.TabIndex = 5;

            // 
            // lblTenMonHoc (Tiêu đề chính)
            // 
            this.lblTenMonHoc.AutoEllipsis = true;
            this.lblTenMonHoc.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45))))); // Màu chữ đậm hơn
            this.lblTenMonHoc.Location = new System.Drawing.Point(28, 20);
            this.lblTenMonHoc.Name = "lblTenMonHoc";
            this.lblTenMonHoc.Size = new System.Drawing.Size(185, 50); 
            this.lblTenMonHoc.TabIndex = 1;
            this.lblTenMonHoc.Text = "Lập trình trên Windows";
            this.lblTenMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblThoiGian (Thông tin phụ)
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblThoiGian.ForeColor = System.Drawing.Color.Gray;
            this.lblThoiGian.Location = new System.Drawing.Point(28, 75);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(110, 20);
            this.lblThoiGian.TabIndex = 2;
            this.lblThoiGian.Text = "HK1 - 2024/2025";

            // 
            // lblTenNhom (Thông tin phụ 2)
            // 
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblTenNhom.Location = new System.Drawing.Point(28, 95);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(95, 20);
            this.lblTenNhom.TabIndex = 3;
            this.lblTenNhom.Text = "Nhóm: 01CL";

            // 
            // btnJoin (Nút hành động chính)
            // 
            this.btnJoin.BorderRadius = 8; // Bo góc vừa phải (Modern style)
            this.btnJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJoin.CustomizableEdges = customizableEdges3;
            this.btnJoin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnJoin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnJoin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnJoin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnJoin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255))))); // Nền xanh nhạt
            this.btnJoin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnJoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255))))); // Chữ xanh đậm
            this.btnJoin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255))))); // Hover: Nền xanh
            this.btnJoin.HoverState.ForeColor = System.Drawing.Color.White; // Hover: Chữ trắng
            this.btnJoin.Location = new System.Drawing.Point(145, 115); // Đẩy nút về góc phải
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.btnJoin.Size = new System.Drawing.Size(100, 35); // Nút nhỏ gọn hơn
            this.btnJoin.TabIndex = 4;
            this.btnJoin.Text = "Chi tiết";

            // 
            // btnThoat (Nút Setting/Thoát)
            // 
            this.btnThoat.BorderRadius = 15; // Hình tròn
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.CustomizableEdges = customizableEdges5;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.Transparent; // Trong suốt
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230))))); // Hover đỏ nhạt cảnh báo
            this.btnThoat.Image = Properties.Resources.icon_phanquyencaidat; // Giữ icon của bạn
            this.btnThoat.ImageSize = new System.Drawing.Size(18, 18);
            this.btnThoat.Location = new System.Drawing.Point(220, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.btnThoat.Size = new System.Drawing.Size(30, 30);
            this.btnThoat.TabIndex = 6;

            // 
            // UC_NhomHocPhanItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UC_NhomHocPhanItem";
            this.Size = new System.Drawing.Size(260, 160);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
        // Khai báo biến (Thêm vào class, bên ngoài hàm InitializeComponent)
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlMain;
        private System.Windows.Forms.Label lblTenMonHoc;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblTenNhom;
        private Guna.UI2.WinForms.Guna2Button btnJoin;
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
