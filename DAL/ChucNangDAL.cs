using DTO;
using System.Data;
namespace DAL
{
    public class ChucNangDAL
    {
        public List<ChucNangDTO> getAllCHucNang()
        {
            string query = "SELECT * FROM chuc_nang";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<ChucNangDTO> danhSachChucNang = new List<ChucNangDTO>();

            foreach (DataRow row in dt.Rows)
            {
                danhSachChucNang.Add(new ChucNangDTO
                {
                    MaChucNang = Convert.ToInt32(row["ma_chuc_nang"]),
                    TenChucNang = row["ten_chuc_nang"].ToString()
                });
            }

            return danhSachChucNang;
        }
    }
}
