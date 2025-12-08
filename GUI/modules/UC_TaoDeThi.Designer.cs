using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Syncfusion.WinForms.Input;
using Syncfusion.WinForms.Input.Enums;

namespace GUI.modules
{
    partial class UC_TaoDeThi
    {
        private Guna2Panel panelMain;
        private Guna2Panel panelConfig;
        private Guna2TextBox txtTenDe;
        private SfDateTimeEdit dtpTu, dtpDen;
        private Guna2NumericUpDown numThoiGianLamBai, numCanhBao, numDe, numTrungBinh, numKho;
        private Guna2ComboBox cbNhomHocPhan;
        private CheckedListBox clbChuong;
        private Guna2Button btnTaoDe;
        private Guna2ComboBox cbMonHoc; // Chọn môn học
        private CheckedListBox clbNhomHocPhan; // Chọn nhiều nhóm học phần


        private Guna2ToggleSwitch swTuDongLay, swXemDiem, swXemDapAn, swXemBaiLam, swDaoCauHoi, swDaoDapAn, swTuDongNop, swDeLuyenTap, swTinhDiem;

        private void InitializeComponent()
        {
            // ==== PANEL TRÁI ====
            panelMain = new Guna2Panel
            {
                Size = new Size(730, 670),
                Location = new Point(20, 30),
                BorderRadius = 12,
                FillColor = Color.White
            };

            int x = 30;
            int y = 20;

            Font fontLabel = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontInput = new Font("Segoe UI", 9);

            // ===== TÊN ĐỀ =====
            AddLabel(panelMain, "Tên đề", x, y, fontLabel);
            y += 25;

            txtTenDe = new Guna2TextBox
            {
                Location = new Point(x, y),
                Width = 480,
                Height = 30,
                BorderRadius = 8,
                AutoRoundedCorners = true,
                PlaceholderText = "Nhập tên đề kiểm tra",
                Font = fontInput
            };
            panelMain.Controls.Add(txtTenDe);

            y += 50;

            // ==== THỜI GIAN ====
            AddLabel(panelMain, "Thời gian", x, y, fontLabel);
            y += 25;

            dtpTu = new SfDateTimeEdit
            {
                Location = new Point(x, y),
                Width = 220,
                Height = 30,
                Font = fontInput,
                Value = DateTime.Now,
                AllowNull = false,
                MinDateTime = DateTime.MinValue,
                MaxDateTime = DateTime.MaxValue,
                ShowDropDown = true,
                DateTimePattern = DateTimePattern.Custom,
                Format = "dd/MM/yyyy HH:mm", // Use 'Format' property for custom format
                DateTimeEditingMode = DateTimeEditingMode.Default
            };

            dtpDen = new SfDateTimeEdit
            {
                Location = new Point(x + 240, y),
                Width = 220,
                Height = 30,
                Font = fontInput,
                Value = DateTime.Now.AddHours(1),
                AllowNull = false,
                MinDateTime = DateTime.MinValue,
                MaxDateTime = DateTime.MaxValue,
                ShowDropDown = true,
                DateTimePattern = DateTimePattern.Custom,
                Format = "dd/MM/yyyy HH:mm", // Use 'Format' property for custom format
                DateTimeEditingMode = DateTimeEditingMode.Default
            };

            // Add to panel
            panelMain.Controls.Add(dtpTu);
            panelMain.Controls.Add(dtpDen);

            y += 50;
            // ===== THỜI GIAN LÀM BÀI & CẢNH BÁO (CÙNG 1 DÒNG) =====
            var panelTimeWarning = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(480, 35)
            };

            // Label "Thời gian làm bài"
            var lblThoiGianLamBai = new Label
            {
                Text = "Thời gian làm bài",
                Location = new Point(0, 0),
                Font = fontLabel,
                AutoSize = true
            };
            panelTimeWarning.Controls.Add(lblThoiGianLamBai);

            // NumericUpDown thời gian làm bài
            numThoiGianLamBai = CreateSmallNumeric(lblThoiGianLamBai.Right + 10, 0, 45, 1, 300);
            panelTimeWarning.Controls.Add(numThoiGianLamBai);

