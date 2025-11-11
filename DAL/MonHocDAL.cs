using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class MonHocDAL
    {

        public List<MonHocDTO> GetAllMonHoc()
        {
            List<MonHocDTO> list = new List<MonHocDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ma_mh, ten_mh, so_tin_chi, trang_thai FROM mon_hoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new MonHocDTO
                    {
                        MaMH = reader.GetInt64(0),
                        TenMH = reader.GetString(1),
                        SoTinChi = reader.GetInt32(2),
                        TrangThai = reader.GetByte(3),
                    });
                }
            }
            return list;
        }

        public long AddMonHoc(MonHocDTO monHoc)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO mon_hoc (ten_mh, so_tin_chi, trang_thai) " +
                               "OUTPUT INSERTED.ma_mh " +
                               "VALUES (@ten_mh, @so_tin_chi, @trang_thai)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten_mh", monHoc.TenMH);
                    cmd.Parameters.AddWithValue("@so_tin_chi", monHoc.SoTinChi);
                    cmd.Parameters.AddWithValue("@trang_thai", monHoc.TrangThai);

                    long newId = (long)cmd.ExecuteScalar();
                    return newId;
                }
            }
        }
    }
}
