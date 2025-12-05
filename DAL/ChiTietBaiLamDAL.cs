using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChiTietBaiLamDAL
    {
        public List<ChiTietBaiLamDTO> GetByMaBai(long maBai)
        {
            string query = "SELECT * FROM bai_lam_chi_tiet WHERE ma_bai = @maBai";
            var param = new SqlParameter[] { new SqlParameter("@maBai", maBai) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            var list = new List<ChiTietBaiLamDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietBaiLamDTO
                {
                    MaBai = Convert.ToInt64(row["ma_bai"]),
                    MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                    MaDapAnChon = row["ma_dap_an_chon"] == DBNull.Value ? null : (long?)Convert.ToInt64(row["ma_dap_an_chon"])
                });
            }
            return list;
        }

        public bool Insert(ChiTietBaiLamDTO chiTiet)
        {
            string query = @"INSERT INTO bai_lam_chi_tiet (ma_bai, ma_cau_hoi, ma_dap_an_chon)
                             VALUES (@ma_bai, @ma_cau_hoi, @ma_dap_an_chon)";
            var param = new SqlParameter[]
            {
                new SqlParameter("@ma_bai", chiTiet.MaBai),
                new SqlParameter("@ma_cau_hoi", chiTiet.MaCauHoi),
                new SqlParameter("@ma_dap_an_chon", chiTiet.MaDapAnChon ?? (object)DBNull.Value)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param);
            return rows > 0;
        }

        public bool Update(ChiTietBaiLamDTO chiTiet)
        {
            string query = @"UPDATE bai_lam_chi_tiet SET ma_dap_an_chon = @ma_dap_an_chon
                             WHERE ma_bai = @ma_bai AND ma_cau_hoi = @ma_cau_hoi";
            var param = new SqlParameter[]
            {
                new SqlParameter("@ma_dap_an_chon", chiTiet.MaDapAnChon ?? (object)DBNull.Value),
                new SqlParameter("@ma_bai", chiTiet.MaBai),
                new SqlParameter("@ma_cau_hoi", chiTiet.MaCauHoi)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param);
            return rows > 0;
        }
    }
}
