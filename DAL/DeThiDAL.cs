using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DeThiDAL
    {
        private DeThiDTO MapDeThi(DataRow row)
        {
            return new DeThiDTO
            {
                MaDe = Convert.ToInt64(row["ma_de"]),
                TenDe = row["ten_de"].ToString(),
                ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                ThoiGianKetThuc = row["thoi_gian_ket_thuc"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_ket_thuc"]),
                ThoiGianLamBai = row["thoi_gian_lam_bai"] == DBNull.Value ? 0 : Convert.ToInt32(row["thoi_gian_lam_bai"]),
                TrangThai = row["trang_thai"] == DBNull.Value ? 1 : Convert.ToInt32(row["trang_thai"]),
                TenNhomHocPhan = row.Table.Columns.Contains("ten_nhom") ? row["ten_nhom"].ToString() : null
            };
        }

        public List<DeThiDTO> GetAll()
        {
            string query = "SELECT * FROM de_thi";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            var list = new List<DeThiDTO>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                list.Add(MapDeThi(row));

            return list;
        }

        public List<BangDiemItemDTO> GetBangDiemByDeThi(long maDe)
        {
            var result = new List<BangDiemItemDTO>();
            string query = @"
                SELECT bl.ma_nd, nd.ho_ten, bl.diem, 
                       bl.thoi_gian_bat_dau, bl.thoi_gian_nop,
                       DATEDIFF(MINUTE, bl.thoi_gian_bat_dau, bl.thoi_gian_nop) AS thoi_gian_thi
                FROM bai_lam bl
                JOIN nguoi_dung nd ON bl.ma_nd = nd.ma_nd
                WHERE bl.ma_de = @maDe";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@maDe", maDe));
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BangDiemItemDTO
                {
                    MSSV = row["ma_nd"].ToString(),
                    HoTen = row["ho_ten"].ToString(),
                    Diem = row["diem"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["diem"]),
                    ThoiGianVaoThi = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                    ThoiGianNopBai = row["thoi_gian_nop"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_nop"]),
                    ThoiGianThi = row["thoi_gian_thi"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["thoi_gian_thi"])
                });
            }
            return result;
        }

        public long InsertDeThi(DeThiDTO deThi)
        {
            string query = @"
                INSERT INTO de_thi
                (ten_de, thoi_gian_bat_dau, thoi_gian_ket_thuc, thoi_gian_lam_bai, 
                 canh_bao_neu_duoi, so_cau_de, so_cau_trung_binh, so_cau_kho, trang_thai)
                VALUES (@ten, @bd, @kt, @tg, @cb, @cd, @ctb, @ck, 1);
                SELECT SCOPE_IDENTITY();";

            var parameters = new SqlParameter[]
            {
                new("@ten", deThi.TenDe),
                new("@bd", deThi.ThoiGianBatDau ?? (object)DBNull.Value),
                new("@kt", deThi.ThoiGianKetThuc ?? (object)DBNull.Value),
                new("@tg", deThi.ThoiGianLamBai),
                new("@cb", deThi.CanhBaoNeuDuoi),
                new("@cd", deThi.SoCauDe),
                new("@ctb", deThi.SoCauTrungBinh),
                new("@ck", deThi.SoCauKho)
            };

            long maDe = Convert.ToInt64(DatabaseHelper.ExecuteScalar(query, parameters));

            string qCauHinh = @"
                INSERT INTO de_thi_cau_hinh
                (ma_de, tu_dong_lay, xem_diem_sau_thi, xem_dap_an_sau_thi,
                 xem_bai_lam, dao_cau_hoi, dao_dap_an, tu_dong_nop, de_luyen_tap, tinh_diem)
                VALUES (@ma, @tdl, @xd, @xda, @xbl, @dch, @dda, @tdn, @dlt, @td)";

            var pConfig = new SqlParameter[]
            {
                new("@ma", maDe),
                new("@tdl", deThi.CauHinh.TuDongLay),
                new("@xd", deThi.CauHinh.XemDiemSauThi),
                new("@xda", deThi.CauHinh.XemDapAnSauThi),
                new("@xbl", deThi.CauHinh.XemBaiLam),
                new("@dch", deThi.CauHinh.DaoCauHoi),
                new("@dda", deThi.CauHinh.DaoDapAn),
                new("@tdn", deThi.CauHinh.TuDongNop),
                new("@dlt", deThi.CauHinh.DeLuyenTap),
                new("@td", deThi.CauHinh.TinhDiem)
            };

            DatabaseHelper.ExecuteNonQuery(qCauHinh, pConfig);

            foreach (var id in deThi.NhomHocPhanIds)
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_nhom (ma_de, ma_nhom) VALUES (@ma, @nhom)",
                    new SqlParameter("@ma", maDe),
                    new SqlParameter("@nhom", id)
                );

            foreach (var id in deThi.ChuongIds)
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_chuong (ma_de, ma_chuong) VALUES (@ma, @chuong)",
                    new SqlParameter("@ma", maDe),
                    new SqlParameter("@chuong", id)
                );

            return maDe;
        }

        public List<DeThiDTO> GetAllWithNhomHocPhan()
        {
            string query = @"
                SELECT dt.*, nhp.ten_nhom
                FROM de_thi dt
                LEFT JOIN de_thi_nhom dtn ON dt.ma_de = dtn.ma_de
                LEFT JOIN nhom_hoc_phan nhp ON nhp.ma_nhom = dtn.ma_nhom";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            var list = new List<DeThiDTO>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
                list.Add(MapDeThi(row));

            return list;
        }

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
        public List<DeThiDTO> GetDeKiemTraByMaNhom(long maNhom)
        {
            List<DeThiDTO> list = new List<DeThiDTO>();
            string query = @"
                SELECT dt.*
                FROM de_thi dt
                INNER JOIN de_thi_nhom dtn ON dt.ma_de = dtn.ma_de
                INNER JOIN nhom_hoc_phan nhp ON dtn.ma_nhom = nhp.ma_nhom
                INNER JOIN de_thi_cau_hinh dtch ON dt.ma_de = dtch.ma_de
                WHERE dtn.ma_nhom = @maNhom and dtch.de_luyen_tap = 0";
            SqlParameter parameter = new SqlParameter("@maNhom", maNhom);
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameter);
   
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDeThi(row));
            }
            return list;

        }
        public List<DeThiDTO> GetDeLuyenTapByMaNhom(long maNhom)
        {
            List<DeThiDTO> list = new List<DeThiDTO>();
            string query = @"
                SELECT dt.*
                FROM de_thi dt
                INNER JOIN de_thi_nhom dtn ON dt.ma_de = dtn.ma_de
                INNER JOIN nhom_hoc_phan nhp ON dtn.ma_nhom = nhp.ma_nhom
                INNER JOIN de_thi_cau_hinh dtch ON dt.ma_de = dtch.ma_de
                WHERE dtn.ma_nhom = @maNhom and dtch.de_luyen_tap = 1";
            SqlParameter parameter = new SqlParameter("@maNhom", maNhom);
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameter);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDeThi(row));
            }
            return list;

        }

    }
}
