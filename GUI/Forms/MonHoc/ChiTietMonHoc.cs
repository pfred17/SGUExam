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
namespace GUI.forms.MonHoc
{
    public partial class ChiTietMonHoc : Form
    {
        private enum Mode { Add, Edit }
        private Mode currentMode;
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private readonly ChuongBLL chuongBLL = new ChuongBLL();
        private List<ChuongDTO>? listChuong;
        private ChuongDTO? editingChuong;
        private long _maMonHoc;

        private int pageSize = 5;       // Số dòng mỗi trang
        private int pageNumber = 1;      // Trang hiện tại
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang
        private List<ChuongDTO>? filteredList = null;
        public ChiTietMonHoc(long maMonHoc)
        {
            InitializeComponent();
            _maMonHoc = maMonHoc;
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvChuong.EnableHeadersVisualStyles = false;

            // Custom header
            dgvChuong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvChuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Custom cell
            dgvChuong.DefaultCellStyle.Font = new Font("Segoe UI", 12F);

            // Dòng xen kẽ
            dgvChuong.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            // Bỏ viền header
            //dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            //Border
            dgvChuong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvChuong.GridColor = Color.FromArgb(235, 240, 245);


            // Căn trái
            TenChuong.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Căn giữa
            MaChuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TenChuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Custom style table
            dgvChuong.AllowUserToAddRows = false;
            dgvChuong.AllowUserToOrderColumns = false;
            dgvChuong.AllowUserToResizeColumns = false;
            dgvChuong.AllowUserToResizeRows = false;
            dgvChuong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvChuong.MultiSelect = false;
            dgvChuong.ReadOnly = true;

            // Đặt lại chiều rộng các cột
            MaChuong.Width = 100;
            TenChuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EditCol.Width = 50;
            DeleteCol.Width = 50;
            EditCol.Resizable = DataGridViewTriState.False;
            DeleteCol.Resizable = DataGridViewTriState.False;
        }

        private void ResizeGridToContent()
        {
            // Tính chiều cao
            int rowHeight = dgvChuong.RowTemplate.Height;           // Chiều cao 1 dòng
            int headerHeight = dgvChuong.ColumnHeadersHeight;       // Chiều cao header
            int rowCount = dgvChuong.Rows.Count;                    // Số dòng dữ liệu
            int border = 2; // Đệm viền

            int totalHeight = headerHeight + (rowCount * rowHeight) + border;

            // Giới hạn tối thiểu (nếu không có dữ liệu)
            if (rowCount == 0)
                totalHeight = headerHeight + rowHeight + border; // Hiển thị 1 dòng trống nhẹ

            dgvChuong.Height = totalHeight;
        }

        private void DisplayData(List<ChuongDTO> data)
        {
            dgvChuong.Rows.Clear();

            foreach (var chuong in data)
            {
                int rowIndex = dgvChuong.Rows.Add();

                var row = dgvChuong.Rows[rowIndex];

                row.Cells["MaChuong"].Value = chuong.MaChuong;
                row.Cells["TenChuong"].Value = chuong.TenChuong;
                row.Cells["EditCol"].Value = Properties.Resources.icon_edit;
                row.Cells["DeleteCol"].Value = Properties.Resources.icon_delete;
            }
            ResizeGridToContent();
        }

        private void LoadData()
        {
            pageNumber = 1;
            listChuong = chuongBLL.GetChuongByMonHoc(_maMonHoc);   // lấy dữ liệu gốc để TÌM KIẾM
            filteredList = null;                   // không lọc
            LoadPage();                            // hiển thị 5 dòng đầu
        }

        private void LoadPage()
        {
            List<ChuongDTO> dataToDisplay;

            // Nếu không có tìm kiếm → phân trang trong DB
            if (filteredList == null)
            {
                totalRecords = chuongBLL.GetTotalChuongByMonHoc(_maMonHoc);
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                dataToDisplay = totalRecords > 0
                    ? chuongBLL.GetChuongPaged(_maMonHoc, pageNumber, pageSize)
                    : new List<ChuongDTO>();
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
            lblPage.Text = $"{pageNumber} / {totalPages}";
            btnPrev.Enabled = pageNumber > 1;
            btnNext.Enabled = pageNumber < totalPages;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvChuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = dgvChuong.Columns[e.ColumnIndex].Name;

            // Lấy ID của chương
            var maChuong = dgvChuong.Rows[e.RowIndex].Cells["MaChuong"].Value?.ToString();
            var tenChuong = dgvChuong.Rows[e.RowIndex].Cells["TenChuong"].Value?.ToString();

            if (columnName == "EditCol")
            {
                ShowInput(Mode.Edit, listChuong[e.RowIndex]);
            }
            if (columnName == "DeleteCol")
            {
                DialogResult confirm = MessageBox.Show($"Xoá chương {tenChuong}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    chuongBLL.DeleteChuong(long.Parse(maChuong));
                    LoadData();
                }
            }
        }

        private void dgvChuong_SelectionChanged(object sender, EventArgs e)
        {
            dgvChuong.ClearSelection();
        }

        private void dgvChuong_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvChuong.Columns[e.ColumnIndex].Name;

                // Nếu là cột sửa hoặc xóa => hiện bàn tay
                if (columnName == "EditCol" || columnName == "DeleteCol")
                {
                    dgvChuong.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvChuong.Cursor = Cursors.Default;
                }
            }
        }

        private void ShowInput(Mode mode, ChuongDTO? chuong = null)
        {
            currentMode = mode;
            editingChuong = chuong;
            if (mode == Mode.Add)
            {
                txtInput.Text = "";
                btnSubmit.Text = "Thêm";
            }
            else if (mode == Mode.Edit && chuong != null)
            {
                txtInput.Text = chuong.TenChuong;
                btnSubmit.Text = "Lưu";
            }

            txtInput.Focus();
        }

        private void lblThemChuong_Click(object sender, EventArgs e)
        {
            ShowInput(Mode.Add);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string ten = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(ten)) return;

            if (currentMode == Mode.Add)
            {
                ChuongDTO newChuong = new ChuongDTO
                {
                    TenChuong = ten
                };
                chuongBLL.AddChuong(newChuong, _maMonHoc);
                LoadData();
            }
            else if (currentMode == Mode.Edit && editingChuong != null)
            {
                editingChuong.TenChuong = ten;
                chuongBLL.UpdateChuong(editingChuong);
            }

            LoadData();
            txtInput.Text = "";
            btnSubmit.Text = "Thêm";
            currentMode = Mode.Add;
        }

        private void txtInputChuong_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtInputChuong_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                lblError.Text = "Tên chương không được để trống.";
                lblError.Visible = true;
            }
            else if (txtInput.Text.Length > 50)
            {
                lblError.Text = "Tên chương tối đa 50 ký tự.";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "";
                lblError.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            lblError.Visible = false;
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

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }
}
