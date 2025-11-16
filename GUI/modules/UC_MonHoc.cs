using BLL;
using DTO;
using GUI.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.forms.MonHoc;
namespace GUI.modules
{
    public partial class UC_MonHoc : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private List<MonHocDTO>? listMonHoc;

        private int pageSize = 10;       // Số dòng mỗi trang
        private int pageNumber = 1;      // Trang hiện tại
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang
        private List<MonHocDTO>? filteredList = null;
        public UC_MonHoc(string userId)
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvMonHoc.EnableHeadersVisualStyles = false;

            // Custom header
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Custom cell
            dgvMonHoc.DefaultCellStyle.Font = new Font("Segoe UI", 12F);

            // Dòng xen kẽ
            dgvMonHoc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            // Bỏ viền header
            //dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            //Border
            dgvMonHoc.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dgvMonHoc.GridColor = Color.FromArgb(109, 115, 121);
            dgvMonHoc.GridColor = Color.FromArgb(235, 240, 245);

            // Custom style table
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
            // Tính chiều cao
            int rowHeight = dgvMonHoc.RowTemplate.Height;           // Chiều cao 1 dòng
            int headerHeight = dgvMonHoc.ColumnHeadersHeight;       // Chiều cao header
            int rowCount = dgvMonHoc.Rows.Count;                    // Số dòng dữ liệu
            int border = 2; // Đệm viền

            int totalHeight = headerHeight + (rowCount * rowHeight) + border;

            // Giới hạn tối thiểu (nếu không có dữ liệu)
            if (rowCount == 0)
                totalHeight = headerHeight + rowHeight + border; // Hiển thị 1 dòng trống nhẹ

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
                row.Height = 50;

                row.Cells["TenMonHoc"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["TenMonHoc"].Style.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                row.Cells["TenMonHoc"].Style.ForeColor = Color.FromArgb(120, 120, 120);

                // Ẩn các cột khác
                row.Cells["MaMonHoc"].Value = "";
                row.Cells["SoTinChi"].Value = "";
                row.Cells["TrangThai"].Value = "";
                row.Cells["DetailCol"].Value = null;
                row.Cells["EditCol"].Value = null;
                row.Cells["DeleteCol"].Value = null;
            }
            else
            {
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
            }

            ResizeGridToContent();
        }

        public void LoadData()
        {
            pageNumber = 1;
            listMonHoc = _monHocBLL.GetAllMonHoc();   // lấy dữ liệu gốc để TÌM KIẾM
            filteredList = null;                   // không lọc
            LoadPage();                            // hiển thị 10 dòng đầu
        }
        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            ThemMonHoc frm = new ThemMonHoc();
            frm.ShowDialog();
            LoadData();
        }
        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            dgvMonHoc.ClearSelection();
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = dgvMonHoc.Columns[e.ColumnIndex].Name;

            // Lấy ID của môn học
            var maMonHoc = dgvMonHoc.Rows[e.RowIndex].Cells["MaMonHoc"].Value?.ToString();
            var tenMonHoc = dgvMonHoc.Rows[e.RowIndex].Cells["TenMonHoc"].Value?.ToString();

            if (columnName == "DetailCol")
            {
                ChiTietMonHoc frm = new ChiTietMonHoc(long.Parse(maMonHoc));
                frm.ShowDialog();
            }

            if (columnName == "EditCol")
            {
                SuaMonHoc frm = new SuaMonHoc(long.Parse(maMonHoc));
                frm.ShowDialog();
            }
            if (columnName == "DeleteCol")
            {
                DialogResult confirm = MessageBox.Show($"Xoá môn học {tenMonHoc}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _monHocBLL.DeleteMonHoc(long.Parse(maMonHoc));
                    LoadData();
                }
            }
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

        private System.Threading.Timer _debounceTimer;
        private const int DebounceDelay = 450;
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
                            .Where(mh => mh.TenMH.ToLower().Contains(keyword))
                            .ToList();
                    }

                    pageNumber = 1;
                    LoadPage();
                });
            }, null, DebounceDelay, Timeout.Infinite);
        }

        // Hiển thị Cursor.Hand khi hover vào cột Sửa hoặc Xóa
        private void dgvMonHoc_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvMonHoc.Columns[e.ColumnIndex].Name;
                if (columnName == "DetailCol" || columnName == "EditCol" || columnName == "DeleteCol")
                {
                    dgvMonHoc.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvMonHoc.Cursor = Cursors.Default;
                }
            }
        }
        private void LoadPage()
        {
            List<MonHocDTO> dataToDisplay;

            // Nếu không có tìm kiếm → phân trang trong DB
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
                dgvMonHoc.Enabled = false;
            }
            else
            {

                lblPage.Text = $"{pageNumber} / {totalPages}";
                btnPrev.Enabled = pageNumber > 1;
                btnNext.Enabled = pageNumber < totalPages;
                dgvMonHoc.Enabled = true;
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
    }
}
