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
        private Guna2ComboBox cbLoai;
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
            this.components = new Container();
            this.rootPanel = new Guna2Panel();
            this.filterPanel = new Guna2Panel();
            this.cbLoai = new Guna2ComboBox();
            this.txtSearch = new Guna2TextBox();
            this.cbTrangThai = new Guna2ComboBox();
            this.btnTaoDeThi = new Guna2Button();
            this.flowDeThi = new FlowLayoutPanel();

            // Root Panel
            this.rootPanel.Dock = DockStyle.Fill;
            this.rootPanel.FillColor = Color.FromArgb(248, 250, 255);
            this.rootPanel.Controls.Add(this.flowDeThi);
            this.rootPanel.Controls.Add(this.filterPanel);

            // Filter Panel
            this.filterPanel.Dock = DockStyle.Top;
            this.filterPanel.Height = 70;
            this.filterPanel.ShadowDecoration.Enabled = true;
            this.filterPanel.ShadowDecoration.Depth = 5;
            this.filterPanel.Padding = new Padding(15);
            this.filterPanel.FillColor = Color.White;
            this.filterPanel.BorderRadius = 8;

            // Combo loại
            this.cbLoai.BorderRadius = 8;
            this.cbLoai.Width = 150;
            this.cbLoai.Location = new Point(10, 18);
            this.cbLoai.Items.AddRange(new object[] { "Tất cả", "Học kì", "Giữa kì", "Kiểm tra" });

            // Search
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.PlaceholderText = "Tìm kiếm đề thi...";
            this.txtSearch.Width = 330;
            this.txtSearch.Height = 36;
            this.txtSearch.Location = new Point(170, 18);

            // Trạng thái
            this.cbTrangThai.BorderRadius = 8;
            this.cbTrangThai.Width = 150;
            this.cbTrangThai.Location = new Point(520, 18);
            this.cbTrangThai.Items.AddRange(new object[] { "Tất cả", "Đã đóng", "Đang mở" });

            // Nút tạo đề thi
            this.btnTaoDeThi.Text = "+  TẠO ĐỀ THI";
            this.btnTaoDeThi.BorderRadius = 8;
            this.btnTaoDeThi.Width = 160;
            this.btnTaoDeThi.Location = new Point(900, 15);
            this.btnTaoDeThi.FillColor = Color.FromArgb(55, 123, 255);
            this.btnTaoDeThi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnTaoDeThi.ForeColor = Color.White;

            // Add controls vào filter
            this.filterPanel.Controls.Add(this.cbLoai);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.cbTrangThai);
            this.filterPanel.Controls.Add(this.btnTaoDeThi);

            // Flow panel danh sách đề thi
            this.flowDeThi.Dock = DockStyle.Fill;
            this.flowDeThi.AutoScroll = true;
            this.flowDeThi.Padding = new Padding(20);
            this.flowDeThi.BackColor = Color.FromArgb(245, 248, 250);
            this.flowDeThi.FlowDirection = FlowDirection.TopDown;
            this.flowDeThi.WrapContents = false;

            // UC
            this.Controls.Add(this.rootPanel);
            this.Size = new Size(1100, 731);
        }


        #endregion
    }
}
