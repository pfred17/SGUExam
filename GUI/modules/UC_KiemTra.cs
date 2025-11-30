using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DTO;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    public partial class UC_KiemTra : UserControl
    {
        private readonly DeThiBLL deThiBLL = new DeThiBLL();
        private readonly string _userId;

        public UC_KiemTra(string userId)
        {
            InitializeComponent();
            _userId = userId;

            cbLoai.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            btnTaoDeThi.Click += BtnTaoDeThi_Click; // Gắn sự kiện

            LoadDeThi();
        }

        private void LoadDeThi()
        {
            flowDeThi.Controls.Clear();
            List<DeThiDTO> danhSachDeThi = deThiBLL.GetAll();

            foreach (var deThi in danhSachDeThi)
            {
                var card = CreateDeThiCard(deThi);
                flowDeThi.Controls.Add(card);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna2Button;
            var deThi = btn.Tag as DeThiDTO;

            // Tìm MainForm cha và panelMain
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                var uc = new UC_ChiTietKiemTra(deThi.MaDe);
                var panelMain = mainForm.Controls["panelMain"];
                if (panelMain is Panel p)
                {
                    p.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    p.Controls.Add(uc);
                }
            }
        }
        private void BtnTaoDeThi_Click(object sender, EventArgs e)
        {
            // Tìm MainForm cha và panelMain
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                var uc = new UC_TaoDeThi();
                var panelMain = mainForm.Controls["panelMain"];
                if (panelMain is Panel p)
                {
                    p.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    p.Controls.Add(uc);
                }
            }
        }


        private Control CreateDeThiCard(DeThiDTO deThi)
        {
            var card = new Guna2Panel
            {
                Width = 1100,
                Height = 130,
                BorderRadius = 10,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 0, 18),
                ShadowDecoration = { Enabled = true, Depth = 4 }
            };

            // ===== TIÊU ĐỀ =====
            var lblTitle = new Label
            {
                Text = deThi.TenDe,
                Font = new Font("Segoe UI", 17, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };

            // ===== MÔ TẢ =====
            var lblMoTa = new Label
            {
                Text = "Giao cho học phần Lập trình web và ứng dụng - NH2025 - HK1",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(22, 55),
                AutoSize = true
            };

            // ===== THỜI GIAN =====
            var lblTG = new Label
            {
                Text = $"Diễn ra từ {deThi.ThoiGianBatDau} đến {deThi.ThoiGianKetThuc}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(22, 75),
                AutoSize = true
            };

            // ===== PANEL CHỨA NÚT =====
            var buttonPanel = new FlowLayoutPanel
            {
                Location = new Point(600, 25),
                Size = new Size(480, 40),  // FIX: rộng hơn, không che nút
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,     // FIX: không xuống hàng
                BackColor = Color.Transparent
            };

            // ===== NÚT TRẠNG THÁI =====
            var btnStatus = new Guna2Button
            {
                Text = deThi.TrangThai == 1 ? "Đang mở" : "Đã đóng",
                FillColor = deThi.TrangThai == 1 ? Color.FromArgb(200, 230, 255) : Color.FromArgb(255, 230, 230),
                ForeColor = deThi.TrangThai == 1 ? Color.FromArgb(21, 101, 192) : Color.FromArgb(198, 40, 40),
                BorderRadius = 10,
                Width = 100,
                Height = 36,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0)
            };

            // ===== NÚT XEM =====
            var btnView = new Guna2Button
            {
                Text = "👁 Xem chi tiết",
                BorderRadius = 10,
                Width = 150,
                Height = 36,
                FillColor = Color.FromArgb(232, 245, 233),
                ForeColor = Color.FromArgb(46, 125, 50),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                Tag = deThi
            };
            btnView.Click += BtnView_Click;

            // ===== NÚT CHỈNH SỬA =====
            var btnEdit = new Guna2Button
            {
                Text = "🛠 Chỉnh sửa",
                BorderRadius = 10,
                Width = 130,
                Height = 36,
                FillColor = Color.FromArgb(227, 242, 253),
                ForeColor = Color.FromArgb(21, 101, 192),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                Tag = deThi
            };
            //btnEdit.Click += BtnEdit_Click;

            // ===== NÚT XOÁ =====
            var btnDelete = new Guna2Button
            {
                Text = "✖",
                BorderRadius = 10,
                Width = 50,
                Height = 36,
                FillColor = Color.FromArgb(255, 235, 238),
                ForeColor = Color.FromArgb(198, 40, 40),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                Tag = deThi
            };
            //btnDelete.Click += BtnDelete_Click;

            // Add nút vào panel
            buttonPanel.Controls.Add(btnStatus);
            buttonPanel.Controls.Add(btnView);
            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);

            // Add tất cả control
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMoTa);
            card.Controls.Add(lblTG);
            card.Controls.Add(buttonPanel);

            return card;
        }

        // ===================== EVENT HANDLER ======================

        //private void BtnView_Click(object sender, EventArgs e)
        //{
        //    var btn = sender as Guna2Button;
        //    var deThi = btn.Tag as DeThiDTO;

        //    MessageBox.Show($"Xem chi tiết đề: {deThi.TenDe}\nID: {deThi.MaDe}");
        //}

        //private void BtnEdit_Click(object sender, EventArgs e)
        //{
        //    var btn = sender as Guna2Button;
        //    var deThi = btn.Tag as DeThiDTO;

        //    MessageBox.Show($"Chỉnh sửa đề: {deThi.TenDe}");
        //}

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    var btn = sender as Guna2Button;
        //    var deThi = btn.Tag as DeThiDTO;

        //    if (MessageBox.Show($"Bạn có chắc muốn xoá đề '{deThi.TenDe}'?",
        //        "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        deThiBLL.Delete(deThi.MaDe);
        //        LoadDeThi();
        //    }
        //}
    }
}
