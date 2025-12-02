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
    }
}
