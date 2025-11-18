using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class MonHocDAL
    {
        public List<MonHocDTO> GetAll()
        {
            var list = new List<MonHocDTO>();
            string query = "SELECT ma_mh, ten_mh FROM mon_hoc WHERE trang_thai = 1 ORDER BY ten_mh";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach(DataRow row in dt.Rows)
            {
                list.Add(new MonHocDTO
                {
                    MaMH = (long)row["ma_mh"],
                    TenMH = row["ten_mh"].ToString()
                });
            }
            return list;
        }
    }
}
