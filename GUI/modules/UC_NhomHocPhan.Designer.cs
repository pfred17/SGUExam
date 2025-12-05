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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnThemUC = new Guna.UI2.WinForms.Guna2Button();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            flowDanhSachNhom = new FlowLayoutPanel();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            flowDanhSachNhom.SuspendLayout();
            SuspendLayout();
            // 
            // btnThemUC
            // 
            btnThemUC.BorderRadius = 6;
            btnThemUC.CustomizableEdges = customizableEdges1;
            btnThemUC.DisabledState.BorderColor = Color.DarkGray;
            btnThemUC.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemUC.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemUC.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemUC.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemUC.ForeColor = Color.White;
            btnThemUC.Location = new Point(898, 18);
            btnThemUC.Name = "btnThemUC";
            btnThemUC.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThemUC.Size = new Size(164, 50);
            btnThemUC.TabIndex = 4;
            btnThemUC.Text = "Thêm";
            btnThemUC.Click += btnThem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.CustomizableEdges = customizableEdges3;
            txtTimKiem.DefaultText = "";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Location = new Point(133, 27);
            txtTimKiem.Margin = new Padding(6, 8, 6, 8);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTimKiem.Size = new Size(367, 41);
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
            flowDanhSachNhom.Controls.Add(richTextBox1);
            flowDanhSachNhom.Location = new Point(0, 95);
            flowDanhSachNhom.Name = "flowDanhSachNhom";
            flowDanhSachNhom.Size = new Size(1120, 635);
            flowDanhSachNhom.TabIndex = 7;
            flowDanhSachNhom.SizeChanged += flowDanhSachNhom_SizeChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(8, 8);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 27);
            label1.Name = "label1";
            label1.Size = new Size(110, 41);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_NhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowDanhSachNhom);
            Controls.Add(label1);
            Controls.Add(txtTimKiem);
            Controls.Add(btnThemUC);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UC_NhomHocPhan";
            Size = new Size(1120, 730);
            Load += UC_NhomHocPhan_Load;
            flowDanhSachNhom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
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
        private RichTextBox richTextBox1;
        private Label label1;
    }
}
