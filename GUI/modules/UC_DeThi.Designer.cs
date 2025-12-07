namespace GUI.modules
{
    partial class UC_DeThi
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            cbTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            flowDeThi = new FlowLayoutPanel();
            panelPagination = new Guna.UI2.WinForms.Guna2Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(cbTrangThai);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.CustomizableEdges = customizableEdges5;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelHeader.Size = new Size(1300, 48);
            panelHeader.TabIndex = 0;
            // 
            // cbTrangThai
            // 
            cbTrangThai.BackColor = Color.Transparent;
            cbTrangThai.BorderRadius = 6;
            cbTrangThai.CustomizableEdges = customizableEdges1;
            cbTrangThai.DrawMode = DrawMode.OwnerDrawFixed;
            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThai.FocusedColor = Color.Empty;
            cbTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cbTrangThai.ForeColor = Color.FromArgb(68, 88, 112);
            cbTrangThai.ItemHeight = 30;
            cbTrangThai.Items.AddRange(new object[] { "Tất cả", "Chưa mở", "Chưa làm", "Đã hoàn thành", "Quá hạn" });
            cbTrangThai.Location = new Point(16, 12);
            cbTrangThai.Margin = new Padding(2);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbTrangThai.Size = new Size(161, 36);
            cbTrangThai.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 6;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(191, 12);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm đề thi, tên nhóm học phần...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(429, 36);
            txtSearch.TabIndex = 1;
            // 
            // flowDeThi
            // 
            flowDeThi.AutoScroll = true;
            flowDeThi.BackColor = Color.Transparent;
            flowDeThi.FlowDirection = FlowDirection.TopDown;
            flowDeThi.Location = new Point(28, 64);
            flowDeThi.Margin = new Padding(2);
            flowDeThi.Name = "flowDeThi";
            flowDeThi.Size = new Size(1440, 654);
            flowDeThi.TabIndex = 1;
            flowDeThi.WrapContents = false;
            // 
            // panelPagination
            // 
            panelPagination.BackColor = Color.Transparent;
            panelPagination.CustomizableEdges = customizableEdges7;
            panelPagination.Location = new Point(384, 560);
            panelPagination.Margin = new Padding(2);
            panelPagination.Name = "panelPagination";
            panelPagination.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelPagination.Size = new Size(200, 36);
            panelPagination.TabIndex = 2;
            // 
            // UC_DeThi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelHeader);
            Controls.Add(flowDeThi);
            Controls.Add(panelPagination);
            Margin = new Padding(2);
            Name = "UC_DeThi";
            Size = new Size(1300, 731);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Guna.UI2.WinForms.Guna2ComboBox cbTrangThai;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FlowLayoutPanel flowDeThi;
        private Guna.UI2.WinForms.Guna2Panel panelPagination;
    }
}
