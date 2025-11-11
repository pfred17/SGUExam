using BLL;
using DTO;
using GUI.Forms;
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
    public partial class UC_MonHoc : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        public UC_MonHoc(string userId)
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private List<MonHocDTO>? listMonHoc;
        public UC_MonHoc()
        {
            _userId = userId;
            InitializeComponent();
            SetupDataGridView();
            LoadMonHocData();
        }

        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvMonHoc.EnableHeadersVisualStyles = false;

            // Custom header
            dgvMonHoc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Custom cell
            dgvMonHoc.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvMonHoc.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dgvMonHoc.DefaultCellStyle.SelectionForeColor = Color.White;

            // Dòng xen kẽ
            dgvMonHoc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);

            // Border
            dgvMonHoc.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMonHoc.GridColor = Color.FromArgb(220, 230, 241);

            // Căn trái
            ten_mh.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Căn giữa
            ma_mh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            so_tin_chi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trang_thai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Custom style table
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToOrderColumns = false;
            dgvMonHoc.AllowUserToResizeColumns = false;
            dgvMonHoc.AllowUserToResizeRows = false;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.ReadOnly = true;

            // Đặt lại chiều rộng các cột
            ma_mh.Width = 100;
            ten_mh.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            so_tin_chi.Width = 100;
            trang_thai.Width = 200;
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

            foreach (var mh in data)
            {
                int rowIndex = dgvMonHoc.Rows.Add();

                var row = dgvMonHoc.Rows[rowIndex];

                row.Cells["ma_mh"].Value = mh.MaMH;
                row.Cells["ten_mh"].Value = mh.TenMH;
                row.Cells["so_tin_chi"].Value = mh.SoTinChi;
                row.Cells["trang_thai"].Value = mh.TrangThai;
            }

            ResizeGridToContent();
        }
        private void txtSearchMonHoc_TextChanged(object sender, EventArgs e)
        {
            if (listMonHoc == null) return;

            if (txtSearchMonHoc.Text == "Tìm kiếm môn học...") return;

            string keyword = txtSearchMonHoc.Text.Trim().ToLower();

            var filtered = listMonHoc
                .Where(mh => mh.TenMH.ToLower().Contains(keyword))
                .ToList();

            dgvMonHoc.Rows.Clear();

            DisplayData(filtered);
        }

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            frmAddMonHoc frm = new frmAddMonHoc();
            frm.ShowDialog();
            LoadMonHocData();
        }

        private void UcMonHoc_Load(object sender, EventArgs e)
        {
            listMonHoc = monHocBLL.ListMonHoc();
            DisplayData(listMonHoc);
        }
        public void LoadMonHocData()
        {
            listMonHoc = monHocBLL.ListMonHoc();
            DisplayData(listMonHoc);
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            dgvMonHoc.ClearSelection();
        }

        private void txtSearchMonHoc_Enter(object sender, EventArgs e)
        {
            if (txtSearchMonHoc.Text == "Tìm kiếm môn học...")
            {
                txtSearchMonHoc.Text = "";
                txtSearchMonHoc.ForeColor = Color.Black;
            }
        }

        private void txtSearchMonHoc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchMonHoc.Text))
            {
                txtSearchMonHoc.Text = "Tìm kiếm môn học...";
                txtSearchMonHoc.ForeColor = Color.Gray;
            }

            if (listMonHoc != null)
                DisplayData(listMonHoc);
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
