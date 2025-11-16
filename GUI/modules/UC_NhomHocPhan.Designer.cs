namespace GUI.modules
{
    partial class UC_NhomHocPhan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnTiemKiem = new Guna.UI2.WinForms.Guna2Button();
            btnThemUC = new Guna.UI2.WinForms.Guna2Button();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            flowDanhSachNhom = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnTiemKiem
            // 
            btnTiemKiem.BorderRadius = 6;
            btnTiemKiem.CustomizableEdges = customizableEdges7;
            btnTiemKiem.DisabledState.BorderColor = Color.DarkGray;
            btnTiemKiem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTiemKiem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTiemKiem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTiemKiem.Font = new Font("Segoe UI", 9F);
            btnTiemKiem.ForeColor = Color.White;
            btnTiemKiem.Location = new Point(29, 45);
            btnTiemKiem.Name = "btnTiemKiem";
            btnTiemKiem.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnTiemKiem.Size = new Size(179, 50);
            btnTiemKiem.TabIndex = 2;
            btnTiemKiem.Text = "Tìm kiếm";
            btnTiemKiem.Click += btnTiemKiem_Click;
            // 
            // btnThemUC
            // 
            btnThemUC.BorderRadius = 6;
            btnThemUC.CustomizableEdges = customizableEdges9;
            btnThemUC.DisabledState.BorderColor = Color.DarkGray;
            btnThemUC.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemUC.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemUC.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemUC.Font = new Font("Segoe UI", 9F);
            btnThemUC.ForeColor = Color.White;
            btnThemUC.Location = new Point(869, 45);
            btnThemUC.Name = "btnThemUC";
            btnThemUC.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnThemUC.Size = new Size(179, 50);
            btnThemUC.TabIndex = 4;
            btnThemUC.Text = "Thêm";
            btnThemUC.Click += btnThem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.CustomizableEdges = customizableEdges11;
            txtTimKiem.DefaultText = "Tìm kiếm...";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Location = new Point(227, 45);
            txtTimKiem.Margin = new Padding(6, 8, 6, 8);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtTimKiem.Size = new Size(326, 50);
            txtTimKiem.TabIndex = 6;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // flowDanhSachNhom
            // 
            flowDanhSachNhom.AutoScroll = true;
            flowDanhSachNhom.Location = new Point(29, 179);
            flowDanhSachNhom.Name = "flowDanhSachNhom";
            flowDanhSachNhom.Size = new Size(1070, 531);
            flowDanhSachNhom.TabIndex = 7;
            // 
            // UC_NhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowDanhSachNhom);
            Controls.Add(txtTimKiem);
            Controls.Add(btnThemUC);
            Controls.Add(btnTiemKiem);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UC_NhomHocPhan";
            Size = new Size(1120, 730);
            Load += UC_NhomHocPhan_Load;
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnTiemKiem;
        private Guna.UI2.WinForms.Guna2Button btnThemUC;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhomHocPhan;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridViewTextBoxColumn dgvMaNhoms;
        private DataGridViewTextBoxColumn dgvMaMon;
        private DataGridViewTextBoxColumn dgvTenNhom;
        private DataGridViewTextBoxColumn dgvHocKy;
        private DataGridViewTextBoxColumn dgvNamHoc;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private FlowLayoutPanel flowDanhSachNhom;
    }
}
