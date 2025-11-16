using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class MonHocDAL
    {
        public List<MonHocDTO> GetAllMonHoc()
        {
            string query = "SELECT ma_mh, ten_mh, so_tin_chi, trang_thai FROM mon_hoc WHERE trang_thai = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<MonHocDTO> list = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                MonHocDTO mh = new MonHocDTO
                {
                    MaMonHoc = Convert.ToInt32(row["ma_mh"]),
                    TenMonHoc = row["ten_mh"].ToString(),
                    SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                };
                list.Add(mh);
            }
            return list;
        }


        public bool InsertMonHoc(MonHocDTO mh)
        {
            string query = "INSERT INTO mon_hoc (ten_mh, so_tin_chi, trang_thai) VALUES (@ten, @tin, @tt)";
            SqlParameter[] param =
            {
                new SqlParameter("@ten", mh.TenMonHoc),
                new SqlParameter("@tin", mh.SoTinChi),
                new SqlParameter("@tt", mh.TrangThai)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        public MonHocDTO GetById(long maMonHoc)
        {
            string query = "SELECT * FROM mon_hoc WHERE ma_mh = @id";
            SqlParameter[] param = { new SqlParameter("@id", maMonHoc) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new MonHocDTO
            {
                MaMonHoc = Convert.ToInt32(row["ma_mh"]),
                TenMonHoc = row["ten_mh"].ToString(),
                SoTinChi = Convert.ToInt32(row["so_tin_chi"]),
                TrangThai = Convert.ToInt32(row["trang_thai"])
            };
        }
    }
}
