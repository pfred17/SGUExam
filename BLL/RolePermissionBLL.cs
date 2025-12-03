
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
            var role = _roleDAL.CreateRole(ten_nhom_quyen);

            if (role == null)
            {
                return false;
            }

            if (role != null && listAddPermission != null && listAddPermission.Count > 0)
            {
                int ma_nhom_quyen = (int)role.MaNhomQuyen;

                foreach (var addPermission in listAddPermission)
                {
                    int ma_chuc_nang = addPermission.MaChucNang;

                    foreach (var quyen in addPermission.Quyen_DuocPhep)
                    {

                        var result = _rolePermissionDAL.CreateRolePermission(ma_nhom_quyen, ma_chuc_nang, quyen.Key, quyen.Value);

                        if (!result) return false;
                    }
                }
            }

            return true;
        }
        public bool UpdateRolePermission(long ma_nhom_quyen, string ten_nhom_quyen_moi, List<AddPermissionDTO> listAddPermission)
        {
            if (!_roleDAL.UpdateRoleName(ma_nhom_quyen, ten_nhom_quyen_moi))
            {
                return false;
            }

            bool success = true; // Theo dõi trạng thái thành công của việc cập nhật quyền

            // 1. Lặp qua từng Chức Năng (Module)
            foreach (var addPermission in listAddPermission)
            {
                int ma_chuc_nang = addPermission.MaChucNang;

                // 2. Lặp qua từng Quyền (Xem, Thêm, Sửa, Xóa, Tham gia,...)
                foreach (var quyen in addPermission.Quyen_DuocPhep)
                {
                    int ma_quyen = quyen.Key; // Mã Quyền (1, 2, 3, 4, 5, 6,...)
                    int duoc_phep = quyen.Value; // Trạng thái (1: Được phép | 0: Bị từ chối)

                    bool result = false;

                    if (_rolePermissionDAL.CheckExistPermission(ma_nhom_quyen, ma_chuc_nang, ma_quyen))
                    {
                        // Nếu tồn tại: Dùng UPDATE
                        result = _rolePermissionDAL.UpdateRolePermission(ma_nhom_quyen, ma_chuc_nang, ma_quyen, duoc_phep);
                    }
                    else
                    {
                        // Nếu chưa tồn tại: Dùng INSERT
                        result = _rolePermissionDAL.CreateRolePermission(ma_nhom_quyen, ma_chuc_nang, ma_quyen, duoc_phep);
                    }

                    // Nếu bất kỳ thao tác DAL nào thất bại, ghi nhận thất bại nhưng tiếp tục cập nhật các quyền khác
                    if (!result)
                    {
                        success = false;
                        // Nếu bạn muốn dừng ngay khi có lỗi, hãy thêm 'break;' hoặc 'return false;' ở đây
                    }
                }
            }

            // Trả về true nếu tên nhóm quyền được cập nhật và tất cả quyền được Upsert thành công
            return success;
        }

        public bool BlockRolePermission(long roleId)
        {
            return _roleDAL.BlockRole(roleId);
        }

        public List<PermissionDTO> GetAllPermissionAviableByRoleId(long roleId)
        {
            return _rolePermissionDAL.GetAllPermissionAviableByRoleId(roleId);
        }   
    }
}