            // "phút" cho thời gian làm bài
            AddRightLabel(panelTimeWarning, "phút", numThoiGianLamBai.Right + 5, 0, fontInput);

            // Label "Cảnh báo"
            var lblCanhBao = new Label
            {
                Text = "Cảnh báo",
                Location = new Point(numThoiGianLamBai.Right + 65, 0),
                Font = fontLabel,
                AutoSize = true
            };
            panelTimeWarning.Controls.Add(lblCanhBao);

            // NumericUpDown cảnh báo
            numCanhBao = CreateSmallNumeric(lblCanhBao.Right + 10, 0, 1, 1, 60);
            panelTimeWarning.Controls.Add(numCanhBao);

            // "phút" cho cảnh báo
            AddRightLabel(panelTimeWarning, "phút", numCanhBao.Right + 5, 0, fontInput);

            panelMain.Controls.Add(panelTimeWarning);

            y += 45; // Move y down for next controls

            // Ghi chú cảnh báo
            panelMain.Controls.Add(new Label
            {
                Text = "Nếu sinh viên làm bài dưới số phút cảnh báo, hệ thống sẽ đánh dấu bất thường.",
                Location = new Point(x, y),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Width = 480
            });

            y += 40;




            // ===== CHỌN MÔN HỌC =====
            AddLabel(panelMain, "Môn học", x, y, fontLabel);
            y += 25;

            cbMonHoc = new Guna2ComboBox
            {
                Location = new Point(x, y),
                Width = 420,
                Height = 30,
                BorderRadius = 8,
                AutoRoundedCorners = true,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = fontInput
            };
            panelMain.Controls.Add(cbMonHoc);

            y += 50;

            // ===== NHÓM HỌC PHẦN =====
            AddLabel(panelMain, "Nhóm học phần", x, y, fontLabel);
            y += 25;

            clbNhomHocPhan = new CheckedListBox
            {
                Location = new Point(x, y),
                Width = 420,
                Height = 60, // Reduced height for compactness
                Font = fontInput,
                IntegralHeight = false, // Always show scrollbar if needed
                ScrollAlwaysVisible = true
            };
            panelMain.Controls.Add(clbNhomHocPhan);

            y += 70; // Slightly more than height for spacing

            // ===== CHƯƠNG =====
            AddLabel(panelMain, "Chương", x, y, fontLabel);
            y += 25;

            clbChuong = new CheckedListBox
            {
                Location = new Point(x, y),
                Width = 420,
                Height = 60, // Reduced height for compactness
                Font = fontInput,
                IntegralHeight = false,
                ScrollAlwaysVisible = true
            };
            panelMain.Controls.Add(clbChuong);

            y += 70;


            // ============ NHÓM 3 NUMERIC UP DOWN — CANH THẲNG HÀNG ============
            var panelNumericGroup = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(500, 35)
            };

            // Cột 1: Dễ
            AddRightLabel(panelNumericGroup, "Số câu dễ", 0, 0, fontInput);
            numDe = CreateSmallNumeric(80, 0, 0, 0, 100);
            panelNumericGroup.Controls.Add(numDe);

            // Cột 2: Trung bình
            AddRightLabel(panelNumericGroup, "Trung bình", 160, 0, fontInput);
            numTrungBinh = CreateSmallNumeric(260, 0, 0, 0, 100);
            panelNumericGroup.Controls.Add(numTrungBinh);

            // Cột 3: Khó
            AddRightLabel(panelNumericGroup, "Khó", 350, 0, fontInput);
            numKho = CreateSmallNumeric(390, 0, 0, 0, 100);
            panelNumericGroup.Controls.Add(numKho);

            panelMain.Controls.Add(panelNumericGroup);

            y += 55;

            // ===== BUTTON TẠO ĐỀ =====
            btnTaoDe = new Guna2Button
            {
                Text = "+ TẠO ĐỀ",
                Location = new Point(x, y),
                Width = 200,
                Height = 45,
                BorderRadius = 8,
                FillColor = Color.FromArgb(55, 123, 255),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White
            };
            panelMain.Controls.Add(btnTaoDe);

            // ==== PANEL PHẢI ====
            panelConfig = new Guna2Panel
            {
                Size = new Size(340, 670),
                Location = new Point(770, 30),
                BorderRadius = 12,
                FillColor = Color.White
            };

