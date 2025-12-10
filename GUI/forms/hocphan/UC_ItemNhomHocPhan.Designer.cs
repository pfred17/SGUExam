namespace GUI.modules
{
    partial class UC_ItemNhomHocPhan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            menuChucNang = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            btnSetting = new Guna.UI2.WinForms.Guna2Button();
            lbTenNhom1 = new Label();
            btnNamHocHK = new Guna.UI2.WinForms.Guna2Button();
            btnSiSo = new Guna.UI2.WinForms.Guna2Button();
            lbGhiChu1 = new Label();
            lbMonHoc1 = new Label();
            lbTenNhom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbGhiChu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbMonHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbSiSo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            menuChucNang.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuChucNang
            // 
            menuChucNang.ImageScalingSize = new Size(24, 24);
            menuChucNang.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem4, toolStripMenuItem7 });
            menuChucNang.Name = "contextMenuStrip1";
            menuChucNang.Size = new Size(208, 100);
            menuChucNang.Opening += menuChucNang_Opening;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(207, 24);
            toolStripMenuItem1.Text = "Danh sách sinh viên";
            toolStripMenuItem1.Click += menuXemSinhVien_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(207, 24);
            toolStripMenuItem2.Text = "Danh sách đề thi";
            toolStripMenuItem2.Click += menuDeThi_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(207, 24);
            toolStripMenuItem4.Text = "Sửa thông tin";
            toolStripMenuItem4.Click += menuSua_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(207, 24);
            toolStripMenuItem7.Text = "Xóa nhóm";
            toolStripMenuItem7.Click += menuXoa_Click;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BorderRadius = 6;
            guna2CustomGradientPanel1.Controls.Add(guna2Separator1);
            guna2CustomGradientPanel1.Controls.Add(btnSetting);
            guna2CustomGradientPanel1.Controls.Add(lbTenNhom1);
            guna2CustomGradientPanel1.Controls.Add(btnNamHocHK);
            guna2CustomGradientPanel1.Controls.Add(btnSiSo);
            guna2CustomGradientPanel1.Controls.Add(lbGhiChu1);
            guna2CustomGradientPanel1.Controls.Add(lbMonHoc1);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges7;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Margin = new Padding(2);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2CustomGradientPanel1.Size = new Size(339, 240);
            guna2CustomGradientPanel1.TabIndex = 0;
            guna2CustomGradientPanel1.Paint += guna2CustomGradientPanel1_Paint;
            // 
            // guna2Separator1
            // 
            guna2Separator1.BackColor = Color.Transparent;
            guna2Separator1.Location = new Point(8, 50);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(317, 16);
            guna2Separator1.TabIndex = 11;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.Transparent;
            btnSetting.BorderColor = Color.Transparent;
            btnSetting.BorderRadius = 3;
            btnSetting.Cursor = Cursors.Hand;
            btnSetting.CustomizableEdges = customizableEdges1;
            btnSetting.DisabledState.BorderColor = Color.DarkGray;
            btnSetting.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSetting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSetting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSetting.FillColor = Color.Transparent;
            btnSetting.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.Transparent;
            btnSetting.Image = Properties.Resources.icon_phanquyencaidat;
            btnSetting.ImageSize = new Size(25, 25);
            btnSetting.Location = new Point(286, 15);
            btnSetting.Margin = new Padding(2);
            btnSetting.Name = "btnSetting";
            btnSetting.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSetting.Size = new Size(39, 36);
            btnSetting.TabIndex = 1;
            btnSetting.Click += btnSetting_Click;
            // 
            // lbTenNhom1
            // 
            lbTenNhom1.BackColor = Color.Transparent;
            lbTenNhom1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTenNhom1.ForeColor = Color.FromArgb(6, 101, 208);
            lbTenNhom1.ImageAlign = ContentAlignment.MiddleLeft;
            lbTenNhom1.Location = new Point(8, 17);
            lbTenNhom1.Name = "lbTenNhom1";
            lbTenNhom1.Size = new Size(254, 32);
            lbTenNhom1.TabIndex = 3;
            lbTenNhom1.Text = "lbTenNhom";
            lbTenNhom1.TextAlign = ContentAlignment.MiddleLeft;
            lbTenNhom1.Click += lbTenNhom1_Click;
            // 
            // btnNamHocHK
            // 
            btnNamHocHK.BackColor = Color.Transparent;
            btnNamHocHK.BorderColor = Color.FromArgb(6, 101, 208);
            btnNamHocHK.BorderRadius = 8;
            btnNamHocHK.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnNamHocHK.BorderThickness = 1;
            btnNamHocHK.CustomizableEdges = customizableEdges3;
            btnNamHocHK.DisabledState.BorderColor = Color.DarkGray;
            btnNamHocHK.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNamHocHK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNamHocHK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNamHocHK.FillColor = Color.Transparent;
            btnNamHocHK.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNamHocHK.ForeColor = Color.FromArgb(6, 101, 208);
            btnNamHocHK.HoverState.BorderColor = Color.FromArgb(6, 101, 208);
            btnNamHocHK.HoverState.FillColor = Color.Transparent;
            btnNamHocHK.HoverState.ForeColor = Color.FromArgb(6, 101, 208);
            btnNamHocHK.Location = new Point(88, 179);
            btnNamHocHK.Name = "btnNamHocHK";
            btnNamHocHK.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnNamHocHK.Size = new Size(149, 35);
            btnNamHocHK.TabIndex = 10;
            btnNamHocHK.Text = "HK1 - 2024-2026";
            // 
            // btnSiSo
            // 
            btnSiSo.BackColor = Color.Transparent;
            btnSiSo.BorderColor = Color.FromArgb(6, 101, 208);
            btnSiSo.BorderRadius = 8;
            btnSiSo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnSiSo.BorderThickness = 1;
            btnSiSo.CustomizableEdges = customizableEdges5;
            btnSiSo.DisabledState.BorderColor = Color.DarkGray;
            btnSiSo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSiSo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSiSo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSiSo.FillColor = Color.Transparent;
            btnSiSo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSiSo.ForeColor = Color.FromArgb(6, 101, 208);
            btnSiSo.HoverState.BorderColor = Color.FromArgb(6, 101, 208);
            btnSiSo.HoverState.FillColor = Color.Transparent;
            btnSiSo.HoverState.ForeColor = Color.FromArgb(6, 101, 208);
            btnSiSo.Location = new Point(243, 179);
            btnSiSo.Name = "btnSiSo";
            btnSiSo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSiSo.Size = new Size(82, 35);
            btnSiSo.TabIndex = 9;
            btnSiSo.Text = "Sĩ số: 19";
            // 
            // lbGhiChu1
            // 
            lbGhiChu1.BackColor = Color.White;
            lbGhiChu1.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbGhiChu1.Location = new Point(9, 114);
            lbGhiChu1.Name = "lbGhiChu1";
            lbGhiChu1.Size = new Size(316, 45);
            lbGhiChu1.TabIndex = 6;
            lbGhiChu1.Text = "lbGhiChu";
            // 
            // lbMonHoc1
            // 
            lbMonHoc1.BackColor = Color.White;
            lbMonHoc1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMonHoc1.ForeColor = Color.Gray;
            lbMonHoc1.Location = new Point(8, 70);
            lbMonHoc1.Name = "lbMonHoc1";
            lbMonHoc1.Size = new Size(317, 44);
            lbMonHoc1.TabIndex = 4;
            lbMonHoc1.Text = "lbMonHoc";
            // 
            // lbTenNhom
            // 
            lbTenNhom.BackColor = Color.Transparent;
            lbTenNhom.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTenNhom.Location = new Point(15, 24);
            lbTenNhom.Margin = new Padding(2);
            lbTenNhom.MaximumSize = new Size(248, 0);
            lbTenNhom.Name = "lbTenNhom";
            lbTenNhom.Size = new Size(97, 25);
            lbTenNhom.TabIndex = 0;
            lbTenNhom.Text = "lbTenNhom";
            lbTenNhom.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lbGhiChu
            // 
            lbGhiChu.BackColor = Color.Transparent;
            lbGhiChu.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGhiChu.Location = new Point(15, 162);
            lbGhiChu.Margin = new Padding(2);
            lbGhiChu.Name = "lbGhiChu";
            lbGhiChu.Size = new Size(75, 27);
            lbGhiChu.TabIndex = 0;
            lbGhiChu.Text = "lbGhiChu";
            // 
            // lbMonHoc
            // 
            lbMonHoc.BackColor = Color.Transparent;
            lbMonHoc.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMonHoc.Location = new Point(15, 82);
            lbMonHoc.Margin = new Padding(2);
            lbMonHoc.MaximumSize = new Size(256, 0);
            lbMonHoc.Name = "lbMonHoc";
            lbMonHoc.Size = new Size(84, 27);
            lbMonHoc.TabIndex = 0;
            lbMonHoc.Text = "lbMonhoc";
            lbMonHoc.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lbSiSo
            // 
            lbSiSo.BackColor = Color.Transparent;
            lbSiSo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSiSo.Location = new Point(208, 194);
            lbSiSo.Margin = new Padding(2);
            lbSiSo.Name = "lbSiSo";
            lbSiSo.Size = new Size(53, 27);
            lbSiSo.TabIndex = 3;
            lbSiSo.Text = "lbSiSo";
            // 
            // UC_ItemNhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Margin = new Padding(2);
            Name = "UC_ItemNhomHocPhan";
            Size = new Size(339, 240);
            menuChucNang.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTenNhom;
        private ContextMenuStrip menuChucNang;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMonHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbGhiChu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSiSo;
        private Label lbMonHoc1;
        private Label lbGhiChu1;
        private Guna.UI2.WinForms.Guna2Button btnSiSo;
        private Guna.UI2.WinForms.Guna2Button btnNamHocHK;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
        private Label lbTenNhom1;
    }
}