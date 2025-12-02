using DAL;
using DTO;

namespace BLL
{
    public class RoleBLL
    {
        private RoleDAL roleDAL = new RoleDAL();

        public List<RoleDTO> getAllRole()
        {
            return RoleDAL.getAllRole();
        }

        public List<RoleDTO> getAllRolePaged(int page, int pageSize, string? keyword = null)
        {
            return roleDAL.getAllRolePaged(page, pageSize, keyword);
        }

        // // Lấy RoleDTO từ RoleId
        public RoleDTO GetRoleDTOById(int id)
        {
            List<RoleDTO> list = this.getAllRole();

            foreach (var role in list)
            {
                if (role.MaNhomQuyen == id)
                    return role;
            }

            return null;
        }

        public string GetRoleNameById(int id) 
        {
            List<RoleDTO> list = this.getAllRole();

            foreach(var role in list)
            {
                if (role.MaNhomQuyen == id)
                    return role.TenNhomQuyen;
            }

            return "";
        }

        public int GetRoleIdByName(string name)
        {
            List<RoleDTO> list = this.getAllRole();

            foreach (var role in list)
            {
                if (role.TenNhomQuyen == name)
                    return Convert.ToInt32(role.MaNhomQuyen);
            }

            return 0;
        }
    }
}
