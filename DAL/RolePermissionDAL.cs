using Microsoft.Data.SqlClient;

namespace DAL
{
    public class RolePermissionDAL
    {


        // Thêm một chức năng (module) cho một nhóm quyền
        public bool CreateRolePermission(long ma_nhom_quyen, int ma_chuc_nang, int ma_quyen, int duoc_phep)
        {
            string query = @"INSERT INTO [nhom_quyen_chuc_nang] 
                                (ma_nhom_quyen, ma_chuc_nang, ma_quyen, duoc_phep) 
                            VALUES (@ma_nhom_quyen, @ma_chuc_nang, @ma_quyen, @duoc_phep)";

            SqlParameter[] parameters = {
                new SqlParameter("@ma_nhom_quyen", ma_nhom_quyen),
                new SqlParameter("@ma_chuc_nang", ma_chuc_nang),
                new SqlParameter("@ma_quyen", ma_quyen),
                new SqlParameter("@duoc_phep", duoc_phep)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);


            return result > 0;

        }

        public bool CreateRolePermissionSpecial(long ma_nhom_quyen, int ma_chuc_nang, int ma_quyen, int duoc_phep)
        {
            string query = @"INSERT INTO [nhom_quyen_chuc_nang] 
                                (ma_nhom_quyen, ma_chuc_nang, ma_quyen, duoc_phep) 
                            VALUES (@ma_nhom_quyen, @ma_chuc_nang, @ma_quyen, @duoc_phep)";

            SqlParameter[] parameters = {
                new SqlParameter("@ma_nhom_quyen", ma_nhom_quyen),
                new SqlParameter("@ma_chuc_nang", ma_chuc_nang),
                new SqlParameter("@ma_quyen", ma_quyen),
                new SqlParameter("@duoc_phep", duoc_phep)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);


            return result > 0;

        }
    }
}
