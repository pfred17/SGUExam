using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DeThiDAL
    {
        public List<CauHoiDTO> GetCauHoiTheoDeThi(long maDe)
        {
            string query = @"
        SELECT ch.*
        FROM de_thi_cau_hoi dtch
        JOIN cau_hoi ch ON ch.ma_cau_hoi = dtch.ma_cau_hoi
        WHERE dtch.ma_de = @maDe AND ch.trang_thai = 1";

            var dt = DatabaseHelper.ExecuteQuery(
                query,
                new SqlParameter("@maDe", maDe)
            );

            var list = new List<CauHoiDTO>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CauHoiDTO
                {
                    MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                    NoiDung = row["noi_dung"].ToString(),
                    DoKho = row["do_kho"].ToString(),
                    MaChuong = Convert.ToInt64(row["ma_chuong"])
                });
            }

            return list;
        }


        public int GetSoLuongCauHoiTheoDe(long maDe)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM de_thi_cau_hoi dtch
        JOIN cau_hoi ch ON ch.ma_cau_hoi = dtch.ma_cau_hoi
        WHERE dtch.ma_de = @maDe AND ch.trang_thai = 1";

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                sql, new SqlParameter("@maDe", maDe)
            ));
        }


        public List<DeThiDTO> LayDeThiCuaNhom(long maNhom)
        {
            string query = @"
        SELECT dt.*
        FROM de_thi dt
        INNER JOIN de_thi_nhom dtn ON dt.ma_de = dtn.ma_de
        WHERE dtn.ma_nhom = @maNhom";

            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@maNhom", maNhom));

            var list = new List<DeThiDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DeThiDTO
                {
                    MaDe = Convert.ToInt64(row["ma_de"]),
                    TenDe = row["ten_de"]?.ToString(),

                    ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value
                        ? null : Convert.ToDateTime(row["thoi_gian_bat_dau"]),

                    ThoiGianKetThuc = row["thoi_gian_ket_thuc"] == DBNull.Value
                        ? null : Convert.ToDateTime(row["thoi_gian_ket_thuc"]),

                    ThoiGianLamBai = row["thoi_gian_lam_bai"] == DBNull.Value ? 0 : Convert.ToInt32(row["thoi_gian_lam_bai"]),
                    CanhBaoNeuDuoi = row["canh_bao_neu_duoi"] == DBNull.Value ? 0 : Convert.ToInt32(row["canh_bao_neu_duoi"]),
                    SoCauDe = row["so_cau_de"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_de"]),
                    SoCauTrungBinh = row["so_cau_trung_binh"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_trung_binh"]),
                    SoCauKho = row["so_cau_kho"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_kho"]),
                    TrangThai = row["trang_thai"] == DBNull.Value ? 0 : Convert.ToInt32(row["trang_thai"])
                });
            }

            return list;
        }


        // XÓA MỀM: Chỉ xóa khỏi bảng de_thi_nhom (không đụng vào bảng de_thi)
        public bool XoaDeThiKhoiNhom(long maDe, long maNhom)
        {
            string query = "DELETE FROM de_thi_nhom WHERE ma_de = @maDe AND ma_nhom = @maNhom";
            var parameters = new[]
            {
                new SqlParameter("@maDe", maDe),
                new SqlParameter("@maNhom", maNhom)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}