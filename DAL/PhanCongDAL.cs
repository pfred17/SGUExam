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
        public bool DeletePhanCong(long maPhanCong)
        {
            string query = @"DELETE FROM phan_cong WHERE ma_pc = @ma_pc";

            SqlParameter[] parameters = {
                new SqlParameter("@ma_pc", maPhanCong)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rows > 0;
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
        public List<PhanCongDTO> GetPhanCongPaged(int page, int pageSize)
        {
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
                ORDER BY pc.ma_pc
                OFFSET(@page - 1) * @pageSize ROWS
                FETCH NEXT @pageSize ROWS ONLY;
            ";
            SqlParameter[] parameters = {
                new SqlParameter("@page",page),
                new SqlParameter("@pageSize", pageSize)
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
        public int GetTotalPhanCong()
        {
            string query = @"
            SELECT COUNT(*) 
            FROM phan_cong AS pc 
            INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
            INNER JOIN nguoi_dung nd ON pc.ma_nd = nd.ma_nd;
            ";

            var result = DatabaseHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
