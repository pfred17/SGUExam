using DTO;
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

        public bool UpdateRolePermission(long ma_nhom_quyen, int ma_chuc_nang, int ma_quyen, int duoc_phep)
        {
            string query = @"
                                UPDATE nhom_quyen_chuc_nang
                                SET duoc_phep = @duoc_phep
                                WHERE ma_nhom_quyen = @ma_nhom_quyen 
                                  AND ma_chuc_nang = @ma_chuc_nang
                                  AND ma_quyen = @ma_quyen
            ";


            SqlParameter[] parameters = {
                                new SqlParameter("@ma_nhom_quyen", ma_nhom_quyen),
                                new SqlParameter("@ma_chuc_nang", ma_chuc_nang),
                                new SqlParameter("@ma_quyen", ma_quyen),
                                new SqlParameter("@duoc_phep", duoc_phep)
                            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public List<PermissionDTO> GetAllPermissionAviableByRoleId(long roleId)
        {
            string query = @"
                SELECT cn.ma_chuc_nang, q.ten_quyen, nqcn.duoc_phep
                FROM nhom_quyen_chuc_nang nqcn
                JOIN chuc_nang cn ON nqcn.ma_chuc_nang = cn.ma_chuc_nang
                JOIN quyen q ON nqcn.ma_quyen = q.ma_quyen
                WHERE nqcn.ma_nhom_quyen = @RoleId AND nqcn.duoc_phep = 1";
            SqlParameter[] param = {
                new SqlParameter("@RoleId", roleId)
            };
            var dataTable = DatabaseHelper.ExecuteQuery(query, param);

            List<PermissionDTO> permissions = new List<PermissionDTO>();

            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                permissions.Add(new PermissionDTO
                {
                    MaChucNang = Convert.ToInt32(row["ma_chuc_nang"]),
                    Quyen = row["ten_quyen"].ToString(),
                    DuocPhep = Convert.ToInt32(row["duoc_phep"]) == 1 ? true : false
                });
            }
            return permissions;
        }

        public bool CheckExistPermission(long ma_nhom_quyen, int ma_chuc_nang, int ma_quyen)
        {
            string query = @"
                                SELECT COUNT(1)
                                FROM nhom_quyen_chuc_nang
                                WHERE ma_nhom_quyen = @ma_nhom_quyen 
                                  AND ma_chuc_nang = @ma_chuc_nang 
                                  AND ma_quyen = @ma_quyen
                            ";

            SqlParameter[] param = {
                                    new SqlParameter("@ma_nhom_quyen", ma_nhom_quyen),
                                    new SqlParameter("@ma_chuc_nang", ma_chuc_nang),
                                    new SqlParameter("@ma_quyen", ma_quyen)
                                };

            object result = DatabaseHelper.ExecuteScalar(query, param);

            int count = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

            return count > 0;
        }
    }
}
