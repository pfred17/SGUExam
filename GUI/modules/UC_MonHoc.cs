using BLL;
using DTO;
using GUI.forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GUI.forms.MonHoc;

namespace GUI.modules
{
    public partial class UC_MonHoc : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();

        private int pageCurrent = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;
        public UC_MonHoc(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }
        private void SetupDataGridView()
        {
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMonHoc.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvMonHoc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            dgvMonHoc.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMonHoc.GridColor = Color.FromArgb(235, 240, 245);

            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToOrderColumns = false;
            dgvMonHoc.AllowUserToResizeColumns = false;
            dgvMonHoc.AllowUserToResizeRows = false;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.ReadOnly = true;
        }
        private void ResizeGridToContent()
        {
            int rowHeight = dgvMonHoc.RowTemplate.Height;
            int headerHeight = dgvMonHoc.ColumnHeadersHeight;
            int rowCount = dgvMonHoc.Rows.Count;
            int border = 2;

            int totalHeight = headerHeight + (rowCount * rowHeight) + border;
            if (rowCount == 0)
                totalHeight = headerHeight + rowHeight + border;

            dgvMonHoc.Height = totalHeight;
        }
        private void DisplayData(List<MonHocDTO> data)
        {
            dgvMonHoc.Rows.Clear();

            if (data == null || data.Count == 0)
            {
                int rowIndex = dgvMonHoc.Rows.Add();
                var row = dgvMonHoc.Rows[rowIndex];

                row.Cells["TenMonHoc"].Value = "Không tìm thấy kết quả";
                row.Cells["TenMonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["TenMonHoc"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["TenMonHoc"].Style.ForeColor = Color.FromArgb(120, 120, 120);

                row.Height = 50;

                row.Cells["MaMonHoc"].Value = "";
                row.Cells["SoTinChi"].Value = "";
                row.Cells["TrangThai"].Value = "";

            }

            foreach (var mh in data)
            {
                int rowIndex = dgvMonHoc.Rows.Add();
                var row = dgvMonHoc.Rows[rowIndex];

                row.Cells["MaMonHoc"].Value = mh.MaMH;
                row.Cells["TenMonHoc"].Value = mh.TenMH;
                row.Cells["SoTinChi"].Value = mh.SoTinChi;
                row.Cells["TrangThai"].Value = mh.TrangThai == 1 ? "Hoạt động" : "Chưa mở";
                row.Cells["DetailCol"].Value = Properties.Resources.icon_detail;
                row.Cells["EditCol"].Value = Properties.Resources.icon_edit;
                row.Cells["DeleteCol"].Value = Properties.Resources.icon_delete;
            }

            ResizeGridToContent();
        }
        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm môn học...") keyword = "";

            totalRecords = _monHocBLL.GetTotalMonHoc(keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _monHocBLL.GetMonHocPaged(pageCurrent, pageSize, keyword);

            DisplayData(data);

            lblPage.Text = $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
        }
        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            new ThemMonHoc().ShowDialog();
            LoadData();
        }
        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            dgvMonHoc.ClearSelection();
        }
        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dgvMonHoc.Columns[e.ColumnIndex].Name;
            if (col != "DetailCol" && col != "EditCol" && col != "DeleteCol") return;

            if (!long.TryParse(dgvMonHoc.Rows[e.RowIndex].Cells["MaMonHoc"].Value?.ToString(), out long maMH))
                return;

            var tenMon = dgvMonHoc.Rows[e.RowIndex].Cells["TenMonHoc"].Value?.ToString();

            if (col == "DetailCol")
                new ChiTietMonHoc(maMH).ShowDialog();

            else if (col == "EditCol")
            {
                var frm = new SuaMonHoc(maMH);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }

            else if (col == "DeleteCol")
            {
                if (_monHocBLL.IsMonHocReferenced(maMH))
                {
                    MessageBox.Show($"Dữ liệu môn {tenMon} có liên quan đến thông tin khác. Không thể xóa.", "Cảnh báo");
                    return;
                }

                if (MessageBox.Show($"Xoá môn học {tenMon}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _monHocBLL.DeleteMonHoc(maMH);
                    LoadData();
                }
            }
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm giảng viên, môn học...")
            {
                txtSearch.Text = "";
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
                txtSearch.Text = "Tìm kiếm môn học...";
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
        private void dgvMonHoc_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string col = dgvMonHoc.Columns[e.ColumnIndex].Name;
                dgvMonHoc.Cursor = (col == "DetailCol" || col == "EditCol" || col == "DeleteCol")
                    ? Cursors.Hand
                    : Cursors.Default;
            }
        }
    }
}