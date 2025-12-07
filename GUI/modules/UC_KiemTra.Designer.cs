using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    partial class UC_KiemTra
    {
        private IContainer components = null;

        private Guna2Panel rootPanel;
        private Guna2Panel filterPanel;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cbTrangThai;
        private Guna2Button btnTaoDeThi;
        private FlowLayoutPanel flowDeThi;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            rootPanel = new Guna2Panel();
            flowDeThi = new FlowLayoutPanel();
            filterPanel = new Guna2Panel();
            txtSearch = new Guna2TextBox();
            cbTrangThai = new Guna2ComboBox();
            btnTaoDeThi = new Guna2Button();
            rootPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.Controls.Add(flowDeThi);
            rootPanel.Controls.Add(filterPanel);
            rootPanel.CustomizableEdges = customizableEdges9;
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.FillColor = Color.FromArgb(248, 250, 255);
            rootPanel.Location = new Point(0, 0);
            rootPanel.Name = "rootPanel";
            rootPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            rootPanel.Size = new Size(1100, 731);
            rootPanel.TabIndex = 0;
            // 
            // flowDeThi
            // 
            flowDeThi.AutoScroll = true;
            flowDeThi.BackColor = Color.FromArgb(245, 248, 250);
            flowDeThi.Dock = DockStyle.Fill;
            flowDeThi.FlowDirection = FlowDirection.TopDown;
            flowDeThi.Location = new Point(0, 70);
            flowDeThi.Name = "flowDeThi";
            flowDeThi.Padding = new Padding(20);
            flowDeThi.Size = new Size(1100, 661);
            flowDeThi.TabIndex = 0;
            flowDeThi.WrapContents = false;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.Transparent;
            filterPanel.BorderRadius = 8;
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cbTrangThai);
            filterPanel.Controls.Add(btnTaoDeThi);
            filterPanel.CustomizableEdges = customizableEdges7;
            filterPanel.Dock = DockStyle.Top;
            filterPanel.FillColor = Color.White;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(15);
            filterPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            filterPanel.ShadowDecoration.Depth = 5;
            filterPanel.ShadowDecoration.Enabled = true;
            filterPanel.Size = new Size(1100, 70);
            filterPanel.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = customizableEdges1;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(18, 18);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm đề thi...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearch.Size = new Size(447, 36);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // cbTrangThai
            // 
            cbTrangThai.BackColor = Color.Transparent;
            cbTrangThai.BorderRadius = 8;
            cbTrangThai.CustomizableEdges = customizableEdges3;
            cbTrangThai.DrawMode = DrawMode.OwnerDrawFixed;
            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThai.FocusedColor = Color.Empty;
            cbTrangThai.Font = new Font("Segoe UI", 10F);
            cbTrangThai.ForeColor = Color.FromArgb(68, 88, 112);
            cbTrangThai.ItemHeight = 30;
            cbTrangThai.Items.AddRange(new object[] { "Tất cả", "Kết thúc", "Đang mở", "Chưa mở" });
            cbTrangThai.Location = new Point(486, 18);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbTrangThai.Size = new Size(150, 36);
            cbTrangThai.TabIndex = 2;
            cbTrangThai.SelectedIndexChanged += CbTrangThai_SelectedIndexChanged;
            // 
            // btnTaoDeThi
            // 
            btnTaoDeThi.BorderRadius = 8;
            btnTaoDeThi.CustomizableEdges = customizableEdges5;
            btnTaoDeThi.FillColor = Color.FromArgb(55, 123, 255);
            btnTaoDeThi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoDeThi.ForeColor = Color.White;
            btnTaoDeThi.Location = new Point(900, 15);
            btnTaoDeThi.Name = "btnTaoDeThi";
            btnTaoDeThi.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTaoDeThi.Size = new Size(160, 45);
            btnTaoDeThi.TabIndex = 3;
            btnTaoDeThi.Text = "+  TẠO ĐỀ THI";
            // 
            // UC_KiemTra
            // 
            Controls.Add(rootPanel);
            Name = "UC_KiemTra";
            Size = new Size(1100, 731);
            rootPanel.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion
    }
}
