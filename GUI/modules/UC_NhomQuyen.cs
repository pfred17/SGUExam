using BLL;
using GUI.forms.nguoidung;
using GUI.forms.nhomquyen;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    public partial class UC_NhomQuyen : UserControl
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

        public UC_NhomQuyen(string userId)
        {
            _userId = userId;
            InitializeComponent();

            LoadDataForTable();
        }

        public void LoadDataForTable()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm...") keyword = "";

            //totalRecords = _userBLL.GetAllUsers().Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var roles = _roleBLL.getAllRolePaged(pageCurrent, pageSize, keyword);

            if (roles.Count() == 0)
            {
                MessageBox.Show(this, "Không tìm thấy nhóm quyền nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Text = "";
                return;
            }

            tblNhomQuyen.Rows.Clear();

            foreach (var role in roles)
            {

                tblNhomQuyen.Rows.Add(
                     role.MaNhomQuyen,
                     role.TenNhomQuyen,
                     role.SoNguoiDung,
                     Properties.Resources.icon_edit,
                     Properties.Resources.icon_delete
                );
            }
            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            tblNhomQuyen.Enabled = totalRecords > 0;
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
                txtSearch.Text = "Tìm kiếm...";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = "";
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageCurrent > 1)
            {
                pageCurrent--;
                LoadDataForTable();
            }
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
    }
}
