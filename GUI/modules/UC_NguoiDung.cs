using BLL;
using DAL;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using GUI.forms.nguoidung;
using Guna.UI2.WinForms;
using System.Collections.Generic;

namespace GUI.modules
{
    public partial class UC_NguoiDung : UserControl
    {

        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly RoleBLL _roleBLL = new RoleBLL();
        private readonly UserBLL _userBLL = new UserBLL();

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;

        private int pageCurrent = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        public UC_NguoiDung(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void UC_NguoiDung_Load(object sender, EventArgs e)
        {
            loadPermission();
            loadRoleData();
            loadDataForTable();
        }

        private void loadPermission()
        {
            guna2Button1.Visible = _permissionBLL.HasPermission(_userId, 8, "Thêm");
            tableNguoiDung.Columns["editCol"].Visible = _permissionBLL.HasPermission(_userId, 8, "Sửa");
            tableNguoiDung.Columns["deleteCol"].Visible = _permissionBLL.HasPermission(_userId, 8, "Xóa");
        }

        public void loadRoleData()
        {
            List<RoleDTO> roles = _roleBLL.getAllRole();

            List<RoleDTO> danhSachMoi = new List<RoleDTO>();

            // 1. Thêm mục "Tất cả" vào danh sách mới
            RoleDTO itemTatCa = new RoleDTO
            {
                MaNhomQuyen = 0,
                TenNhomQuyen = "Tất cả"
            };
            danhSachMoi.Add(itemTatCa);

            // 2. Thêm tất cả các mục từ danh sách gốc vào sau
            foreach (var role in roles)
            {
                if (role.TrangThai == 1)
                {
                    danhSachMoi.Add(role);
                }
            }

            // 3. Gán danh sách mới cho DataSource
            cbbFilter.DataSource = danhSachMoi;

            // 4. Thiết lập các thuộc tính hiển thị
            cbbFilter.DisplayMember = "TenNhomQuyen";
            cbbFilter.ValueMember = "MaNhomQuyen";

            // 5. Chọn mục đầu tiên ("Tất cả")
            cbbFilter.SelectedIndex = 0;
        }

        private void loadDataForTable()
        {

            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm...") keyword = "";

            int option = _roleBLL.GetRoleIdByName(cbbFilter.GetItemText(cbbFilter.SelectedItem));

            totalRecords = _userBLL.GetAllUsers().Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var users = _userBLL.GetUserPaged(pageCurrent, pageSize, keyword, option);

            tableNguoiDung.Rows.Clear();
            foreach (var user in users)
            {

                var roleDto = _roleBLL.GetRoleDTOById(user.Role);

                if (roleDto.TrangThai == 0 || user.MSSV == _userId) continue;


                int rowIndex = tableNguoiDung.Rows.Add(
                    user.MSSV, user.HoTen,
                    user.Email, _roleBLL.GetRoleNameById(user.Role),
                    user.TrangThai == 1 ? "Hoạt động" : "Bị khóa",
                    Properties.Resources.icon_edit,
                    Properties.Resources.icon_delete);

                DataGridViewRow row = tableNguoiDung.Rows[rowIndex];
                DataGridViewCell cellTrangThai = row.Cells[4]; // cột trạng thái

                if (user.TrangThai == 1)
                {
                    cellTrangThai.Style.ForeColor = System.Drawing.Color.Green;
                    cellTrangThai.Style.Font = new System.Drawing.Font(tableNguoiDung.Font, FontStyle.Bold);
                }
                else
                {
                    cellTrangThai.Style.ForeColor = System.Drawing.Color.Red;
                    cellTrangThai.Style.Font = new System.Drawing.Font(tableNguoiDung.Font, FontStyle.Bold);
                }
            }
            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            tableNguoiDung.Enabled = totalRecords > 0;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = tableNguoiDung.Columns[e.ColumnIndex].Name;

            // Lấy ID của người dùng
            var userId = tableNguoiDung.Rows[e.RowIndex].Cells["MaNguoiDung"].Value.ToString();
            var userName = tableNguoiDung.Rows[e.RowIndex].Cells["HoVaTen"].Value.ToString();
            var status = tableNguoiDung.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

            // === Khi click vào icon SỬA ===
            if (columnName == "editCol")
            {
                Sua formSua = new Sua(userId);

                // Đăng ký lắng nghe sự kiện UserAdded từ form Them
                formSua.UserUpdated += (s, ev) =>
                {
                    loadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
                };

                formSua.ShowDialog();
            }

            // === Khi click vào icon XÓA ===
            else if (columnName == "deleteCol")
            {
                if (status == "Hoạt động")
                {
                    var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn KHÓA người dùng: {userName} không?",
                    "Xác nhận khóa",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _userBLL.LockUser(userId, 0);
                            loadDataForTable();
                            MessageBox.Show("Đã khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn MỞ KHÓA người dùng: {userName} không?",
                    "Xác nhận khóa",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _userBLL.LockUser(userId, 1);
                            loadDataForTable();
                            MessageBox.Show("Đã mở khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }



            }
        }

        // Hiển thị Cursor.Hand khi hover vào cột Sửa hoặc Xóa
        private void guna2DataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = tableNguoiDung.Columns[e.ColumnIndex].Name;

                // Nếu là cột Sửa hoặc Xóa => hiện bàn tay
                if (columnName == "editCol" || columnName == "deleteCol")
                {
                    tableNguoiDung.Cursor = Cursors.Hand;
                }
                else
                {
                    tableNguoiDung.Cursor = Cursors.Default;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Them formThem = new Them();

            // Đăng ký lắng nghe sự kiện UserAdded từ form Them
            formThem.UserAdded += (s, ev) =>
            {
                loadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
            };

            formThem.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageCurrent < totalPages)
            {
                pageCurrent++;
                loadDataForTable();
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
                    loadDataForTable();
                }));
            }, null, DebounceDelay, Timeout.Infinite);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Tìm kiếm...";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = "";
            }
        }

        private void cbbFilter_ValueChanged(object sender, EventArgs e)
        {
            loadDataForTable();
        }

        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            if (pageCurrent > 1)
            {
                pageCurrent--;
                loadDataForTable();
            }
        }
    }
}
