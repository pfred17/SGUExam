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
using System.Xml.Linq;

namespace GUI.forms.PhanCong
{
    public partial class ThemTheoGiangVien : UserControl
    {
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();

        private List<UserDTO>? listUser;
        private List<MonHocDTO>? listMonHoc;
        private BindingList<MonHocDTO> bindingList; // dùng cho DataSource
        private Dictionary<long, bool> checkedState = new Dictionary<long, bool>();
        private List<MonHocDTO>? filteredList;

        private int pageSize = 5;       // Số dòng mỗi trang
        private int pageNumber = 1;      // Trang hiện tại
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang

        private System.Threading.Timer _debounceTimer;
        private const int DebounceDelay = 450;
        public ThemTheoGiangVien()
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
        public void LoadData()
        {
            pageNumber = 1;
            listMonHoc = _monHocBLL.GetAllMonHoc();
            filteredList = null;
            checkedState.Clear();
            bindingList = new BindingList<MonHocDTO>(listMonHoc);
            dgv.DataSource = bindingList;
            LoadComboBox();
            LoadPage();
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
            listUser = _userBLL.GetAllUserByRole();
            UserDTO defaultUser = new UserDTO
            {
                MSSV = "",
                HoTen = "Chọn giảng viên cần phân công"
            };
            listUser.Insert(0, defaultUser);
            var displayList = listUser
                .Select(u => new 
                { 
                    Text = u.MSSV == "" ? u.HoTen : $"{u.MSSV} - {u.HoTen}", 
                    Value = u.MSSV 
                })
                .ToList();
            cbxGiangVien.DataSource = displayList;
            cbxGiangVien.DisplayMember = "Text";
            cbxGiangVien.ValueMember = "Value";
            cbxGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGiangVien.MaxDropDownItems = 5;
            cbxGiangVien.DropDownHeight = cbxGiangVien.ItemHeight * Math.Min(listUser.Count, cbxGiangVien.MaxDropDownItems);
            cbxGiangVien.SelectedIndex = 0;
        }
        private void LoadPage()
        {
            SaveCheckedState();

            List<MonHocDTO> dataToDisplay;

            if (filteredList == null)
            {
                totalRecords = _monHocBLL.GetTotalMonHoc();
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                dataToDisplay = totalRecords > 0
                    ? _monHocBLL.GetMonHocPaged(pageNumber, pageSize)
                    : new List<MonHocDTO>();
            }
            else
            {
                totalRecords = filteredList.Count;
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                dataToDisplay = filteredList
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            bindingList = new BindingList<MonHocDTO>(dataToDisplay);
            dgv.DataSource = bindingList;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MaMonHoc"].Value is long maMH)
                {
                    row.Cells["CheckCol"].Value = checkedState.ContainsKey(maMH) && checkedState[maMH];
                }
            }

            if (dataToDisplay.Count == 0)
            {
                dgv.DataSource = null;
                dgv.Rows.Clear();
                var row = dgv.Rows[dgv.Rows.Add()];
                row.Cells["TenMonHoc"].Value = "Không tìm thấy kết quả";
                row.Cells["TenMonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["TenMonHoc"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["TenMonHoc"].Style.ForeColor = Color.Gray;
            }
            ResizeGridToContent();
            UpdatePageInfo();
        }
        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageNumber} / {totalPages}";
            btnPrev.Enabled = pageNumber > 1;
            btnNext.Enabled = pageNumber < totalPages;
            dgv.Enabled = totalRecords > 0;
        }
        private void SaveCheckedState()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var cellValue = row.Cells["MaMonHoc"].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                    continue;

                long maMH = Convert.ToInt64(cellValue);
                bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value);

                checkedState[maMH] = isChecked;
            }
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                LoadPage();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber < totalPages)
            {
                pageNumber++;
                LoadPage();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (listMonHoc == null) return;

            if (txtSearch.Text == "Tìm kiếm môn học...")
            {
                txtSearch.Text = "";
            }
            // Huỷ timer cũ nếu người dùng vẫn đang gõ
            _debounceTimer?.Dispose();

            // Tạo timer mới (chạy 1 lần sau khi dừng gõ)
            _debounceTimer = new System.Threading.Timer(_ =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string keyword = txtSearch.Text.Trim().ToLower();
                    if (string.IsNullOrEmpty(keyword))
                    {
                        filteredList = null;
                    }
                    else
                    {
                        filteredList = listMonHoc
                            .Where(mh => mh.TenMonHoc.ToLower().Contains(keyword))
                            .ToList();
                    }
                    pageNumber = 1;
                    LoadPage();
                });
            }, null, DebounceDelay, Timeout.Infinite);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm môn học...";
                filteredList = null;
                pageNumber = 1;
                LoadPage();
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SaveCheckedState();
            if (cbxGiangVien.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maND = cbxGiangVien.SelectedValue.ToString();

            var sourceList = filteredList ?? listMonHoc;
            var selectedMonHoc = sourceList.Where(mh => checkedState.ContainsKey(mh.MaMonHoc) && checkedState[mh.MaMonHoc]).ToList();

            if (selectedMonHoc.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                foreach (var mh in selectedMonHoc)
                {
                    var phanCong = new PhanCongDTO
                    {
                        MaNguoiDung = maND,
                        MaMonHoc = mh.MaMonHoc,
                    };
                    _phanCongBLL.AddPhanCong(phanCong);
                }

                MessageBox.Show($"Đã phân công {selectedMonHoc.Count} môn học cho giảng viên {cbxGiangVien.Text} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var mh in selectedMonHoc)
                    checkedState[mh.MaMonHoc] = false;
                filteredList = null;
                txtSearch.Text = "Tìm kiếm môn học...";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["CheckCol"].Index) return;
            
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["CheckCol"].Index) return;

            var row = dgv.Rows[e.RowIndex];
            var maMHObj = row.Cells["MaMonHoc"].Value;
            if (maMHObj == null) return;

            long maMH = Convert.ToInt64(maMHObj);
            bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value);

            checkedState[maMH] = isChecked;
        }
    }
}
