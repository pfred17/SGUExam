using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class MonHocDAL
    {
        public List<MonHocDTO> GetAllMonHoc()
        {
            string query = "SELECT * FROM mon_hoc";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<MonHocDTO> list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = Convert.ToInt64(row["ma_mh"]),
                    TenMH = Convert.ToString(row["ten_mh"]) ?? "",
                    SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToByte(row["trang_thai"])
                });
            }

            return list;
        }
        public MonHocDTO? GetMonHocById(long maMonHoc)
        {
            string query = "SELECT * FROM mon_hoc WHERE ma_mh = @ma_mh";
            SqlParameter[] parameters =  {
                new ("@ma_mh", maMonHoc)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new MonHocDTO
        {
                MaMH = Convert.ToInt64(row["ma_mh"]),
                TenMH = Convert.ToString(row["ten_mh"]) ?? "",
                SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                TrangThai = Convert.ToByte(row["trang_thai"])
            };
        }
        public bool IsMonHocExists(long maMH)
            {
            string query = "SELECT COUNT(*) FROM mon_hoc WHERE ma_mh = @ma_mh";
            SqlParameter[] parameters =
            {
                new ("@ma_mh", maMH)
            };
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            int count = result != null ? Convert.ToInt32(result) : 0;
            return count > 0;
        }
        public long AddMonHoc(MonHocDTO monHoc)
        {
            string query = @"
                INSERT INTO mon_hoc (ma_mh, ten_mh, so_tin_chi, trang_thai)
                OUTPUT INSERTED.ma_mh
                VALUES (@ma_mh, @ten_mh, @so_tin_chi, @trang_thai);
            ";

            SqlParameter[] parameters =
            {
                new ("@ma_mh", monHoc.MaMH),
                new ("@ten_mh", monHoc.TenMH),
                new ("@so_tin_chi", monHoc.SoTinChi),
                new ("@trang_thai", monHoc.TrangThai)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt64(result);
        }

        public bool UpdateMonHoc(MonHocDTO monHoc)
        {
            string query = @"
                UPDATE mon_hoc
                SET ten_mh = @ten_mh,
                    so_tin_chi = @so_tin_chi,
                    trang_thai = @trang_thai
                WHERE ma_mh = @ma_mh;
            ";

            SqlParameter[] parameters =
            {
                new ("@ma_mh", monHoc.MaMH),
                new ("@ten_mh", monHoc.TenMH),
                new ("@so_tin_chi",monHoc.SoTinChi),
                new ("@trang_thai", monHoc.TrangThai)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool DeleteMonHoc(long maMH)
        {
            string query = @"DELETE FROM mon_hoc WHERE ma_mh = @ma_mh";
            SqlParameter parameters = new("@ma_mh", maMH);
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool IsMonHocReferenced(long maMH)
        {
            string query = @"
                SELECT
                    (SELECT COUNT(*) FROM phan_cong WHERE ma_mh = @ma_mh) +
                    (SELECT COUNT(*) FROM nhom_hoc_phan WHERE ma_mh = @ma_mh) +
                    (SELECT COUNT(*) FROM chuong WHERE ma_mh = @ma_mh) 
            ";
            SqlParameter parameter = new("@ma_mh", maMH);
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameter));
            return count > 0;
        }
        public List<MonHocDTO> GetMonHocPaged(int page, int pageSize, string? keyword = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT * FROM mon_hoc
                WHERE (@keyword = '' OR ten_mh LIKE '%' + @keyword + '%')
                ORDER BY ma_mh
                OFFSET @offset ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";

            SqlParameter[] parameters = {
                new("@keyword", keyword),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<MonHocDTO> list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
            {
                    MaMH = Convert.ToInt64(row["ma_mh"]),
                    TenMH = Convert.ToString(row["ten_mh"]) ?? "",
                SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToByte(row["trang_thai"])
                });
            }

            return list;
        }

        public int GetTotalMonHoc(string? keyword = null)
        {
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT COUNT(*) FROM mon_hoc
                WHERE (@keyword = '' OR ten_mh LIKE '%' + @keyword + '%')
            ";

            SqlParameter parameters = new("@keyword", keyword);
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }
        
    }
}
