using BLL;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GUI.forms.PhanCong
{
    public partial class ThemTheoGiangVien : UserControl
    {
        private readonly string _userId;
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();

        private BindingList<MonHocDTO> bindingList = new BindingList<MonHocDTO>();
        private Dictionary<long, bool> checkedState = new Dictionary<long, bool>();

        private int pageCurrent = 1;
        private int pageSize = 5;
        private int totalRecords = 0;
        private int totalPages = 0;

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;

        public ThemTheoGiangVien(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadComboBox();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoGenerateColumns = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.FromArgb(235, 240, 245);
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false;
        }

        private void LoadComboBox()
        {
            var listUser = _phanCongBLL.GetAllUserByRoleExcluding(_userId);
            listUser.Insert(0, new UserDTO { MSSV = "", HoTen = "Chọn giảng viên cần phân công" });

            var displayList = listUser
                .Select(u => new { Text = u.MSSV == "" ? u.HoTen : $"{u.MSSV} - {u.HoTen}", Value = u.MSSV })
                .ToList();

            cbxGiangVien.DataSource = displayList;
            cbxGiangVien.DisplayMember = "Text";
            cbxGiangVien.ValueMember = "Value";
            cbxGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGiangVien.MaxDropDownItems = 5;
            cbxGiangVien.DropDownHeight = cbxGiangVien.ItemHeight * Math.Min(listUser.Count, cbxGiangVien.MaxDropDownItems);
            cbxGiangVien.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm môn học...") keyword = "";

            totalRecords = _phanCongBLL.GetTotalMonHocForSelection(keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _phanCongBLL.GetMonHocForSelection(pageCurrent, pageSize, keyword);

            bindingList.Clear();

            if (data.Any())
            {
                foreach (var item in data)
                    bindingList.Add(item);
            }
            else
            {
                bindingList.Add(new MonHocDTO
                {
                    MaMonHoc = -1,
                    TenMonHoc = "Không tìm thấy kết quả"
                });
            }
            // reload UI
            dgv.DataSource = null;
            dgv.DataSource = bindingList;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MaMonHoc"].Value is long maMH)
                {
                    if (maMH == -1)
                    {
                        row.Cells["CheckCol"].ReadOnly = true;
                        row.Cells["CheckCol"].Value = false;
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                        row.Cells["TenMonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        row.Cells["CheckCol"].ReadOnly = false;
                        row.Cells["CheckCol"].Value = checkedState.ContainsKey(maMH) && checkedState[maMH];
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

        private void ResizeGridToContent()
        {
            int rowHeight = dgv.RowTemplate.Height;
            int headerHeight = dgv.ColumnHeadersHeight;
            int rowCount = dgv.Rows.Count;
            int border = 2;
            dgv.Height = headerHeight + (rowCount * rowHeight) + border;
        }

        private void SaveCheckedState()
        {
            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MaMonHoc"].Value == null) continue;
                long maMH = Convert.ToInt64(row.Cells["MaMonHoc"].Value);
                bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value ?? false);
                checkedState[maMH] = isChecked;
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SaveCheckedState();
            if (txtSearch.Text == "Tìm kiếm môn học...") txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            SaveCheckedState();
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) txtSearch.Text = "Tìm kiếm môn học...";
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();
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
            long maMH = Convert.ToInt64(row.Cells["MaMonHoc"].Value);
            bool isChecked = Convert.ToBoolean(row.Cells["CheckCol"].Value ?? false);
            checkedState[maMH] = isChecked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SaveCheckedState();

            if (cbxGiangVien.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maND = cbxGiangVien.SelectedValue?.ToString() ?? "";

            var selectedMaMH = checkedState
                .Where(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            if (selectedMaMH.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var maMH in selectedMaMH)
                {
                    var mh = _phanCongBLL.GetMonHocById(maMH);
                    if (mh != null)
                    {
                        _phanCongBLL.AddPhanCong(new PhanCongDTO
                        {
                            MaNguoiDung = maND,
                            MaMonHoc = mh.MaMonHoc,
                            TrangThai = 1
                        });
                    }
                    checkedState[maMH] = false;
                }


                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["CheckCol"] != null)
                        row.Cells["CheckCol"].Value = false;
                }

                LoadData();

                MessageBox.Show($"Đã phân công {selectedMaMH.Count} môn học cho giảng viên {cbxGiangVien.Text}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxGiangVien.SelectedIndex = 0;
                txtSearch.Text = "Tìm kiếm môn học...";
                pageCurrent = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
