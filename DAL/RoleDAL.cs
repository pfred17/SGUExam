using DTO;
using System;
using System.Data;

namespace DAL
{
    public class RoleDAL
    {
        public static List<RoleDTO> getAllRole()
        {
            string query = @"SELECT * FROM nhom_quyen";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new RoleDTO
                {
                    MaNhomQuyen = Convert.ToInt32(row["ma_nhom_quyen"]),
                    TenNhomQuyen = row["ten_nhom_quyen"].ToString(),
                    Modules = new List<ModulePermissionDTO>()
                });
            }
            return roles;
        }

        public long getRoleIdByTenNhomQuyen(string name)
        {
            List<RoleDTO> roles = getAllRole();
            foreach (RoleDTO role in roles)
            {
                if (role.TenNhomQuyen.Equals(name))
                    return role.MaNhomQuyen;
            }

            return 1; // Mặc định là SINH VIÊN
        }
    }
}
