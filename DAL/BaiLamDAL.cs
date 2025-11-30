using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BaiLamDAL
    {
        public List<BaiLamDTO> GetByDeThi(long maDe)
        {
            string query = "SELECT * FROM bai_lam WHERE ma_de = @maDe";
            var param = new MySqlParameter[] { new("@maDe", maDe) };
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
            var param = new MySqlParameter[] { new("@maBai", maBai) };
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
                             SELECT LAST_INSERT_ID();";
            var param = new MySqlParameter[]
            {
                new("@ma_de", baiLam.MaDe),
                new("@ma_nd", baiLam.MaNguoiDung),
                new("@batdau", baiLam.ThoiGianBatDau),
                new("@nop", baiLam.ThoiGianNop),
                new("@diem", baiLam.Diem)
            };
            object result = DatabaseHelper.ExecuteScalar(query, param);
            return Convert.ToInt64(result);
        }

        public bool Update(BaiLamDTO baiLam)
        {
            string query = @"UPDATE bai_lam SET thoi_gian_bat_dau = @batdau, thoi_gian_nop = @nop, diem = @diem
                             WHERE ma_bai = @ma_bai";
            var param = new MySqlParameter[]
            {
                new("@batdau", baiLam.ThoiGianBatDau),
                new("@nop", baiLam.ThoiGianNop),
                new("@diem", baiLam.Diem),
                new("@ma_bai", baiLam.MaBai)
            };
            int rows = DatabaseHelper.ExecuteNonQuery(query, param);
            return rows > 0;
        }
    }
}

