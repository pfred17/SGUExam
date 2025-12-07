using BLL;
using ClosedXML.Excel;
using DAL;
using DTO;
using GUI.forms.hocphan;
using GUI.modules;
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
namespace GUI
{
    public partial class UC_SinhVienTrongNhom : UserControl
    {
        private int _currentPage = 1;
        private const int PageSize = 10;
        private int _totalRecords = 0;
        private List<DataRow> _allRows = new List<DataRow>(); // lưu toàn bộ dữ liệu (gốc + tìm kiếm)
        private UC_ThemSVVaoNhom ucThemSV;
        private NhomHocPhanDTO _nhom;
        private MonHocDTO _mon;
        private NhomHocPhanBLL _nhomHP;
        private readonly NhomHocPhanBLL _nhomBLL = new NhomHocPhanBLL();
        private long _maNhom;
        private DeThiBLL _deThi = new DeThiBLL();
        public void SetGroupInfo(NhomHocPhanDTO nhom)
        {
            _nhom = nhom;
            lbThongTinNhom.Text = $"{nhom.MaMonHoc} - {nhom.TenMonHoc} - {nhom.NamHoc} - {nhom.HocKy} - {nhom.TenNhom} - Mã nhóm: {nhom.MaNhom}";
            //lbThongTinNhom.Text = $"{nhom.MaMonHoc} - {nhom.TenMonHoc} - {nhom.NamHoc} - {nhom.HocKy} - {nhom.TenNhom} ";
            LoadDanhSachSinhVien(); // ← Tự động load lại danh sách thành viên
            lbThongTinNhomDeThi.Text = $"{nhom.MaMonHoc} - {nhom.TenMonHoc} - {nhom.NamHoc} - {nhom.HocKy} - {nhom.TenNhom}";

        }
        public UC_SinhVienTrongNhom()
        {
            InitializeComponent();
            SetupDataGridView(); // ← GỌI Ở ĐÂY
            dgvSinhVien.CellContentClick += dgvSinhVien_CellContentClick;
            // Tự động tìm khi gõ
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            if (_nhom == null)
            {
                MessageBox.Show("Chưa chọn nhóm học phần!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long maNhom = _nhom.MaNhom;

            frmChiTietDiem frm = new frmChiTietDiem(maNhom);
            frm.ShowDialog();   // ✅ đúng
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetupDataGridView()
        {
            // === CHỈ CẦN GỌI 1 LẦN TRONG CONSTRUCTOR HOẶC LOAD ===
            // Tắt style hệ thống để custom header
            dgvSinhVien.EnableHeadersVisualStyles = false;

            // Custom Header (đẹp như phần mềm xịn)
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSinhVien.ColumnHeadersHeight = 45;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Custom Cell
            dgvSinhVien.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvSinhVien.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgvSinhVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvSinhVien.DefaultCellStyle.SelectionForeColor = Color.White;

            // Dòng xen kẽ (rất đẹp mắt)
            dgvSinhVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 252, 255);
            dgvSinhVien.RowsDefaultCellStyle.BackColor = Color.White;

            // Border & Grid
            dgvSinhVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSinhVien.GridColor = Color.FromArgb(225, 235, 245);
            dgvSinhVien.BorderStyle = BorderStyle.None;

            // Căn giữa cột STT và Giới tính, nút Xóa
            dgvSinhVien.Columns["colSTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSinhVien.Columns["colGioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSinhVien.Columns["colHanhDong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tối ưu trải nghiệm người dùng
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AllowUserToOrderColumns = false;
            dgvSinhVien.AllowUserToResizeColumns = false;
            dgvSinhVien.AllowUserToResizeRows = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.RowHeadersVisible = false;

            // Hover effect khi di chuột (rất xịn)
            dgvSinhVien.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            if (ucThemSV == null)
            {
                ucThemSV = new UC_ThemSVVaoNhom(_nhom.MaNhom);
                ucThemSV.Width = 644;
                ucThemSV.Height = 347;
                ucThemSV.Location = new Point((this.Width - ucThemSV.Width) / 2, 50);
                this.Controls.Add(ucThemSV);
                ucThemSV.SinhVienAdded += UcThemSV_SinhVienAdded;
            }

            ucThemSV.Visible = true;
            ucThemSV.BringToFront();
        }
        private void UcThemSV_SinhVienAdded(object sender, UC_ThemSVVaoNhom.SinhVienAddedEventArgs e)
        {
            UserDTO user = e.User;
            bool isFromExcel = e.IsFromExcel;

            long maNhom = _nhom.MaNhom;
            if (!isFromExcel)
            {
                if (ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(user.MSSV, maNhom))
                {
                    MessageBox.Show("Sinh viên này đã có trong nhóm rồi!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(user.MSSV, maNhom))
            {
                return;
            }
            bool success = ChiTietNhomHocPhanBLL.ThemSinhVienVaoNhom(user.MSSV, maNhom);
            if (!success)
            {
                if (!isFromExcel)
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isFromExcel)
            {
                MessageBox.Show("Đã thêm sinh viên vào nhóm thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDanhSachSinhVien();
        }

        private void UC_SinhVienTrongNhom_Load(object sender, EventArgs e)
        {
            if (_nhom != null)
                LoadDanhSachSinhVien();
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvSinhVien.Columns["colHanhDong"].Index)
            {
                string mssv = dgvSinhVien.Rows[e.RowIndex].Cells["colMaSinhVien"]?.Value?.ToString()
                              ?? dgvSinhVien.Rows[e.RowIndex].Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(mssv))
                {
                    MessageBox.Show("Không xác định được sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận xóa
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sinh viên {mssv} khỏi nhóm này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    long maNhom = _nhom.MaNhom;

                    // XÓA TRONG SQL
                    bool deleted = ChiTietNhomHocPhanBLL.XoaSinhVienKhoiNhom(mssv, maNhom);

                    if (deleted)
                    {
                        MessageBox.Show("Đã xóa sinh viên khỏi nhóm thành công!", "Thành công",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachSinhVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Vui lòng thử lại.", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            // 2. Click vào icon con mắt → mở form chi tiết
            else if (e.ColumnIndex == dgvSinhVien.Columns["colChiTiet"].Index)
            {
                // Lấy MSSV từ dòng hiện tại (cột thứ 3 - index = 2)
                //string mssv = dgvSinhVien.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();

                string mssv = dgvSinhVien.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                long maNhom = _nhom.MaNhom; // cái này bạn đã có sẵn

                frmChiTietSinhVien frm = new frmChiTietSinhVien(mssv, maNhom);
                frm.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSinhVien(tbTimKiem.Text.Trim());
        }
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien(tbTimKiem.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        // Phân trang
        public void LoadDanhSachSinhVien()
        {
            if (_nhom == null) return;

            var dt = ChiTietNhomHocPhanBLL.LayDanhSachSinhVienTrongNhom(_nhom.MaNhom);
            _allRows = dt.AsEnumerable().ToList();
            _totalRecords = _allRows.Count;

            _currentPage = 1;
            HienThiTrangHienTai();
            CapNhatPhanTrang();
        }
        private void TimKiemSinhVien(string tuKhoa)
        {
            if (_nhom == null) return;

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadDanhSachSinhVien(); // load lại toàn bộ
                return;
            }

            var dt = ChiTietNhomHocPhanBLL.LayDanhSachSinhVienTrongNhom(_nhom.MaNhom);

            var rowsTimThay = dt.AsEnumerable()
                .Where(row =>
                    row["HoTen"].ToString().RemoveDiacritics()
                        .IndexOf(tuKhoa.RemoveDiacritics(), StringComparison.OrdinalIgnoreCase) >= 0 ||
                    row["MSSV"].ToString()
                        .IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

            _allRows = rowsTimThay;
            _totalRecords = _allRows.Count;
            _currentPage = 1;

            HienThiTrangHienTai();
            CapNhatPhanTrang();
        }
        private void HienThiTrangHienTai()
        {
            dgvSinhVien.Rows.Clear();

            var pageData = _allRows
                .Skip((_currentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            int stt = (_currentPage - 1) * PageSize + 1;
            foreach (var row in pageData)
            {
                dgvSinhVien.Rows.Add(
                    stt++,
                    row["HoTen"].ToString(),
                    row["MSSV"].ToString(),
                    Convert.ToInt32(row["GioiTinh"]) == 0 ? "Nam" : "Nữ",
                    "Xóa"
                );
            }
        }


        private void CapNhatPhanTrang()
        {
            int totalPages = _totalRecords == 0 ? 1 : (int)Math.Ceiling((double)_totalRecords / PageSize);
            lblPagination.Text = $" {_currentPage} / {totalPages}";
            lbTongSV.Text = $"Sỉ số: {_totalRecords}";
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;


        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                HienThiTrangHienTai();
                CapNhatPhanTrang();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);

            if (_currentPage < totalPages)
            {
                _currentPage++;
                HienThiTrangHienTai();
                CapNhatPhanTrang();
            }
        }

        private void BtnPage_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is int page)
            {
                _currentPage = page;
                HienThiTrangHienTai();
                CapNhatPhanTrang();
            }
        }

        private void lblPagination_Click(object sender, EventArgs e)
        {

        }

        private void flpPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            dgvSinhVien.ClearSelection();
        }

        private void btnXuatDL_Click(object sender, EventArgs e)
        {
            try
            {
                if (_nhom == null)
                {
                    MessageBox.Show("Không có nhóm để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy toàn bộ danh sách sinh viên trong nhóm (not paged)
                var dt = ChiTietNhomHocPhanBLL.LayDanhSachSinhVienTrongNhom(_nhom.MaNhom);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = $"{_nhom?.TenNhom ?? "DanhSach"}_{DateTime.Now:yyyyMMdd}.xlsx",
                    Title = "Lưu file Excel",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;
                string path = sfd.FileName;

                // Tạo workbook và worksheet, ghi dữ liệu
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("DanhSachSinhVien");

                    // Header cố định (thay / mở rộng nếu cần)
                    ws.Cell(1, 1).Value = "STT";
                    ws.Cell(1, 2).Value = "Họ tên";
                    ws.Cell(1, 3).Value = "MSSV";
                    ws.Cell(1, 4).Value = "Giới tính";
                    ws.Range(1, 1, 1, 4).Style.Font.SetBold();

                    int r = 2;
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        string hoTen = row["HoTen"]?.ToString() ?? string.Empty;
                        string mssv = row["MSSV"]?.ToString() ?? string.Empty;
                        int gioiTinh = 0;
                        if (row.Table.Columns.Contains("GioiTinh") && row["GioiTinh"] != DBNull.Value)
                        {
                            int.TryParse(row["GioiTinh"].ToString(), out gioiTinh);
                        }

                        ws.Cell(r, 1).Value = stt++;
                        ws.Cell(r, 2).Value = hoTen;

                        // Đặt MSSV là Text để giữ leading zeros
                        var cellMSSV = ws.Cell(r, 3);

                        // Write the MSSV as text and force Excel cell format to Text so leading zeros are preserved
                        cellMSSV.Value = mssv;
                        cellMSSV.Style.NumberFormat.Format = "@";

                        ws.Cell(r, 4).Value = gioiTinh == 0 ? "Nam" : "Nữ";

                        r++;
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(path);
                }

                // Mở Explorer và chọn file vừa lưu, đồng thời copy đường dẫn vào clipboard
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{path}\"");
                    Clipboard.SetText(path);
                }
                catch
                {
                    // fallback: thử mở file trực tiếp
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = path,
                            UseShellExecute = true
                        });
                    }
                    catch { /* ignore */ }
                }

                MessageBox.Show($"Xuất thành công.\nFile đã lưu: {path}\nĐường dẫn đã được copy vào clipboard.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbTongSV_Click(object sender, EventArgs e)
        {

        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            if (_nhom == null)
            {
                MessageBox.Show("Chưa chọn nhóm!");
                return;
            }

            panelDeThi.Visible = true;
            LoadDanhSachDeThiTheoNhom();
        }

        private void LoadDanhSachDeThiTheoNhom()
        {
            flowDeThi.Controls.Clear();

            List<DeThiDTO> danhSach = _deThi.LayDeThiCuaNhom(_nhom.MaNhom);

            foreach (var deThi in danhSach)
            {
                var card = TaoCardDeThiSinhVien(deThi);
                flowDeThi.Controls.Add(card);
            }
        }

        // Thay thế/ thêm vào trong UC_SinhVienTrongNhom
        private Control TaoCardDeThiSinhVien(DeThiDTO deThi)
        {
            // Panel chính (dùng Guna2Panel nếu bạn có thư viện, hoặc Panel tiêu chuẩn)
            var card = new Guna.UI2.WinForms.Guna2Panel
            {
                Width = 500,
                Height = 135,
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.LightGray,
                FillColor = Color.White,
                Margin = new Padding(15, 8, 8, 8),
                ShadowDecoration = { Enabled = true, Depth = 3 }
            };

            // Tiêu đề
            //var lblTitle = new Label
            //{
            //    Text = deThi.TenDe ?? "(Không tên đề)",
            //    Font = new Font("Segoe UI", 12, FontStyle.Bold),
            //    Location = new Point(15, 10),
            //    AutoSize = false,
            //    Width = card.Width - 30,
            //    Height = 35

            //};
            var lblTitle = new Label
            {
                Text = deThi.TenDe ?? "(Không tên đề)",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = false,
                Width = card.Width - 30,
                Height = 35,
                Cursor = Cursors.Hand,   // ✅ Biến thành tay khi hover
                Tag = deThi              // ✅ GẮN ĐỀ THI VÀO TAG
            };
            lblTitle.Click += LblTitle_Click;


            // Mô tả/nhóm (nếu muốn hiển thị tên nhóm)
            // var lblNhom = new Label { Text = deThi.TenNhomHocPhan ?? "", Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Location = new Point(15, 38), AutoSize = true };

            // Thời gian hiển thị (an toàn với null)
            string tg;
            if (deThi.ThoiGianBatDau.HasValue && deThi.ThoiGianKetThuc.HasValue)
                tg = $"{deThi.ThoiGianBatDau:dd/MM/yyyy HH:mm} → {deThi.ThoiGianKetThuc:dd/MM/yyyy HH:mm}";
            else if (deThi.ThoiGianBatDau.HasValue)
                tg = $"Bắt đầu: {deThi.ThoiGianBatDau:dd/MM/yyyy HH:mm}";
            else if (deThi.ThoiGianKetThuc.HasValue)
                tg = $"Kết thúc: {deThi.ThoiGianKetThuc:dd/MM/yyyy HH:mm}";
            else
                tg = "Chưa đặt thời gian";

            var lblTG = new Label
            {
                Text = tg,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(15, 44),
                AutoSize = false,
                Width = card.Width - 30,
                Height = 20
            };

            // Trạng thái
            var trangThaiText = deThi.TrangThai == 1 ? "Đang mở" : "Đã đóng";
            var lblTrangThai = new Label
            {
                Text = trangThaiText,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = deThi.TrangThai == 1 ? Color.FromArgb(21, 101, 192) : Color.FromArgb(198, 40, 40),
                Location = new Point(15, 70),
                AutoSize = true
            };

            // Nếu bạn muốn chỉ xem (không nút) thì không thêm button nào.
            // Nếu muốn click card để mở chi tiết, gắn event cho card.Click

            // Thêm control vào card
            card.Controls.Add(lblTitle);
            // card.Controls.Add(lblNhom); // nếu cần
            card.Controls.Add(lblTG);
            card.Controls.Add(lblTrangThai);

            // Optional: hover effect
            card.MouseEnter += (s, e) => card.FillColor = Color.FromArgb(250, 250, 250);
            card.MouseLeave += (s, e) => card.FillColor = Color.White;

            // Optional: khi click mở chi tiết (nếu muốn)
            // card.Click += (s, e) => OpenChiTietDeThi(deThi.MaDe);

            return card;
        }
        private void LblTitle_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl?.Tag is not DeThiDTO deThi) return;

            // Tìm MainForm cha và panelMain
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                var uc = new UC_ChiTietKiemTra(deThi.MaDe);

                var panelMain = mainForm.Controls["panelMain"];
                if (panelMain is Panel p)
                {
                    p.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    p.Controls.Add(uc);
                }
            }
        }



        private void btnClose_Click_1(object sender, EventArgs e)
        {
            // Tìm đúng Panel Dock=Right đang chứa nút Close
            Panel panelRight = this.FindForm()
                                    .Controls
                                    .Find("panelDeThi", true)
                                    .FirstOrDefault() as Panel;

            if (panelRight != null)
            {
                panelRight.Visible = false;   // ✅ ẨN ĐÚNG PANEL
            }
        }
    }
}