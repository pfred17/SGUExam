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

        // ... (Constructor giữ nguyên) ...
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

            // --- 1. THÔNG TIN NGƯỜI LÀM BÀI (LUÔN HIỂN THỊ) ---
            var lblMSSV = new Label { Text = $"MSSV: {user.MSSV}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblMSSV);
            top += 28;

            var lblHoTen = new Label { Text = $"Họ tên: {user.HoTen}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblHoTen);
            top += 28;

            var lblEmail = new Label { Text = $"Email: {user.Email}", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(20, top), AutoSize = true };
            panel.Controls.Add(lblEmail);
            top += 28;

            // --- 2. HIỂN THỊ ĐIỂM (THEO QUY TẮC) ---
            // Quy tắc: Chỉ hiện điểm nếu XemDiemSauThi = 1 HOẶC (XemDapAnSauThi = 1 VÀ XemBaiLam = 1)
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

            // --- XỬ LÝ TRƯỜNG HỢP: CHỈ XEM ĐIỂM (THEO RÀNG BUỘC) ---
            // "Nếu xem_diem_sau_thi = 1 thì hiển thị đề thi này bạn chỉ được phép xem điểm..."
            // Điều kiện để DỪNG lại sau khi hiển thị điểm: XemDiemSauThi = 1 VÀ KHÔNG được xem chi tiết (XemDapAnSauThi = 0)
            if (_cauHinh.XemDiemSauThi == true && _cauHinh.XemDapAnSauThi == false)
            {
                // Thêm thông báo rõ ràng hơn
                var lblChiXemDiem = new Label
                {
                    Text = "Bạn chỉ được phép xem thông tin và điểm số.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.OrangeRed,
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panel.Controls.Add(lblChiXemDiem);
                return; // KẾT THÚC, không hiển thị chi tiết câu hỏi
            }


            // --- 3. HIỂN THỊ CHI TIẾT CÂU HỎI VÀ ĐÁP ÁN (THEO QUY TẮC) ---
            // Quy tắc: Chỉ hiển thị chi tiết nếu XemDapAnSauThi = 1 (vì nó bao gồm cả XemBaiLam=0 và XemBaiLam=1)
            if (_cauHinh.XemDapAnSauThi == true)
            {
                // Biến cờ quyết định xem có tô màu cho đáp án đã chọn của USER hay không
                // "xem_bai_lam = 1" mới hiển thị toàn bộ bài làm của user (kể cả đáp án đã chọn)
                bool shouldShowUserChoice = _cauHinh.XemBaiLam == true;

                for (int i = 0; i < dsCauHoi.Count; i++)
                {
                    var cau = dsCauHoi[i];
                    var dapAnBLL = new BLL.DapAnBLL();
                    var dapAnList = dapAnBLL.GetByCauHoi(cau.MaCauHoi);

                    int dapAnDungIndex = dapAnList.FindIndex(da => da.Dung);

                    // Tiêu đề câu hỏi
                    var lblCau = new Label
                    {
                        Text = $"Câu {i + 1}: {cau.NoiDung}",
                        Font = new Font("Segoe UI", 13, FontStyle.Bold),
                        Location = new Point(20, top),
                        AutoSize = true,
                        ForeColor = (cau.DapAnChon == dapAnDungIndex && shouldShowUserChoice) ? Color.DarkGreen : Color.Black // Chỉ tô màu đúng/sai khi được xem bài làm
                    };
                    panel.Controls.Add(lblCau);
                    top += 30;

                    // Hiển thị chi tiết đáp án
                    for (int j = 0; j < cau.DapAnList.Count; j++)
                    {
                        string prefix = $"{(char)('A' + j)}. ";
                        Color foreColor = Color.Black;
                        Color backColor = Color.White;
                        string suffix = "";

                        bool isDapAnDung = (j == dapAnDungIndex);
                        bool isDapAnChon = (j == cau.DapAnChon);

                        if (isDapAnDung)
                        {
                            // 1. Đáp án đúng của đề (Luôn hiển thị nếu XemDapAnSauThi = 1)
                            foreColor = Color.DarkGreen;
                            suffix = " ✓";

                            if (isDapAnChon && shouldShowUserChoice)
                            {
                                // 2. Chọn đúng (Chỉ tô nền nếu được xem bài làm)
                                backColor = Color.LightGreen;
                            }
                        }
                        else if (isDapAnChon && shouldShowUserChoice)
                        {
                            // 3. Chọn sai (Chỉ tô nền và ký hiệu nếu được xem bài làm)
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
                // Trường hợp không được xem điểm và cũng không được xem đáp án.
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