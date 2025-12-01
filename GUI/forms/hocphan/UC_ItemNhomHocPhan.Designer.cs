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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ItemNhomHocPhan));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            panel1 = new Panel();
            lbMonHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbGhiChu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnSetting = new Guna.UI2.WinForms.Guna2Button();
            lbTenNhom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            menuChucNang = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            guna2CustomGradientPanel1.SuspendLayout();
            menuChucNang.SuspendLayout();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BorderRadius = 15;
            guna2CustomGradientPanel1.Controls.Add(panel1);
            guna2CustomGradientPanel1.Controls.Add(lbMonHoc);
            guna2CustomGradientPanel1.Controls.Add(lbGhiChu);
            guna2CustomGradientPanel1.Controls.Add(btnSetting);
            guna2CustomGradientPanel1.Controls.Add(lbTenNhom);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel1.Size = new Size(366, 300);
            guna2CustomGradientPanel1.TabIndex = 0;
            guna2CustomGradientPanel1.Paint += guna2CustomGradientPanel1_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlText;
            panel1.Location = new Point(3, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 2);
            panel1.TabIndex = 2;
            // 
            // lbMonHoc
            // 
            lbMonHoc.BackColor = Color.Transparent;
            lbMonHoc.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMonHoc.Location = new Point(19, 19);
            lbMonHoc.Name = "lbMonHoc";
            lbMonHoc.Size = new Size(101, 32);
            lbMonHoc.TabIndex = 0;
            lbMonHoc.Text = "lbMonhoc";
            // 
            // lbGhiChu
            // 
            lbGhiChu.BackColor = Color.Transparent;
            lbGhiChu.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGhiChu.Location = new Point(19, 202);
            lbGhiChu.Name = "lbGhiChu";
            lbGhiChu.Size = new Size(91, 32);
            lbGhiChu.TabIndex = 0;
            lbGhiChu.Text = "lbGhiChu";
            lbGhiChu.Click += lbGhiChu_Click;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = SystemColors.ButtonFace;
            btnSetting.BorderRadius = 3;
            btnSetting.CustomizableEdges = customizableEdges1;
            btnSetting.DisabledState.BorderColor = Color.DarkGray;
            btnSetting.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSetting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSetting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSetting.FillColor = Color.White;
            btnSetting.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.White;
            btnSetting.Image = (Image)resources.GetObject("btnSetting.Image");
            btnSetting.ImageSize = new Size(30, 30);
            btnSetting.Location = new Point(302, 70);
            btnSetting.Name = "btnSetting";
            btnSetting.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSetting.Size = new Size(49, 51);
            btnSetting.TabIndex = 1;
            btnSetting.Click += btnSetting_Click;
            // 
            // lbTenNhom
            // 
            lbTenNhom.BackColor = Color.Transparent;
            lbTenNhom.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTenNhom.Location = new Point(19, 109);
            lbTenNhom.Name = "lbTenNhom";
            lbTenNhom.Size = new Size(117, 32);
            lbTenNhom.TabIndex = 0;
            lbTenNhom.Text = "lbTenNhom";
            // 
            // menuChucNang
            // 
            menuChucNang.ImageScalingSize = new Size(24, 24);
            menuChucNang.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });
            menuChucNang.Name = "contextMenuStrip1";
            menuChucNang.Size = new Size(287, 228);
            menuChucNang.Opening += menuChucNang_Opening;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(286, 32);
            toolStripMenuItem1.Text = "Danh sách sinh viên";
            toolStripMenuItem1.Click += menuXemSinhVien_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(286, 32);
            toolStripMenuItem2.Text = "Danh sách đề thi";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(286, 32);
            toolStripMenuItem3.Text = "Danh sách mã điểm danh";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(286, 32);
            toolStripMenuItem4.Text = "Sửa thông tin";
            toolStripMenuItem4.Click += menuSua_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(286, 32);
            toolStripMenuItem5.Text = "Tạo mã QR điểm danh";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(286, 32);
            toolStripMenuItem6.Text = "Ẩn nhóm";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(286, 32);
            toolStripMenuItem7.Text = "Xóa nhóm";
            toolStripMenuItem7.Click += menuXoa_Click;
            // 
            // UC_ItemNhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Name = "UC_ItemNhomHocPhan";
            Size = new Size(366, 300);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            menuChucNang.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTenNhom;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private ContextMenuStrip menuChucNang;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMonHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbGhiChu;
        private Panel panel1;
    }
}
