using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PermissionDAL
    {
        public DataTable GetPermissionsByUser(string userId)
        {
            string query = @"
            SELECT cn.ma_chuc_nang, q.ten_quyen, nqcn.duoc_phep
            FROM nguoi_dung nd
            JOIN nhom_quyen nq ON nd.ma_nhom_quyen = nq.ma_nhom_quyen
            JOIN nhom_quyen_chuc_nang nqcn ON nq.ma_nhom_quyen = nqcn.ma_nhom_quyen
            JOIN chuc_nang cn ON nqcn.ma_chuc_nang = cn.ma_chuc_nang
            JOIN quyen q ON nqcn.ma_quyen = q.ma_quyen
            WHERE nd.ma_nd = @UserId";

            SqlParameter[] param = {
            new SqlParameter("@UserId", userId)
        };

            return DatabaseHelper.ExecuteQuery(query, param);
        }
    }
}
