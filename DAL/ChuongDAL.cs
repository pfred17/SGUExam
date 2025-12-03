using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ChuongDAL
    {
        public List<ChuongDTO> GetChuongByMonHoc(long maMonHoc)
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
                        MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                        TrangThai = Convert.ToInt32(row["trang_thai"])
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
                INSERT INTO chuong (ten_chuong, ma_mh, trang_thai)
                OUTPUT INSERTED.ma_chuong
                VALUES (@ten_chuong, @ma_mh, @trang_thai)
            ";

            SqlParameter[] parameters = {
                new SqlParameter("@ten_chuong", chuong.TenChuong),
                new SqlParameter("@ma_mh", maMonHoc),
                new SqlParameter("@trang_thai", chuong.TrangThai)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt64(result);
        }

        public bool UpdateChuong(ChuongDTO chuong)
        {
            string query = @"
                UPDATE chuong
                SET ten_chuong = @ten_chuong,
                    trang_thai = @trang_thai
                WHERE ma_chuong = @ma_chuong;
            ";

            SqlParameter[] parameters =
            {
                new ("@ma_chuong", chuong.MaChuong),
                new ("@ten_chuong", chuong.TenChuong),
                new ("@trang_thai", chuong.TrangThai)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public bool UpdateStatus(long maChuong, int trangThai)
        {
            string query = @"
                UPDATE chuong
                SET trang_thai = @trang_thai
                WHERE ma_chuong = @ma_chuong;
            ";

            SqlParameter[] parameters = {
                new("@ma_chuong", maChuong),
                new("@trang_thai", trangThai)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
        public int GetStatus(long maChuong)
        {
            string query = "SELECT trang_thai FROM chuong WHERE ma_chuong = @ma_chuong";
            SqlParameter parameter = new("@ma_chuong", maChuong);
            object result = DatabaseHelper.ExecuteScalar(query, parameter);
            return Convert.ToInt32(result);
        }
        public bool DeleteChuong(long maChuong)
        {
            string query = @"
                UPDATE chuong 
                SET trang_thai = 0 
                WHERE ma_chuong = @ma_chuong";

            SqlParameter parameter = new("@ma_chuong", maChuong);

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameter);
            return rows > 0;
        }
        public bool IsChuongReferenced(long maChuong)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM cau_hoi WHERE ma_chuong = @ma_chuong)
                    OR EXISTS (SELECT 1 FROM de_thi_chuong WHERE ma_chuong = @ma_chuong)
                SELECT 1 ELSE SELECT 0;
            ";

            SqlParameter parameter = new("@ma_chuong", maChuong);
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
                new SqlParameter("@page", page),
                new SqlParameter("@pageSize", pageSize)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<ChuongDTO> list = new List<ChuongDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChuongDTO
                {
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
                    TenChuong = Convert.ToString(row["ten_chuong"]) ?? "",
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]), 
                    TrangThai = Convert.ToInt32(row["trang_thai"])
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
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }
    }
}
