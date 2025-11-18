using BLL;
using GUI.forms.nguoidung;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    public partial class UC_NguoiDung : UserControl
    {

        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly UserBLL _userBLL = new UserBLL();
        public UC_NguoiDung(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void UC_NguoiDung_Load(object sender, EventArgs e)
        {
            loadPermission();
            loadDataForTable();
        }

        private void loadDataForTable()
        {
            List<DTO.UserDTO> users = _userBLL.GetAllUsers();
            tableNguoiDung.Rows.Clear();
            foreach (var user in users)
            {
                Guna2Button btnEdit = new Guna2Button
                {
                    Tag = user.MSSV,
                    Image = Properties.Resources.icon_dekiemtra,
                    Size = new Size(30, 30),
                };

                int rowIndex = tableNguoiDung.Rows.Add(
                    user.MSSV, user.HoTen,
                    user.Email, user.Role,
                    user.TrangThai == 1 ? "Hoạt động" : "Bị khóa",
                    Properties.Resources.icon_edit,
                    Properties.Resources.icon_delete);

                DataGridViewRow row = tableNguoiDung.Rows[rowIndex];
                DataGridViewCell cellTrangThai = row.Cells[4]; // cột trạng thái

                if (user.TrangThai == 1)
                {
                    cellTrangThai.Style.ForeColor = Color.Green;
                    cellTrangThai.Style.Font = new Font(tableNguoiDung.Font, FontStyle.Bold);
                }
                else
                {
                    cellTrangThai.Style.ForeColor = Color.Red;
                    cellTrangThai.Style.Font = new Font(tableNguoiDung.Font, FontStyle.Bold);
                }
            }
        }

        private void loadPermission()
        {
            //btnAdd.Visible = _permissionBLL.HasPermission(_userId, 8, "Thêm");
            //btnEdit.Visible = _permissionBLL.HasPermission(_userId, 8, "Sửa");
            //btnDelete.Visible = _permissionBLL.HasPermission(_userId, 8, "Xóa");
            //btnView.Visible = _permissionBLL.HasPermission(_userId, 8, "Xem");
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

            // === Khi click vào icon SỬA ===
            if (columnName == "editCol")
            {
                MessageBox.Show($"Bạn vừa bấm SỬA người dùng: {userName} (ID: {userId}, RowIndex: {e.RowIndex}, ColumnIndex: {e.ColumnIndex})",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Sua().Show();
            }

            // === Khi click vào icon XÓA ===
            else if (columnName == "deleteCol")
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn XÓA người dùng: {userName} (ID: {userId}) không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: gọi _userBLL.DeleteUser(userId);
                    // loadData();
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
