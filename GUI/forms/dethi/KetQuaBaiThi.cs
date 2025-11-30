using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            // Thông tin người làm bài (mỗi dòng riêng)
            var lblMSSV = new Label
            {
                Text = $"MSSV: {user.MSSV}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            };
            panel.Controls.Add(lblMSSV);
            top += 28;

            var lblHoTen = new Label
            {
                Text = $"Họ tên: {user.HoTen}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            };
            panel.Controls.Add(lblHoTen);
            top += 28;

            var lblEmail = new Label
            {
                Text = $"Email: {user.Email}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            };
            panel.Controls.Add(lblEmail);
            top += 28;

            // Hiển thị điểm nếu cho phép
            if (_cauHinh.XemDiemSauThi)
            {
                var lblTongKet = new Label
                {
                    Text = $"Số câu đúng: {soCauDung}/{dsCauHoi.Count}   Điểm: {diem}",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panel.Controls.Add(lblTongKet);
                top += 40;
            }

            for (int i = 0; i < dsCauHoi.Count; i++)
            {
                var cau = dsCauHoi[i];
                var lblCau = new Label
                {
                    Text = $"Câu {i + 1}: {cau.NoiDung}",
                    Font = new Font("Segoe UI", 13, FontStyle.Bold),
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panel.Controls.Add(lblCau);
                top += 30;

                // Hiển thị đáp án nếu cho phép
                if (_cauHinh.XemDapAnSauThi)
                {
                    for (int j = 0; j < cau.DapAnList.Count; j++)
                    {
                        var lblDapAn = new Label
                        {
                            Text = $"{(char)('A' + j)}. {cau.DapAnList[j]}",
                            Location = new Point(40, top),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12)
                        };
                        // Đáp án đúng: xanh
                        if (j < cau.DapAnIds.Count)
                        {
                            var dapAnBLL = new BLL.DapAnBLL();
                            var dapAnList = dapAnBLL.GetByCauHoi(cau.MaCauHoi);
                            var dapAnDungIndex = dapAnList.FindIndex(da => da.Dung);
                            if (j == dapAnDungIndex)
                                lblDapAn.ForeColor = Color.Green;
                        }
                        // Đáp án đã chọn: vàng nền
                        if (j == cau.DapAnChon)
                            lblDapAn.BackColor = Color.LightYellow;
                        panel.Controls.Add(lblDapAn);
                        top += 28;
                    }
                    top += 10;
                }
            }
        }
    }
}
