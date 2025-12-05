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
            string query = "SELECT * FROM nhom_hoc_phan WHERE trang_thai = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<NhomHocPhanDTO> list = new List<NhomHocPhanDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    MaPc = Convert.ToInt64(row["ma_mh"]),
                    GhiChu = row["ghi_chu"].ToString(),
                    TenNhom = row["ten_nhom"].ToString(),
                    HocKy = row["hoc_ky"].ToString(),
                    NamHoc = row["nam_hoc"].ToString(),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return list;
        }
        // lấy danh sách học kỳ
        public List<string> GetDistinctHocKy()
        {
            string query = "SELECT DISTINCT hoc_ky FROM nhom_hoc_phan WHERE trang_thai = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["hoc_ky"].ToString());
            }
            return list;
        }
        //Lấy danh sách năm học 
        public List<string> GetDistinctNamHoc()
        {
            string query = "SELECT DISTINCT nam_hoc FROM nhom_hoc_phan WHERE trang_thai = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["nam_hoc"].ToString());
            }
            return list;
        }


        //Thêm nhóm học phần
        public bool Insert(NhomHocPhanDTO nhom)
        {
            string query = @"INSERT INTO nhom_hoc_phan (ma_mh, ten_nhom, ghi_chu, hoc_ky, nam_hoc, trang_thai)
                             VALUES (@ma_mh, @ten_nhom, @ghi_chu, @hoc_ky, @nam_hoc, @trang_thai)";

            SqlParameter[] param =
            {
                new SqlParameter("@ma_mh", nhom.MaPc),
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
            string query = @"INSERT INTO nhom_hoc_phan (ma_mh, ten_nhom, ghi_chu, hoc_ky, nam_hoc, trang_thai)
                     OUTPUT INSERTED.ma_nhom
                     VALUES (@ma_mh, @ten_nhom, @ghi_chu, @hoc_ky, @nam_hoc, @trang_thai)";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@ma_mh", nhom.MaPc),
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
                     SET ten_nhom = @TenNhom, ma_mh = @MaMH, hoc_ky = @HocKy, nam_hoc = @NamHoc, ghi_chu = @GhiChu 
                     WHERE ma_nhom = @MaNhom";

            SqlParameter[] param =
            {
        new SqlParameter("@GhiChu", nhom.GhiChu),
        new SqlParameter("@TenNhom", nhom.TenNhom),
        new SqlParameter("@MaMH", nhom.MaPc),
        new SqlParameter("@HocKy", nhom.HocKy),
        new SqlParameter("@NamHoc", nhom.NamHoc),
        new SqlParameter("@MaNhom", nhom.MaNhom)
    };

            int result = DatabaseHelper.ExecuteNonQuery(query, param);
            return result > 0;
        }

        // Xóa nhóm học phần (soft delete)
        public bool Delete(long maNhom)
        {
            //string query = "UPDATE nhom_hoc_phan SET trang_thai = 0 WHERE ma_nhom = @MaNhom";
            //SqlParameter[] param = { new SqlParameter("@MaNhom", maNhom) };

            //int result = DatabaseHelper.ExecuteNonQuery(query, param);
            //return result > 0; 
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
                // Log to console for quick debug; replace with proper logging if available
                Console.WriteLine($"Lỗi DAL.Delete maNhom={maNhom}: {ex.Message}");
                return false;
            }
        }

        // Tìm theo mã nhóm
        public NhomHocPhanDTO GetById(long maNhom)
        {
            try
            {
                string query = "SELECT * FROM nhom_hoc_phan WHERE ma_nhom = @MaNhom";
                SqlParameter[] parameters = { new SqlParameter("@MaNhom", maNhom) };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    HocKy = row["hoc_ky"].ToString(),
                    NamHoc = row["nam_hoc"].ToString()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL.GetById: " + ex.Message);
                return null;
            }
        }
        public List<NhomHocPhanDTO> GetByMonHoc(long maMonHoc)
        {
            var list = new List<NhomHocPhanDTO>();
            string query = @"
        SELECT nh.*
        FROM nhom_hoc_phan nh
        INNER JOIN phan_cong pc ON nh.ma_pc = pc.ma_pc
        WHERE pc.ma_mh = @ma_mh AND nh.trang_thai = 1 AND pc.trang_thai = 1";
            var dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@ma_mh", maMonHoc));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    GhiChu = row["ghi_chu"]?.ToString(),
                    HocKy = row["hoc_ky"]?.ToString(),
                    NamHoc = row["nam_hoc"]?.ToString(),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return list;
        }
        // dal của bảo phan
        public List<NhomHocPhanDTO> GetNhomHocPhanByUserId(string userId)
        {
            List<NhomHocPhanDTO> list = new List<NhomHocPhanDTO>();
            string query = @"
                SELECT nhp.*
                FROM nhom_hoc_phan nhp
                INNER JOIN chi_tiet_nhom_hoc_phan cthp ON cthp.ma_nhom = nhp.ma_nhom
                WHERE cthp.ma_nd = @UserId AND nhp.trang_thai = 1";
            SqlParameter[] parameters = { new SqlParameter("@UserId", userId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    MaPc = Convert.ToInt64(row["ma_pc"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    GhiChu = row["ghi_chu"].ToString(),
                    HocKy = row["hoc_ky"].ToString(),
                    NamHoc = row["nam_hoc"].ToString(),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return list;
        }
        
        public string GetTenMonHocByMaNhom(long maNhom)
        {
            string query = @"
                SELECT mh.ten_mh
                FROM mon_hoc mh
                INNER JOIN phan_cong pc ON pc.ma_mh = mh.ma_mh
                INNER JOIN nhom_hoc_phan nhp ON nhp.ma_pc = pc.ma_pc
                WHERE nhp.ma_nhom = @MaNhom";

            SqlParameter[] parameters = { new SqlParameter("@MaNhom", maNhom) };
            object result = DatabaseHelper.ExecuteScalar(query, parameters);

            return result != null ? result.ToString() : string.Empty;
        }

        public List<NhomHocPhanDTO> SearchNhomHocPhan(string userId, string keyword)
        {
            List<NhomHocPhanDTO> list = new List<NhomHocPhanDTO>();
            string query = @"
        SELECT * FROM nhom_hoc_phan nhp
        INNER JOIN phan_cong pc ON pc.ma_pc = nhp.ma_pc
        INNER JOIN mon_hoc mh ON mh.ma_mh = pc.ma_mh
        INNER JOIN chi_tiet_nhom_hoc_phan cthp ON cthp.ma_nhom = nhp.ma_nhom
        WHERE cthp.ma_nd = @userId AND mh.ten_mh LIKE '%'+@keyword+'%'";

            SqlParameter[] parameters = {
        new SqlParameter("@keyword", keyword),
        new SqlParameter("@userId", userId)
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomHocPhanDTO
                {
                    MaNhom = Convert.ToInt64(row["ma_nhom"]),
                    MaPc = Convert.ToInt64(row["ma_pc"]),
                    TenNhom = row["ten_nhom"].ToString(),
                    GhiChu = row["ghi_chu"].ToString(),
                    HocKy = row["hoc_ky"].ToString(),
                    NamHoc = row["nam_hoc"].ToString(),
                    TrangThai = Convert.ToInt32(row["trang_thai"])
                });
            }
            return list;
        }

    }
}
