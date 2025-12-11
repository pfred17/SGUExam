using BLL;
using DTO;
using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using ClosedXML.Excel;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace GUI.modules
{
    public partial class UC_ThemSVVaoNhom : UserControl
    {

        //public event EventHandler<UserDTO> SinhVienAdded;
        public event EventHandler<SinhVienAddedEventArgs> SinhVienAdded;
        private UserBLL userBLL = new UserBLL();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private long _maNhom; // sẽ được truyền từ form cha
        private string filePathExcel = "";
        public UC_ThemSVVaoNhom(long maNhom)
        {
            _maNhom = maNhom;
            InitializeComponent();

        }

        private void panelTab_Paint(object sender, PaintEventArgs e)
        {

        }
        public class SinhVienAddedEventArgs : EventArgs
        {
            public UserDTO User { get; set; }
            public bool IsFromExcel { get; set; }  // CỜ QUAN TRỌNG NHẤT!

            public SinhVienAddedEventArgs(UserDTO user, bool isFromExcel = false)
            {
                User = user;
                IsFromExcel = isFromExcel;
            }
        }

        protected virtual void OnSinhVienAdded(UserDTO user, bool isFromExcel = false)
        {
            SinhVienAdded?.Invoke(this, new SinhVienAddedEventArgs(user, isFromExcel));
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        private void btnTaoMaMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab == tabPage3)
                {
                    if (string.IsNullOrWhiteSpace(txtDuongDan.Text) || txtDuongDan.Text == "Chưa có tệp nào được chọn")
                        txtDuongDan.Text = "Chưa có tệp nào được chọn";

                    btnChonFileExcel?.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"tabControl_SelectedIndexChange error: {ex.Message}");
            }
        }


        private void btnThemExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePathExcel))
            {
                MessageBox.Show("Vui lòng chọn file trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                using (var workbook = new XLWorkbook(filePathExcel))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.LastRowUsed().RowNumber();

                    int thanhCong = 0;
                    int thatBai = 0;
                    var loiChiTiet = new List<string>();

                    var daCoTrongNhom = new HashSet<string>();
                    var emailHoacTenDangNhapTrung = new HashSet<string>();
                    var khongPhaiSinhVien = new HashSet<string>();
                    var loiHeThong = new List<string>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string mssv = worksheet.Cell(row, 1).GetString().Trim();
                        string tenDangNhap = worksheet.Cell(row, 2).GetString().Trim();
                        string matKhau = worksheet.Cell(row, 3).GetString().Trim();
                        string hoTen = worksheet.Cell(row, 4).GetString().Trim();
                        string email = worksheet.Cell(row, 5).GetString().Trim();
                        int role = Convert.ToInt32(worksheet.Cell(row, 6).GetString().Trim());
                        int gioiTinh = worksheet.Cell(row, 7).GetValue<int>();
                        int trangThai = worksheet.Cell(row, 8).GetValue<int>();

                        var cotRong = new List<string>();
                        if (string.IsNullOrWhiteSpace(mssv)) cotRong.Add("MSSV");
                        if (string.IsNullOrWhiteSpace(tenDangNhap)) cotRong.Add("TenDangNhap");
                        if (string.IsNullOrWhiteSpace(matKhau)) cotRong.Add("MatKhau");
                        if (string.IsNullOrWhiteSpace(hoTen)) cotRong.Add("HoTen");
                        if (string.IsNullOrWhiteSpace(email)) cotRong.Add("Email");
                        if (cotRong.Count > 0)
                        {
                            loiChiTiet.Add($"• Dòng {row} → Các cột trống: {string.Join(", ", cotRong)}");
                            thatBai++;
                            continue; // bỏ qua dòng này vì dữ liệu không đầy đủ
                        }



                        UserDTO user = userBLL.GetUserByMSSV(mssv, true);

                        // 1. CHƯA CÓ → TẠO MỚI (CHỈ SINH VIÊN)
                        if (user == null && role == 1)
                        {
                            // ✅ KIỂM TRA TRÙNG TRƯỚC KHI TẠO
                            bool trungEmail = userBLL.IsEmailExists(email);
                            bool trungTenDangNhap = userBLL.IsMssvExists(tenDangNhap);

                            if (trungEmail || trungTenDangNhap)
                            {
                                if (trungEmail && trungTenDangNhap)
                                    loiChiTiet.Add($"• {mssv} → Trùng cả Email và Tên đăng nhập");
                                else if (trungEmail)
                                    loiChiTiet.Add($"• {mssv} → Trùng Email");
                                else
                                    loiChiTiet.Add($"• {mssv} → Trùng Tên đăng nhập");

                                thatBai++;
                                continue;
                            }

                            // ✅ KHÔNG TRÙNG → TẠO BÌNH THƯỜNG
                            bool taoOK = userBLL.CreateNewUser(new UserDTO
                            {
                                MSSV = mssv,
                                TenDangNhap = tenDangNhap,
                                MatKhau = matKhau,
                                HoTen = hoTen,
                                Email = email,
                                Role = role,
                                GioiTinh = gioiTinh,
                                TrangThai = trangThai
                            });

                            if (taoOK)
                            {
                                user = userBLL.GetUserByMSSV(mssv, true);
                            }
                            else
                            {
                                loiHeThong.Add($"• {mssv} → Lỗi hệ thống khi tạo tài khoản");
                                thatBai++;
                                continue;
                            }
                        }

                        else if (user == null)
                        {
                            khongPhaiSinhVien.Add(mssv);
                            loiChiTiet.Add($"• {mssv} → Không phải Sinh viên hoặc bị khóa");
                            thatBai++;
                            continue;
                        }

                        // 2. KIỂM TRA QUYỀN THAM GIA NHÓM
                        bool coQuyenThamGia = userBLL.QuyenThamGia(mssv);
                        if (!coQuyenThamGia)
                        {
                            khongPhaiSinhVien.Add(mssv);
                            loiChiTiet.Add($"• {mssv} → Không có quyền tham gia nhóm");
                            thatBai++;
                            continue;
                        }

                        // 3. KIỂM TRA ĐÃ TRONG NHÓM CHƯA
                        if (ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(mssv, _maNhom))
                        {
                            daCoTrongNhom.Add(mssv);
                            loiChiTiet.Add($"• {mssv} → Đã có trong nhóm");
                            thatBai++;
                            continue;
                        }

                        // 4. THÊM VÀO NHÓM
                        bool themOK = ChiTietNhomHocPhanBLL.ThemSinhVienVaoNhom(mssv, _maNhom);
                        if (themOK)
                        {
                            thanhCong++;
                            OnSinhVienAdded(user, isFromExcel: true);
                        }
                        else
                        {
                            loiHeThong.Add($"• {mssv} → Lỗi hệ thống khi thêm vào nhóm");
                            thatBai++;
                        }
                    }

                    // TỔNG HỢP THÔNG BÁO
                    string thongBao = $"Hoàn tất import!\n\n" +
                                      $"✅ Thành công: {thanhCong} sinh viên\n" +
                                      $"❌ Thất bại: {thatBai} sinh viên\n\n";

                    if (loiChiTiet.Count > 0 || loiHeThong.Count > 0)
                    {
                        thongBao += "Chi tiết lỗi:\n";
                        foreach (var loi in loiChiTiet) thongBao += loi + "\n";
                        foreach (var loi in loiHeThong) thongBao += loi + "\n";
                    }

                    MessageBox.Show(
                        thongBao,
                        "Kết quả import",
                        MessageBoxButtons.OK,
                        thanhCong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                    );
                    if (thanhCong > 0)
                    {
                        // Gọi trực tiếp form cha để load lại danh sách (không cần event)
                        var parent = this.Parent as UC_SinhVienTrongNhom;
                        parent?.LoadDanhSachSinhVien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnChonTep_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            ofd.Title = "Chọn file danh sách sinh viên";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathExcel = ofd.FileName;
                txtDuongDan.Text = "Đã chọn: " + Path.GetFileName(filePathExcel);
                btnThemExcel.Enabled = true;

            }
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void btnThemSV1_Click(object sender, EventArgs e)
        {
            string mssv = tbMaSv.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra trong CSDL
                UserDTO user = userBLL.GetUserByMSSV(mssv, true);

                if (user == null)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại hoặc tài khoản đã bị khóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool coQuyen = userBLL.QuyenThamGia(user.MSSV);

                if (!coQuyen)
                {
                    MessageBox.Show("Tài khoản này không có quyền tham gia nhóm học phần!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Thành công → phát event cho form cha
                OnSinhVienAdded(user, isFromExcel: false);

                // Xóa ô nhập và focus lại để thêm tiếp
                tbMaSv.Clear();
                tbMaSv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
