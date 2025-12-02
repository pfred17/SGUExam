using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DAL
{
    public class PermissionDAL
    {
        public DataTable GetPermissionsByUser(string userId)
        {
            string query = @"
                SELECT cn.ma_chuc_nang, q.ten_quyen, nqcn.duoc_phep
                FROM nguoi_dung_nhom_quyen ndnq
                JOIN nhom_quyen_chuc_nang nqcn ON ndnq.ma_nhom_quyen = nqcn.ma_nhom_quyen
                JOIN chuc_nang cn ON nqcn.ma_chuc_nang = cn.ma_chuc_nang
                JOIN quyen q ON nqcn.ma_quyen = q.ma_quyen
                WHERE ndnq.ma_nd = @UserId";

            SqlParameter[] param = {
                new SqlParameter("@UserId", userId)
            };

            return DatabaseHelper.ExecuteQuery(query, param);
        }
    }
}
