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
        private readonly string _userId;
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();

        private BindingList<UserDTO> bindingList = new BindingList<UserDTO>();
        private Dictionary<string, bool> checkedState = new Dictionary<string, bool>();

        private int pageCurrent = 1;      // Trang hiện tại
        private int pageSize = 5;       // Số dòng mỗi trang
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;
        public ThemTheoMonHoc(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadComboBox();
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
            var listMonHoc = _phanCongBLL.GetAllMonHocByStatus(1);
            listMonHoc.Insert(0, new MonHocDTO { MaMonHoc = 0, TenMonHoc = "Chọn môn học cần phân công" });
            var displayList = listMonHoc
                .Select(mh => new
                {
                    Text = mh.MaMonHoc == 0 ? mh.TenMonHoc : $"{mh.MaMonHoc} - {mh.TenMonHoc}",
                    Value = mh.MaMonHoc
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
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm giảng viên...") keyword = "";

            totalRecords = _phanCongBLL.GetTotalUserForSelection(_userId, keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _phanCongBLL.GetUSerForSelection(pageCurrent, pageSize, _userId, keyword);

            bindingList.Clear();

            if (data.Any())
            {
                foreach (var item in data)
                    bindingList.Add(item);
            }
            else
            {
                bindingList.Add(new UserDTO
                {
                    MSSV = "-1",
                    HoTen = "Không tìm thấy kết quả"
                });
            }
            // reload UI
            dgv.DataSource = null;
            dgv.DataSource = bindingList;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MSSV"].Value?.ToString() is string MSSV)
                {
                    if (MSSV == "-1")
                    {
                        row.Cells["CheckCol"].ReadOnly = true;
                        row.Cells["CheckCol"].Value = false;
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                        row.Cells["HoTen"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        row.Cells["CheckCol"].ReadOnly = false;
                        row.Cells["CheckCol"].Value = checkedState.ContainsKey(MSSV) && checkedState[MSSV];
                    }
                }
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
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SaveCheckedState();
            if (txtSearch.Text == "Tìm kiếm giảng viên...") txtSearch.Text = "";
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SaveCheckedState();

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
            SaveCheckedState();
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm giảng viên...";
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCheckedState();
            if (pageCurrent > 1)
            {
                pageCurrent--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCheckedState();
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

            var selectedUser = checkedState
             .Where(x => x.Value)
             .Select(x => x.Key)
             .ToList();

            if (selectedUser?.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var userId in selectedUser)
                {
                    var user = _phanCongBLL.GetUserById(userId);
                    if (user != null)
                        _phanCongBLL.AddPhanCong(new PhanCongDTO
                        {
                            MaMonHoc = long.Parse(maMH),
                            MaNguoiDung = user.MSSV,
                            TrangThai = 1
                        });
                    checkedState[user.MSSV] = false;
                }
                txtSearch.Text = "Tìm kiếm giảng viên...";
                pageCurrent = 1;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["CheckCol"] != null)
                        row.Cells["CheckCol"].Value = false;
                }

                LoadData();

                MessageBox.Show($"Đã phân công {selectedUser.Count} giảng viên cho môn học\n {cbxMonHoc.Text}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxMonHoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}