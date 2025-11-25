using BLL;
using DTO;
using GUI.forms.MonHoc;
using GUI.forms.PhanCong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private List<PhanCongDTO>? listPhanCong;

        private int pageSize = 10;       // Số dòng mỗi trang
        private int pageNumber = 1;      // Trang hiện tại
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang
        private List<PhanCongDTO>? filteredList = null;
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
        public void LoadData()
        {
            pageNumber = 1;
            listPhanCong = _phanCongBLL.getAllPhanCong();   // lấy dữ liệu gốc để TÌM KIẾM
            filteredList = null;                   // không lọc
            LoadPage();                            // hiển thị 10 dòng đầu
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
                row.Height = 50;

                row.Cells["MonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["MonHoc"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["MonHoc"].Style.ForeColor = Color.FromArgb(120, 120, 120);

                // Ẩn các cột khác
                row.Cells["MaPhanCong"].Value = "";
                row.Cells["MaMon"].Value = "";
                row.Cells["MaGiangVien"].Value = "";
                row.Cells["TenGiangVien"].Value = "";
                row.Cells["EditCol"].Value = null;
                row.Cells["DeleteCol"].Value = null;
            }
            else
            {
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
            }

            ResizeGridToContent();
        }
        private void LoadPage()
        {
            List<PhanCongDTO> dataToDisplay;

            // Nếu không có tìm kiếm → phân trang trong DB
            if (filteredList == null)
            {
                totalRecords = _phanCongBLL.GetTotalPhanCong();
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                dataToDisplay = totalRecords > 0
                    ? _phanCongBLL.getPhanCongPaged(pageNumber, pageSize)
                    : new List<PhanCongDTO>();
            }
            else
            {
                // Có tìm kiếm → phân trang TRÊN LIST đã lọc
                totalRecords = filteredList.Count;
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                dataToDisplay = filteredList
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            }
            DisplayData(dataToDisplay);

            if (totalRecords == 0)
            {
                lblPage.Text = "0";
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                dgvPhanCong.Enabled = false;
            }
            else
            {

                lblPage.Text = $"{pageNumber} / {totalPages}";
                btnPrev.Enabled = pageNumber > 1;
                btnNext.Enabled = pageNumber < totalPages;
                dgvPhanCong.Enabled = true;
            }
        }

        private System.Threading.Timer _debounceTimer;
        private const int DebounceDelay = 450;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (listPhanCong == null) return;

            if (txtSearch.Text == "Tìm kiếm giảng viên, môn học...")
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
                        filteredList = listPhanCong
                            .Where(pc =>
                                pc.TenNguoiDung.ToLower().Contains(keyword) ||
                                pc.TenMonHoc.ToLower().Contains(keyword)
                            )
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
                txtSearch.Text = "Tìm kiếm giảng viên, môn học...";
                filteredList = null;
                pageNumber = 1;
                LoadPage();
            }
        }
        private void dgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = dgvPhanCong.Columns[e.ColumnIndex].Name;

            if (columnName == "EditCol" || columnName == "DeleteCol")
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
                    long maMH = dataItem.MaMonHoc;

                    if (columnName == "EditCol")
                    {

                        SuaPhanCong frm = new SuaPhanCong(maPC, maMH, _userId);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }

                    if (columnName == "DeleteCol")
                    {
                        DialogResult confirm = MessageBox.Show($"Xoá phân công {maPC}?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
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
