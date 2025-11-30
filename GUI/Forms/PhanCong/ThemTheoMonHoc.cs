using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.forms.PhanCong
{
    public partial class ThemTheoMonHoc : UserControl
    {
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();

        private BindingList<UserDTO>? bindingList; // dùng cho DataSource
        private Dictionary<string, bool>? checkedState = new Dictionary<string, bool>();

        private int pageCurrent = 1;      // Trang hiện tại
        private int pageSize = 5;       // Số dòng mỗi trang
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;
        public ThemTheoMonHoc()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }
        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgv.EnableHeadersVisualStyles = false;

            // Tắt tự động tạo cột
            dgv.AutoGenerateColumns = false;

            // Custom header
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Custom cell
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 12F);

            // Dòng xen kẽ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            // Bỏ viền header
            //dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            //Border
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dgvMonHoc.GridColor = Color.FromArgb(109, 115, 121);
            dgv.GridColor = Color.FromArgb(235, 240, 245);

            // Custom style table
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false;
        }
        private void ResizeGridToContent()
        {
            // Tính chiều cao
            int rowHeight = dgv.RowTemplate.Height;           // Chiều cao 1 dòng
            int headerHeight = dgv.ColumnHeadersHeight;       // Chiều cao header
            int rowCount = dgv.Rows.Count;                    // Số dòng dữ liệu
            int border = 2; // Đệm viền

            int totalHeight = headerHeight + (rowCount * rowHeight) + border;

            // Giới hạn tối thiểu (nếu không có dữ liệu)
            if (rowCount == 0)
                totalHeight = headerHeight + rowHeight + border; // Hiển thị 1 dòng trống nhẹ

            dgv.Height = totalHeight;
        }
        private void LoadComboBox()
        {
            var listMonHoc = _monHocBLL.GetAllMonHoc();
            listMonHoc.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn môn học cần phân công" });
            var displayList = listMonHoc
                .Select(mh => new
                {
                    Text = mh.MaMH == 0 ? mh.TenMH : $"{mh.MaMH} - {mh.TenMH}",
                    Value = mh.MaMH
                })
                .ToList();

            cbxMonHoc.DataSource = displayList;
            cbxMonHoc.DisplayMember = "Text";
            cbxMonHoc.ValueMember = "Value";
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.DropDownHeight = cbxMonHoc.ItemHeight * Math.Min(listMonHoc.Count, cbxMonHoc.MaxDropDownItems);
            cbxMonHoc.SelectedIndex = 0;
        }
        public void LoadData()
        {
            SaveCheckedState();

            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm giảng viên...") keyword = "";

            totalRecords = _phanCongBLL.GetTotalPhanCong(keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _userBLL.GetUserPaged(pageCurrent, pageSize, keyword);

            bindingList = new BindingList<UserDTO>(data);
            dgv.DataSource = bindingList;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MSSV"].Value?.ToString() is string MSSV)
                    row.Cells["CheckCol"].Value = checkedState.ContainsKey(MSSV) && checkedState[MSSV];
            }

            if (totalRecords == 0)
            {
                dgv.DataSource = null;
                dgv.Rows.Clear();
                var row = dgv.Rows[dgv.Rows.Add()];
                row.Cells["HoTen"].Value = "Không tìm thấy kết quả";
                row.Cells["HoTen"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["HoTen"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["HoTen"].Style.ForeColor = Color.Gray;
            }
            ResizeGridToContent();
            UpdatePageInfo();
        }
        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            dgv.Enabled = totalRecords > 0;
        }
        private void SaveCheckedState()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string MSSV = row.Cells["MSSV"].Value?.ToString() ?? "";
                bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value ?? false);
                checkedState[MSSV] = isChecked;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_debounceTimer != null)
                _debounceTimer.Dispose();

            _debounceTimer = new System.Threading.Timer(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    pageCurrent = 1;
                    LoadData();
                }));
            }, null, DebounceDelay, Timeout.Infinite);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm giảng viên...";
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageCurrent > 1)
            {
                pageCurrent--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageCurrent < totalPages)
            {
                pageCurrent++;
                LoadData();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["CheckCol"]?.Index) return;

            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["CheckCol"]?.Index) return;

            var row = dgv.Rows[e.RowIndex];
            string MSSV = row.Cells["MSSV"].Value?.ToString() ?? "";
            bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value ?? false);

            checkedState[MSSV] = isChecked;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SaveCheckedState();

            if (cbxMonHoc.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maMH = cbxMonHoc.SelectedValue?.ToString() ?? "";

            var selectedUser = bindingList?
                .Where(u => checkedState.ContainsKey(u.MSSV) && checkedState[u.MSSV])
                .ToList();

            if (selectedUser?.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                foreach (var u in selectedUser)
                {
                    _phanCongBLL.AddPhanCong(new PhanCongDTO
                    {
                        MaMonHoc = long.Parse(maMH),
                        MaNguoiDung = u.MSSV,
                    });
                    checkedState[u.MSSV] = false;
                }

                MessageBox.Show($"Đã phân công {selectedUser.Count} giảng viên cho môn học {cbxMonHoc.Text} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pageCurrent = 1;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
