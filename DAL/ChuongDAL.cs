using DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class ChuongDAL
    {
        public List<ChuongDTO> GetByMonHoc(long maMH)
        {
            var list = new List<ChuongDTO>();
            string query = @"SELECT ch.ma_chuong, ch.ten_chuong, chh.noi_dung AS cau_hoi
                             FROM cau_hoi chh
                             INNER JOIN chuong ch ON chh.ma_chuong = ch.ma_chuong
                             WHERE chh.trang_thai = 1 AND ch.ma_mh = @MaMH";
            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MaMH", maMH));
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new ChuongDTO
                {
                    MaChuong = (long)row["ma_chuong"],
                    TenChuong = (string)row["ten_chuong"],
                    MaMh = maMH
                });
            }
            return list;
        }
    }
}
