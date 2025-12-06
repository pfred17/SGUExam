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
        public DeThiDTO GetFullDetailById(long maDe)
        {
            // 1. Lấy thông tin đề thi
            var dtTable = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM de_thi WHERE ma_de = " + maDe);

            if (dtTable.Rows.Count == 0)
                return null; // Không tồn tại đề thi

            DataRow row = dtTable.Rows[0];

            var dto = new DeThiDTO
            {
                MaDe = maDe,
                TenDe = row["ten_de"].ToString(),
                ThoiGianBatDau = row["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_bat_dau"]),
                ThoiGianKetThuc = row["thoi_gian_ket_thuc"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["thoi_gian_ket_thuc"]),
                ThoiGianLamBai = row["thoi_gian_lam_bai"] == DBNull.Value ? 0 : Convert.ToInt32(row["thoi_gian_lam_bai"]),
                CanhBaoNeuDuoi = row.Table.Columns.Contains("canh_bao_neu_duoi") && row["canh_bao_neu_duoi"] != DBNull.Value ? Convert.ToInt32(row["canh_bao_neu_duoi"]) : 0,
                SoCauDe = row["so_cau_de"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_de"]),
                SoCauTrungBinh = row["so_cau_trung_binh"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_trung_binh"]),
                SoCauKho = row["so_cau_kho"] == DBNull.Value ? 0 : Convert.ToInt32(row["so_cau_kho"]),
                TrangThai = row["trang_thai"] == DBNull.Value ? 1 : Convert.ToInt32(row["trang_thai"]),
            };

            // 2. Lấy cấu hình đề thi
            var cauHinhTable = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM de_thi_cau_hinh WHERE ma_de = " + maDe);

            if (cauHinhTable.Rows.Count > 0)
            {
                var chRow = cauHinhTable.Rows[0];
                dto.CauHinh = new DeThiCauHinhDTO
                {
                    TuDongLay = Convert.ToBoolean(chRow["tu_dong_lay"]),
                    XemDiemSauThi = Convert.ToBoolean(chRow["xem_diem_sau_thi"]),
                    XemDapAnSauThi = Convert.ToBoolean(chRow["xem_dap_an_sau_thi"]),
                    XemBaiLam = Convert.ToBoolean(chRow["xem_bai_lam"]),
                    DaoCauHoi = Convert.ToBoolean(chRow["dao_cau_hoi"]),
                    DaoDapAn = Convert.ToBoolean(chRow["dao_dap_an"]),
                    TuDongNop = Convert.ToBoolean(chRow["tu_dong_nop"]),
                    DeLuyenTap = chRow.Table.Columns.Contains("de_luyen_tap") ? Convert.ToBoolean(chRow["de_luyen_tap"]) : false,
                    TinhDiem = chRow.Table.Columns.Contains("tinh_diem") ? Convert.ToBoolean(chRow["tinh_diem"]) : false
                };
            }

            // 3. Lấy nhóm học phần
            var nhomTable = DatabaseHelper.ExecuteQuery(@"
        SELECT dt.ma_de, nh.ma_nhom, nh.ten_nhom
        FROM de_thi_nhom dt
        JOIN nhom_hoc_phan nh ON dt.ma_nhom = nh.ma_nhom
        WHERE dt.ma_de = " + maDe);

            dto.NhomHocPhanIds = nhomTable.AsEnumerable()
                .Select(r => Convert.ToInt64(r["ma_nhom"]))
                .ToList();

            dto.TenNhomHocPhan = string.Join(", ",
                nhomTable.AsEnumerable().Select(r => r["ten_nhom"].ToString()));

            // 4. Lấy chương
            var chuongTable = DatabaseHelper.ExecuteQuery(@"
        SELECT dt.ma_de, ch.ma_chuong, ch.ten_chuong
        FROM de_thi_chuong dt
        JOIN chuong ch ON dt.ma_chuong = ch.ma_chuong
        WHERE dt.ma_de = " + maDe);

            dto.ChuongIds = chuongTable.AsEnumerable()
                .Select(r => Convert.ToInt64(r["ma_chuong"]))
                .ToList();

            return dto;
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
        public bool UpdateDeThi(DeThiDTO deThi)
        {
            // 1. Update de_thi
            string query = @"
        UPDATE de_thi SET
            ten_de = @ten,
            thoi_gian_bat_dau = @bd,
            thoi_gian_ket_thuc = @kt,
            thoi_gian_lam_bai = @tg,
            canh_bao_neu_duoi = @cb,
            so_cau_de = @cd,
            so_cau_trung_binh = @ctb,
            so_cau_kho = @ck,
            trang_thai = @tt
        WHERE ma_de = @ma";
            var parameters = new SqlParameter[]
            {
        new("@ten", deThi.TenDe),
        new("@bd", deThi.ThoiGianBatDau ?? (object)DBNull.Value),
        new("@kt", deThi.ThoiGianKetThuc ?? (object)DBNull.Value),
        new("@tg", deThi.ThoiGianLamBai),
        new("@cb", deThi.CanhBaoNeuDuoi),
        new("@cd", deThi.SoCauDe),
        new("@ctb", deThi.SoCauTrungBinh),
        new("@ck", deThi.SoCauKho),
        new("@tt", deThi.TrangThai),
        new("@ma", deThi.MaDe)
            };
            int affected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            // 2. Update de_thi_cau_hinh
            string qCauHinh = @"
        UPDATE de_thi_cau_hinh SET
            tu_dong_lay = @tdl,
            xem_diem_sau_thi = @xd,
            xem_dap_an_sau_thi = @xda,
            xem_bai_lam = @xbl,
            dao_cau_hoi = @dch,
            dao_dap_an = @dda,
            tu_dong_nop = @tdn,
            de_luyen_tap = @dlt,
            tinh_diem = @td
        WHERE ma_de = @ma";
            var pConfig = new SqlParameter[]
            {
        new("@tdl", deThi.CauHinh.TuDongLay),
        new("@xd", deThi.CauHinh.XemDiemSauThi),
        new("@xda", deThi.CauHinh.XemDapAnSauThi),
        new("@xbl", deThi.CauHinh.XemBaiLam),
        new("@dch", deThi.CauHinh.DaoCauHoi),
        new("@dda", deThi.CauHinh.DaoDapAn),
        new("@tdn", deThi.CauHinh.TuDongNop),
        new("@dlt", deThi.CauHinh.DeLuyenTap),
        new("@td", deThi.CauHinh.TinhDiem),
        new("@ma", deThi.MaDe)
            };
            DatabaseHelper.ExecuteNonQuery(qCauHinh, pConfig);

            // 3. Xóa và thêm lại nhóm học phần
            DatabaseHelper.ExecuteNonQuery("DELETE FROM de_thi_nhom WHERE ma_de = @ma", new SqlParameter("@ma", deThi.MaDe));
            if (deThi.NhomHocPhanIds != null)
            {
                foreach (var id in deThi.NhomHocPhanIds)
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO de_thi_nhom (ma_de, ma_nhom) VALUES (@ma, @nhom)",
                        new SqlParameter("@ma", deThi.MaDe),
                        new SqlParameter("@nhom", id)
                    );
                }
            }

            // 4. Xóa và thêm lại chương
            DatabaseHelper.ExecuteNonQuery("DELETE FROM de_thi_chuong WHERE ma_de = @ma", new SqlParameter("@ma", deThi.MaDe));
            if (deThi.ChuongIds != null)
            {
                foreach (var id in deThi.ChuongIds)
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO de_thi_chuong (ma_de, ma_chuong) VALUES (@ma, @chuong)",
                        new SqlParameter("@ma", deThi.MaDe),
                        new SqlParameter("@chuong", id)
                    );
                }
            }

            // 5. Không động đến de_thi_cau_hoi ở đây (xử lý riêng nếu cần)
            return affected > 0;
        }
        public void DeleteDeThiCauHoi(long maDe)
        {
            string sql = "DELETE FROM de_thi_cau_hoi WHERE ma_de = @maDe";
            DatabaseHelper.ExecuteNonQuery(sql, new Microsoft.Data.SqlClient.SqlParameter("@maDe", maDe));
        }
        public bool DeleteDeThi(long maDe)
        {
            try
            {
                // 1
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM bai_lam_chi_tiet WHERE ma_bai IN (SELECT ma_bai FROM bai_lam WHERE ma_de = @maDe)",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 2
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM bai_lam WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 3
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM de_thi_nhom WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 4
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM de_thi_chuong WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 5
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM de_thi_cau_hinh WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 6
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM de_thi_cau_hoi WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                // 7
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM de_thi WHERE ma_de = @maDe",
                    new SqlParameter("@maDe", SqlDbType.BigInt) { Value = maDe });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }





    }
}
