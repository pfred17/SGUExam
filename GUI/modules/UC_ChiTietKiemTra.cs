using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.modules
{
    public partial class UC_ChiTietKiemTra : UserControl
    {
        private readonly long _maDe;
        private readonly DeThiBLL _deThiBLL = new DeThiBLL();

        public UC_ChiTietKiemTra(long maDe)
        {
            InitializeComponent();
            _maDe = maDe;
            LoadBangDiem();
            LoadPhanTichKetQua();

        }

        private void LoadBangDiem()
        {
            var bangDiem = _deThiBLL.GetBangDiemByDeThi(_maDe);

            tableBangDiem.Rows.Clear();
            foreach (var item in bangDiem)
            {
                int rowIdx = tableBangDiem.Rows.Add(
                    item.MSSV,
                    item.HoTen,
                    item.Diem,
                    item.ThoiGianVaoThi?.ToString("dd/MM/yyyy HH:mm"),
                    item.ThoiGianNopBai?.ToString("dd/MM/yyyy HH:mm"),
                    item.ThoiGianThi,
                    "Hoạt động"
                );
                // Style cho trạng thái
                var cell = tableBangDiem.Rows[rowIdx].Cells["colTrangThai"];
                cell.Style.ForeColor = Color.FromArgb(0, 153, 0);
                cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void LoadPhanTichKetQua()
        {
            var bangDiem = _deThiBLL.GetBangDiemByDeThi(_maDe);

            int daNop = bangDiem.Count;
            int chuaNop = 0; // Nếu có danh sách sinh viên dự kiến, bạn tính được số này
            int khongThi = 0; // Nếu có danh sách sinh viên dự kiến, bạn tính được số này
            decimal diemTB = bangDiem.Count > 0 ? (decimal)bangDiem.Where(x => x.Diem.HasValue).Average(x => x.Diem.Value) : 0;
            int diemNhoHon1 = bangDiem.Count(x => x.Diem <= 1);
            int diemNhoHon5 = bangDiem.Count(x => x.Diem <= 5);
            int diemLonHon5 = bangDiem.Count(x => x.Diem >= 5);
            decimal diemCaoNhat = bangDiem.Count > 0 ? bangDiem.Max(x => x.Diem ?? 0) : 0;

            // Xóa các card cũ
            flowThongKeCard.Controls.Clear();

            // Thêm card
            flowThongKeCard.Controls.Add(CreateThongKeCard(daNop.ToString(), "Thí sinh đã nộp", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(chuaNop.ToString(), "Thí sinh chưa nộp", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(khongThi.ToString(), "Thí sinh không thi", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemTB.ToString("0.##"), "Điểm trung bình", "🌐"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemNhoHon1.ToString(), "Số thí sinh điểm <= 1", "🗑"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemNhoHon5.ToString(), "Số thí sinh điểm <= 5", "👎"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemLonHon5.ToString(), "Số thí sinh điểm >= 5", "🏅"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemCaoNhat.ToString("0.##"), "Điểm cao nhất", "👥"));

            // Biểu đồ phân bố điểm
            var diemBuckets = new int[11]; // 0-1, 1-2, ..., 9-10
            foreach (var item in bangDiem)
            {
                if (item.Diem.HasValue)
                {
                    int idx = (int)Math.Floor(item.Diem.Value);
                    if (idx < 0) idx = 0;
                    if (idx > 10) idx = 10;
                    diemBuckets[idx]++;
                }
            }
            var series = chartDiemThi.Series["Số lượng sinh viên"];
            series.Points.Clear();
            for (int i = 0; i <= 10; i++)
            {
                string label = i == 10 ? "<= 10" : $"<= {i + 1}";
                series.Points.AddXY(label, diemBuckets[i]);
            }
            chartDiemThi.ChartAreas[0].AxisX.Title = "";
            chartDiemThi.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
            chartDiemThi.Titles.Clear();
            chartDiemThi.Titles.Add("Thống kê điểm thi");
        }

        // Tạo card thống kê
        private Panel CreateThongKeCard(string value, string label, string icon)
        {
            var card = new Panel
            {
                Width = 250,
                Height = 100,
                BackColor = Color.White,
                Margin = new Padding(15, 15, 0, 0),
                BorderStyle = BorderStyle.None
            };
            card.Padding = new Padding(20, 15, 20, 15);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Location = new Point(10, 50),
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 100, 100)
            });
            card.Controls.Add(new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 24, FontStyle.Regular),
                Location = new Point(180, 25),
                AutoSize = true,
                ForeColor = Color.FromArgb(33, 150, 243)
            });
            return card;
        }

    }
}
