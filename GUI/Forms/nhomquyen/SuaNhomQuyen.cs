using BLL;
using BLL.Validator;
using DTO;

namespace GUI.forms.nhomquyen
{
    //public event EventHandler PermissionUpdated;
    public partial class SuaNhomQuyen : Form
    {
        public event EventHandler Callback;

        private readonly ChucNangBLL _chucNangBLL = new ChucNangBLL();
        private readonly RolePermissionBLL _rolePermissionBLL = new RolePermissionBLL();
        private long _roleId;
        private string _ten_nhom_quyen;
        public SuaNhomQuyen(long roleId, string ten_nhom_quyen)
        {
            _roleId = roleId;
            _ten_nhom_quyen = ten_nhom_quyen;
            InitializeComponent();
            loadDataForTable(_roleId);
        }

        public void loadDataForTable(long _roleId) // Thêm ID của Role để tải quyền
        {

            txtName.Text = _ten_nhom_quyen;

            // 1. Tải danh sách Chức Năng (Modules)
            var listChucNang = _chucNangBLL.GetAllChucNang();

            // 2. Tải danh sách Quyền (Permissions) hiện tại của Role này
            // Giả sử bạn có hàm này:
            var currentRolePermissions = _rolePermissionBLL.GetAllPermissionAviableByRoleId(_roleId);

            tblSua.Rows.Clear();

            bool checkPermission1(int maChucNang) =>
            currentRolePermissions.Any(p =>
            p.MaChucNang == maChucNang &&
            p.DuocPhep);



            bool thamgiathi = checkPermission1(9);
            bool thamgiahocphan = checkPermission1(10);

            tsThamGiaThi.Checked = thamgiathi;
            tsThamGiaHocPhan.Checked = thamgiahocphan;

            foreach (var cn in listChucNang)
            {
                // ... (bỏ qua cn.MaChucNang == 9 || cn.MaChucNang == 10)
                if (cn.MaChucNang == 9 || cn.MaChucNang == 10) // Bỏ qua Chức Năng Quản Lý Quyền và Quản Lý Người Dùng
                    continue;
                // --- 3. KIỂM TRA QUYỀN VÀ GÁN GIÁ TRỊ CHECKBOX ---

                // Hàm trợ giúp để kiểm tra xem quyền cụ thể có được phép không
                bool checkPermission(string tenQuyen) =>
                    currentRolePermissions.Any(p =>
                        p.MaChucNang == cn.MaChucNang &&
                        p.Quyen == tenQuyen &&
                        p.DuocPhep);

                // Lấy trạng thái check của 4 quyền:
                bool xem = checkPermission("Xem");
                bool them = checkPermission("Thêm");
                bool sua = checkPermission("Sửa");
                bool xoa = checkPermission("Xóa");

                // --- 4. THÊM HÀNG VỚI GIÁ TRỊ CHECKBOX ---
                tblSua.Rows.Add(
                    cn.MaChucNang, // Cột 0: Mã Chức Năng
                    cn.TenChucNang, // Cột 1: Tên Chức Năng
                    xem,            // Cột 2: colXem (bool)
                    them,           // Cột 3: colThem (bool)
                    sua,            // Cột 4: colSua (bool)
                    xoa             // Cột 5: colXoa (bool)
                );
            }
        }

        public List<AddPermissionDTO> LayDanhSachQuyenTuDataGridView(DataGridView dgv)
        {
            List<AddPermissionDTO> danhSachQuyen = new List<AddPermissionDTO>();

            // Đã sửa: đảm bảo cả trạng thái 0 và 1 đều được thu thập
            string[] actionColumns = { "colXem", "colThem", "colSua", "colXoa" };

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                AddPermissionDTO dto = new AddPermissionDTO
                {
                    Quyen_DuocPhep = new Dictionary<int, int>()
                };

                try
                {
                    // Cột 0 là colId
                    object maChucNangValue = row.Cells[0].Value;
                    if (maChucNangValue == null || maChucNangValue == DBNull.Value) continue;

                    dto.MaChucNang = Convert.ToInt32(maChucNangValue);

                    // Bắt đầu từ cột 2 (colXem)
                    for (int i = 2; i < dgv.Columns.Count; i++)
                    {
                        string colName = dgv.Columns[i].Name;

                        // Chỉ xử lý các cột quyền
                        if (actionColumns.Contains(colName))
                        {
                            object cellValue = row.Cells[colName].Value;

                            // Lấy giá trị boolean từ Checkbox Cell
                            bool isChecked = (cellValue != null && cellValue != DBNull.Value) && (bool)cellValue;
                            int permissionValue = isChecked ? 1 : 0;

                            // Lấy Mã Quyền từ tên cột (colXem -> Xem)
                            string actionKey = colName.Substring(3);
                            int maQuyen = GetMaQuyen(actionKey);

                            if (maQuyen > 0)
                            {
                                // Thêm tất cả trạng thái (1 hoặc 0)
                                dto.Quyen_DuocPhep.Add(maQuyen, permissionValue);
                            }
                        }
                    }

                    if (dto.Quyen_DuocPhep.Count > 0)
                    {
                        danhSachQuyen.Add(dto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý hàng DataGridView: {ex.Message}");
                }
            }
            return danhSachQuyen;
        }
        private int GetMaQuyen(string actionName)
        {
            switch (actionName)
            {
                case "Xem": return 1;
                case "Them": return 2;
                case "Sua": return 3;
                case "Xoa": return 4;
                default: return 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ten_nhom_quyen_moi = txtName.Text;
            if (!InputValidator.IsValidName(ten_nhom_quyen_moi))
            {
                lbErrorTenNhomQuyen.Text = "Họ tên phải có độ dài trên 6 ký tự ";
                lbErrorTenNhomQuyen.Visible = true;
                txtName.Focus();
                return;
            }

            List<AddPermissionDTO> danhSachQuyen = LayDanhSachQuyenTuDataGridView(tblSua);
            if (danhSachQuyen.Count == 0 && !tsThamGiaThi.Checked && !tsThamGiaHocPhan.Checked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một quyền cho nhóm quyền.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddPermissionDTO thamGiaThi = new AddPermissionDTO
            {
                MaChucNang = 9,
                Quyen_DuocPhep = new Dictionary<int, int> { { 6, tsThamGiaThi.Checked ? 1 : 0 } }
            };
            danhSachQuyen.Add(thamGiaThi);

            AddPermissionDTO thamGiaHocPhan = new AddPermissionDTO
            {
                MaChucNang = 10,
                Quyen_DuocPhep = new Dictionary<int, int> { { 5, tsThamGiaHocPhan.Checked ? 1 : 0 } }
            };
            danhSachQuyen.Add(thamGiaHocPhan);

            if (!_rolePermissionBLL.UpdateRolePermission(_roleId, ten_nhom_quyen_moi, danhSachQuyen))
            {
                MessageBox.Show("Sửa nhóm quyền thất bại. Vui lòng kiểm tra log lỗi.", "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Sửa nhóm quyền thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Callback?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
