using BLL;
using DTO;
using GUI.forms.MonHoc;
using GUI.forms.PhanCong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_PhanCong : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();

        private int pageCurrent = 1;      // Trang hiện tại
        private int pageSize = 10;       // Số dòng mỗi trang
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;
        public UC_PhanCong(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }
        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvPhanCong.EnableHeadersVisualStyles = false;

            // Custom header
            dgvPhanCong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvPhanCong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Custom cell
            dgvPhanCong.DefaultCellStyle.Font = new Font("Segoe UI", 12F);

            // Dòng xen kẽ
            dgvPhanCong.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            // Bỏ viền header
            //dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            //Border
            dgvPhanCong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPhanCong.GridColor = Color.FromArgb(235, 240, 245);

            // Custom style table
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.AllowUserToOrderColumns = false;
            dgvPhanCong.AllowUserToResizeColumns = false;
            dgvPhanCong.AllowUserToResizeRows = false;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.ReadOnly = true;
        }
        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm giảng viên, môn học...") keyword = "";

            totalRecords = _phanCongBLL.GetTotalPhanCong(keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _phanCongBLL.getPhanCongPaged(pageCurrent, pageSize, keyword);

            DisplayData(data);

            lblPage.Text = $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
        }
        private void ResizeGridToContent()
        {
            // Tính chiều cao
            int rowHeight = dgvPhanCong.RowTemplate.Height;           // Chiều cao 1 dòng
            int headerHeight = dgvPhanCong.ColumnHeadersHeight;       // Chiều cao header
            int rowCount = dgvPhanCong.Rows.Count;                    // Số dòng dữ liệu
            int border = 2; // Đệm viền

            int totalHeight = headerHeight + (rowCount * rowHeight) + border;

            // Giới hạn tối thiểu (nếu không có dữ liệu)
            if (rowCount == 0)
                totalHeight = headerHeight + rowHeight + border; // Hiển thị 1 dòng trống nhẹ

            dgvPhanCong.Height = totalHeight;
        }
        private void DisplayData(List<PhanCongDTO> data)
        {
            dgvPhanCong.Rows.Clear();

            if (data == null || data.Count == 0)
            {
                int rowIndex = dgvPhanCong.Rows.Add();
                var row = dgvPhanCong.Rows[rowIndex];

                row.Cells["MonHoc"].Value = "Không tìm thấy kết quả";

                row.Cells["MonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["MonHoc"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["MonHoc"].Style.ForeColor = Color.FromArgb(120, 120, 120);

                row.Height = 50;

                row.Cells["MaPhanCong"].Value = "";
                row.Cells["MaMon"].Value = "";
                row.Cells["MaGiangVien"].Value = "";
                row.Cells["TenGiangVien"].Value = "";
                row.Cells["EditCol"].Value = null;
                row.Cells["DeleteCol"].Value = null;
            }

            foreach (var pc in data)
            {
                int rowIndex = dgvPhanCong.Rows.Add();
                var row = dgvPhanCong.Rows[rowIndex];

                row.Tag = pc;

                row.Cells["MaPhanCong"].Value = pc.MaPhanCong;
                row.Cells["MaMon"].Value = pc.MaMonHoc;
                row.Cells["MonHoc"].Value = pc.TenMonHoc;
                row.Cells["MaGiangVien"].Value = pc.MaNguoiDung;
                row.Cells["TenGiangVien"].Value = pc.TenNguoiDung;
                row.Cells["EditCol"].Value = Properties.Resources.icon_edit;
                row.Cells["DeleteCol"].Value = Properties.Resources.icon_delete;
            }

            ResizeGridToContent();
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
            {
                txtSearch.Text = "Tìm kiếm giảng viên, môn học...";
            }
        }
        private void dgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string col = dgvPhanCong.Columns[e.ColumnIndex].Name;

            if (col == "EditCol" || col == "DeleteCol")
            {
                string? maGiangVien = dgvPhanCong.Rows[e.RowIndex].Cells["MaGiangVien"].Value?.ToString();

                if (maGiangVien == _userId)
                {
                    MessageBox.Show("Bạn không thể thao tác!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var currentRow = dgvPhanCong.Rows[e.RowIndex];
                if (currentRow.Tag is PhanCongDTO dataItem)
                {
                    long maPC = dataItem.MaPhanCong;

                    if (col == "EditCol")
                    {

                        SuaPhanCong frm = new SuaPhanCong(maPC, _userId);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }

                    if (col == "DeleteCol")
                    {
                        if (_phanCongBLL.IsPhanCongReferenced(maPC))
                        {
                            MessageBox.Show($"Dữ liệu phân công có liên quan đến thông tin khác. Không thể xóa.", "Cảnh báo");
                            return;
                        }

                        if (MessageBox.Show($"Xoá mã phân công {maPC}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _phanCongBLL.DeletePhanCong(maPC);
                            LoadData();
                        }
                    }
                }
            }
        }
        private void dgvPhanCong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvPhanCong.Columns[e.ColumnIndex].Name == "EditCol" ||
                dgvPhanCong.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                string? maGiangVien = dgvPhanCong.Rows[e.RowIndex].Cells["MaGiangVien"].Value?.ToString();
                if (maGiangVien == _userId)
                {
                    e.Value = null;
                    return;
                }
            }
        }
        private void dgvPhanCong_SelectionChanged(object sender, EventArgs e)
        {

            dgvPhanCong.ClearSelection();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemPhanCong frm = new ThemPhanCong(_userId);
            frm.ShowDialog();
            LoadData();
        }
        private void dgvPhanCong_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvPhanCong.Columns[e.ColumnIndex].Name;

                if (columnName == "EditCol" || columnName == "DeleteCol")
                {
                    string? maGiangVien = dgvPhanCong.Rows[e.RowIndex].Cells["MaGiangVien"].Value?.ToString();

                    if (maGiangVien == _userId)
                        dgvPhanCong.Cursor = Cursors.Default;
                    else
                        dgvPhanCong.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvPhanCong.Cursor = Cursors.Default;
                }
            }
        }
    }
}
