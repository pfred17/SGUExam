using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

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
                Role = row["loai_nd"].ToString(),
                GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }

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
                    Role = row["loai_nd"].ToString(),
                    GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return users;
        }

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

        private Dictionary<string, UserDTO> users = new Dictionary<string, UserDTO>();

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

        public UserDTO GetUserByMSSV(string mssv, bool includeInactive = false)
        {
            //if (string.IsNullOrWhiteSpace(mssv))
            //    return null;

            //string query = @"SELECT ma_nd, ho_ten, gioi_tinh, loai_nd, trang_thai 
            //         FROM nguoi_dung 
            //         WHERE ma_nd = @mssv";

            //if (!includeInactive)
            //    query += " AND trang_thai = 1";

            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@mssv", mssv.Trim())
            //};

            //DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            //if (dt.Rows.Count == 0)
            //    return null;

            //DataRow row = dt.Rows[0];

            //return new UserDTO
            //{
            //    MSSV = row["ma_nd"].ToString(),
            //    HoTen = row["ho_ten"].ToString(),
            //    GioiTinh = Convert.ToInt32(row["gioi_tinh"]),
            //    Role = row["loai_nd"].ToString(),
            //    TrangThai = Convert.ToInt32(row["trang_thai"])
            //};

            if (string.IsNullOrWhiteSpace(mssv)) return null;

            string cleanMssv = mssv.Trim();

            string query = @"
                SELECT ma_nd, ten_dang_nhap, mat_khau, ho_ten, email, loai_nd, gioi_tinh, trang_thai
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
                Role = r["loai_nd"].ToString(),
                GioiTinh = r["gioi_tinh"] == DBNull.Value ? 1 : Convert.ToInt32(r["gioi_tinh"]),
                TrangThai = r["trang_thai"] == DBNull.Value ? 1 : Convert.ToInt32(r["trang_thai"])
            };
        }

    }
}
