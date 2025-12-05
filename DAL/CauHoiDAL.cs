using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class CauHoiDAL
    {
        private readonly DapAnDAL _dapAnDAL = new DapAnDAL();

        public List<CauHoiDTO> GetAllForDisplay(long maMH = 0, long maChuong = 0, string doKho = "", string tuKhoa = "")
        {
            var list = new List<CauHoiDTO>();
            string query = @"
                SELECT ch.ma_cau_hoi, ch.noi_dung, mh.ten_mh, mh.ma_mh, ch.do_kho, cg.ma_chuong 
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                WHERE ch.trang_thai = 1
                ORDER BY ch.ma_cau_hoi ASC";

            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new CauHoiDTO
                {
                    MaCauHoi = (long)row["ma_cau_hoi"],
                    NoiDung = (string)row["noi_dung"],
                    DoKho = (string)row["do_kho"],
                    MaMonHoc = (long)row["ma_mh"],
                    MaChuong = (long)row["ma_chuong"],
                    TenMonHoc = (string)row["ten_mh"],
                });
            }
            return list;
        }
        public CauHoiDTO? GetById(long maCauHoi)
        {
            string query = @"
                SELECT ch.*, cg.ma_mh, mh.ten_mh, cg.ten_chuong
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                WHERE ch.ma_cau_hoi = @MaCH";

            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaCH", maCauHoi));
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new CauHoiDTO
                {
                    MaCauHoi = Convert.ToInt64(row["ma_cau_hoi"]),
                    MaChuong = Convert.ToInt64(row["ma_chuong"]),
                    MaMonHoc = Convert.ToInt64(row["ma_mh"]),
                    NoiDung = row["noi_dung"]?.ToString() ?? "",
                    DoKho = row["do_kho"]?.ToString() ?? "",
                    TenMonHoc = row["ten_mh"]?.ToString() ?? "",
                };
            }
            return null;
        }

        public long ThemMoi(long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction(); // BeginTransaction là bắt đầu một giao dịch
            try
            {
                string insertCH = @"INSERT INTO cau_hoi (ma_chuong, noi_dung, do_kho, trang_thai)
                                    VALUES (@MaChuong, @NoiDung, @DoKho, 1);
                                    SELECT SCOPE_IDENTITY();";

                var cmd = new SqlCommand(insertCH, conn, tran);
                cmd.Parameters.AddWithValue("@MaChuong", maChuong);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@DoKho", doKho);
                long maCauHoi = Convert.ToInt64(cmd.ExecuteScalar());

                // thêm đáp án cho câu hỏi vừa tạo dùng transaction
                string insertDA = "INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung) VALUES (@MaCH, @NoiDung, @Dung)";
                foreach (var da in dapAnList)
                {
                    var cmdDA = new SqlCommand(insertDA, conn, tran);
                    cmdDA.Parameters.AddWithValue("@MaCH", maCauHoi);
                    cmdDA.Parameters.AddWithValue("@NoiDung", da.NoiDung);
                    cmdDA.Parameters.AddWithValue("@Dung", da.Dung ? 1 : 0);
                    cmdDA.ExecuteNonQuery();
                }

                tran.Commit(); // Nếu tất cả các lệnh trên thành công, commit transaction
                return maCauHoi;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
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

        public void Xoa(long maCauHoi) // Xóa mềm
        {
            string query = "UPDATE cau_hoi SET trang_thai=0 WHERE ma_cau_hoi=@MaCH";
            var param = new SqlParameter("@MaCH", maCauHoi);
            DatabaseHelper.ExecuteNonQuery(query, param);
        }

    }
}