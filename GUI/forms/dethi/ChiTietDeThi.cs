using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;

namespace GUI.forms.dethi
{
    public partial class ChiTietDeThi : Form
    {
        private readonly DeThiDTO deThi;
        private readonly string _userId;
        private readonly DeThiBLL deThiBLL = new DeThiBLL();



        public ChiTietDeThi(DeThiDTO deThi, String userId)
        {
            this._userId = userId;
            this.deThi = deThi;
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Size = new Size(720, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 243, 249);

            var panel = new Panel
            {
                Size = new Size(700, 350),
                Location = new Point(
        (this.ClientSize.Width - 700) / 2,   // căn giữa theo X
        (this.ClientSize.Height - 390) / 2   // căn giữa theo Y
    ),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Padding = new Padding(20)
            };

            var lblTitle = new Label
            {
                Text = deThi.TenDe,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };

            var lblWarning = new Label
            {
                Text = "⚠ Đề thi chính thức: Bạn chỉ có thể làm đề này một lần duy nhất",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 236, 204),
                ForeColor = Color.FromArgb(183, 110, 0),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 10, 0, 0)
            };

            var table = new TableLayoutPanel
            {
                RowCount = 5,
                ColumnCount = 2,
                Dock = DockStyle.Top,
                Height = 170,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = new Padding(0, 10, 0, 0)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            table.Controls.Add(new Label { Text = "⏰ Thời gian làm bài", Font = new Font("Segoe UI", 11), AutoSize = true }, 0, 0);
            table.Controls.Add(new Label { Text = $"{deThi.ThoiGianLamBai} phút", Font = new Font("Segoe UI", 11), AutoSize = true }, 1, 0);

            table.Controls.Add(new Label { Text = "📅 Thời gian mở đề", Font = new Font("Segoe UI", 11), AutoSize = true }, 0, 1);
            table.Controls.Add(new Label { Text = $"{deThi.ThoiGianBatDau:HH:mm dd/MM/yyyy}", Font = new Font("Segoe UI", 11), AutoSize = true }, 1, 1);

            table.Controls.Add(new Label { Text = "📅 Thời gian kết thúc", Font = new Font("Segoe UI", 11), AutoSize = true }, 0, 2);
            table.Controls.Add(new Label { Text = $"{deThi.ThoiGianKetThuc:HH:mm dd/MM/yyyy}", Font = new Font("Segoe UI", 11), AutoSize = true }, 1, 2);

            int soLuongCauHoi = deThiBLL.GetSoLuongCauHoiTheoDe(deThi.MaDe);
            table.Controls.Add(new Label { Text = "❓ Số lượng câu hỏi", Font = new Font("Segoe UI", 11), AutoSize = true }, 0, 3);
            table.Controls.Add(new Label { Text = $"{soLuongCauHoi}", Font = new Font("Segoe UI", 11), AutoSize = true }, 1, 3);

            //table.Controls.Add(new Label { Text = "📘 Môn học", Font = new Font("Segoe UI", 11), AutoSize = true }, 0, 4);
            //table.Controls.Add(new Label { Text = deThi.TenMonHoc, Font = new Font("Segoe UI", 11), AutoSize = true }, 1, 4);
            var btnStatus = new Button
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 40
            };

            var baiLamBLL = new BaiLamBLL();
            var baiLam = baiLamBLL.GetByUserAndDeThi(_userId, deThi.MaDe); 
            DateTime now = DateTime.Now;

            int trangThaiSinhVien;
            if (now < deThi.ThoiGianBatDau)
            {
                trangThaiSinhVien = 0; // Chưa mở
            }
            else if (baiLam != null)
            {
                trangThaiSinhVien = 2; // Đã hoàn thành
            }
            else if (now > deThi.ThoiGianKetThuc)
            {
                trangThaiSinhVien = 3; // Quá hạn
            }
            else
            {
                trangThaiSinhVien = 1; // Chưa làm (đang mở)
            }

