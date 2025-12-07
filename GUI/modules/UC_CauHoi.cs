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
using GUI.Forms.CauHoi;

namespace GUI.modules
{
    public partial class UC_CauHoi : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly CauHoiBLL _cauHoiBLL = new();
        private readonly MonHocBLL _monHocBLL = new();
        private readonly ChuongBLL _chuongBLL = new();

        private List<CauHoiDTO> filteredList = new(); // Dữ liệu đã lọc
        private UC_CauHoiTrungLap1? _ucTrungLap;

        private const string PLACEHOLDER = "Nhập nội dung câu hỏi để tìm kiếm...";
        // Phân trang
        private int CurrentPage = 1;
        private int PageSize = 10;
        private int TotalPage = 1;
        private System.Windows.Forms.Timer? timerSearch = null;
        public UC_CauHoi(string userId)
        {
            _userId = userId;
            InitializeComponent();
            //SetupDataGridView();

            loadPermission();

            // Gán event
            LoadMonHoc();
            LoadDoKho();
            LoadData(1);
        }

        private void loadPermission()
        {
            btnThemMoi.Visible = _permissionBLL.HasPermission(_userId, 2, "Thêm");
            dgvCauHoi.Columns["SuaCol"].Visible = _permissionBLL.HasPermission(_userId, 2, "Sửa");
            dgvCauHoi.Columns["XoaCol"].Visible = _permissionBLL.HasPermission(_userId, 2, "Xóa");
        }

        #region Load dữ liệu
        private void LoadMonHoc()
        {
            var list = _monHocBLL.GetAllMonHocByStatus(1);
            list.Insert(0, new MonHocDTO { MaMonHoc = 0, TenMonHoc = "Chọn tất cả môn học" });
            SetComboBoxData(cbMonHoc, list, "TenMonHoc", "MaMonHoc", cbMonHoc_SelectedIndexChanged);
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
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

            combo.SelectedIndexChanged -= eventHandler;  // Tạm thời bỏ event để tránh gọi LoadData thừa khi gán DataSource
            combo.DataSource = list;                     // Gán danh sách dữ liệu vào ComboBox
                     
            combo.SelectedIndex = 0;          
            combo.SelectedIndexChanged += eventHandler;  // Gắn lại event handler
        }
        private void LoadData(int? page = null)
        {
            CurrentPage = Math.Max(1, page ?? CurrentPage);

            var maMH = cbMonHoc.SelectedItem is MonHocDTO m && m.MaMonHoc > 0 ? m.MaMonHoc : 0;
            var maCh = cbChuong.SelectedItem is ChuongDTO c && c.MaChuong > 0 ? c.MaChuong : 0;
            var doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text;
            var keyword = txtTimKiem.Text == PLACEHOLDER ? "" : txtTimKiem.Text.Trim();

            filteredList = _cauHoiBLL.GetAllForDisplay(maMH, maCh, doKho, keyword)
                 .GroupBy(x => new { Key = CauHoiBLL.Normalize(x.NoiDung), x.MaMonHoc })
                .Select(g => g.OrderByDescending(x => x.MaCauHoi).First())
                .ToList();

            TotalPage = Math.Max(1, (int)Math.Ceiling(filteredList.Count / (double)PageSize));
            CurrentPage = Math.Min(CurrentPage, TotalPage);

            RenderGrid(filteredList
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList());

            lblTrangHienTai.Text = $"Trang {CurrentPage}/{TotalPage}";
            btnTrangTruoc.Enabled = CurrentPage > 1;
            btnTrangSau.Enabled = CurrentPage < TotalPage;
        }
        public void dispkayTatCaCauHoiFromTrungLap()
        {
            LoadData(); // load lại toàn bộ câu hỏi
        }
        private void RenderGrid(List<CauHoiDTO> list)
        {
            dgvCauHoi.Rows.Clear();

            if (list.Count == 0)
            {
                var row = dgvCauHoi.Rows[dgvCauHoi.Rows.Add()];
                row.Cells["colNoiDung"].Value = "Không tìm thấy kết quả";
                row.Cells["colNoiDung"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["colNoiDung"].Style.ForeColor = Color.Gray;
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                var x = list[i];
                dgvCauHoi.Rows.Add(
                    (CurrentPage - 1) * PageSize + i + 1, // số thứ tự
                    x.NoiDung,
                    x.TenMonHoc,
                    x.DoKho,
                    Properties.Resources.icon_edit,
                    Properties.Resources.icon_delete
                );
                // Lưu ID thật vào Tag của dòng để dùng khi sửa/xóa
                dgvCauHoi.Rows[i].Tag = x.MaCauHoi;
            }
        }

        #endregion

        #region Sự kiện UI
        private void txtTimKiem_TextChanged_LiveSearch(object s, EventArgs e)
        {
            if (txtTimKiem.Text == PLACEHOLDER) return;
            timerSearch?.Stop();
            timerSearch = new System.Windows.Forms.Timer { Interval = 300 };
            timerSearch.Tick += (a, b) => { timerSearch.Stop(); LoadData(1); };
            timerSearch.Start();
        }
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == PLACEHOLDER)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = PLACEHOLDER;
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
                LoadChuongTheoMonHoc(monHoc.MaMonHoc);
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
            var frm = new frmDieuChinhDoKho();
            if(frm.ShowDialog()== DialogResult.OK)
                LoadData();
        }

        private void dgvCauHoi_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvCauHoi.Columns[e.ColumnIndex].Name;
            // Lấy ID thật từ Tag
            long maCH = Convert.ToInt64(dgvCauHoi.Rows[e.RowIndex].Tag);

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
        private void showAllCauHoi(object sender, EventArgs e)
        {
            // reset combobox 
            if (cbMonHoc.Items.Count > 0)
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
                _ucTrungLap = new UC_CauHoiTrungLap1(this); // Tạo mới UC_CauHoiTrungLap nếu chưa có
                _ucTrungLap.Dock = DockStyle.Fill;
                var parent = this.Parent;
                if (parent != null)
                    parent.Controls.Add(_ucTrungLap);
            }
            _ucTrungLap.Visible = true;
        }

        #endregion

        // xóa chọn dòng khi click vào DataGridView
        private void dgvCauHoi_SelectionChanged(object sender, EventArgs e)
        {
            dgvCauHoi.ClearSelection();
        }
    }
}