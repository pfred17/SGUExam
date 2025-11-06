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

        public bool CreateUser(UserDTO userDTO)
        {
            string query = @"INSERT INTO nguoi_dung 
                        (ma_nd ,ten_dang_nhap, mat_khau, ho_ten, email, gioi_tinh, loai_nd, trang_thai)
                     VALUES 
                        (@MSSV, @TenDangNhap, @MatKhau, @HoTen, @Email, @GioiTinh, @LoaiNguoiDung, @TrangThai)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", userDTO.MSSV),
                new SqlParameter("@TenDangNhap", userDTO.TenDangNhap),
                new SqlParameter("@MatKhau", userDTO.MatKhau),
                new SqlParameter("@HoTen", userDTO.HoTen),
                new SqlParameter("@Email", userDTO.Email),
                new SqlParameter("@GioiTinh", userDTO.GioiTinh),
                new SqlParameter("@LoaiNguoiDung", userDTO.Role),
                new SqlParameter("@TrangThai", userDTO.TrangThai)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rows > 0;
        }

    }
}