            panelConfig.Controls.Add(new Label
            {
                Text = "CẤU HÌNH",
                Location = new Point(20, 20),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            });

            int sy = 60;

            swTuDongLay = AddSwitch(panelConfig, "Tự động lấy từ ngân hàng đề", ref sy);
            swXemDiem = AddSwitch(panelConfig, "Xem điểm sau khi thi xong", ref sy);
            swXemDapAn = AddSwitch(panelConfig, "Xem đáp án khi thi xong", ref sy);
            swXemBaiLam = AddSwitch(panelConfig, "Xem bài làm khi thi xong", ref sy);
            swDaoCauHoi = AddSwitch(panelConfig, "Đảo câu hỏi", ref sy);
            swDaoDapAn = AddSwitch(panelConfig, "Đảo đáp án", ref sy);
            swTuDongNop = AddSwitch(panelConfig, "Tự động nộp bài", ref sy);
            swDeLuyenTap = AddSwitch(panelConfig, "Đề luyện tập", ref sy);
            swTinhDiem = AddSwitch(panelConfig, "Tính điểm", ref sy);

            // Add panels
            this.Controls.Add(panelMain);
            this.Controls.Add(panelConfig);
            this.Size = new Size(1120, 731);

            // 🔥 Xóa toàn bộ nền xám — đồng bộ style
            ApplyFlatWhiteStyle(this);
            panelMain.BackColor = Color.White;
            panelConfig.BackColor = Color.White;
            txtTenDe.BackColor = Color.White;
            dtpTu.BackColor = Color.White;
            dtpDen.BackColor = Color.White;
            numThoiGianLamBai.BackColor = Color.White;
            numCanhBao.BackColor = Color.White;
            numDe.BackColor = Color.White;
            numTrungBinh.BackColor = Color.White;
            numKho.BackColor = Color.White;
            clbChuong.BackColor = Color.White;
            btnTaoDe.BackColor = Color.White;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
        }

        // ====================================================================
        // ======================= HÀM TIỆN ÍCH ================================
        // ====================================================================

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

        private void AddLabel(Control parent, string text, int x, int y, Font font)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                Font = font,
                AutoSize = true
            });
        }

        private void AddRightLabel(Control parent, string text, int x, int y, Font font)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y + 5),
                Font = font,
                AutoSize = true
            });
        }

        private Guna2NumericUpDown CreateSmallNumeric(int x, int y, int value, int min, int max)
        {
            return new Guna2NumericUpDown
            {
                Location = new Point(x, y),
                Width = 60,
                Height = 28,
                Minimum = min,
                Maximum = max,
                Value = value,
                Font = new Font("Segoe UI", 9),
                AutoRoundedCorners = false,
                BorderRadius = 6
            };
        }

        private void ApplyFlatWhiteStyle(Control c)
        {
            if (c is Guna2TextBox t)
            {
                t.FillColor = Color.White;
                t.BorderColor = Color.Silver;
                t.DisabledState.FillColor = Color.White;
                t.HoverState.FillColor = Color.White;
                t.FocusedState.FillColor = Color.White;
            }
            else if (c is Guna2ComboBox cb)
            {
                cb.FillColor = Color.White;
                cb.BorderColor = Color.Silver;
                cb.HoverState.FillColor = Color.White;
                cb.FocusedState.FillColor = Color.White;
            }
            else if (c is Guna2DateTimePicker dtp)
            {
                dtp.FillColor = Color.White;
                dtp.BorderColor = Color.Silver;
            }
            else if (c is Guna2NumericUpDown num)
            {
                num.FillColor = Color.White;
                num.BorderColor = Color.Silver;
                num.UpDownButtonFillColor = Color.White;
                num.UpDownButtonForeColor = Color.Black;
            }
            else if (c is Guna2Panel pnl)
            {
                pnl.FillColor = Color.White;
            }
            else if (c is CheckedListBox clb)
            {
                clb.BackColor = Color.White;
                clb.ForeColor = Color.Black;
            }

            foreach (Control child in c.Controls)
                ApplyFlatWhiteStyle(child);
        }
    }
}
