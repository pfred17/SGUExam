using BLL;
using DTO;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_DeThi : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly DeThiBLL deThiBLL = new DeThiBLL();

        public UC_DeThi(string userId)
        {
            _userId = userId;
            InitializeComponent();
            cbTrangThai.SelectedIndexChanged += (s, e) => LoadDeThi();
            txtSearch.TextChanged += (s, e) => LoadDeThi();
            LoadDeThi();
        }

        private void LoadDeThi()
        {
            flowDeThi.Controls.Clear();
            var danhSachDeThi = deThiBLL.GetAllWithNhomHocPhan();

            // Lấy danh sách nhóm học phần của sinh viên
            var nhomIds = new ChiTietNhomHocPhanBLL().GetNhomHocPhanIdsByUser(_userId);

            // Chỉ lấy đề thi mà sinh viên thuộc ít nhất một nhóm học phần của đề đó
            danhSachDeThi = danhSachDeThi
                .Where(deThi => deThi.NhomHocPhanIds != null && deThi.NhomHocPhanIds.Any(id => nhomIds.Contains(id)))
                .ToList();

            // Lọc trạng thái
            int trangThai = cbTrangThai.SelectedIndex; // 0: tất cả, 1: chưa mở, 2: chưa làm, 3: hoàn thành, 4: quá hạn
            if (trangThai > 0)
                danhSachDeThi = danhSachDeThi.Where(x => x.TrangThai == trangThai).ToList();

            // Tìm kiếm
            string keyword = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
                danhSachDeThi = danhSachDeThi.Where(x =>
                    x.TenDe.ToLower().Contains(keyword) ||
                    (x.TenNhomHocPhan?.ToLower().Contains(keyword) ?? false)
                ).ToList();

            foreach (var deThi in danhSachDeThi)
            {
                var card = CreateDeThiCard(deThi);
                flowDeThi.Controls.Add(card);
            }
        }


        private Control CreateDeThiCard(DeThiDTO deThi)
        {
            var card = new Guna2Panel
            {
                Width = 1080,
                Height = 130,
                BorderRadius = 8,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 0, 12),
                ShadowDecoration = { Enabled = true, Depth = 2 }
            };

            // Tiêu đề đề thi
            var lblTitle = new Label
            {
                Text = deThi.TenDe,
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Location = new Point(20, 12),
                AutoSize = true
            };

            // Nhóm học phần
            var lblNhom = new Label
            {
                Text = $"🧑‍🎓 {deThi.TenNhomHocPhan}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(22, 52),
                AutoSize = true
            };

            // Thời gian
            var lblTG = new Label
            {
                Text = $"🕒 {deThi.ThoiGianBatDau:HH:mm dd/MM/yyyy} - {deThi.ThoiGianKetThuc:HH:mm dd/MM/yyyy}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(22, 75),
                AutoSize = true
            };

            // Panel chứa nút
            var buttonPanel = new FlowLayoutPanel
            {
                Location = new Point(card.Width - 290, 40),
                Size = new Size(300, 36),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            // Nút trạng thái
            var statusText = GetTrangThaiText(deThi);
            var btnStatus = new Guna2Button
            {
                Text = statusText,
                FillColor = GetTrangThaiColor(statusText),
                ForeColor = Color.White,
                BorderRadius = 8,
                Width = 110,
                Height = 36,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0)
            };

            // Nút xem chi tiết
            var btnView = new Guna2Button
            {
                Text = "Xem chi tiết",
                BorderRadius = 8,
                Width = 140,
                Height = 36,
                FillColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                Tag = deThi
            };
            btnView.Click += (s, e) => XemChiTiet(deThi);

            buttonPanel.Controls.Add(btnStatus);
            buttonPanel.Controls.Add(btnView);

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblNhom);
            card.Controls.Add(lblTG);
            card.Controls.Add(buttonPanel);

            return card;
        }

        // Hàm lấy text trạng thái
        private string GetTrangThaiText(DeThiDTO deThi)
        {
            var now = DateTime.Now;
            if (deThi.ThoiGianBatDau != null && now < deThi.ThoiGianBatDau)
                return "Chưa mở";
            if (deThi.ThoiGianBatDau != null && deThi.ThoiGianKetThuc != null &&
                now >= deThi.ThoiGianBatDau && now <= deThi.ThoiGianKetThuc)
                return "Đang thi";
            if (deThi.ThoiGianKetThuc != null && now > deThi.ThoiGianKetThuc)
                return "Kết thúc";
            return "Không xác định";
        }


        // Hàm lấy màu trạng thái
        private Color GetTrangThaiColor(string statusText)
        {
            return statusText switch
            {
                "Chưa mở" => Color.LightGray,
                "Đang thi" => Color.LightBlue,
                "Kết thúc" => Color.FromArgb(120, 144, 156),
                "Đã hủy" => Color.FromArgb(255, 138, 128),
                _ => Color.Gray
            };
        }


        private void XemChiTiet(DeThiDTO deThi)
        {
            var form = new GUI.forms.dethi.ChiTietDeThi(deThi, _userId);

            form.ShowDialog(); // or form.Show() if non-modal is desired
        }

    }
}
