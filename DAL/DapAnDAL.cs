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
                    MaDapAn = (long)row["ma_dap_an"],
                    NoiDung = (string)row["noi_dung"],
                    Dung = (bool)row["dung"],
                    MaCauHoi = maCauHoi
                });
            }
            return list;
        }

        public void XoaTheoCauHoi(long maCauHoi, SqlTransaction tran = null)
        {
            string query = "DELETE FROM dap_an WHERE ma_cau_hoi = @MaCH";
            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MaCH", maCauHoi));
        }
    }
}
