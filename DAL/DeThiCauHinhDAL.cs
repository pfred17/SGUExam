using DTO;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DeThiCauHinhDAL
    {
        public DeThiCauHinhDTO? GetByMaDe(long maDe)
        {
            string query = "SELECT * FROM de_thi_cau_hinh WHERE ma_de = @maDe";
            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@maDe", maDe));
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new DeThiCauHinhDTO
            {
                TuDongLay = Convert.ToBoolean(row["tu_dong_lay"]),
                XemDiemSauThi = Convert.ToBoolean(row["xem_diem_sau_thi"]),
                XemDapAnSauThi = Convert.ToBoolean(row["xem_dap_an_sau_thi"]),
                XemBaiLam = Convert.ToBoolean(row["xem_bai_lam"]),
                DaoCauHoi = Convert.ToBoolean(row["dao_cau_hoi"]),
                DaoDapAn = Convert.ToBoolean(row["dao_dap_an"]),
                TuDongNop = Convert.ToBoolean(row["tu_dong_nop"]),
                DeLuyenTap = Convert.ToBoolean(row["de_luyen_tap"]),
                TinhDiem = Convert.ToBoolean(row["tinh_diem"])
            };
        }

        public bool Update(long maDe, DeThiCauHinhDTO cauHinh)
        {
            string query = @"
                UPDATE de_thi_cau_hinh SET
                    tu_dong_lay = @tdl,
                    xem_diem_sau_thi = @xdst,
                    xem_dap_an_sau_thi = @xdast,
                    xem_bai_lam = @xbl,
                    dao_cau_hoi = @dch,
                    dao_dap_an = @dda,
                    tu_dong_nop = @tdn,
                    de_luyen_tap = @dlt,
                    tinh_diem = @td
                WHERE ma_de = @maDe";
            var param = new SqlParameter[]
            {
                new("@tdl", cauHinh.TuDongLay),
                new("@xdst", cauHinh.XemDiemSauThi),
                new("@xdast", cauHinh.XemDapAnSauThi),
                new("@xbl", cauHinh.XemBaiLam),
                new("@dch", cauHinh.DaoCauHoi),
                new("@dda", cauHinh.DaoDapAn),
                new("@tdn", cauHinh.TuDongNop),
                new("@dlt", cauHinh.DeLuyenTap),
                new("@td", cauHinh.TinhDiem),
                new("@maDe", maDe)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }
    }
}
