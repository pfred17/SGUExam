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
            string queryDeThi = "SELECT * FROM de_thi";
            DataTable dtDeThi = DatabaseHelper.ExecuteQuery(queryDeThi);

            string queryNhom = @"
        SELECT dtn.ma_de, dtn.ma_nhom, nhp.ten_nhom
        FROM de_thi_nhom dtn
        JOIN nhom_hoc_phan nhp ON nhp.ma_nhom = dtn.ma_nhom";
            DataTable dtNhom = DatabaseHelper.ExecuteQuery(queryNhom);

            var nhomDict = new Dictionary<long, List<(long, string)>>();

            foreach (DataRow row in dtNhom.Rows)
            {
                long maDe = Convert.ToInt64(row["ma_de"]);
                long maNhom = Convert.ToInt64(row["ma_nhom"]);
                string tenNhom = row["ten_nhom"].ToString();

                if (!nhomDict.ContainsKey(maDe))
                    nhomDict[maDe] = new List<(long, string)>();
                nhomDict[maDe].Add((maNhom, tenNhom));
            }

            var cauHinhDAL = new DeThiCauHinhDAL();
            var list = new List<DeThiDTO>(dtDeThi.Rows.Count);

            foreach (DataRow row in dtDeThi.Rows)
            {
                var deThi = MapDeThi(row);

                if (nhomDict.TryGetValue(deThi.MaDe, out var nhomList))
                {
                    deThi.NhomHocPhanIds = nhomList.Select(x => x.Item1).ToList();
                    deThi.TenNhomHocPhan = string.Join(", ", nhomList.Select(x => x.Item2));
                }
                else
                {
                    deThi.NhomHocPhanIds = new List<long>();
                    deThi.TenNhomHocPhan = null;
                }

                // Sử dụng DeThiCauHinhDAL để lấy cấu hình đề thi
                deThi.CauHinh = cauHinhDAL.GetByMaDe(deThi.MaDe);

                list.Add(deThi);
            }

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
        public void InsertDeThiChuong(long maDe, List<long> chuongIds)
        {
            if (chuongIds == null || chuongIds.Count == 0) return;
            foreach (var id in chuongIds)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_chuong (ma_de, ma_chuong) VALUES (@maDe, @maChuong)",
                    new SqlParameter("@maDe", maDe),
                    new SqlParameter("@maChuong", id)
                );
            }
        }

        public void InsertDeThiNhom(long maDe, List<long> nhomHocPhanIds)
        {
            if (nhomHocPhanIds == null || nhomHocPhanIds.Count == 0) return;
            foreach (var id in nhomHocPhanIds)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_nhom (ma_de, ma_nhom) VALUES (@maDe, @maNhom)",
                    new SqlParameter("@maDe", maDe),
                    new SqlParameter("@maNhom", id)
                );
            }
        }
        public void InsertDeThiCauHoi(long maDe, List<long> cauHoiIds)
        {
            if (cauHoiIds == null || cauHoiIds.Count == 0) return;
            foreach (var id in cauHoiIds)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_cau_hoi (ma_de, ma_cau_hoi) VALUES (@maDe, @maCauHoi)",
                    new SqlParameter("@maDe", maDe),
                    new SqlParameter("@maCauHoi", id)
                );
            }
        }


    }
}
