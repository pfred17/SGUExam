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
                SELECT ch.ma_cau_hoi, ch.noi_dung, mh.ten_mh, mh.ma_mh, ch.do_kho, cg.ma_chuong ,nd.ho_ten AS tac_gia
                FROM cau_hoi ch
                JOIN chuong cg ON ch.ma_chuong = cg.ma_chuong
                JOIN mon_hoc mh ON cg.ma_mh = mh.ma_mh
                LEFT JOIN phan_cong pc ON mh.ma_mh = pc.ma_mh
                LEFT JOIN nguoi_dung nd ON pc.ma_nd = nd.ma_nd
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
                    TacGia = row["tac_gia"]?.ToString() ?? "Chưa rõ tác giả",
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

        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                string updateCH = @"UPDATE cau_hoi 
                                    SET ma_chuong=@MaChuong, noi_dung=@NoiDung, do_kho=@DoKho
                                    WHERE ma_cau_hoi=@MaCH";

                var cmd = new SqlCommand(updateCH, conn, tran);
                cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                cmd.Parameters.AddWithValue("@MaChuong", maChuong);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@DoKho", doKho);
                cmd.ExecuteNonQuery();

                _dapAnDAL.XoaTheoCauHoi(maCauHoi, tran);

                string insertDA = "INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung) VALUES (@MaCH, @NoiDung, @Dung)";
                foreach (var da in dapAnList)
                {
                    var cmdDA = new SqlCommand(insertDA, conn, tran);
                    cmdDA.Parameters.AddWithValue("@MaCH", maCauHoi);
                    cmdDA.Parameters.AddWithValue("@NoiDung", da.NoiDung);
                    cmdDA.Parameters.AddWithValue("@Dung", da.Dung ? 1 : 0);
                    cmdDA.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback(); // Nếu có lỗi xảy ra, rollback transaction
                throw;
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
