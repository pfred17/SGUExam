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
        public event EventHandler<UserDTO> SinhVienAdded;
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
        // Hàm gọi khi muốn thông báo "đã thêm sinh viên thành công"
        protected virtual void OnSinhVienAdded(UserDTO user)
        {
            SinhVienAdded?.Invoke(this, user);
        }
        private void btnThemSV_Click(object sender, EventArgs e)
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

                // Kiểm tra trùng trong nhóm hiện tại (tránh thêm 2 lần)
                // Cha sẽ truyền DataGridView hoặc bạn có thể dùng event để cha tự kiểm tra

                if (user.Role != 1) // tùy tên role trong DB của bạn
                {
                    MessageBox.Show("Đây không phải tài khoản sinh viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thành công → phát event cho form cha
                OnSinhVienAdded(user);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Read only MSSV values (first column) from Excel, tolerant to file lock by copying to temp

        //private void btnThemExcel_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(filePathExcel))
        //    {
        //        MessageBox.Show("Vui lòng chọn file trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    rtbKetQua.Clear();
        //    rtbKetQua.AppendText("Đang đọc file Excel...\n\n");

        //    try
        //    {
        //        using (var workbook = new XLWorkbook(filePathExcel))
        //        {
        //            var worksheet = workbook.Worksheet(1); // Sheet đầu tiên
        //            var rowCount = worksheet.LastRowUsed().RowNumber();

        //            int thanhCong = 0;
        //            int thatBai = 0;
        //            var loiChiTiet = new List<string>();

        //            // Bắt đầu từ dòng 2 (dòng 1 là tiêu đề)
        //            for (int row = 2; row <= rowCount; row++)
        //            {
        //                // ĐỌC ĐẦY ĐỦ 8 CỘT THEO THỨ TỰ TRONG FILE CỦA BẠN
        //                string mssv = worksheet.Cell(row, 1).GetString().Trim();
        //                string tenDangNhap = worksheet.Cell(row, 2).GetString().Trim();
        //                string matKhau = worksheet.Cell(row, 3).GetString().Trim();
        //                string hoTen = worksheet.Cell(row, 4).GetString().Trim();
        //                string email = worksheet.Cell(row, 5).GetString().Trim();
        //                string role = worksheet.Cell(row, 6).GetString().Trim();
        //                int gioiTinh = worksheet.Cell(row, 7).GetValue<int>();
        //                int trangThai = worksheet.Cell(row, 8).GetValue<int>();

        //                rtbKetQua.AppendText($"Dòng {row}: Đang xử lý MSSV = [{mssv}]\n");

        //                if (string.IsNullOrWhiteSpace(mssv))
        //                {
        //                    loiChiTiet.Add($"Dòng {row}: MSSV trống");
        //                    thatBai++;
        //                    continue;
        //                }

        //                // BƯỚC 1: KIỂM TRA MSSV ĐÃ TỒN TẠI CHƯA?
        //                UserDTO user = userBLL.GetUserByMSSV(mssv, true);

        //                if (user == null && role == "Sinh viên") // CHƯA TỒN TẠI → TẠO MỚI THEO FILE
        //                {
        //                    UserDTO newUser = new UserDTO
        //                    {
        //                        MSSV = mssv,
        //                        TenDangNhap = tenDangNhap,
        //                        MatKhau = matKhau,
        //                        HoTen = hoTen,
        //                        Email = email,
        //                        Role = role,
        //                        GioiTinh = gioiTinh,
        //                        TrangThai = trangThai
        //                    };

        //                    bool taoOK = userBLL.CreateNewUser(newUser);
        //                    if (taoOK)
        //                    {
        //                        user = userBLL.GetUserByMSSV(mssv, true); // lấy lại user vừa tạo
        //                        rtbKetQua.AppendText($" → ĐÃ TẠO TÀI KHOẢN MỚI: {hoTen} ({mssv})\n", Color.Blue);
        //                    }
        //                    else
        //                    {
        //                        loiChiTiet.Add($"Dòng {row}: {mssv} → Tạo tài khoản thất bại (trùng email/tên đăng nhập)");
        //                        thatBai++;
        //                        continue;
        //                    }
        //                }
        //                else if (user != null)
        //                {
        //                    rtbKetQua.AppendText($" → ĐÃ TỒN TẠI: {user.HoTen} ({mssv})\n", Color.Orange);
        //                }
        //                else
        //                {
        //                    loiChiTiet.Add($"Dòng {row}: {mssv} → Không phải Sinh viên hoặc bị khóa");
        //                    thatBai++;
        //                    continue;
        //                }

        //                // BƯỚC 2: KIỂM TRA ROLE
        //                if (user.Role != "Sinh viên")
        //                {
        //                    loiChiTiet.Add($"Dòng {row}: {mssv} → Không phải sinh viên");
        //                    thatBai++;
        //                    continue;
        //                }

        //                // BƯỚC 3: KIỂM TRA ĐÃ TRONG NHÓM CHƯA
        //                if (ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(mssv, _maNhom))
        //                {
        //                    loiChiTiet.Add($"Dòng {row}: {mssv} → Đã có trong nhóm");
        //                    thatBai++;
        //                    continue;
        //                }

        //                // BƯỚC 4: THÊM VÀO NHÓM
        //                bool themOK = ChiTietNhomHocPhanBLL.ThemSinhVienVaoNhom(mssv, _maNhom);
        //                if (themOK)
        //                {
        //                    thanhCong++;
        //                    OnSinhVienAdded(user);
        //                    rtbKetQua.AppendText($" → ĐÃ THÊM VÀO NHÓM THÀNH CÔNG!\n", Color.Green);
        //                }
        //                else
        //                {
        //                    loiChiTiet.Add($"Dòng {row}: {mssv} → Lỗi khi thêm vào nhóm");
        //                    thatBai++;
        //                }
        //            }

        //            // HIỂN THỊ KẾT QUẢ
        //            rtbKetQua.AppendText($"HOÀN TẤT!\n\n");
        //            rtbKetQua.AppendText($"Thành công: {thanhCong} sinh viên\n", Color.Green);
        //            rtbKetQua.AppendText($"Thất bại: {thatBai} sinh viên\n\n", Color.Red);

        //            if (loiChiTiet.Count > 0)
        //            {
        //                rtbKetQua.AppendText("Chi tiết lỗi (20 dòng đầu):\n", Color.DarkRed);
        //                foreach (var loi in loiChiTiet.Take(20))
        //                    rtbKetQua.AppendText($"• {loi}\n", Color.Maroon);
        //            }

        //            MessageBox.Show($"Đã thêm thành công {thanhCong} sinh viên vào nhóm!",
        //                           "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void btnThemExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePathExcel))
            {
                MessageBox.Show("Vui lòng chọn file trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rtbKetQua.Clear();
            rtbKetQua.AppendText("Đang đọc file Excel và xử lý sinh viên...\n\n");

            try
            {
                using (var workbook = new XLWorkbook(filePathExcel))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.LastRowUsed().RowNumber();

                    int thanhCong = 0;
                    int thatBai = 0;
                    var loiChiTiet = new List<string>();

                    // BIẾN GỘP THÔNG BÁO – SIÊU ĐẸP, SIÊU CHUYÊN NGHIỆP
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

                        rtbKetQua.AppendText($"Dòng {row}: MSSV = [{mssv}]\n");

                        if (string.IsNullOrWhiteSpace(mssv))
                        {
                            loiChiTiet.Add("• Dòng trống hoặc MSSV không hợp lệ");
                            thatBai++;
                            continue;
                        } 

                        UserDTO user = userBLL.GetUserByMSSV(mssv, true);

                        // 1. CHƯA TỒN TẠI → TẠO MỚI (nếu là Sinh viên)
                        if (user == null && role == 1)
                        {
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
                                rtbKetQua.AppendText($" → ĐÃ TẠO TÀI KHOẢN MỚI: {hoTen} ({mssv})\n", Color.Blue);
                            }
                            else
                            {
                                if (!emailHoacTenDangNhapTrung.Contains(mssv))
                                {
                                    emailHoacTenDangNhapTrung.Add(mssv);
                                    loiChiTiet.Add($"• {mssv} → Trùng email hoặc tên đăng nhập (và {emailHoacTenDangNhapTrung.Count} trường hợp khác)");
                                }
                                thatBai++;
                                continue;
                            }
                        }
                        else if (user != null)
                        {
                            rtbKetQua.AppendText($" → ĐÃ TỒN TẠI: {user.HoTen} ({mssv})\n", Color.Orange);
                        }
                        else
                        {
                            if (!khongPhaiSinhVien.Contains(mssv))
                            {
                                khongPhaiSinhVien.Add(mssv);
                                loiChiTiet.Add($"• {mssv} → Không phải Sinh viên hoặc bị khóa (và {khongPhaiSinhVien.Count} trường hợp khác)");
                            }
                            thatBai++;
                            continue;
                        }

                        // 2. KIỂM TRA ROLE
                        if (user.Role != 1)
                        {
                            if (!khongPhaiSinhVien.Contains(mssv))
                            {
                                khongPhaiSinhVien.Add(mssv);
                                loiChiTiet.Add($"• {mssv} → Không phải Sinh viên (và {khongPhaiSinhVien.Count} trường hợp khác)");
                            }
                            thatBai++;
                            continue;
                        }

                        // 3. KIỂM TRA ĐÃ TRONG NHÓM CHƯA
                        if (ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(mssv, _maNhom))
                        {
                            if (!daCoTrongNhom.Contains(mssv))
                            {
                                daCoTrongNhom.Add(mssv);
                                loiChiTiet.Add($"• {mssv} → Đã có trong nhóm (và {daCoTrongNhom.Count - 1} sinh viên khác)");
                            }
                            thatBai++;
                            continue;
                        }

                        // 4. THÊM VÀO NHÓM
                        bool themOK = ChiTietNhomHocPhanBLL.ThemSinhVienVaoNhom(mssv, _maNhom);
                        if (themOK)
                        {
                            thanhCong++;
                            OnSinhVienAdded(user);
                            rtbKetQua.AppendText($" → ĐÃ THÊM VÀO NHÓM THÀNH CÔNG!\n", Color.Green);
                        }
                        else
                        {
                            loiHeThong.Add($"• {mssv} → Lỗi hệ thống khi thêm vào nhóm");
                            thatBai++;
                        }
                    }

                    // HIỂN THỊ KẾT QUẢ SIÊU ĐẸP
                    rtbKetQua.AppendText($"\nHOÀN TẤT!\n", Color.Navy);
                    rtbKetQua.AppendText($"Thành công: {thanhCong} sinh viên\n", Color.Green);
                    rtbKetQua.AppendText($"Thất bại: {thatBai} sinh viên\n\n", Color.Red);

                    if (loiChiTiet.Count > 0 || loiHeThong.Count > 0)
                    {
                        rtbKetQua.AppendText("Chi tiết lỗi:\n", Color.DarkRed);
                        foreach (var loi in loiChiTiet) rtbKetQua.AppendText($"{loi}\n", Color.Maroon);
                        foreach (var loi in loiHeThong) rtbKetQua.AppendText($"{loi}\n", Color.DarkRed);
                    }

                    MessageBox.Show(
                        $"Hoàn tất xử lý!\n\nThành công: {thanhCong} sinh viên\nThất bại: {thatBai} sinh viên",
                        "Kết quả import",
                        MessageBoxButtons.OK,
                        thanhCong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                    );
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
                rtbKetQua.Clear();
            }
        }
        

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
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
