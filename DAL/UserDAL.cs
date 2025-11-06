using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class UserDAL
    {
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
                MaNguoiDung = Convert.ToInt32(row["ma_nd"]),
                TenDangNhap = row["ten_dang_nhap"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                Email = row["email"].ToString(),
                Role = row["loai_nd"].ToString(),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }
        public UserDTO CreateUser(string username, string hoten, string password, string email)
        {
            string query = "INSERT INTO nguoi_dung (ten_dang_nhap, ho_ten, mat_khau, email, loai_nd, trang_thai) " +
                           "VALUES (@u, @h, @p, @e, 'Sinh viên', 1); " +
                           "SELECT * FROM nguoi_dung WHERE ten_dang_nhap = @u";
            SqlParameter[] param =
            {
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
                MaNguoiDung = Convert.ToInt32(row["ma_nd"]),
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


    }
}
