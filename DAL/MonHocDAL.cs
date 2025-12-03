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
        public List<MonHocDTO> GetAllMonHocByStatus(int? trangThai = null)
        {
            string query = "SELECT mh.ma_mh, mh.ten_mh, mh.so_tin_chi, mh.trang_thai FROM mon_hoc mh";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (trangThai != null)
            {
                // Chỉ định rõ cột trang_thai thuộc về bảng mh
                query += " WHERE mh.trang_thai = @trang_thai";
                parameters.Add(new SqlParameter("@trang_thai", trangThai));
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

            List<MonHocDTO> list = new List<MonHocDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = Convert.ToInt64(row["ma_mh"]),
                    TenMH = Convert.ToString(row["ten_mh"]) ?? "",
                    SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return list;
        }
        public MonHocDTO GetMonHocById(long maMonHoc)
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
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }
        public bool IsMonHocExists(long maMonHoc)
        {
            string query = "SELECT COUNT(*) FROM mon_hoc WHERE ma_mh = @ma_mh";
            SqlParameter[] parameters =
            {
                new ("@ma_mh", maMonHoc)
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
        public bool IsMonHocReferenced(long maMonHoc)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM phan_cong WHERE ma_mh = @ma_mh)
                    OR EXISTS (SELECT 1 FROM chuong WHERE ma_mh = @ma_mh)
                SELECT 1 ELSE SELECT 0;
            ";
            SqlParameter param = new("@ma_mh", maMonHoc);
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, param));
            return count > 0;
        }
        public bool DeleteMonHoc(long maMonHoc)
        {
            string query = @"
                UPDATE mon_hoc
                SET trang_thai = 0
                WHERE ma_mh = @ma_mh;
            ";
            SqlParameter parameters = new("@ma_mh", maMonHoc);
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public int GetStatus(long maMonHoc)
        {
            string query = "SELECT trang_thai FROM mon_hoc WHERE ma_mh = @ma_mh";
            SqlParameter parameter = new("@ma_mh", maMonHoc);
            object result = DatabaseHelper.ExecuteScalar(query, parameter);
            return Convert.ToInt32(result); 
        }
        public bool UpdateStatus(long maMonHoc, int trangThai)
        {
            string query = @"
                UPDATE mon_hoc
                SET trang_thai = @trang_thai
                WHERE ma_mh = @ma_mh;
            ";

            SqlParameter[] parameters = {
                new("@ma_mh", maMonHoc),
                new("@trang_thai", trangThai)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public List<MonHocDTO> GetMonHocPaged(int page, int pageSize, string? keyword = null, int? trangThai = null)
        {
            int offset = (page - 1) * pageSize;
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT * FROM mon_hoc
                WHERE (@keyword = '' OR ten_mh LIKE '%' + @keyword + '%')
            ";

            if(trangThai != null)
            {
                query += " AND trang_thai = @trang_thai";
            }

            query += @"
                ORDER BY ma_mh
                OFFSET @offset ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";

            List<SqlParameter> parameters = new List<SqlParameter>{
                new("@keyword", keyword),
                new("@offset", offset),
                new("@pageSize", pageSize)
            };

            if(trangThai != null)
            {
                parameters.Add(new SqlParameter("@trang_thai", trangThai));
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            List<MonHocDTO> list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = Convert.ToInt64(row["ma_mh"]),
                    TenMH = Convert.ToString(row["ten_mh"]) ?? "",
                    SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }

            return list;
        }

        public int GetTotalMonHoc(string? keyword = null, int? trangThai = null)
        {
            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword;

            string query = @"
                SELECT COUNT(*) FROM mon_hoc
                WHERE (@keyword = '' OR ten_mh LIKE '%' + @keyword + '%')
            ";

            List<SqlParameter> parameters = new List<SqlParameter>{
                new("@keyword", keyword)
            };

            if (trangThai != null)
            {
                query += " AND trang_thai = @trang_thai";
                parameters.Add(new SqlParameter("@trang_thai", trangThai));
            }

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray()));
        }
    }
}
