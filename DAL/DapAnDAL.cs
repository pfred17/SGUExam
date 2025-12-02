using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class DapAnDAL
    {
        public List<DapAnDTO> GetByCauHoi(long maCauHoi)
        {
            var list = new List<DapAnDTO>();
            string query = "SELECT ma_dap_an, noi_dung, dung FROM dap_an WHERE ma_cau_hoi = @MaCH ORDER BY ma_dap_an";
            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaCH", maCauHoi));
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new DapAnDTO
                {
                    MaDapAn = Convert.ToInt64(row["ma_dap_an"]),
                    NoiDung = row["noi_dung"]?.ToString() ?? string.Empty,
                    Dung = Convert.ToBoolean(row["dung"]),
                    MaCauHoi = maCauHoi
                });
            }
            return list;
        }
        public void ThemDapAn(List<DapAnDTO> dapAnList)
        {
            foreach (var da in dapAnList)
            {
                string query = @"
                    INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung)
                    VALUES (@MaCH, @NoiDung, @Dung)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaCH", da.MaCauHoi),
                    new SqlParameter("@NoiDung", da.NoiDung),
                    new SqlParameter("@Dung", da.Dung));
            }
        }
        public void CapNhat(DapAnDTO da)
        {
            string query = @"
                UPDATE dap_an 
                SET noi_dung=@NoiDung, dung=@Dung
                WHERE ma_dap_an=@MaDA";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@NoiDung", da.NoiDung),
                new SqlParameter("@Dung", da.Dung),
                new SqlParameter("@MaDA", da.MaDapAn));
        }
        public void Xoa(long maDapAn)
        {
            string query = "DELETE FROM dap_an WHERE ma_dap_an=@MaDA";
            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MaDA", maDapAn));
        }
        public void XoaTheoCauHoi(long maCauHoi)
        {
            // Xóa các đáp án chưa được sử dụng trong bai_lam_chi_tiet
            string query = @"
                DELETE FROM dap_an
                WHERE ma_cau_hoi = @MaCH
                  AND ma_dap_an NOT IN (
                      SELECT DISTINCT ma_dap_an_chon 
                      FROM bai_lam_chi_tiet
                  )";

            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MaCH", maCauHoi));
        }
    }
}