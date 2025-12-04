using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class PhanCongDAL
    {
        public List<PhanCongDTO> getAllPhanCong()
        {
            string query = @"
                SELECT
                    pc.ma_pc,
                    mh.ma_mh,
                    mh.ten_mh,
                    nd.ma_nd,
                    nd.ho_ten
                FROM 
	                phan_cong as pc
	                INNER JOIN mon_hoc as mh ON pc.ma_mh = mh.ma_mh
	                INNER JOIN nguoi_dung as nd ON pc.ma_nd = nd.ma_nd;
            ";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<PhanCongDTO> list = new List<PhanCongDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhanCongDTO
                {
                    MaPhanCong = Convert.ToInt64(row["ma_pc"]),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                    TenMonHoc = Convert.ToString(row["ten_mh"]) ?? "",
                    MaNguoiDung = Convert.ToString(row["ma_nd"]) ?? "",
                    TenNguoiDung = Convert.ToString(row["ho_ten"]) ?? ""
                });
            }
            return list;
        }
        public PhanCongDTO? GetPhanCongById(long maPhanCong)
        {
            string query = @"
                SELECT
                    pc.ma_pc,
                    mh.ma_mh,
                    mh.ten_mh,
                    nd.ma_nd,
                    nd.ho_ten
                FROM 
	                phan_cong as pc
	                INNER JOIN mon_hoc as mh ON pc.ma_mh = mh.ma_mh
	                INNER JOIN nguoi_dung as nd ON pc.ma_nd = nd.ma_nd            
                WHERE ma_pc = @ma_pc;
            ";
            SqlParameter[] parameters = {
                new SqlParameter("@ma_pc", maPhanCong)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new PhanCongDTO
            {
                MaPhanCong = Convert.ToInt64(row["ma_pc"]),
                MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                TenMonHoc = Convert.ToString(row["ten_mh"]) ?? "",
                MaNguoiDung = Convert.ToString(row["ma_nd"]) ?? "",
                TenNguoiDung = Convert.ToString(row["ho_ten"]) ?? ""
            };
        }
        public long AddPhanCong(PhanCongDTO phanCong)
        {
            string query = @"
                INSERT INTO phan_cong (ma_mh, ma_nd)
                OUTPUT INSERTED.ma_pc
                VALUES (@ma_mh, @ma_nd);
            ";

            SqlParameter[] parameters = {
                new("ma_mh", phanCong.MaMonHoc),
                new("ma_nd",phanCong.MaNguoiDung)
            };
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt64(result);
        }
        public bool UpdatePhanCong(PhanCongDTO phanCong)
        {
            string query = @"
                UPDATE phan_cong
                SET ma_mh = @ma_mh,
                    ma_nd = @ma_nd
                WHERE ma_pc = @ma_pc;
            ";

            SqlParameter[] parameters = {
                new("ma_pc", phanCong.MaPhanCong),
                new("ma_mh", phanCong.MaMonHoc),
                new("ma_nd", phanCong.MaNguoiDung),
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool DeletePhanCong(long maPhanCong)
        {
            string query = @"DELETE FROM phan_cong WHERE ma_pc = @maPhanCong";

            SqlParameter parameters = new("@maPhanCong", maPhanCong);
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool IsPhanCongReferenced(long maPhanCong)
        {
            string query = "SELECT COUNT(*) FROM phan_cong WHERE ma_pc = @maPhanCong";
            SqlParameter parameter = new("@maPhanCong", maPhanCong);
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameter));
            return count > 0;
        }
        public List<PhanCongDTO> GetPhanCongPaged(int page, int pageSize, string? keyword = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT 
                    pc.ma_pc,
                    pc.ma_mh,
                    mh.ten_mh,
                    pc.ma_nd,
                    nd.ho_ten
                FROM phan_cong pc
                INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
                INNER JOIN nguoi_dung nd ON pc.ma_nd = nd.ma_nd
                WHERE (@keyword = '' 
                    OR nd.ho_ten LIKE '%' + @keyword + '%'
                    OR mh.ten_mh LIKE '%' + @keyword + '%')
                ORDER BY pc.ma_pc
                OFFSET @offset ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";

            SqlParameter[] parameters = {
                new("@keyword", keyword),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<PhanCongDTO> list = new List<PhanCongDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhanCongDTO
                {
                    MaPhanCong = Convert.ToInt64(row["ma_pc"]),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                    TenMonHoc = Convert.ToString(row["ten_mh"]) ?? "",
                    MaNguoiDung = Convert.ToString(row["ma_nd"]) ?? "",
                    TenNguoiDung = Convert.ToString(row["ho_ten"]) ?? ""
                });
            }

            return list;
        }
        public int GetTotalPhanCong(string? keyword = null)
        {
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
            SELECT COUNT(*) 
            FROM phan_cong pc 
            INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
            INNER JOIN nguoi_dung nd ON pc.ma_nd = nd.ma_nd
            WHERE (@keyword = '' 
                OR nd.ho_ten LIKE '%' + @keyword + '%'
                OR mh.ten_mh LIKE '%' + @keyword + '%') 
            ";

            SqlParameter parameters = new("@keyword", keyword);
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }
        public long GetMaPCByCriteria(long maMH, string maND)
        {
            long maPhanCong = 0;

            string query = @"
            SELECT TOP 1 ma_pc 
            FROM phan_cong 
            WHERE ma_mh = @MaMH 
              AND ma_nd = @MaND 
              AND trang_thai = 1;"; // Chỉ lấy bản ghi đang hoạt động

            SqlParameter[] parameters = {
            new SqlParameter("@MaMH", maMH),
            new SqlParameter("@MaND", maND)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Lấy giá trị MaPC từ dòng đầu tiên
                if (long.TryParse(dt.Rows[0]["ma_pc"].ToString(), out long result))
                {
                    maPhanCong = result;
                }
            }

            return maPhanCong;
        }
        public long GetMaPCByGiangVienAndMonHoc(long maMH, string maND)
        {
            string query = "SELECT ma_pc FROM phan_cong WHERE ma_nd = @maND AND ma_mh = @maMH AND trang_thai = 1";
            var parameters = new[]
            {
                new SqlParameter("@maND", maND),
                new SqlParameter("@maMH", maMH)
            };
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt64(result) : 0;
        }
        public List<MonHocDTO> GetMonHocByGiangVien(string maND)
        {
            string query = @"
                SELECT DISTINCT mh.ma_mh AS MaMH, mh.ten_mh AS TenMH, mh.so_tin_chi AS SoTinChi
                FROM phan_cong pc
                INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
                WHERE pc.ma_nd = @maND 
                  AND pc.trang_thai = 1 
                  AND mh.trang_thai = 1";

            var parameters = new[] { new SqlParameter("@maND", maND) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            var list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = Convert.ToInt64(row["MaMH"]),
                    TenMH = row["TenMH"].ToString(),
                    SoTinChi = Convert.ToInt32(row["SoTinChi"])
                });
            }
            return list;
        }
    }
}
