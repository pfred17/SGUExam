
using DAL;
using DTO;

namespace BLL
{
    public class RolePermissionBLL
    {
        private readonly RolePermissionDAL _rolePermissionDAL = new RolePermissionDAL();
        private readonly RoleDAL _roleDAL = new RoleDAL();
        private readonly PermissionDAL _permissionDAL = new PermissionDAL();

        public bool CreateRolePermission(string ten_nhom_quyen, List<AddPermissionDTO> listAddPermission)
        {
            // 1. Tạo Nhóm Quyền Mới (Role)
            // Giả định _roleDAL.CreateRole(string) trả về RoleDTO chứa Mã Nhóm Quyền (MaNhomQuyen)
            var role = _roleDAL.CreateRole(ten_nhom_quyen);

            if (role == null)
            {
                // Tạo nhóm quyền thất bại
                return false;
            }

            // 2. KIỂM TRA: Nếu Nhóm Quyền được tạo thành công
            if (role != null && listAddPermission != null && listAddPermission.Count > 0)
            {
                // Lấy Mã Nhóm Quyền (MaNhomQuyen) vừa được tạo (Khóa chính mới)
                int ma_nhom_quyen = (int)role.MaNhomQuyen;

                // 3. Lặp qua danh sách Module có quyền được check
                foreach (var addPermission in listAddPermission)
                {
                    int ma_chuc_nang = addPermission.MaChucNang;

                    // 4. Lặp qua các quyền (Xem, Thêm, Sửa, Xóa) trong từng Module
                    foreach (var quyen in addPermission.Quyen_DuocPhep)
                    {
                        // quyen.Key là Mã Quyền (1, 2, 3, 4)
                        // quyen.Value là Trạng thái (1 hoặc 0, nhưng do bạn đã lọc nên chỉ là 1)

                        // Thực hiện thêm chi tiết quyền vào bảng RolePermission
                        // Tham số: (Mã Nhóm Quyền MỚI, Mã Chức Năng, Mã Quyền, Trạng thái)
                        var result = _rolePermissionDAL.CreateRolePermission(ma_nhom_quyen, ma_chuc_nang, quyen.Key, quyen.Value);

                        if (!result) return false;
                    }
                }
            }

            // Trả về đối tượng Role vừa tạo (hoặc null nếu lỗi ở bước 1)
            return true;
        }
    }
}
