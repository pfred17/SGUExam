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
            string query = "SELECT ma_dap_an, noi_dung, dung FROM dap_an WHERE ma_cau_hoi = @MaCH ORDER BY ma_dap_an";
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

        // Sử dụng transaction nếu được truyền vào, nếu không thì dùng DatabaseHelper
        public void XoaTheoCauHoi(long maCauHoi, SqlTransaction? tran = null)
        {
            string query = "DELETE FROM dap_an WHERE ma_cau_hoi = @MaCH";
            if (tran != null && tran.Connection != null)
            {
                using var cmd = new SqlCommand(query, tran.Connection, tran);
                cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                cmd.ExecuteNonQuery();
            }
            else
            {
                DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MaCH", maCauHoi));
            }
        }
    }
}
