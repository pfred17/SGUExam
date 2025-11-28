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

        public UC_CauHoi(string userId)
        {
            _userId = userId;
            InitializeComponent();

            // Gán event
            cbDoKho.SelectedIndexChanged += cbDoKho_SelectedIndexChanged;

            LoadMonHoc();
            LoadDoKho();
            LoadData();
        }

        #region Load dữ liệu

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
        private void LoadData()
        {
            long maMH = cbMonHoc.SelectedItem is MonHocDTO monHoc ? monHoc.MaMH : 0;
            long maChuong = cbChuong.SelectedItem is ChuongDTO chuong ? chuong.MaChuong : 0;
            string doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text.Trim();
            string tuKhoa = txtTimKiem.Text.Trim() == "Nhập nội dung câu hỏi để tìm kiếm..." ? "" : txtTimKiem.Text.Trim();

            filteredList = _cauHoiBLL.GetAllForDisplay(maMH, maChuong, doKho, tuKhoa)
                                      .GroupBy(c => (c.NoiDung ?? string.Empty).Trim())
                                      .Select(g => g.First())
                                      .ToList();
            RenderGrid(filteredList);
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
                LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadData();

        private void cbMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbMonHoc.SelectedItem is MonHocDTO monHoc)
                LoadChuongTheoMonHoc(monHoc.MaMH);
            LoadData();
        }

        private void cbChuong_SelectedIndexChanged(object? sender, EventArgs e) => LoadData();

        private void cbDoKho_SelectedIndexChanged(object? sender, EventArgs e) => LoadData();

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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        // xóa chọn dòng khi click vào DataGridView
        private void dgvCauHoi_SelectionChanged(object sender, EventArgs e)
        {
            dgvCauHoi.ClearSelection();
        }
    }
}
