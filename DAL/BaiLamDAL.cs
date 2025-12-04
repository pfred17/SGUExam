using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class BaiLamDAL
    {
        public List<BaiLamDTO> GetByDeThi(long maDe)
        {
            string query = "SELECT * FROM bai_lam WHERE ma_de = @maDe";
            var param = new SqlParameter[] { new SqlParameter("@maDe", maDe) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            var list = new List<BaiLamDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new BaiLamDTO
                {
                    MaBai = Convert.ToInt64(row["ma_bai"]),
                    MaDe = Convert.ToInt64(row["ma_de"]),
                    MaNguoiDung = row["ma_nd"].ToString(),
                    ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                    ThoiGianNop = row["thoi_gian_nop"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_nop"]),
                    Diem = row["diem"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["diem"])
                });
            }
            return list;
        }

        public BaiLamDTO GetById(long maBai)
        {
            string query = "SELECT * FROM bai_lam WHERE ma_bai = @maBai";
            var param = new SqlParameter[] { new SqlParameter("@maBai", maBai) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new BaiLamDTO
            {
                MaBai = Convert.ToInt64(row["ma_bai"]),
                MaDe = Convert.ToInt64(row["ma_de"]),
                MaNguoiDung = row["ma_nd"].ToString(),
                ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                ThoiGianNop = row["thoi_gian_nop"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_nop"]),
                Diem = row["diem"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["diem"])
            };
        }

        public long Insert(BaiLamDTO baiLam)
        {
            string query = @"INSERT INTO bai_lam (ma_de, ma_nd, thoi_gian_bat_dau, thoi_gian_nop, diem)
                             VALUES (@ma_de, @ma_nd, @batdau, @nop, @diem);
                             SELECT SCOPE_IDENTITY();";
            var param = new SqlParameter[]
            {
                new SqlParameter("@ma_de", baiLam.MaDe),
                new SqlParameter("@ma_nd", baiLam.MaNguoiDung),
                new SqlParameter("@batdau", baiLam.ThoiGianBatDau ?? (object)DBNull.Value),
                new SqlParameter("@nop", baiLam.ThoiGianNop ?? (object)DBNull.Value),
                new SqlParameter("@diem", baiLam.Diem ?? (object)DBNull.Value)
            };
            object result = DatabaseHelper.ExecuteScalar(query, param);
            return Convert.ToInt64(result);
        }

        public bool Update(BaiLamDTO baiLam)
        {
            string query = @"UPDATE bai_lam SET thoi_gian_bat_dau = @batdau, thoi_gian_nop = @nop, diem = @diem
                             WHERE ma_bai = @ma_bai";
            var param = new SqlParameter[]
            {
                new SqlParameter("@batdau", baiLam.ThoiGianBatDau ?? (object)DBNull.Value),
                new SqlParameter("@nop", baiLam.ThoiGianNop ?? (object)DBNull.Value),
                new SqlParameter("@diem", baiLam.Diem ?? (object)DBNull.Value),
                new SqlParameter("@ma_bai", baiLam.MaBai)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param);
            return rows > 0;
        }
        public BaiLamDTO? GetByUserAndDeThi(string userId, long maDe)
        {
            string query = "SELECT * FROM bai_lam WHERE ma_nd = @userId AND ma_de = @maDe";
            var param = new SqlParameter[]
            {
        new SqlParameter("@userId", userId),
        new SqlParameter("@maDe", maDe)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new BaiLamDTO
            {
                MaBai = Convert.ToInt64(row["ma_bai"]),
                MaDe = Convert.ToInt64(row["ma_de"]),
                MaNguoiDung = row["ma_nd"].ToString(),
                ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                ThoiGianNop = row["thoi_gian_nop"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_nop"]),
                Diem = row["diem"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["diem"])
            };
        }

    }
}