            switch (trangThaiSinhVien)
            {
                case 0:
                    btnStatus.Text = "CHƯA MỞ";
                    btnStatus.BackColor = Color.LightGray;
                    btnStatus.ForeColor = Color.Black;
                    break;
                case 1:
                    btnStatus.Text = "VÀO THI";
                    btnStatus.BackColor = Color.FromArgb(33, 150, 243);
                    btnStatus.ForeColor = Color.White;
                    btnStatus.Click += (s, e) =>
                    {
                        var frm = new Form
                        {
                            Size = new Size(1920, 1080),
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        var ucTrangThi = new GUI.modules.UC_TrangThi(deThi.MaDe, _userId);
                        ucTrangThi.Dock = DockStyle.Fill;
                        frm.Controls.Add(ucTrangThi);
                        frm.ShowDialog();
                        this.Dispose();
                    };
                    break;
                case 2:
                    btnStatus.Text = "ĐÃ HOÀN THÀNH BÀI THI (XEM KẾT QUẢ)";
                    btnStatus.BackColor = Color.FromArgb(76, 175, 80);
                    btnStatus.ForeColor = Color.White;

                    var cauHinh = deThi.CauHinh;
                    bool allowViewResult = cauHinh != null && (
                        cauHinh.XemDapAnSauThi ||
                        cauHinh.XemBaiLam ||
                        cauHinh.XemDiemSauThi
                    );

                    if (allowViewResult)
                    {
                        btnStatus.Cursor = Cursors.Hand;
                        btnStatus.Click += (s, e) =>
                        {
                            var baiLamBLL = new BaiLamBLL();
                            var chiTietBaiLamBLL = new ChiTietBaiLamBLL();
                            var cauHoiBLL = new CauHoiBLL();
                            var userBLL = new UserBLL();

                            var baiLam = baiLamBLL.GetByUserAndDeThi(_userId, deThi.MaDe);
                            var dsCauHoi = deThiBLL.GetCauHoiTheoDeThi(deThi.MaDe);
                            var chiTietList = baiLam != null ? chiTietBaiLamBLL.GetByMaBai(baiLam.MaBai) : new List<ChiTietBaiLamDTO>();
                            var user = userBLL.GetUserByMSSV(_userId);

                            // Gán đáp án cho từng câu hỏi
                            foreach (var cau in dsCauHoi)
                            {
                                var dapAnList = cauHoiBLL.GetDapAn(cau.MaCauHoi);
                                cau.DapAnList = dapAnList.Select(da => da.NoiDung).ToList();
                                cau.DapAnIds = dapAnList.Select(da => da.MaDapAn).ToList();

                                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaCauHoi == cau.MaCauHoi);
                                if (chiTiet != null && chiTiet.MaDapAnChon.HasValue)
                                {
                                    var idx = cau.DapAnIds.IndexOf(chiTiet.MaDapAnChon.Value);
                                    cau.DapAnChon = idx;
                                }
                                else
                                {
                                    cau.DapAnChon = -1;
                                }
                            }

                            decimal diem = baiLam?.Diem ?? 0;
                            int soCauDung = baiLam != null && dsCauHoi.Count > 0
                                ? (int)Math.Round(diem * dsCauHoi.Count / 10)
                                : 0;

                            var frmKetQua = new GUI.forms.dethi.KetQuaBaiThi(dsCauHoi, soCauDung, diem, user, cauHinh);
                            frmKetQua.ShowDialog();
                        };
                    }
                    else
                    {
                        btnStatus.Enabled = false;
                    }
                    break;

                case 3:
                    btnStatus.Text = "ĐÃ QUÁ THỜI GIAN LÀM BÀI";
                    btnStatus.BackColor = Color.FromArgb(217, 71, 23);
                    btnStatus.ForeColor = Color.White;
                    break;
                default:
                    btnStatus.Text = "KHÔNG XÁC ĐỊNH";
                    btnStatus.BackColor = Color.Gray;
                    btnStatus.ForeColor = Color.White;
                    break;
            }

            panel.Controls.Add(btnStatus);
            panel.Controls.Add(table);
            panel.Controls.Add(lblWarning);
            panel.Controls.Add(lblTitle);

            this.Controls.Add(panel);
        }
    }
}

