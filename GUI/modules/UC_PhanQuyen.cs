using BLL;
using DocumentFormat.OpenXml.Wordprocessing;
using GUI.forms.nhomquyen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI.modules
{
    public partial class UC_PhanQuyen : UserControl
    {

        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly RoleBLL _roleBLL = new RoleBLL();

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;

        private int pageCurrent = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        public UC_PhanQuyen(string userId)
        {
            _userId = userId;
            InitializeComponent();
            loadPermission();
            LoadDataForTable();
        }
        private void loadPermission()
        {
            btnAdd.Visible = _permissionBLL.HasPermission(_userId, 7, "Thêm");
            tablePhanQuyen.Columns["EditCol"].Visible = _permissionBLL.HasPermission(_userId, 7, "Sửa");
            tablePhanQuyen.Columns["DeleteCol"].Visible = _permissionBLL.HasPermission(_userId, 7, "Xóa");
        }
        public void LoadDataForTable()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm...") keyword = "";

            totalRecords = _roleBLL.GetTotalActiveRolesCount(keyword);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var roles = _roleBLL.getAllRolePaged(pageCurrent, pageSize, keyword);

            tablePhanQuyen.Rows.Clear();

            foreach (var role in roles)
            {

                tablePhanQuyen.Rows.Add(
                     role.MaNhomQuyen,
                     role.TenNhomQuyen,
                     role.SoNguoiDung,
                     Properties.Resources.icon_edit,
                     Properties.Resources.icon_delete
                );
            }
            UpdatePageInfo();
        }

        private void tablePhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = tablePhanQuyen.Columns[e.ColumnIndex].Name;

            // Lấy ID của người dùng
            long roleId = Convert.ToInt32(tablePhanQuyen.Rows[e.RowIndex].Cells["MaNhomQuyen"].Value.ToString());
            string ten_nhom_quyen = tablePhanQuyen.Rows[e.RowIndex].Cells["TenNhomQuyen"].Value.ToString();

            // === Khi click vào icon SỬA ===
            if (columnName == "editCol")
            {
                SuaNhomQuyen formSua = new SuaNhomQuyen(roleId, ten_nhom_quyen);

                // Đăng ký lắng nghe sự kiện UserAdded từ form Them
                formSua.Callback += (s, ev) =>
                {
                    this.LoadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
                };

                formSua.ShowDialog();
            }
            else if (columnName == "deleteCol")
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhóm quyền: {ten_nhom_quyen} không?",
                    "Xác nhận khóa",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _roleBLL.BlockRole(roleId);
                        this.LoadDataForTable();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            tablePhanQuyen.Enabled = totalRecords > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemNhomQuyen themNhomQuyenForm = new ThemNhomQuyen();
            // Đăng ký lắng nghe sự kiện UserAdded từ form Them
            themNhomQuyenForm.UserAdded += (s, ev) =>
            {
                LoadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
            };

            themNhomQuyenForm.ShowDialog();
        }

        private void tablePhanQuyen_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = tablePhanQuyen.Columns[e.ColumnIndex].Name;

                // Nếu là cột Sửa hoặc Xóa => hiện bàn tay
                if (columnName == "editCol" || columnName == "deleteCol")
                {
                    tablePhanQuyen.Cursor = Cursors.Hand;
                }
                else
                {
                    tablePhanQuyen.Cursor = Cursors.Default;
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (pageCurrent > 1)
            {
                pageCurrent--;
                LoadDataForTable();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageCurrent < totalPages)
            {
                pageCurrent++;
                LoadDataForTable();
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
                    LoadDataForTable();
                }));
            }, null, DebounceDelay, Timeout.Infinite);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "";
            }
        }
    }
}
