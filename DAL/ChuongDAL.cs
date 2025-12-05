using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ChuongDAL
    {
        public  List<ChuongDTO> GetChuongByMonHoc(long maMonHoc)
        {
            string query = "SELECT * FROM chuong WHERE ma_mh = @ma_mh";
            SqlParameter[] parameters = {
                new SqlParameter("@ma_mh", maMonHoc)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<ChuongDTO> list = new List<ChuongDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChuongDTO
                {
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
                        TenChuong = Convert.ToString(row["ten_chuong"]) ?? "",
                    MaMonHoc = Convert.ToInt64(row["ma_mh"])
                });
            }
            return list;
        }
        public bool IsChuongExists(string tenChuong)
        {
            string query = "SELECT COUNT(*) FROM chuong WHERE ten_chuong = @ten_chuong";
            SqlParameter parameters = new SqlParameter("@ten_chuong", tenChuong);
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            int count = result != null ? Convert.ToInt32(result) : 0;
            return count > 0;
        }
        public long AddChuong(ChuongDTO chuong, long maMonHoc)
        {
            string query = @"
                INSERT INTO chuong (ten_chuong, ma_mh)
                OUTPUT INSERTED.ma_chuong
                VALUES (@ten_chuong, @ma_mh)
            ";

            SqlParameter[] parameters = {
                new SqlParameter("@ten_chuong", chuong.TenChuong),
                new SqlParameter("@ma_mh", maMonHoc)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt64(result);
        }

        public bool UpdateChuong(ChuongDTO chuong)
        {
            string query = @"
                UPDATE chuong
                SET ten_chuong = @ten_chuong
                WHERE ma_chuong = @ma_chuong;
            ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ma_chuong", chuong.MaChuong),
                new SqlParameter("@ten_chuong", chuong.TenChuong),
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        public bool DeleteChuong(long maChuong)
        {
            string query = @"DELETE FROM chuong WHERE ma_chuong = @ma_chuong";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ma_chuong", maChuong)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool IsChuongReferenced(long maChuong)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM cau_hoi WHERE ma_chuong = @maChuong)
                    OR EXISTS (SELECT 1 FROM de_thi_chuong WHERE ma_chuong = @maChuong)
                SELECT 1 ELSE SELECT 0";

            SqlParameter parameter = new("@maChuong", maChuong);
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameter));
            return count > 0;
        }
        public List<ChuongDTO> GetChuongPaged(long maMonHoc, int page, int pageSize)
        {
            string query = @"
                SELECT * FROM chuong
                WHERE ma_mh = @ma_mh
                ORDER BY ma_chuong
                OFFSET(@page - 1) * @pageSize ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";
            SqlParameter[] parameters = {
                new SqlParameter("@ma_mh", maMonHoc),
                new SqlParameter("@page",page),
                new SqlParameter("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<ChuongDTO> list = new List<ChuongDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChuongDTO
                {
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
                    TenChuong = Convert.ToString(row["ten_chuong"]),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"])
                });
            }

            return list;
        }

        public int GetTotalChuongByMonHoc(long maMonHoc)
        {
            string query = "SELECT COUNT(*) FROM chuong WHERE ma_mh = @ma_mh";
            SqlParameter[] parameters = {
                new SqlParameter("@ma_mh", maMonHoc)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,parameters));
        }
    }
}
