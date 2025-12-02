namespace GUI.Forms.nhomhocphan
{
    partial class UC_DeThiUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabMain = new Guna.UI2.WinForms.Guna2TabControl();
            tabKiemTra = new TabPage();
            tabLuyenTap = new TabPage();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            lblTenNhom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            tabMain.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMain.Controls.Add(tabKiemTra);
            tabMain.Controls.Add(tabLuyenTap);
            tabMain.ItemSize = new Size(247, 40);
            tabMain.Location = new Point(0, 45);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(500, 608);
            tabMain.TabButtonHoverState.BorderColor = Color.Empty;
            tabMain.TabButtonHoverState.FillColor = Color.DodgerBlue;
            tabMain.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tabMain.TabButtonHoverState.ForeColor = Color.White;
            tabMain.TabButtonHoverState.InnerColor = Color.DodgerBlue;
            tabMain.TabButtonIdleState.BorderColor = Color.Empty;
            tabMain.TabButtonIdleState.FillColor = Color.FromArgb(41, 58, 81);
            tabMain.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tabMain.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tabMain.TabButtonIdleState.InnerColor = Color.FromArgb(41, 58, 81);
            tabMain.TabButtonSelectedState.BorderColor = Color.Empty;
            tabMain.TabButtonSelectedState.FillColor = Color.FromArgb(41, 58, 81);
            tabMain.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tabMain.TabButtonSelectedState.ForeColor = Color.White;
            tabMain.TabButtonSelectedState.InnerColor = Color.DodgerBlue;
            tabMain.TabButtonSize = new Size(247, 40);
            tabMain.TabIndex = 0;
            tabMain.TabMenuBackColor = Color.FromArgb(41, 58, 81);
            tabMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabKiemTra
            // 
            tabKiemTra.Location = new Point(4, 44);
            tabKiemTra.Name = "tabKiemTra";
            tabKiemTra.Size = new Size(492, 560);
            tabKiemTra.TabIndex = 0;
            tabKiemTra.Text = "Đề Kiểm Tra";
            // 
            // tabLuyenTap
            // 
            tabLuyenTap.Location = new Point(4, 44);
            tabLuyenTap.Name = "tabLuyenTap";
            tabLuyenTap.Size = new Size(492, 560);
            tabLuyenTap.TabIndex = 1;
            tabLuyenTap.Text = "Đề Luyện Tập";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Cursor = Cursors.Hand;
            btnBack.CustomizableEdges = customizableEdges1;
            btnBack.FillColor = Color.Transparent;
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = Color.Black;
            btnBack.Location = new Point(455, 5);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBack.Size = new Size(40, 40);
            btnBack.TabIndex = 2;
            btnBack.Text = "X";
            btnBack.Click += btnBack_Click;
            // 
            // lblTenNhom
            // 
            lblTenNhom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTenNhom.BackColor = Color.Transparent;
            lblTenNhom.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTenNhom.ForeColor = Color.FromArgb(30, 30, 45);
            lblTenNhom.Location = new Point(0, 3);
            lblTenNhom.Name = "lblTenNhom";
            lblTenNhom.Size = new Size(317, 33);
            lblTenNhom.TabIndex = 3;
            lblTenNhom.Text = "Lập Trình Windows - Nhóm 1 ";
            lblTenNhom.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // UC_DeThiUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTenNhom);
            Controls.Add(tabMain);
            Controls.Add(btnBack);
            Name = "UC_DeThiUser";
            Size = new Size(500, 653);
            tabMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tabMain;
        private TabPage tabKiemTra;
        private TabPage tabLuyenTap;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenNhom;
    }
}