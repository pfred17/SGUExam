using BLL;
using DAL;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text;

namespace GUI.forms.nhomquyen
{
    public partial class ThemNhomQuyen : Form
    {
        public readonly RolePermissionBLL _rolePermissionBLL = new RolePermissionBLL();
        public readonly RoleBLL _roleBLL = new RoleBLL();
        public readonly PermissionBLL _permissionBLL = new PermissionBLL();
        public readonly ChucNangBLL _chucNangBLL = new ChucNangBLL();
        public event EventHandler UserAdded;

        public ThemNhomQuyen()
        {
            InitializeComponent();
            loadDataForTable();
            // Gán sự kiện cho nút Lưu (giả định tên là btnLuu)
            // Nếu bạn có nút Lưu, hãy tạo sự kiện Click cho nó.
            // this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
        }

        public void loadDataForTable()
        {
            var listChucNang = _chucNangBLL.GetAllChucNang();
            tblThem.Rows.Clear();

            // Khuyến nghị: Tạo 2 cột ẩn/hiện:
            // Cột 0: colMaChucNang (ẩn)
            // Cột 1: colTenChucNang (hiện)
            // Các cột tiếp theo: colXem, colThem, colSua, colXoa

            foreach (var cn in listChucNang)
            {
                if (cn.MaChucNang == 9 || cn.MaChucNang == 10) // Bỏ qua Chức Năng Quản Lý Quyền và Quản Lý Người Dùng
                    continue;
                // Thêm Mã Chức Năng vào cột đầu tiên (để có thể lấy ID khi lưu)
                // và Tên Chức Năng vào cột thứ hai
                tblThem.Rows.Add(
                    cn.MaChucNang, // Giá trị cột 0: Mã Chức Năng (ID)
                    cn.TenChucNang // Giá trị cột 1: Tên Chức Năng (Hiển thị)
                                   // ... các cột checkbox sẽ là False mặc định
                );
            }
        }

        public List<AddPermissionDTO> LayDanhSachQuyenTuDataGridView(DataGridView dgv)
        {
            List<AddPermissionDTO> danhSachQuyen = new List<AddPermissionDTO>();

            string[] actionColumns = { "colXem", "colThem", "colSua", "colXoa" };

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                AddPermissionDTO dto = new AddPermissionDTO();
                dto.Quyen_DuocPhep = new Dictionary<int, int>();

                try
                {
                    object maChucNangValue = row.Cells["colId"].Value;
                    if (maChucNangValue == null || maChucNangValue == DBNull.Value) continue;

                    dto.MaChucNang = Convert.ToInt32(maChucNangValue);

                    foreach (string colName in actionColumns)
                    {
                        object cellValue = row.Cells[colName].Value;

                        bool isChecked = (cellValue != null && cellValue != DBNull.Value) && (bool)cellValue;

                        int permissionValue = isChecked ? 1 : 0;

                        if (permissionValue == 1)
                        {
                            string actionKey = colName.Substring(3);
                            int maQuyen = GetMaQuyen(actionKey);

                            if (maQuyen > 0)
                            {
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
            List<AddPermissionDTO> danhSachQuyen = LayDanhSachQuyenTuDataGridView(tblThem);

            string ten_nhom_quyen = txtName.Text;

            if (tsThamGiaThi.Checked)
            {
                AddPermissionDTO thamGiaThi = new AddPermissionDTO
                {
                    MaChucNang = 9,
                    Quyen_DuocPhep = new Dictionary<int, int> { { 6, 1 } } // Quyền tham gia thi
                };
                danhSachQuyen.Add(thamGiaThi);
            }

            if (tsThamGiaHocPhan.Checked)
            {
                AddPermissionDTO thamGiaHocPhan = new AddPermissionDTO
                {
                    MaChucNang = 10,
                    Quyen_DuocPhep = new Dictionary<int, int> { { 5, 1 } } // Quyền tham gia học phần
                };
                danhSachQuyen.Add(thamGiaHocPhan);
            }

            if (!_rolePermissionBLL.CreateRolePermission(ten_nhom_quyen, danhSachQuyen))
            {
                MessageBox.Show("Thêm nhóm quyền thất bại", "Thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm nhóm quyền thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UserAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Nhập tên nhóm quyền...")
            {
                txtName.Text = "";
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Text = "Nhập tên nhóm quyền...";
        }
    }
}