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
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();


        public UC_KiemTra(string userId)
        {
            InitializeComponent();
            _userId = userId;
            loadPermission();
            cbTrangThai.SelectedIndex = 0;
            btnTaoDeThi.Click += BtnTaoDeThi_Click; // Gắn sự kiện
            LoadDeThi();
        }

        private void loadPermission()
        {
            btnTaoDeThi.Visible = _permissionBLL.HasPermission(_userId, 5, "Thêm");
        }

        private void LoadDeThi()
        {
            flowDeThi.Controls.Clear();
            List<DeThiDTO> danhSachDeThi = deThiBLL.GetAll();
            AutoUpdateDeThiStatus(danhSachDeThi);
            // 🔥 Lọc theo từ khóa tìm kiếm
            string keyword = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                danhSachDeThi = danhSachDeThi
                    .Where(x => x.TenDe != null && x.TenDe.ToLower().Contains(keyword))
                    .ToList();
            }

            // Lọc theo trạng thái
            string selectedStatus = cbTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            DateTime now = DateTime.Now;

            switch (selectedStatus)
            {
                case "Nháp":
                    danhSachDeThi = danhSachDeThi.Where(deThi => deThi.TrangThai == 0).ToList();
                    break;
                case "Khóa":
                    danhSachDeThi = danhSachDeThi.Where(deThi => deThi.TrangThai == 4).ToList();
                    break;
                case "Sẵn sàng":
                    danhSachDeThi = danhSachDeThi.Where(deThi => deThi.TrangThai == 1).ToList();
                    break;
                case "Đang thi":
                    danhSachDeThi = danhSachDeThi.Where(deThi => deThi.TrangThai == 2).ToList();
                    break;
                case "Đã thi":
                    danhSachDeThi = danhSachDeThi.Where(deThi => deThi.TrangThai == 3).ToList();
                    break;
            }


            // Tạo thẻ (card)
            foreach (var deThi in danhSachDeThi)
            {
                var card = CreateDeThiCard(deThi);
                flowDeThi.Controls.Add(card);
            }
        }



        private void CbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeThi();
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDeThi();
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
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna2Button;
            var deThi = btn.Tag as DeThiDTO;

            // Tìm MainForm cha và panelMain
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                var uc = new ChinhSuaDeThi(deThi.MaDe);
                var panelMain = mainForm.Controls["panelMain"];
                if (panelMain is Panel p)
                {
                    p.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    p.Controls.Add(uc);
                }
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna2Button;
            var deThi = btn?.Tag as DeThiDTO;
            if (deThi == null) return;

            var confirm = MessageBox.Show(
                $"CẢNH BÁO: Việc xóa đề thi \"{deThi.TenDe}\" sẽ xóa toàn bộ dữ liệu liên quan (bài làm, câu hỏi, cấu hình, nhóm, chương, ...).\n\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận xóa đề thi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool result = deThiBLL.DeleteDeThi(deThi.MaDe);
                if (result)
                {
                    MessageBox.Show("Đã xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeThi(); // Reload the exam list
                }
                else
                {
                    MessageBox.Show("Xóa đề thi thất bại! Không thể xóa toàn bộ dữ liệu liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa đề thi thất bại!\nChi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutoUpdateDeThiStatus(List<DeThiDTO> danhSachDeThi)
        {
            DateTime now = DateTime.Now;
            foreach (var deThi in danhSachDeThi)
            {
                int oldStatus = deThi.TrangThai;
                // Chỉ xử lý nếu đề thi đang ở trạng thái "Sẵn sàng" hoặc "Đang thi"
                if (deThi.TrangThai == 1 && deThi.ThoiGianBatDau != null && now >= deThi.ThoiGianBatDau)
                {
                    deThi.TrangThai = 2; // Đang thi
                    deThiBLL.UpdateDeThiStatus(deThi);
                }
                else if (deThi.TrangThai == 2 && deThi.ThoiGianKetThuc != null && now > deThi.ThoiGianKetThuc)
                {
                    deThi.TrangThai = 3; // Đã thi
                    deThiBLL.UpdateDeThiStatus(deThi);
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

            var deThiFull = deThiBLL.GetFullDetailById(deThi.MaDe);
            var lblMoTa = new Label
            {
                Text = $"Nhóm học phần: {deThiFull.TenNhomHocPhan ?? "Chưa có"}",
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
            string statusText;
            Color statusColor;
            DateTime now = DateTime.Now;
            var btnStatus = new Guna2Button
            {
                BorderRadius = 10,
                Width = 100,
                Height = 36,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                ForeColor = Color.White
            };
            switch (deThi.TrangThai)
            {
                case 0: // Nháp
                    statusText = "Nháp";
                    statusColor = Color.DarkGray;
                    // Thêm sự kiện click xác nhận chuyển trạng thái
                    btnStatus.Cursor = Cursors.Hand;
                    btnStatus.Click += (s, e) =>
                    {
                        var confirm = MessageBox.Show(
                            "Bạn có chắc chắn muốn chuyển trạng thái đề thi này sang 'Sẵn sàng' để mở cho sinh viên?",
                            "Xác nhận chuyển trạng thái",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            // Cập nhật trạng thái sang 1 (Sẵn sàng)
                            deThi.TrangThai = 1;
                            deThiBLL.UpdateDeThiStatus(deThi);
                            // Reload lại danh sách đề thi
                            LoadDeThi();
                        }
                    };
                    break;
                case 4: // Khóa
                    statusText = "Đã khóa";
                    statusColor = Color.FromArgb(120, 120, 120);
                    // Thêm sự kiện click xác nhận mở khóa lại
                    btnStatus.Cursor = Cursors.Hand;
                    btnStatus.Click += (s, e) =>
                    {
                        var confirm = MessageBox.Show(
                            "Bạn có chắc chắn muốn MỞ KHÓA đề thi này để cho phép sinh viên vào thi?",
                            "Xác nhận mở khóa đề thi",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            deThi.TrangThai = 1; // Sẵn sàng
                            deThiBLL.UpdateDeThiStatus(deThi);
                            LoadDeThi();
                        }
                    };
                    break;
                case 2: // Đang thi (luôn hiển thị Đang thi)
                    statusText = "Đang thi";
                    statusColor = Color.LightBlue;
                    break;
                case 3: // Đã thi (luôn hiển thị Đã kết thúc)
                    statusText = "Đã kết thúc";
                    statusColor = Color.FromArgb(120, 144, 156);
                    break;
                case 1: // Sẵn sàng, xét theo thời gian
                    if (deThi.ThoiGianBatDau != null && now < deThi.ThoiGianBatDau)
                    {
                        statusText = "Chưa mở";
                        statusColor = Color.LightGray;
                        // Thêm sự kiện click xác nhận khóa đề
                        btnStatus.Cursor = Cursors.Hand;
                        btnStatus.Click += (s, e) =>
                        {
                            var confirm = MessageBox.Show(
                                "Bạn có chắc chắn muốn KHÓA đề thi này? Sau khi khóa, sinh viên sẽ không thể vào thi cho đến khi mở lại.",
                                "Xác nhận khóa đề thi",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                            if (confirm == DialogResult.Yes)
                            {
                                deThi.TrangThai = 4; // Khóa
                                deThiBLL.UpdateDeThiStatus(deThi);
                                LoadDeThi();
                            }
                        };
                    }
                    else if (deThi.ThoiGianBatDau != null && deThi.ThoiGianKetThuc != null &&
                             now >= deThi.ThoiGianBatDau && now <= deThi.ThoiGianKetThuc)
                    {
                        statusText = "Đang thi";
                        statusColor = Color.LightBlue;
                    }
                    else if (deThi.ThoiGianKetThuc != null && now > deThi.ThoiGianKetThuc)
                    {
                        statusText = "Kết thúc";
                        statusColor = Color.FromArgb(120, 144, 156);
                        btnStatus.Cursor = Cursors.Hand;
                        btnStatus.Click += (s, e) =>
                        {
                            var confirm = MessageBox.Show(
                                "Bạn có chắc chắn muốn KHÓA đề thi này. Sau khi khóa không thể chỉnh sửa?",
                                "Xác nhận mở khóa đề thi",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                            if (confirm == DialogResult.Yes)
                            {
                                deThi.TrangThai = 4;
                                deThiBLL.UpdateDeThiStatus(deThi);
                                LoadDeThi();
                            }
                        };
                    }
                    else
                    {
                        statusText = "Không xác định";
                        statusColor = Color.Gray;
                    }
                    break;
                default:
                    statusText = "Không xác định";
                    statusColor = Color.Gray;
                    break;
            }
            btnStatus.Text = statusText;
            btnStatus.FillColor = statusColor;
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
            btnView.Visible = _permissionBLL.HasPermission(_userId, 5, "Xem");
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
            btnEdit.Visible = _permissionBLL.HasPermission(_userId, 5, "Sửa");
            btnEdit.Click += BtnEdit_Click;

            // ===== NÚT KHÓA/MỞ KHÓA hoặc XOÁ =====
            // ===== NÚT KHÓA/MỞ KHÓA =====
            var btnAction = new Guna2Button
            {
                Text = (deThi.TrangThai == 4) ? "🔓" : "🔒",
                BorderRadius = 10,
                Width = 60,
                Height = 36,
                FillColor = (deThi.TrangThai == 4) ? Color.FromArgb(232, 245, 233) : Color.FromArgb(255, 235, 238),
                ForeColor = (deThi.TrangThai == 4) ? Color.FromArgb(46, 125, 50) : Color.FromArgb(198, 40, 40),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(4, 0, 4, 0),
                Tag = deThi
            };
            btnAction.Visible = _permissionBLL.HasPermission(_userId, 5, "Sửa");
            btnAction.Click += (s, e) =>
            {
                // Chỉ cho phép khóa/mở khóa ở trạng thái 0, 1, 3, 4
                if (deThi.TrangThai == 0 || deThi.TrangThai == 1 || deThi.TrangThai == 3 || deThi.TrangThai == 4)
                {
                    var isUnlock = deThi.TrangThai == 4;
                    var confirm = MessageBox.Show(
                        isUnlock
                            ? "Bạn có chắc chắn muốn MỞ KHÓA đề thi này để cho phép sinh viên vào thi?"
                            : "Bạn có chắc chắn muốn KHÓA đề thi này? Sau khi khóa, sinh viên sẽ không thể vào thi cho đến khi mở lại.",
                        isUnlock ? "Xác nhận mở khóa đề thi" : "Xác nhận khóa đề thi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        deThi.TrangThai = isUnlock ? 1 : 4;
                        deThiBLL.UpdateDeThiStatus(deThi);
                        LoadDeThi();
                    }
                }
                else
                {
                    MessageBox.Show("Đề thi đang ở trạng thái không thể khóa/mở khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Add nút vào panel
            buttonPanel.Controls.Add(btnStatus);
            buttonPanel.Controls.Add(btnView);
            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnAction);


            // Add tất cả control
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMoTa);
            card.Controls.Add(lblTG);
            card.Controls.Add(buttonPanel);

            return card;
        }
    }
}
