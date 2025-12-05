using Azure;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserDAL
    {
        private static UserDAL instance;
        public static UserDAL Instance
        {
            get { if (instance == null) instance = new UserDAL(); return instance; }
            private set { instance = value; }
        }
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
                Role = Convert.ToInt32(row["ma_nhom_quyen"]),
                GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }

        // Lấy danh sách người dùng có phân trang
        public List<UserDTO> GetUserPaged(int page, int pageSize, string? keyword = null, int? option = 0)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT 
                    nd.ma_nd,
                    nd.ten_dang_nhap,
                    nd.mat_khau,
                    nd.ho_ten,
                    nd.email,
                    nd.ma_nhom_quyen,
                    nd.gioi_tinh,
                    nd.trang_thai,
                    nq.ten_nhom_quyen
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                WHERE
                    (
                        @keyword = '' 
                        OR nd.ho_ten LIKE N'%' + @keyword + N'%'
                        OR nd.ten_dang_nhap LIKE N'%' + @keyword + N'%'
                        OR nd.email LIKE N'%' + @keyword + N'%'
                        OR nq.ten_nhom_quyen LIKE N'%' + @keyword + N'%'
                    )
                    AND (@option = 0 OR nd.ma_nhom_quyen = @option)
                ORDER BY nd.ma_nd
                OFFSET @offset ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";

            SqlParameter[] parameters = {
                new("@keyword", keyword),
                new("@option", option),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<UserDTO> list = new List<UserDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserDTO
                {
                    MSSV = row["ma_nd"].ToString() ?? "",
                    TenDangNhap = row["ten_dang_nhap"].ToString() ?? "",
                    MatKhau = row["mat_khau"].ToString() ?? "",
                    HoTen = row["ho_ten"].ToString() ?? "",
                    Email = row["email"].ToString() ?? "",
                    GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"]),
                    Role = Convert.ToInt32(row["ma_nhom_quyen"])
                });
            }

            return list;
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
                    Role = Convert.ToInt32(row["ma_nhom_quyen"]),
                    GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return users;
        }

        // Hàm tạo người dùng mới
        public bool CreateNewUser(UserDTO userDTO)
        {
            string query = @"
                        INSERT INTO nguoi_dung  
                                        (ma_nd ,ten_dang_nhap, mat_khau, ho_ten, email, gioi_tinh, ma_nhom_quyen, trang_thai)
                        VALUES (@MSSV, @TenDangNhap, @MatKhau, @HoTen, @Email, @GioiTinh, @MaNhomQuyen, @TrangThai)";


            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", userDTO.MSSV),
                new SqlParameter("@TenDangNhap", userDTO.TenDangNhap),
                new SqlParameter("@MatKhau", userDTO.MatKhau),
                new SqlParameter("@HoTen", userDTO.HoTen),
                new SqlParameter("@Email", userDTO.Email),
                new SqlParameter("@GioiTinh", userDTO.GioiTinh),
                new SqlParameter("@MaNhomQuyen", userDTO.Role),
                new SqlParameter("@TrangThai", userDTO.TrangThai)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rows > 0;
        }

        public UserDTO CreateUser(string username, string hoten, string password, string email)
        {
            // Thêm người dùng mới và set nhóm quyền cho người dùng

            string query = @"
                    INSERT INTO nguoi_dung (ma_nd, ten_dang_nhap, ho_ten, mat_khau, email, ma_nhom_quyen, trang_thai)
                    VALUES (@mssv, @u, @h, @p, @e, 1, 1);

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
                Role = Convert.ToInt32(row["ma_nhom_quyen"]),
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
                                 ma_nhom_quyen = @MaNhomQuyen
                             WHERE ma_nd = @MSSV";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", user.MSSV),
                new SqlParameter("@TenDangNhap", user.TenDangNhap),
                new SqlParameter("@MatKhau", user.MatKhau),
                new SqlParameter("@HoTen", user.HoTen),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@MaNhomQuyen", user.Role),
                new SqlParameter("@GioiTinh", user.GioiTinh),
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // Hàm khóa người dùng
        public bool LockUser(string userId, int status)
        {
            string query = "UPDATE nguoi_dung SET trang_thai = @status WHERE ma_nd = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@status", status),
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
                Role = Convert.ToInt32(row["ma_nhom_quyen"]),
                GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }
        public List<UserDTO> GetAssignableUsersPaged(int page, int pageSize, string? userId = null, string? keyword = null, int? trangThai = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT DISTINCT 
                    nd.ma_nd,
                    nd.ho_ten,
                    nd.email,
                    nq.ten_nhom_quyen,
                    nd.trang_thai
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                JOIN nhom_quyen_chuc_nang AS nqcn ON nqcn.ma_nhom_quyen = nq.ma_nhom_quyen
                WHERE nqcn.duoc_phep = 1 
                    AND nqcn.duoc_phep = 1
	                AND nqcn.ma_chuc_nang = '4'                    
                    AND (@keyword = '' OR nd.ho_ten LIKE N'%' + @keyword + N'%')      
            ";

            if(userId != null)
            {
                query += "AND nd.ma_nd != @userId";
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
                    TenNhomQuyen = row["ten_nhom_quyen"].ToString() ?? "",
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                }); 
            }

            return list;
        }

        public int GetTotalAssignableUsers(string? userId = null, string? keyword = null)
        {
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT COUNT(DISTINCT nd.ma_nd) 
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                JOIN nhom_quyen_chuc_nang AS nqcn ON nqcn.ma_nhom_quyen = nq.ma_nhom_quyen
                WHERE nd.trang_thai = 1
                    AND nqcn.duoc_phep = 1
	                AND nqcn.ma_chuc_nang = '4'
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
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray()));
        }

        public UserDTO GetUserByMSSV(string mssv, bool includeInactive = false)
        {

            if (string.IsNullOrWhiteSpace(mssv)) return null;

            string cleanMssv = mssv.Trim();

            string query = @"
                SELECT ma_nd, ten_dang_nhap, mat_khau, ho_ten, email, ma_nhom_quyen, gioi_tinh, trang_thai
                FROM nguoi_dung 
                WHERE TRIM(ma_nd) = @MSSV";

            if (!includeInactive)
                query += " AND trang_thai = 1";

            var param = new SqlParameter("@MSSV", cleanMssv);

            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new UserDTO
            {
                MSSV = r["ma_nd"].ToString().Trim(),
                TenDangNhap = r["ten_dang_nhap"].ToString(),
                MatKhau = r["mat_khau"].ToString(),
                HoTen = r["ho_ten"].ToString(),
                Email = r["email"].ToString(),
                Role = Convert.ToInt32(r["ma_nhom_quyen"]),
                GioiTinh = r["gioi_tinh"] == DBNull.Value ? 1 : Convert.ToInt32(r["gioi_tinh"]),
                TrangThai = r["trang_thai"] == DBNull.Value ? 1 : Convert.ToInt32(r["trang_thai"])
            };
        }

        public List<UserDTO> GetAllAssignableUsers()
        {
            string query = @"
                SELECT DISTINCT
                    nd.ma_nd,
                    nd.ho_ten
                FROM nguoi_dung AS nd
                JOIN nhom_quyen AS nq ON nq.ma_nhom_quyen = nd.ma_nhom_quyen
                JOIN nhom_quyen_chuc_nang AS nqcn ON nqcn.ma_nhom_quyen = nq.ma_nhom_quyen
                WHERE nd.trang_thai = 1
                    AND nqcn.duoc_phep = 1
	                AND nqcn.ma_chuc_nang = '4'
            ";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<UserDTO> list = new List<UserDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new UserDTO
                {
                    MSSV = row["ma_nd"].ToString() ?? "",
                    HoTen = row["ho_ten"].ToString() ?? ""
                });
            }

            return list;
        }
    }
}
