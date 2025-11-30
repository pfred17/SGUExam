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
        private readonly ChuongBLL _chuongBLL = new ChuongBLL();
        private List<ChuongDTO>? listChuong;
        private ChuongDTO? editingChuong;
        private long _maMonHoc;

        private int pageCurrent = 1;      // Trang hiện tại
        private int pageSize = 5;       // Số dòng mỗi trang
        private int totalRecords = 0;    // Tổng số bản ghi
        private int totalPages = 0;      // Tổng số trang
        public ChiTietMonHoc(long maMonHoc)
        {
            _maMonHoc = maMonHoc;
            InitializeComponent();
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

            //Border
            dgvChuong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvChuong.GridColor = Color.FromArgb(235, 240, 245);


            // Căn trái
            TenChuong.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Căn giữa
            MaChuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TenChuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

            // chiều cao row
            dgvChuong.RowTemplate.Height = 40;
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
            totalRecords = _chuongBLL.GetTotalChuongByMonHoc(_maMonHoc);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var data = _chuongBLL.GetChuongPaged(_maMonHoc, pageCurrent, pageSize);

            DisplayData(data);

            lblPage.Text = $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
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
                if (_chuongBLL.IsChuongReferenced(long.Parse(maChuong)))
                {
                    MessageBox.Show($"Dữ liệu chương {tenChuong} có liên quan đến thông tin khác. Không thể xóa.", "Cảnh báo");
                    return;
                }

                if (MessageBox.Show($"Xoá chương {tenChuong}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _chuongBLL.DeleteChuong(long.Parse(maChuong));
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
            txtInputChuong_Leave(sender, e);
            if (lblError.Visible)
            {
                txtInput.Focus();
                return;
            }

            string tenChuong = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(tenChuong)) return;

            if (currentMode == Mode.Add)
            {
                ChuongDTO newChuong = new ChuongDTO
                {
                    TenChuong = tenChuong
                };
                _chuongBLL.AddChuong(newChuong, _maMonHoc);
                LoadData();
            }
            else if (currentMode == Mode.Edit && editingChuong != null)
            {
                editingChuong.TenChuong = tenChuong;
                _chuongBLL.UpdateChuong(editingChuong);
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
            string input = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                lblError.Text = "Tên chương không được để trống.";
                lblError.Visible = true;
            }
            else if (_chuongBLL.IsChuongExists(input))
            {
                lblError.Text = "Tên chương đã tồn tại.";
                lblError.Visible = true;
            }
            else if (input.Length > 50)
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
    }
}
