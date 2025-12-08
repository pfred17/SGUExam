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
            panel.Controls.Add(new Label
            {
                Text = $"MSSV: {user.MSSV}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            });
            top += 28;

            panel.Controls.Add(new Label
            {
                Text = $"Họ tên: {user.HoTen}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            });
            top += 28;

            panel.Controls.Add(new Label
            {
                Text = $"Email: {user.Email}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, top),
                AutoSize = true
            });
            top += 28;

            // 2. Hiển thị điểm
            bool shouldShowScore =
                _cauHinh.XemDiemSauThi == true ||
                (_cauHinh.XemDapAnSauThi == true && _cauHinh.XemBaiLam == true);

            if (shouldShowScore)
            {
                panel.Controls.Add(new Label
                {
                    Text = $"Số câu đúng: {soCauDung}/{dsCauHoi.Count}    Điểm: {diem}",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    Location = new Point(20, top),
                    AutoSize = true
                });
                top += 40;
            }

            // 3. Chỉ xem điểm – không xem chi tiết
            if (_cauHinh.XemDiemSauThi == true && _cauHinh.XemDapAnSauThi == false && _cauHinh.XemBaiLam == false)
            {
                panel.Controls.Add(new Label
                {
                    Text = "Bạn chỉ được xem điểm, không được xem chi tiết bài làm.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.OrangeRed,
                    Location = new Point(20, top),
                    AutoSize = true
                });
                return;
            }

            // 4. Không được xem điểm + không xem đáp án + không xem bài làm
            if (_cauHinh.XemDiemSauThi == false && _cauHinh.XemDapAnSauThi == false && _cauHinh.XemBaiLam == false)
            {
                panel.Controls.Add(new Label
                {
                    Text = "Bạn không được phép xem bất kỳ thông tin nào về bài thi.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(20, top),
                    AutoSize = true
                });
                return;
            }

            // 5. CASE: Chỉ xem đáp án – không xem bài làm
            if (_cauHinh.XemDapAnSauThi == true && _cauHinh.XemBaiLam == false)
            {
                panel.Controls.Add(new Label
                {
                    Text = "Bạn chỉ được xem đáp án đúng của bài thi.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.RoyalBlue,
                    Location = new Point(20, top),
                    AutoSize = true
                });
                top += 35;
            }

            // 6. CASE: Chỉ xem bài làm – không xem đáp án
            if (_cauHinh.XemBaiLam == true && _cauHinh.XemDapAnSauThi == false)
            {
                panel.Controls.Add(new Label
                {
                    Text = "Bạn chỉ được xem bài làm của mình (không xem đáp án đúng).",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.OrangeRed,
                    Location = new Point(20, top),
                    AutoSize = true
                });
                top += 35;
            }

            // 7. Hiển thị câu hỏi + đáp án
            var dapAnBLL = new BLL.DapAnBLL();
            bool allowSeeAnswer = _cauHinh.XemDapAnSauThi == true;
            bool allowSeeUserChoice = _cauHinh.XemBaiLam == true;

            for (int i = 0; i < dsCauHoi.Count; i++)
            {
                var cau = dsCauHoi[i];
                var dapAnList = dapAnBLL.GetByCauHoi(cau.MaCauHoi);

                var dapAnDung = dapAnList.FirstOrDefault(da => da.Dung);
                long? dapAnDungId = dapAnDung?.MaDapAn;

                // Tiêu đề câu hỏi
                panel.Controls.Add(new Label
                {
                    Text = $"Câu {i + 1}: {cau.NoiDung}",
                    Font = new Font("Segoe UI", 13, FontStyle.Bold),
                    Location = new Point(20, top),
                    AutoSize = true
                });
                top += 30;

                // Vòng for hiển thị đáp án
                for (int j = 0; j < cau.DapAnList.Count; j++)
                {
                    bool isCorrect = (cau.DapAnIds[j] == dapAnDungId);
                    bool isChosen = (j == cau.DapAnChon);

                    Color foreColor = Color.Black;
                    Color backColor = Color.White;
                    string suffix = "";
                    string prefix = $"{(char)('A' + j)}. ";

                    // CASE 1: Xem đáp án đúng
                    if (allowSeeAnswer)
                    {
                        if (isCorrect)
                        {
                            foreColor = Color.DarkGreen;
                            suffix = " ✓";

                            if (isChosen && allowSeeUserChoice)
                                backColor = Color.LightGreen;
                        }
                        else if (isChosen && allowSeeUserChoice)
                        {
                            backColor = Color.LightCoral;
                            suffix = " ✗";
                        }
                    }
                    // CASE 2: Chỉ xem bài làm – không xem đáp án
                    else if (!allowSeeAnswer && allowSeeUserChoice)
                    {
                        if (isChosen)
                        {
                            backColor = Color.LightYellow;
                            foreColor = Color.DarkBlue;
                        }
                    }

                    // CASE 3: Không được xem bài làm → không highlight
                    else
                    {
                        backColor = Color.White;
                    }

                    panel.Controls.Add(new Label
                    {
                        Text = $"{prefix}{cau.DapAnList[j]}{suffix}",
                        Font = new Font("Segoe UI", 12),
                        Location = new Point(40, top),
                        AutoSize = true,
                        ForeColor = foreColor,
                        BackColor = backColor,
                        Padding = new Padding(5)
                    });

                    top += 35;
                }
                top += 10;
            }
        }
    }
}