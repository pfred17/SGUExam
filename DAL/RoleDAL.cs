using DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RoleDAL
    {
        // Lấy tất cả nhóm quyền
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
                    Modules = new List<ModulePermissionDTO>(),
                });
            }
            return roles;
        }

        // Lấy tất cả nhóm quyền CÓ PHÂN TRANG và TÌM KIẾM
        public List<RoleDTO> getAllRolePaged(int page, int pageSize, string? keyword = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"SELECT 
                                nq.ma_nhom_quyen,
                                nq.ten_nhom_quyen,
                                COUNT(ndnq.ma_nd) AS SoNguoiDung
                            FROM nhom_quyen AS nq
                            LEFT JOIN nguoi_dung_nhom_quyen AS ndnq
                                ON nq.ma_nhom_quyen = ndnq.ma_nhom_quyen
                            WHERE (@keyword = '' OR nq.ten_nhom_quyen LIKE N'%' + @keyword + N'%')
                            GROUP BY 
                                nq.ma_nhom_quyen,
                                nq.ten_nhom_quyen
                            ORDER BY nq.ma_nhom_quyen 
                            OFFSET @offset ROWS
                            FETCH NEXT @pageSize ROWS ONLY";
            SqlParameter[] parameters =
            {
                new("@keyword", keyword),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new RoleDTO
                {
                    MaNhomQuyen = Convert.ToInt32(row["ma_nhom_quyen"]),
                    TenNhomQuyen = row["ten_nhom_quyen"].ToString(),
                    Modules = new List<ModulePermissionDTO>(),
                    SoNguoiDung = Convert.ToInt32(row["SoNguoiDung"]),
                });
            }
            return roles;
        }

        // Lấy RoleId từ Tên Nhóm Quyền
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

        // Tạo nhóm quyền mới
        public RoleDTO CreateRole(string tenNhomQuyen)
        {
            string query = @"INSERT INTO nhom_quyen (ten_nhom_quyen) 
                     VALUES (@tenNhomQuyen);
                     
                     SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters =
            {
                new("@tenNhomQuyen", tenNhomQuyen)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                int ma_nhom_quyen = Convert.ToInt32(result);

                return new RoleDTO
                {
                    MaNhomQuyen = ma_nhom_quyen,
                    TenNhomQuyen = tenNhomQuyen 
                };
            }

            return null;
        }
    }
}
