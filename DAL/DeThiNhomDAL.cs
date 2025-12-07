using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
// Giả định DatabaseHelper, DeThiDTO và CauHoiDTO đã tồn tại

namespace DAL
{
    public class DeThiNhomDAL
    {
        // Thêm một đề thi vào một nhóm học phần
        public bool ThemDeThiVaoNhom(long maDe, long maNhom)
        {
            // Tránh thêm trùng lặp
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM de_thi_nhom WHERE ma_de = @maDe AND ma_nhom = @maNhom)
                BEGIN
                    INSERT INTO de_thi_nhom (ma_de, ma_nhom)
                    VALUES (@maDe, @maNhom)
                END";

            var parameters = new[]
            {
                new SqlParameter("@maDe", maDe),
                new SqlParameter("@maNhom", maNhom)
            };

            // ExecuteNonQuery sẽ trả về số hàng bị ảnh hưởng (1 nếu Insert, 0 nếu đã tồn tại)
            return DatabaseHelper.ExecuteNonQuery(query, parameters) >= 0;
        }

        
        public bool KiemTraTonTai(long maDe, long maNhom)
        {
            string query = "SELECT COUNT(*) FROM de_thi_nhom WHERE ma_de = @maDe AND ma_nhom = @maNhom";
            var parameters = new[]
            {
                new SqlParameter("@maDe", maDe),
                new SqlParameter("@maNhom", maNhom)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

       
    }
}