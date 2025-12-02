using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class CauHoiDAL
    {
        public List<CauHoiDTO> GetAllForDisplay()
        {
            var list = new List<CauHoiDTO>();
            string query = @"
            SELECT ch.ma_cau_hoi, ch.noi_dung, ch.do_kho,cg.ma_chuong, mh.ma_mh, mh.ten_mh
            FROM cau_hoi ch
            JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
            JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
            WHERE ch.trang_thai = 1
            ORDER BY ch.ma_cau_hoi ASC";

            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CauHoiDTO
                {
                    MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                    NoiDung = row["noi_dung"].ToString(),
                    DoKho = row["do_kho"].ToString(),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
                    TenMonHoc = row["ten_mh"].ToString()
                });
            }

            return list;
        }
        public CauHoiDTO? GetById(long maCauHoi)
        {
            string query = @"
            SELECT ch.*, cg.ma_mh, mh.ten_mh
            FROM cau_hoi ch
            JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
            JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
            WHERE ch.ma_cau_hoi = @MaCH";

            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaCH", maCauHoi));

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new CauHoiDTO
            {
                MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                MaChuong = Convert.ToInt64(row["ma_chuong"]),
                MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                NoiDung = row["noi_dung"].ToString(),
                DoKho = row["do_kho"].ToString(),
                TenMonHoc = row["ten_mh"].ToString(),
            };
        }


       
        public long ThemMoi(long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            string query = @"
            INSERT INTO cau_hoi (ma_chuong, noi_dung, do_kho, trang_thai)
            VALUES (@c, @n, @d, 1);
            SELECT SCOPE_IDENTITY();";

            object result = DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@c", maChuong),
                new SqlParameter("@n", noiDung),
                new SqlParameter("@d", doKho)
            );

            return Convert.ToInt64(result);
        }

        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> list)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            // update câu hỏi
            using (var cmd = new SqlCommand(
                "UPDATE cau_hoi SET ma_chuong=@c, noi_dung=@n, do_kho=@d WHERE ma_cau_hoi=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", maCauHoi);
                cmd.Parameters.AddWithValue("@c", maChuong);
                cmd.Parameters.AddWithValue("@n", noiDung);
                cmd.Parameters.AddWithValue("@d", doKho);
                cmd.ExecuteNonQuery();
            }

            // lấy danh sách đáp án cũ (key = ma_dap_an)
            var old = new HashSet<long>();
            using (var cmd = new SqlCommand("SELECT ma_dap_an FROM dap_an WHERE ma_cau_hoi=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", maCauHoi);
                using var rd = cmd.ExecuteReader();
                while (rd.Read()) old.Add(rd.GetInt64(0));
            }

            // update hoặc insert
            foreach (var da in list)
            {
                if (old.Contains(da.MaDapAn))
                {
                    using var u = new SqlCommand(
                        "UPDATE dap_an SET noi_dung=@n, dung=@d WHERE ma_dap_an=@id", conn);
                    u.Parameters.AddWithValue("@id", da.MaDapAn);
                    u.Parameters.AddWithValue("@n", da.NoiDung);
                    u.Parameters.AddWithValue("@d", da.Dung ? 1 : 0);
                    u.ExecuteNonQuery();
                }
                else
                {
                    using var i = new SqlCommand(
                        "INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung) VALUES (@ch, @n, @d)", conn);
                    i.Parameters.AddWithValue("@ch", maCauHoi);
                    i.Parameters.AddWithValue("@n", da.NoiDung);
                    i.Parameters.AddWithValue("@d", da.Dung ? 1 : 0);
                    i.ExecuteNonQuery();
                }
            }
        }
        public void Xoa(long maCauHoi)
        {
            string query = "UPDATE cau_hoi SET trang_thai=0 WHERE ma_cau_hoi=@MaCH";
            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MaCH", maCauHoi));
        }


        public List<CauHoiDTO> GetAllForDisplayTrungLap()
        {
            var list = new List<CauHoiDTO>();

            string query = @"
                SELECT ch.ma_cau_hoi, ch.noi_dung, mh.ten_mh, mh.ma_mh,
                       ch.do_kho, cg.ma_chuong,
                       MIN(nd.ho_ten) AS TacGia
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                LEFT JOIN phan_cong pc ON mh.ma_mh = pc.ma_mh
                LEFT JOIN nguoi_dung nd ON pc.ma_nd = nd.ma_nd
                WHERE ch.trang_thai = 1
                GROUP BY ch.ma_cau_hoi, ch.noi_dung, mh.ten_mh, mh.ma_mh, ch.do_kho, cg.ma_chuong
                ORDER BY ch.ma_cau_hoi";

            var dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CauHoiDTO
                {
                    MaCauHoi = (long)row["ma_cau_hoi"],
                    NoiDung = row["noi_dung"].ToString(),
                    DoKho = row["do_kho"].ToString(),
                    MaMonHoc = (long)row["ma_mh"],
                    MaChuong = (long)row["ma_chuong"],
                    TenMonHoc = row["ten_mh"].ToString(),
                    TacGia = row["TacGia"].ToString()
                });
            }
            return list;
        }

        public List<CauHoiDTO> LayThongKeDoKho(long maMonHoc)
        {
            string query = @"
                        WITH ThongKe AS (
                SELECT ct.ma_cau_hoi,
                       SUM(CASE WHEN da.dung = 0 THEN 1 ELSE 0 END) AS SoLanSai,
                       COUNT(*) AS SoLuotLam
                FROM bai_lam_chi_tiet ct
                JOIN dap_an da ON ct.ma_dap_an_chon = da.ma_dap_an
                GROUP BY ct.ma_cau_hoi
                )
                SELECT ch.ma_cau_hoi, ch.noi_dung, ch.do_kho,
                       ISNULL(tk.SoLuotLam, 0) AS SoLuotLam,
                       ISNULL(tk.SoLanSai, 0) AS SoLanSai,
                       CASE WHEN ISNULL(tk.SoLuotLam, 0) = 0 THEN 0
                            ELSE CAST(ISNULL(tk.SoLanSai, 0) AS float) / ISNULL(tk.SoLuotLam, 0)
                       END AS TyLeSai
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                LEFT JOIN ThongKe tk ON ch.ma_cau_hoi = tk.ma_cau_hoi
                WHERE ch.trang_thai = 1 AND (@MaMH = 0 OR mh.ma_mh = @MaMH)
                ORDER BY ch.ma_cau_hoi";

            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaMH", maMonHoc));

            return dt.AsEnumerable().Select(row => new CauHoiDTO
            {
                MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                NoiDung = row["noi_dung"].ToString(),
                DoKho = row["do_kho"].ToString(),
                SoLuotLam = Convert.ToInt32(row["SoLuotLam"]),
                TyLeSai = Convert.ToDouble(row["TyLeSai"])
            }).ToList();
        }

        public void CapNhatDoKho(long maCauHoi, string doKhoMoi)
        {
            string query = "UPDATE cau_hoi SET do_kho=@d WHERE ma_cau_hoi=@id";
            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@d", doKhoMoi),
                new SqlParameter("@id", maCauHoi));
        }
    }
}
