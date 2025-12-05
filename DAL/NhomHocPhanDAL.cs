using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class NhomHocPhanDAL
    {
        // Lấy toàn bộ danh sách nhóm học phần
        public List<NhomHocPhanDTO> GetAll()
        {
            string query = @"
                SELECT 
                    n.ma_nhom,
                    n.ma_pc,
                    n.ten_nhom,
                    n.ghi_chu,
                    n.hoc_ky,
                    n.nam_hoc,
                    n.trang_thai,
                    mh.ma_mh AS MaMonHoc,
                    mh.ten_mh AS TenMonHoc
                FROM nhom_hoc_phan n
                INNER JOIN phan_cong pc ON n.ma_pc = pc.ma_pc
                INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
                WHERE n.trang_thai = 1";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            var list = new List<NhomHocPhanDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    MaPC = Convert.ToInt64(row["ma_pc"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    GhiChu = row["ghi_chu"].ToString(),
                    HocKy = row["hoc_ky"].ToString(),
                    NamHoc = row["nam_hoc"].ToString(),
                    TrangThai = Convert.ToInt32(row["trang_thai"]),
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString()
                });
            }
            return list;
        }
        //Thêm nhóm học phần
        public bool Insert(NhomHocPhanDTO nhom)
        {
            string query = @"INSERT INTO nhom_hoc_phan (ma_pc, ten_nhom, ghi_chu, hoc_ky, nam_hoc, trang_thai)
                             VALUES (@ma_pc, @ten_nhom, @ghi_chu, @hoc_ky, @nam_hoc, @trang_thai)";

            SqlParameter[] param =
            {
                new SqlParameter("@ma_pc", nhom.MaPC),
                new SqlParameter("@ten_nhom", nhom.TenNhom),
                new SqlParameter("@ghi_chu", nhom.GhiChu),
                new SqlParameter("@hoc_ky", nhom.HocKy),
                new SqlParameter("@nam_hoc", nhom.NamHoc),
                new SqlParameter("@trang_thai", nhom.TrangThai)
            };

            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }
        // Insert và trả về id vừa chèn
        public long InsertReturnId(NhomHocPhanDTO nhom)
        {
            string query = @"INSERT INTO nhom_hoc_phan (ma_pc, ten_nhom, ghi_chu, hoc_ky, nam_hoc, trang_thai)
                     OUTPUT INSERTED.ma_nhom
                     VALUES (@ma_pc, @ten_nhom, @ghi_chu, @hoc_ky, @nam_hoc, @trang_thai)";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@ma_pc", nhom.MaPC),
                        new SqlParameter("@ten_nhom", nhom.TenNhom ?? string.Empty),
                        new SqlParameter("@ghi_chu", nhom.GhiChu ?? string.Empty),
                        new SqlParameter("@hoc_ky", nhom.HocKy ?? string.Empty),
                        new SqlParameter("@nam_hoc", nhom.NamHoc ?? string.Empty),
                        new SqlParameter("@trang_thai", nhom.TrangThai)
                    });

                    var res = cmd.ExecuteScalar();
                    return res == null || res == DBNull.Value ? 0 : Convert.ToInt64(res);
                }
            }
        }

        // Cập nhật nhóm học phần
        public bool Update(NhomHocPhanDTO nhom)
        {
            string query = @"UPDATE nhom_hoc_phan 
                     SET ten_nhom = @TenNhom, ma_pc = @MaPC, hoc_ky = @HocKy, nam_hoc = @NamHoc, ghi_chu = @GhiChu 
                     WHERE ma_nhom = @MaNhom";

            SqlParameter[] param =
            {
        new SqlParameter("@GhiChu", nhom.GhiChu),
        new SqlParameter("@TenNhom", nhom.TenNhom),
        new SqlParameter("@MaPC", nhom.MaPC),
        new SqlParameter("@HocKy", nhom.HocKy),
        new SqlParameter("@NamHoc", nhom.NamHoc),
        new SqlParameter("@MaNhom", nhom.MaNhom)
    };

            int result = DatabaseHelper.ExecuteNonQuery(query, param);
            return result > 0;
        }

        public bool Delete(long maNhom)
        {
            try
            {
                if (maNhom <= 0)
                {
                    Console.WriteLine($"DAL.Delete called with invalid maNhom={maNhom}");
                    return false;
                }

                string query = "UPDATE nhom_hoc_phan SET trang_thai = 0 WHERE ma_nhom = @MaNhom";
                SqlParameter[] param = { new SqlParameter("@MaNhom", maNhom) };

                int result = DatabaseHelper.ExecuteNonQuery(query, param);

                Console.WriteLine($"DAL.Delete maNhom={maNhom}, rowsAffected={result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DAL.Delete maNhom={maNhom}: {ex.Message}");
                return false;
            }
        }

        // Tìm theo mã nhóm
        public NhomHocPhanDTO GetById(long maNhom)
        {
            string query = @"
                SELECT 
                    n.ma_nhom, n.ma_pc, n.ten_nhom, n.ghi_chu, n.hoc_ky, n.nam_hoc, n.trang_thai,
                    mh.ma_mh AS MaMonHoc, mh.ten_mh AS TenMonHoc
                FROM nhom_hoc_phan n
                INNER JOIN phan_cong pc ON n.ma_pc = pc.ma_pc
                INNER JOIN mon_hoc mh ON pc.ma_mh = mh.ma_mh
                WHERE n.ma_nhom = @ma AND n.trang_thai = 1";

            var param = new SqlParameter("@ma", maNhom);
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new NhomHocPhanDTO
            {
                MaNhom = Convert.ToInt64(r["ma_nhom"]),
                MaPC = Convert.ToInt64(r["ma_pc"]),
                TenNhom = r["ten_nhom"].ToString(),
                GhiChu = r["ghi_chu"].ToString(),
                HocKy = r["hoc_ky"].ToString(),
                NamHoc = r["nam_hoc"].ToString(),
                TrangThai = Convert.ToInt32(r["trang_thai"]),
                MaMonHoc = r["MaMonHoc"].ToString(),
                TenMonHoc = r["TenMonHoc"].ToString()
            };
        }
        public DataTable LayBangDiemTheoNhom(long maNhom)
        {
            string sql = @"
                SELECT 
                    nd.ma_nd      AS MSSV,
                    nd.ho_ten     AS HoTen,
                    dt.ten_de     AS TenDe,
                    bl.diem       AS Diem
                FROM chi_tiet_nhom_hoc_phan ct
                JOIN nguoi_dung nd 
                    ON nd.ma_nd = ct.ma_nd
                JOIN de_thi_nhom dtn 
                    ON dtn.ma_nhom = ct.ma_nhom
                JOIN de_thi dt 
                    ON dt.ma_de = dtn.ma_de
                LEFT JOIN bai_lam bl 
                    ON bl.ma_nd = nd.ma_nd 
                   AND bl.ma_de = dt.ma_de
                WHERE ct.ma_nhom = @maNhom
                ORDER BY nd.ma_nd, dt.ma_de";

            return DatabaseHelper.ExecuteQuery(
                sql,
                new SqlParameter("@maNhom", maNhom)
            );
        }
        public DataTable LayBangDiemPivot(long maNhom)
        {
            string sql = @" 
                DECLARE @cols NVARCHAR(MAX);
                DECLARE @sql NVARCHAR(MAX);

                -- 1. Lấy danh sách TÊN ĐỀ THI làm CỘT
                SELECT @cols = STRING_AGG(QUOTENAME(dt.ten_de), ',')
                FROM de_thi_nhom dtn
                JOIN de_thi dt ON dt.ma_de = dtn.ma_de
                WHERE dtn.ma_nhom = @maNhom;

                -- 2. Pivot
                SET @sql = '
                SELECT MSSV, HoTen, ' + @cols + '
                FROM
                (
                    SELECT 
                        nd.ma_nd  AS MSSV,
                        nd.ho_ten AS HoTen,
                        dt.ten_de AS TenDe,
                        bl.diem   AS Diem
                    FROM chi_tiet_nhom_hoc_phan ct
                    JOIN nguoi_dung nd ON nd.ma_nd = ct.ma_nd
                    JOIN de_thi_nhom dtn ON dtn.ma_nhom = ct.ma_nhom
                    JOIN de_thi dt ON dt.ma_de = dtn.ma_de
                    LEFT JOIN bai_lam bl 
                        ON bl.ma_nd = nd.ma_nd 
                        AND bl.ma_de = dt.ma_de
                    WHERE ct.ma_nhom = @maNhom
                ) src
                PIVOT
                (
                    MAX(Diem)
                    FOR TenDe IN (' + @cols + ')
                ) p
                ORDER BY MSSV;
                ';

                EXEC sp_executesql 
                    @sql,
                    N'@maNhom BIGINT',
                    @maNhom = @maNhom;
                    ";

            return DatabaseHelper.ExecuteQuery(
                sql,
                new SqlParameter("@maNhom", maNhom)
            );
        }



    }
}
