using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DeThiDAL
    {
        // -------------------------
        //   HÀM MAP DỮ LIỆU CHUNG
        // -------------------------
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

        // -------------------------
        //     LẤY TẤT CẢ ĐỀ THI
        // -------------------------
        public List<DeThiDTO> GetAll()
        {
            string query = "SELECT * FROM de_thi";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            var list = new List<DeThiDTO>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                list.Add(MapDeThi(row));

            return list;
        }

        // -------------------------
        //   BẢNG ĐIỂM THEO ĐỀ THI
        // -------------------------
        public List<BangDiemItemDTO> GetBangDiemByDeThi(long maDe)
        {
            var result = new List<BangDiemItemDTO>();

            string query = @"
                SELECT bl.ma_nd, nd.ho_ten, bl.diem, 
                       bl.thoi_gian_bat_dau, bl.thoi_gian_nop,
                       TIMESTAMPDIFF(MINUTE, bl.thoi_gian_bat_dau, bl.thoi_gian_nop) AS thoi_gian_thi
                FROM bai_lam bl
                JOIN nguoi_dung nd ON bl.ma_nd = nd.ma_nd
                WHERE bl.ma_de = @maDe";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maDe", maDe);
                conn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        result.Add(new BangDiemItemDTO
                        {
                            MSSV = rd["ma_nd"].ToString(),
                            HoTen = rd["ho_ten"].ToString(),
                            Diem = rd["diem"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(rd["diem"]),
                            ThoiGianVaoThi = rd["thoi_gian_bat_dau"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(rd["thoi_gian_bat_dau"]),
                            ThoiGianNopBai = rd["thoi_gian_nop"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(rd["thoi_gian_nop"]),
                            ThoiGianThi = rd["thoi_gian_thi"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["thoi_gian_thi"])
                        });
                    }
                }
            }

            return result;
        }

        // -------------------------
        //     THÊM ĐỀ THI
        // -------------------------
        public long InsertDeThi(DeThiDTO deThi)
        {
            string query = @"
                INSERT INTO de_thi
                (ten_de, thoi_gian_bat_dau, thoi_gian_ket_thuc, thoi_gian_lam_bai, 
                 canh_bao_neu_duoi, so_cau_de, so_cau_trung_binh, so_cau_kho, trang_thai)
                VALUES (@ten, @bd, @kt, @tg, @cb, @cd, @ctb, @ck, 1);
                SELECT LAST_INSERT_ID();";

            var parameters = new MySqlParameter[]
            {
                new("@ten", deThi.TenDe),
                new("@bd", deThi.ThoiGianBatDau),
                new("@kt", deThi.ThoiGianKetThuc),
                new("@tg", deThi.ThoiGianLamBai),
                new("@cb", deThi.CanhBaoNeuDuoi),
                new("@cd", deThi.SoCauDe),
                new("@ctb", deThi.SoCauTrungBinh),
                new("@ck", deThi.SoCauKho)
            };

            long maDe = Convert.ToInt64(DatabaseHelper.ExecuteScalar(query, parameters));

            // Insert cấu hình
            string qCauHinh = @"
                INSERT INTO de_thi_cau_hinh
                (ma_de, tu_dong_lay, xem_diem_sau_thi, xem_dap_an_sau_thi,
                 xem_bai_lam, dao_cau_hoi, dao_dap_an, tu_dong_nop, de_luyen_tap, tinh_diem)
                VALUES (@ma, @tdl, @xd, @xda, @xbl, @dch, @dda, @tdn, @dlt, @td)";

            var pConfig = new MySqlParameter[]
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

            // Insert nhóm học phần
            foreach (var id in deThi.NhomHocPhanIds)
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_nhom (ma_de, ma_nhom) VALUES (@ma, @nhom)",
                    new MySqlParameter("@ma", maDe),
                    new MySqlParameter("@nhom", id)
                );

            // Insert chương
            foreach (var id in deThi.ChuongIds)
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO de_thi_chuong (ma_de, ma_chuong) VALUES (@ma, @chuong)",
                    new MySqlParameter("@ma", maDe),
                    new MySqlParameter("@chuong", id)
                );

            return maDe;
        }

        // -------------------------
        //   LẤY ĐỀ + TÊN NHÓM HP
        // -------------------------
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

        // -------------------------
        //   LẤY CÂU HỎI THEO ĐỀ
        // -------------------------
        public List<CauHoiDTO> GetCauHoiTheoDeThi(long maDe)
        {
            string query = @"
                SELECT ch.*
                FROM de_thi_chuong dtc
                JOIN cau_hoi ch ON ch.ma_chuong = dtc.ma_chuong
                WHERE dtc.ma_de = @maDe AND ch.trang_thai = 1";

            var dt = DatabaseHelper.ExecuteQuery(
                query,
                new MySqlParameter("@maDe", maDe)
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

        // -------------------------
        //   ĐẾM SỐ CÂU HỎI THEO ĐỀ
        // -------------------------
        public int GetSoLuongCauHoiTheoDe(long maDe)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM de_thi_chuong dtc
                JOIN cau_hoi ch ON ch.ma_chuong = dtc.ma_chuong
                WHERE dtc.ma_de = @maDe AND ch.trang_thai = 1";

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                sql, new MySqlParameter("@maDe", maDe)
            ));
        }
    }
}
