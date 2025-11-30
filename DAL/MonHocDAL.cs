using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ma_mh", maMonHoc)
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
        public long AddMonHoc(MonHocDTO monHoc)
        {
            string query = @"
                INSERT INTO mon_hoc (ma_mh, ten_mh, so_tin_chi, trang_thai)
                OUTPUT INSERTED.ma_mh
                VALUES (@ma_mh, @ten_mh, @so_tin_chi, @trang_thai);
            ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ma_mh", monHoc.MaMH),
                new SqlParameter("@ten_mh", monHoc.TenMH),
                new SqlParameter("@so_tin_chi", monHoc.SoTinChi),
                new SqlParameter("@trang_thai", monHoc.TrangThai)
            };
            
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt64(result);
        }

        public bool UpdateMonHoc(MonHocDTO monHoc)
        {
            string query = @"
                UPDATE mon_hon
                SET ten_mh = @ten_mh
                    so_tin_chi = @so_tin_chi
                    trang_thai = @trang_thai
                WHERE ma_mh = @ma_mh;
            ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ma_mh", monHoc.MaMH),
                new SqlParameter("@ten_mh", monHoc.TenMH),
                new SqlParameter("@so_tin_chi",monHoc.SoTinChi),
                new SqlParameter("@trang_thai", monHoc.TrangThai)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        public bool DeleteMonHoc(long maMH)
        {
            string query = @"DELETE FROM mon_hoc WHERE ma_mh = @ma_mh";

            SqlParameter[] parameters = {
                new SqlParameter("@ma_mh", maMH)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        public List<MonHocDTO> GetMonHocPaged(int page, int pageSize)
        {
            string query = @"
                SELECT * FROM mon_hoc
                ORDER BY ma_mh
                OFFSET(@page - 1) * @pageSize ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";
            SqlParameter[] parameters = { 
                new SqlParameter("@page",page),
                new SqlParameter("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<MonHocDTO> list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = Convert.ToInt64(row["ma_mh"]),
                    TenMH = Convert.ToString(row["ten_mh"]),
                    SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToByte(row["trang_thai"])
                });
            }

            return list;
        }

        public int GetTotalMonHoc()
        {
            string query = "SELECT COUNT(*) FROM mon_hoc";
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
        }
    }
}
