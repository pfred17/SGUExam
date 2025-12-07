using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.forms.dethi
{
    public partial class KetQuaBaiThi : Form
    {
        private readonly DeThiCauHinhDTO _cauHinh;

        public KetQuaBaiThi(List<CauHoiDTO> dsCauHoi, int soCauDung, decimal diem, UserDTO user, DeThiCauHinhDTO cauHinh)
        {
            _cauHinh = cauHinh;
            InitializeComponent();
            BuildUI(dsCauHoi, soCauDung, diem, user);
        }

        private void BuildUI(List<CauHoiDTO> dsCauHoi, int soCauDung, decimal diem, UserDTO user)
        {
            this.Text = "Kết quả bài thi";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            var panel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            this.Controls.Add(panel);

            int top = 10;

            // 1. Thông tin người làm bài
            var lblMSSV = new Label { Text = $"MSSV: {user.MSSV}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblMSSV);
            top += 28;

            var lblHoTen = new Label { Text = $"Họ tên: {user.HoTen}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblHoTen);
            top += 28;

            var lblEmail = new Label { Text = $"Email: {user.Email}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblEmail);
            top += 28;

            // 2. Hiển thị điểm
            bool shouldShowScore = _cauHinh.XemDiemSauThi == true || (_cauHinh.XemDapAnSauThi == true && _cauHinh.XemBaiLam == true);

            if (shouldShowScore)
            {
                var lblTongKet = new Label
                {
                    Text = $"Số câu đúng: {soCauDung}/{dsCauHoi.Count}    Điểm: {diem}",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panel.Controls.Add(lblTongKet);
                top += 40;
            }

            // 3. Chỉ xem điểm, không xem chi tiết
            if (_cauHinh.XemDiemSauThi == true && _cauHinh.XemDapAnSauThi == false)
            {
                var lblChiXemDiem = new Label
                {
                    Text = "Bạn chỉ được phép xem thông tin và điểm số.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.OrangeRed,
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panel.Controls.Add(lblChiXemDiem);
                return;
            }

            // 4. Hiển thị chi tiết câu hỏi và đáp án
            if (_cauHinh.XemDapAnSauThi == true)
            {
                bool shouldShowUserChoice = _cauHinh.XemBaiLam == true;
                var dapAnBLL = new BLL.DapAnBLL();

                for (int i = 0; i < dsCauHoi.Count; i++)
                {
                    var cau = dsCauHoi[i];
                    var dapAnList = dapAnBLL.GetByCauHoi(cau.MaCauHoi);

                    // Tìm ID đáp án đúng
                    var dapAnDung = dapAnList.FirstOrDefault(da => da.Dung);
                    long? dapAnDungId = dapAnDung?.MaDapAn;

                    // Tiêu đề câu hỏi
                    var lblCau = new Label
                    {
                        Text = $"Câu {i + 1}: {cau.NoiDung}",
                        Font = new Font("Segoe UI", 13, FontStyle.Bold),
                        Location = new Point(20, top),
                        AutoSize = true,
                        ForeColor = (shouldShowUserChoice && cau.DapAnChon >= 0 && cau.DapAnChon < cau.DapAnIds.Count && cau.DapAnIds[cau.DapAnChon] == dapAnDungId)
                            ? Color.DarkGreen
                            : Color.Black
                    };
                    panel.Controls.Add(lblCau);
                    top += 30;

                    // Hiển thị đáp án
                    for (int j = 0; j < cau.DapAnList.Count; j++)
                    {
                        string prefix = $"{(char)('A' + j)}. ";
                        Color foreColor = Color.Black;
                        Color backColor = Color.White;
                        string suffix = "";

                        bool isDapAnDung = (cau.DapAnIds[j] == dapAnDungId);
                        bool isDapAnChon = (j == cau.DapAnChon);

                        if (isDapAnDung)
                        {
                            foreColor = Color.DarkGreen;
                            suffix = " ✓";
                            if (isDapAnChon && shouldShowUserChoice)
                            {
                                backColor = Color.LightGreen;
                            }
                        }
                        else if (isDapAnChon && shouldShowUserChoice)
                        {
                            backColor = Color.LightCoral;
                            suffix = " ✗";
                        }

                        var lblDapAn = new Label
                        {
                            Text = $"{prefix}{cau.DapAnList[j]}{suffix}",
                            Location = new Point(40, top),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12),
                            ForeColor = foreColor,
                            BackColor = backColor,
                            Padding = new Padding(5)
                        };

                        panel.Controls.Add(lblDapAn);
                        top += 35;
                    }
                    top += 10;
                }
            }
            else
            {
                if (_cauHinh.XemDiemSauThi == false)
                {
                    var lblKhongDuocXem = new Label
                    {
                        Text = "Bạn không được phép xem kết quả chi tiết hay điểm số.",
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Location = new Point(20, top),
                        AutoSize = true
                    };
                    panel.Controls.Add(lblKhongDuocXem);
                }
            }
        }
    }
}