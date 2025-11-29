using BLL;
using DTO;
using GUI.modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace GUI.modules
{
    public partial class UC_CauHoi : UserControl
    {
        private readonly string _userId;
        private readonly CauHoiBLL _cauHoiBLL = new();
        private readonly MonHocBLL _monHocBLL = new();
        private readonly ChuongBLL _chuongBLL = new();

        private List<CauHoiDTO> filteredList = new(); // Dữ liệu đã lọc
        private UC_CauHoiTrungLap? _ucTrungLap;

        // Phân trang
        private int CurrentPage = 1;
        private int PageSize = 10;
        private int TotalPage = 1;
        private System.Windows.Forms.Timer? timerSearch = null;
        public UC_CauHoi(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();

            // Gán event
            LoadMonHoc();
            LoadDoKho();
            LoadData(1);
        }

        #region Load dữ liệu
        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvCauHoi.EnableHeadersVisualStyles = false;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvCauHoi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgvCauHoi.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvCauHoi.GridColor = Color.FromArgb(235, 240, 245);

            // Custom style table
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.AllowUserToOrderColumns = false;
            dgvCauHoi.AllowUserToResizeColumns = false;
            dgvCauHoi.AllowUserToResizeRows = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCauHoi.MultiSelect = false;
            dgvCauHoi.ReadOnly = true;
        }
        private void LoadMonHoc()
        {
            var list = _monHocBLL.GetAllMonHoc();
            list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn tất cả môn học" });
            SetComboBoxData(cbMonHoc, list, "TenMH", "MaMH", cbMonHoc_SelectedIndexChanged);
        }

        private void LoadDoKho()
        {
            cbDoKho.Items.Clear();
            cbDoKho.Items.AddRange(new object[] { "Tất cả", "Dễ", "Trung bình", "Khó" });
            cbDoKho.SelectedIndex = 0;
        }

        private void LoadChuongTheoMonHoc(long maMH)
        {
            var list = new List<ChuongDTO> { new ChuongDTO { MaChuong = 0, TenChuong = "Chọn tất cả chương" } };
            if (maMH > 0)
                list.AddRange(_chuongBLL.GetChuongByMonHoc(maMH));

            SetComboBoxData(cbChuong, list, "TenChuong", "MaChuong", cbChuong_SelectedIndexChanged);
        }

        private void SetComboBoxData<T>(ComboBox combo, List<T> list, string displayMember, string valueMember, EventHandler eventHandler)
        {
            combo.SelectedIndexChanged -= eventHandler;  // Tạm thời bỏ event để tránh gọi LoadData thừa khi gán DataSource
            combo.DataSource = list;                     // Gán danh sách dữ liệu vào ComboBox
            combo.DisplayMember = displayMember;         // Thuộc tính hiển thị trên ComboBox (vd: "TenMH")
            combo.ValueMember = valueMember;             // Thuộc tính giá trị ẩn (vd: "MaMH")
            combo.SelectedIndex = 0;                     // Mặc định chọn phần tử đầu tiên
            combo.SelectedIndexChanged += eventHandler;  // Gắn lại event handler
        }
        private void LoadData(int? page = null)
        {
            // Nếu có truyền page (từ nút prev/next), dùng nó. Không thì giữ trang hiện tại hoặc về 1 nếu đang filter
            CurrentPage = page ?? CurrentPage;
            CurrentPage = Math.Max(1, CurrentPage); // không để nhỏ hơn 1

            // Lấy điều kiện lọc
            long maMH = cbMonHoc.SelectedIndex > 0 && cbMonHoc.SelectedItem is MonHocDTO mon ? mon.MaMH : 0;
            long maChuong = cbChuong.SelectedIndex > 0 && cbChuong.SelectedItem is ChuongDTO chuong ? chuong.MaChuong : 0;
            string doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text.Trim();
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == "Nhập nội dung câu hỏi để tìm kiếm...") tuKhoa = "";

            // Lấy dữ liệu + lọc + loại trùng (giữ lại bản mới nhất theo MaCauHoi)
            filteredList = _cauHoiBLL.GetAllForDisplay(maMH, maChuong, doKho, tuKhoa)
                .GroupBy(c => CauHoiBLL.Normalize(c.NoiDung))// loại trùng chính xác nội dung
                .Select(g => g.OrderByDescending(x => x.MaCauHoi).First()) // giữ bản mới nhất
                .ToList();

            // Tính tổng trang
            TotalPage = (int)Math.Ceiling(filteredList.Count / (double)PageSize);
            CurrentPage = Math.Min(CurrentPage, TotalPage); // không để vượt quá TotalPage
            if (TotalPage == 0) TotalPage = 1;

            // Lấy dữ liệu phân trang
            var pagedData = filteredList
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            RenderGrid(pagedData);
            lblTrangHienTai.Text = $"Trang {CurrentPage}/{TotalPage}";

            // Disable/enable nút prev next
            btnTrangTruoc.Enabled = CurrentPage > 1;
            btnTrangSau.Enabled = CurrentPage < TotalPage;
        }
        public void dispkayTatCaCauHoiFromTrungLap()
        {
            LoadData(); // load lại toàn bộ câu hỏi
        }
        private void RenderGrid(List<CauHoiDTO> data)
        {
            dgvCauHoi.Rows.Clear();

            if (data == null || data.Count == 0)
            {
                int rowIndex = dgvCauHoi.Rows.Add();
                var row = dgvCauHoi.Rows[rowIndex];
                row.Cells["colNoiDung"].Value = "Không tìm thấy kết quả";
                row.Cells["colNoiDung"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["colNoiDung"].Style.ForeColor = Color.Gray;

                row.Cells["colID"].Value = "";
                row.Cells["colMonHoc"].Value = "";
                row.Cells["colDoKho"].Value = "";
                row.Cells["SuaCol"].Value = null;
                row.Cells["XoaCol"].Value = null;
                return;
            }

            foreach (var ch in data)
            {
                int rowIndex = dgvCauHoi.Rows.Add();
                var row = dgvCauHoi.Rows[rowIndex];
                row.Cells["colID"].Value = ch.MaCauHoi;
                row.Cells["colNoiDung"].Value = ch.NoiDung;
                row.Cells["colMonHoc"].Value = ch.TenMonHoc;
                row.Cells["colDoKho"].Value = ch.DoKho;
                row.Cells["SuaCol"].Value = Properties.Resources.icon_edit;
                row.Cells["XoaCol"].Value = Properties.Resources.icon_delete;
            }
        }

        #endregion

        #region Sự kiện UI
        private void txtTimKiem_TextChanged_LiveSearch(object sender, EventArgs e)
        {
            // Nếu đang hiển thị placeholder → không tìm
            if (txtTimKiem.Text == "Nhập nội dung câu hỏi để tìm kiếm...") return;

            // Hủy timer cũ
            timerSearch?.Stop();
            timerSearch?.Dispose();

            // Tạo timer mới
            timerSearch = new System.Windows.Forms.Timer
            {
                Interval = 300 // 300ms sau khi ngừng gõ mới tìm
            };

            timerSearch.Tick += (s, ev) =>
            {
                timerSearch.Stop();
                LoadData(1); // về trang 1 khi tìm kiếm mới
            };

            timerSearch.Start();
        }
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập nội dung câu hỏi để tìm kiếm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập nội dung câu hỏi để tìm kiếm...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoadData(1); // // bắt đầu từ trang 1 khi search
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadData();

        private void cbMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbMonHoc.SelectedItem is MonHocDTO monHoc)
                LoadChuongTheoMonHoc(monHoc.MaMH);
            LoadData(1);
        }

        private void cbChuong_SelectedIndexChanged(object? sender, EventArgs e) => LoadData(1);

        private void cbDoKho_SelectedIndexChanged(object? sender, EventArgs e) => LoadData(1);

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
                LoadData(CurrentPage - 1);
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPage)
                LoadData(CurrentPage + 1);
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            var frm = new frmThemCauHoi();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnTuDieuChinh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang phát triển...", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvCauHoi_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvCauHoi.Columns[e.ColumnIndex].Name;
            long maCH = Convert.ToInt64(dgvCauHoi.Rows[e.RowIndex].Cells["colID"].Value);

            if (colName == "SuaCol")
            {
                var frm = new frmSuaCauHoi(maCH); // truyền mã câu hỏi cần sửa
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            else if (colName == "XoaCol")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cauHoiBLL.Xoa(maCH);
                    LoadData();
                }
            }
        }

        // hàm này sẽ hiển thị tất cả câu hỏi khi ở form UC_CauHoi
        private void showAllCauHoi(object sender, EventArgs e) {
            // reset combobox 
            if(cbMonHoc.Items.Count >0)
                cbMonHoc.SelectedIndex = 0; // chọn tất cả môn học
            if (cbChuong.Items.Count > 0)
                cbChuong.SelectedIndex = 0;  // "Chọn tất cả chương"
            if (cbDoKho.Items.Count > 0)
                cbDoKho.SelectedIndex = 0;   // "Tất cả"
            // Reset textbox tìm kiếm
            txtTimKiem.Text = "Nhập nội dung câu hỏi để tìm kiếm...";
            txtTimKiem.ForeColor = Color.Gray;
        }
        private void cauHoiTrungLap_Click(object sender, EventArgs e) => ShowCauHoiTrungLap();

        #endregion

        #region Chuyển view UC

        private void ShowCauHoiTrungLap()
        {
            this.Visible = false; // ẩn UC_CauHoi hiện tại

            if (_ucTrungLap == null)
            {
                _ucTrungLap = new UC_CauHoiTrungLap(this); // Tạo mới UC_CauHoiTrungLap nếu chưa có
                _ucTrungLap.Dock = DockStyle.Fill;
                var parent = this.Parent;
                if (parent != null)
                    parent.Controls.Add(_ucTrungLap);
            }
            _ucTrungLap.Visible = true;
            _ucTrungLap.LoadDuLieu(); // Đảm bảo load lại dữ liệu khi chuyển view
        }

        #endregion

        // xóa chọn dòng khi click vào DataGridView
        private void dgvCauHoi_SelectionChanged(object sender, EventArgs e)
        {
            dgvCauHoi.ClearSelection();
        }
    }
}
