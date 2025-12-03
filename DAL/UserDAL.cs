using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class UserDAL
    {
        private RoleDAL roleDAL = new RoleDAL();
        public UserDTO CheckLogin(string username, string password)
        {
            string query = "SELECT * FROM nguoi_dung WHERE ten_dang_nhap = @u AND mat_khau = @p";
            SqlParameter[] param =
            {
                new SqlParameter("@u", username),
                new SqlParameter("@p", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new UserDTO
            {
                MSSV = row["ma_nd"].ToString(),
                TenDangNhap = row["ten_dang_nhap"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                Email = row["email"].ToString(),
                Role = row["ma_nhom_quyen"].ToString(),
                GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }

        // Hàm lấy danh sách tất cả người dùng của hệ thống
        public List<UserDTO> getAllUsers()
        {
            string query = "SELECT * FROM nguoi_dung";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<UserDTO> users = new List<UserDTO>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new UserDTO
                {
                    MSSV = row["ma_nd"].ToString(),
                    TenDangNhap = row["ten_dang_nhap"].ToString(),
                    MatKhau = row["mat_khau"].ToString(),
                    HoTen = row["ho_ten"].ToString(),
                    Email = row["email"].ToString(),
                    Role = row["ma_nhom_quyen"].ToString(),
                    GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return users;
        }

        // Hàm tạo người dùng mới
        public bool CreateNewUser(UserDTO userDTO)
        {
            string query = @"INSERT INTO nguoi_dung  (ma_nd ,ten_dang_nhap, mat_khau, ho_ten, email, gioi_tinh, loai_nd, trang_thai)
                     VALUES (@MSSV, @TenDangNhap, @MatKhau, @HoTen, @Email, @GioiTinh, @LoaiNguoiDung, @TrangThai);
                    
                     INSERT INTO nguoi_dung_nhom_quyen (ma_nd, ma_nhom_quyen)
                    VALUES (@MSSV, @ma_nhom_quyen)
                    ";

            long roleId = roleDAL.getRoleIdByTenNhomQuyen(userDTO.Role);


            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", userDTO.MSSV),
                new SqlParameter("@TenDangNhap", userDTO.TenDangNhap),
                new SqlParameter("@MatKhau", userDTO.MatKhau),
                new SqlParameter("@HoTen", userDTO.HoTen),
                new SqlParameter("@Email", userDTO.Email),
                new SqlParameter("@GioiTinh", userDTO.GioiTinh),
                new SqlParameter("@LoaiNguoiDung", userDTO.Role),
                new SqlParameter("@TrangThai", userDTO.TrangThai),
                new SqlParameter("@ma_nhom_quyen", roleId)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rows > 0;
        }

        public UserDTO CreateUser(string username, string hoten, string password, string email)
        {
            // Thêm người dùng mới và set nhóm quyền cho người dùng

            string query = @"
                    INSERT INTO nguoi_dung (ma_nd, ten_dang_nhap, ho_ten, mat_khau, email, loai_nd, trang_thai)
                    VALUES (@mssv, @u, @h, @p, @e, 'Sinh viên', 1);

                    INSERT INTO nguoi_dung_nhom_quyen (ma_nd, ma_nhom_quyen)
                    VALUES (@mssv, 1);

                    SELECT * FROM nguoi_dung WHERE ten_dang_nhap = @u;
            ";
            SqlParameter[] param =
            {
                new SqlParameter("@mssv", username),
                new SqlParameter("@u", username),
                new SqlParameter("@h", hoten),
                new SqlParameter("@p", password),
                new SqlParameter("@e", email)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count == 0)
                return null;
            DataRow row = dt.Rows[0];
            return new UserDTO
            {
                MSSV = row["ma_nd"].ToString(),
                TenDangNhap = row["ten_dang_nhap"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                Email = row["email"].ToString(),
                Role = row["loai_nd"].ToString(),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }


        // Hàm cập nhật thông tin người dùng
        public bool UpdateUser(UserDTO user)
        {
            string query = @"UPDATE nguoi_dung 
                             SET ten_dang_nhap = @TenDangNhap, 
                                 mat_khau = @MatKhau, 
                                 ho_ten = @HoTen, 
                                 email = @Email, 
                                 gioi_tinh = @GioiTinh, 
                                 loai_nd = @LoaiNguoiDung
                             WHERE ma_nd = @MSSV";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", user.MSSV),
                new SqlParameter("@TenDangNhap", user.TenDangNhap),
                new SqlParameter("@MatKhau", user.MatKhau),
                new SqlParameter("@HoTen", user.HoTen),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@GioiTinh", user.GioiTinh),
                new SqlParameter("@LoaiNguoiDung", user.Role),
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // Hàm khóa người dùng
        public bool LockUser(string userId)
        {
            string query = "UPDATE nguoi_dung SET trang_thai = 0 WHERE ma_nd = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@id", userId)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param);
            return rows > 0;
        }

        public bool UpdatePassword(string email, string newPassword)
        {
            string query = "UPDATE nguoi_dung SET mat_khau = @p WHERE email = @e";
            SqlParameter[] param =
            {
            new SqlParameter("@p", newPassword),
            new SqlParameter("@e", email)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param); // cần viết thêm ExecuteNonQuery trong DatabaseHelper
            return rows > 0;
        }

        public bool EmailExists(string email)
        {
            string query = "SELECT * FROM nguoi_dung WHERE email = @e";
            SqlParameter[] param = {
                new SqlParameter("@e", email)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            return dt.Rows.Count > 0;
        }

        public UserDTO GetUserById(string userId)
        {
            string query = "SELECT * FROM nguoi_dung WHERE ma_nd = @id";
            SqlParameter[] param = {
                new SqlParameter("@id", userId)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count == 0)
                return null;
            DataRow row = dt.Rows[0];
            return new UserDTO
            {
                MSSV = row["ma_nd"].ToString(),
                TenDangNhap = row["ten_dang_nhap"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                Email = row["email"].ToString(),
                Role = row["ma_nhom_quyen"].ToString(),
                GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }

        public List<UserDTO> GetAllUserByRoleExcluding()
        {
            string query = @"
                SELECT 
                    nd.ma_nd,
                    nd.ho_ten,
                    nd.email,
                    nq.ten_nhom_quyen
                FROM nguoi_dung AS nd
                JOIN nguoi_dung_nhom_quyen AS ndnq ON ndnq.ma_nd = nd.ma_nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = ndnq.ma_nhom_quyen
                WHERE nq.ten_nhom_quyen != N'Quản trị' 
                    AND nq.ten_nhom_quyen != N'Sinh viên' 
                    AND nd.trang_thai = 1;
            ";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<UserDTO> list = new List<UserDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserDTO
                {
                    MSSV = row["ma_nd"].ToString() ?? "",
                    HoTen = row["ho_ten"].ToString() ?? "",
                    Email = row["email"].ToString() ?? "",
                    Role = row["ten_nhom_quyen"].ToString() ?? "",
                });
            }

            return list;
        }
        public List<UserDTO> GetUserPaged(int page, int pageSize, string? userId = null, string? keyword = null, int? trangThai = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT 
                    nd.ma_nd,
                    nd.ho_ten,
                    nd.email,
                    nq.ten_nhom_quyen
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                WHERE nq.ten_nhom_quyen != N'Sinh viên' 
                    AND nq.ten_nhom_quyen != N'Quản trị' 
                    AND (@keyword = '' OR nd.ho_ten LIKE N'%' + @keyword + N'%')      
            ";

            if(userId != null)
            {
                query += "AND nd.ma_nd != @userId";
            }
            if (trangThai != null)
            {
                query += " AND nd.trang_thai = @trang_thai";
            }

            query += @"
                ORDER BY nd.ma_nd
                OFFSET @offset ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";

            List<SqlParameter> parameters = new List<SqlParameter>{
                new("@keyword", keyword),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };

            if (userId != null)
            {
                parameters.Add(new SqlParameter("@userId", userId));
            }

            if (trangThai != null)
            {
                parameters.Add(new SqlParameter("@trang_thai", trangThai));
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            List<UserDTO> list = new List<UserDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserDTO
                {
                    MSSV = row["ma_nd"].ToString() ?? "",
                    HoTen = row["ho_ten"].ToString() ?? "",
                    Email = row["email"].ToString() ?? "",
                    Role = row["ten_nhom_quyen"].ToString() ?? "",
                });
            }

            return list;
        }

        public int GetTotalUser(string? userId = null, string? keyword = null, int? trangThai = null)
        {
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT COUNT(*) 
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                WHERE nq.ten_nhom_quyen != N'Sinh viên' 
                    AND nq.ten_nhom_quyen != N'Quản trị' 
                    AND (@keyword = '' OR nd.ho_ten LIKE N'%' + @keyword + N'%')            
            ";

            List<SqlParameter> parameters = new List<SqlParameter>{
                new("@keyword", keyword)
            };

            if (userId != null)
            {
                query += " AND nd.ma_nd != @userId";
                parameters.Add(new SqlParameter("userId", userId));
            }

            if (trangThai != null)
            {
                query += " AND nd.trang_thai = @trang_thai";
                parameters.Add(new SqlParameter("@trang_thai", trangThai));
            }

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray()));
        }
    }
}
