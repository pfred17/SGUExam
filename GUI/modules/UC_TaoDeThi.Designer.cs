using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    partial class UC_TaoDeThi
    {
        private Guna2Panel panelMain;
        private Guna2Panel panelConfig;
        private Guna2TextBox txtTenDe;
        private Guna2DateTimePicker dtpTu, dtpDen;
        private Guna2NumericUpDown numThoiGianLamBai, numCanhBao, numDe, numTrungBinh, numKho;
        private Guna2ComboBox cbNhomHocPhan;
        private CheckedListBox clbChuong;
        private Guna2Button btnTaoDe;

        // Cấu hình
        private Guna2ToggleSwitch swTuDongLay, swXemDiem, swXemDapAn, swXemBaiLam, swDaoCauHoi, swDaoDapAn, swTuDongNop, swDeLuyenTap, swTinhDiem;

        private void InitializeComponent()
        {
            // Main panel (trái)
            panelMain = new Guna2Panel
            {
                Size = new Size(800, 600),
                Location = new Point(30, 30),
                BorderRadius = 8,
                FillColor = Color.White
            };

            // Tên đề
            txtTenDe = new Guna2TextBox
            {
                PlaceholderText = "Nhập tên đề kiểm tra",
                Location = new Point(30, 40),
                Width = 400,
                BorderRadius = 6
            };
            panelMain.Controls.Add(new Label { Text = "Tên đề kiểm tra", Location = new Point(30, 15), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            panelMain.Controls.Add(txtTenDe);

            // Thời gian bắt đầu
            panelMain.Controls.Add(new Label { Text = "Thời gian bắt đầu", Location = new Point(30, 90), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            dtpTu = new Guna2DateTimePicker { Location = new Point(30, 115), Width = 180, BorderRadius = 6, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
            dtpDen = new Guna2DateTimePicker { Location = new Point(230, 115), Width = 180, BorderRadius = 6, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
            panelMain.Controls.Add(dtpTu);
            panelMain.Controls.Add(dtpDen);

            // Thời gian làm bài
            panelMain.Controls.Add(new Label { Text = "Thời gian làm bài", Location = new Point(30, 165), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            numThoiGianLamBai = new Guna2NumericUpDown { Location = new Point(30, 190), Width = 100, BorderRadius = 6, Minimum = 1, Maximum = 300, Value = 45 };
            panelMain.Controls.Add(numThoiGianLamBai);
            panelMain.Controls.Add(new Label { Text = "phút", Location = new Point(140, 195), Font = new Font("Segoe UI", 10) });

            // Cảnh báo nếu làm dưới
            panelMain.Controls.Add(new Label { Text = "Cảnh báo nếu làm dưới", Location = new Point(30, 230), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            numCanhBao = new Guna2NumericUpDown { Location = new Point(30, 255), Width = 100, BorderRadius = 6, Minimum = 1, Maximum = 60, Value = 1 };
            panelMain.Controls.Add(numCanhBao);
            panelMain.Controls.Add(new Label { Text = "phút", Location = new Point(140, 260), Font = new Font("Segoe UI", 10) });
            panelMain.Controls.Add(new Label { Text = "Nếu sinh viên hoàn thành bài thi dưới số phút này, hệ thống sẽ đánh dấu là bất thường.", Location = new Point(30, 285), Font = new Font("Segoe UI", 8), ForeColor = Color.Gray, Width = 400 });

            // Giao cho
            panelMain.Controls.Add(new Label { Text = "Giao cho", Location = new Point(30, 320), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            cbNhomHocPhan = new Guna2ComboBox { Location = new Point(30, 345), Width = 350, BorderRadius = 6, DropDownStyle = ComboBoxStyle.DropDownList };
            panelMain.Controls.Add(cbNhomHocPhan);

            // Chương
            panelMain.Controls.Add(new Label { Text = "Chương", Location = new Point(30, 390), Font = new Font("Segoe UI", 10, FontStyle.Bold) });
            clbChuong = new CheckedListBox { Location = new Point(30, 415), Width = 350, Height = 60 };
            panelMain.Controls.Add(clbChuong);

            // Số câu
            panelMain.Controls.Add(new Label { Text = "Số câu dễ", Location = new Point(30, 485), Font = new Font("Segoe UI", 10) });
            numDe = new Guna2NumericUpDown { Location = new Point(110, 480), Width = 60, BorderRadius = 6, Minimum = 0, Maximum = 100, Value = 0 };
            panelMain.Controls.Add(numDe);

            panelMain.Controls.Add(new Label { Text = "Số câu trung bình", Location = new Point(190, 485), Font = new Font("Segoe UI", 10) });
            numTrungBinh = new Guna2NumericUpDown { Location = new Point(320, 480), Width = 60, BorderRadius = 6, Minimum = 0, Maximum = 100, Value = 0 };
            panelMain.Controls.Add(numTrungBinh);

            panelMain.Controls.Add(new Label { Text = "Số câu khó", Location = new Point(400, 485), Font = new Font("Segoe UI", 10) });
            numKho = new Guna2NumericUpDown { Location = new Point(480, 480), Width = 60, BorderRadius = 6, Minimum = 0, Maximum = 100, Value = 0 };
            panelMain.Controls.Add(numKho);

            // Nút tạo đề
            btnTaoDe = new Guna2Button
            {
                Text = "+ TẠO ĐỀ",
                Location = new Point(30, 540),
                Width = 180,
                Height = 40,
                BorderRadius = 8,
                FillColor = Color.FromArgb(55, 123, 255),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White
            };
            panelMain.Controls.Add(btnTaoDe);

            // Panel cấu hình (phải)
            panelConfig = new Guna2Panel
            {
                Size = new Size(300, 600),
                Location = new Point(850, 30),
                BorderRadius = 8,
                FillColor = Color.White
            };
            panelConfig.Controls.Add(new Label { Text = "CẤU HÌNH", Location = new Point(20, 20), Font = new Font("Segoe UI", 12, FontStyle.Bold) });

            int y = 60;
            swTuDongLay = AddSwitch(panelConfig, "Tự động lấy từ ngân hàng đề", ref y);
            swXemDiem = AddSwitch(panelConfig, "Xem điểm sau khi thi xong", ref y);
            swXemDapAn = AddSwitch(panelConfig, "Xem đáp án khi thi xong", ref y);
            swXemBaiLam = AddSwitch(panelConfig, "Xem bài làm khi thi xong", ref y);
            swDaoCauHoi = AddSwitch(panelConfig, "Đảo câu hỏi", ref y);
            swDaoDapAn = AddSwitch(panelConfig, "Đảo đáp án", ref y);
            swTuDongNop = AddSwitch(panelConfig, "Tự động nộp bài khi chuyển tab", ref y);
            swDeLuyenTap = AddSwitch(panelConfig, "Đề luyện tập", ref y);
            swTinhDiem = AddSwitch(panelConfig, "Tính điểm", ref y);

            // Add panels vào UC
            this.Controls.Add(panelMain);
            this.Controls.Add(panelConfig);
            this.Size = new Size(1200, 660);
        }

        private Guna2ToggleSwitch AddSwitch(Guna2Panel panel, string text, ref int y)
        {
            var sw = new Guna2ToggleSwitch
            {
                Location = new Point(20, y),
                Width = 40,
                Height = 22
            };
            var lbl = new Label
            {
                Text = text,
                Location = new Point(70, y + 2),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };
            panel.Controls.Add(sw);
            panel.Controls.Add(lbl);
            y += 38;
            return sw;
        }
    }
}
