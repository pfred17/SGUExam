using DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CauHoiDAL
    {
        public List<CauHoiDTO> GetAllForDisplay()
        {
            var list = new List<CauHoiDTO>();
            string query = @"
                SELECT ch.ma_cau_hoi, ch.noi_dung, ch.do_kho, cg.ma_chuong, mh.ma_mh, mh.ten_mh
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                WHERE ch.trang_thai = 1
                ORDER BY ch.ma_cau_hoi";

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
        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 1. Cập nhật bảng cau_hoi
                string updateCH = @"UPDATE cau_hoi 
                            SET ma_chuong=@chuong, noi_dung=@nd, do_kho=@dk
                            WHERE ma_cau_hoi=@id";
                using (var cmd = new SqlCommand(updateCH, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@id", maCauHoi);
                    cmd.Parameters.AddWithValue("@chuong", maChuong);
                    cmd.Parameters.AddWithValue("@nd", noiDung);
                    cmd.Parameters.AddWithValue("@dk", doKho);
                    cmd.ExecuteNonQuery();
                }

                // 2. Lấy danh sách đáp án hiện tại trong DB
                HashSet<long> oldAnswerIds = new();
                using (var cmd = new SqlCommand("SELECT ma_dap_an FROM dap_an WHERE ma_cau_hoi=@id", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@id", maCauHoi);
                    using var rd = cmd.ExecuteReader();
                    while (rd.Read())
                        oldAnswerIds.Add(rd.GetInt64(0));
                }

                // 3. Kiểm tra đáp án gửi từ GUI có nằm trong DB không
                foreach (var da in dapAnList.Where(d => d.MaDapAn > 0 && !oldAnswerIds.Contains(d.MaDapAn)))
                {
                    throw new Exception($"Không thể xóa/đổi đáp án '{da.NoiDung}' vì đã được sử dụng trong bài làm chi tiết.");
                }

                // 4. Xóa đáp án không còn trong danh sách mới
                var newAnswerIds = dapAnList.Where(d => d.MaDapAn > 0).Select(d => d.MaDapAn).ToHashSet();
                var toDelete = oldAnswerIds.Except(newAnswerIds).ToList();
                foreach (var del in toDelete)
                {
                    // Kiểm tra xem đáp án có trong bai_lam_chi_tiet không
                    string check = "SELECT COUNT(*) FROM bai_lam_chi_tiet WHERE ma_dap_an_chon=@id";
                    int used = Convert.ToInt32(DatabaseHelper.ExecuteScalar(check, new SqlParameter("@id", del)));

                    if (used > 0)
                    {
                        // Lấy nội dung đáp án để hiển thị thông báo
                        string queryNoiDung = "SELECT noi_dung FROM dap_an WHERE ma_dap_an=@id";
                        string noiDungDel = (string)DatabaseHelper.ExecuteScalar(queryNoiDung, new SqlParameter("@id", del));

                        throw new Exception($"Không thể xóa đáp án '{noiDungDel}' vì đã được sử dụng trong bài làm chi tiết.");
                    }

                    // Xóa nếu chưa dùng
                    string delQuery = "DELETE FROM dap_an WHERE ma_dap_an=@id";
                    DatabaseHelper.ExecuteNonQuery(delQuery, new SqlParameter("@id", del));
                }

                // 5. Update hoặc Insert đáp án còn lại
                foreach (var da in dapAnList)
                {
                    if (da.MaDapAn > 0)
                    {
                        string updateDA = @"UPDATE dap_an 
                                    SET noi_dung=@nd, dung=@dung
                                    WHERE ma_dap_an=@id";
                        using var cmd = new SqlCommand(updateDA, conn, tran);
                        cmd.Parameters.AddWithValue("@id", da.MaDapAn);
                        cmd.Parameters.AddWithValue("@nd", da.NoiDung);
                        cmd.Parameters.AddWithValue("@dung", da.Dung);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertDA = @"INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung)
                                    VALUES (@ch, @nd, @dung)";
                        using var cmd = new SqlCommand(insertDA, conn, tran);
                        cmd.Parameters.AddWithValue("@ch", maCauHoi);
                        cmd.Parameters.AddWithValue("@nd", da.NoiDung);
                        cmd.Parameters.AddWithValue("@dung", da.Dung);
                        cmd.ExecuteNonQuery();
                    }
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
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
                SELECT ch.ma_cau_hoi, ch.noi_dung, mh.ten_mh, mh.ma_mh, ch.do_kho, cg.ma_chuong,
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
                    MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                    NoiDung = row["noi_dung"].ToString(),
                    DoKho = row["do_kho"].ToString(),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
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
                       CASE WHEN ISNULL(tk.SoLuotLam,0)=0 THEN 0
                            ELSE CAST(ISNULL(tk.SoLanSai,0) AS float)/ISNULL(tk.SoLuotLam,0)
                       END AS TyLeSai
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                LEFT JOIN ThongKe tk ON ch.ma_cau_hoi=tk.ma_cau_hoi
                WHERE ch.trang_thai=1 AND (@MaMH=0 OR mh.ma_mh=@MaMH)
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
        public List<CauHoiDTO> GetCauHoiByChuongAndTrangThai(List<long> chuongIds, int trangThai)
        {
            var list = new List<CauHoiDTO>();
            if (chuongIds == null || chuongIds.Count == 0) return list;

            // Build IN clause safely
            string inClause = string.Join(",", chuongIds.Select((id, idx) => $"@id{idx}"));
            string query = $@"
        SELECT ch.ma_cau_hoi, ch.noi_dung, ch.do_kho, ch.ma_chuong
        FROM cau_hoi ch
        WHERE ch.ma_chuong IN ({inClause}) AND ch.trang_thai = @trangThai";

            var parameters = chuongIds
                .Select((id, idx) => new SqlParameter($"@id{idx}", id))
                .ToList();
            parameters.Add(new SqlParameter("@trangThai", trangThai));

            var dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new CauHoiDTO
                {
                    MaCauHoi = (long)row["ma_cau_hoi"],
                    NoiDung = row["noi_dung"].ToString(),
                    DoKho = row["do_kho"].ToString(),
                    MaChuong = (long)row["ma_chuong"]
                });
            }
            return list;
        }


    }
}