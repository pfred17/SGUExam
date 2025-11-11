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
    }
}
