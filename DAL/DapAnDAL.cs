using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DapAnDAL
    {
        public List<DapAnDTO> GetByCauHoi(long maCauHoi)
        {
            var list = new List<DapAnDTO>();
            string query = "SELECT ma_dap_an, noi_dung, dung FROM dap_an WHERE ma_cau_hoi=@MaCH ORDER BY ma_dap_an";
            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaCH", maCauHoi));
            foreach (DataRow row in dt.Rows)
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
                string query = "INSERT INTO dap_an (ma_cau_hoi, noi_dung, dung) VALUES (@MaCH,@NoiDung,@Dung)";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaCH", da.MaCauHoi),
                    new SqlParameter("@NoiDung", da.NoiDung),
                    new SqlParameter("@Dung", da.Dung));
            }
        }

        public void CapNhat(DapAnDTO da)
        {
            string query = "UPDATE dap_an SET noi_dung=@NoiDung, dung=@Dung WHERE ma_dap_an=@MaDA";
            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@NoiDung", da.NoiDung),
                new SqlParameter("@Dung", da.Dung),
                new SqlParameter("@MaDA", da.MaDapAn));
        }

        public void Xoa(long maDapAn)
        {
            string check = "SELECT COUNT(*) FROM bai_lam_chi_tiet WHERE ma_dap_an_chon=@id";
            int used = Convert.ToInt32(DatabaseHelper.ExecuteScalar(check, new SqlParameter("@id", maDapAn)));
            if (used > 0)
                throw new Exception($"Không thể xóa đáp án ID={maDapAn} vì đã được sử dụng trong bài làm chi tiết.");

            string query = "DELETE FROM dap_an WHERE ma_dap_an=@id";
            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@id", maDapAn));
        }

        public bool CheckDapAnSuDung(long maDapAn)
        {
            string sql = "SELECT COUNT(*) FROM bai_lam_chi_tiet WHERE ma_dap_an_chon=@id";
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, new SqlParameter("@id", maDapAn)));
            return count > 0;
        }
    }
}
