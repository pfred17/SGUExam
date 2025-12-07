using System;
using System.Collections.Generic;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietNhomHocPhanDAL
    {
        private static ChiTietNhomHocPhanDAL instance;
        public static ChiTietNhomHocPhanDAL Instance => instance ??= new ChiTietNhomHocPhanDAL();

        private ChiTietNhomHocPhanDAL() { }

        // Thêm sinh viên vào nhóm
        public bool ThemSinhVienVaoNhom(string maND, long maNhom)
        {
            string query = "INSERT INTO chi_tiet_nhom_hoc_phan (ma_nd, ma_nhom) VALUES (@maND, @maNhom)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@maND", SqlDbType.VarChar) { Value = maND },
                new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom }
            };

            try
            {
                return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false; // đã tồn tại hoặc lỗi kết nối
            }
        }

        // Kiểm tra sinh viên đã trong nhóm chưa
        public bool DaTonTaiTrongNhom(string maND, long maNhom)
        {
            string query = "SELECT COUNT(*) FROM chi_tiet_nhom_hoc_phan WHERE ma_nd = @maND AND ma_nhom = @maNhom";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@maND", SqlDbType.VarChar) { Value = maND },
                new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom }
            };

            object result = DatabaseHelper.ExecuteQuery(query, parameters).Rows[0][0];
            return Convert.ToInt32(result) > 0;
        }

        // Lấy danh sách sinh viên trong nhóm (dùng để load DataGridView)
        public DataTable LayDanhSachSinhVienTrongNhom(long maNhom)
        {
            string query = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY nd.ho_ten) AS STT,
                    nd.ma_nd AS MSSV,
                    nd.ho_ten AS HoTen,
                    nd.gioi_tinh AS GioiTinh
                FROM chi_tiet_nhom_hoc_phan ct
                JOIN nguoi_dung nd ON ct.ma_nd = nd.ma_nd
                WHERE ct.ma_nhom = @maNhom AND nd.trang_thai = 1
                ORDER BY nd.ho_ten";
            //new SqlParameter("@maNhom", maNhom)
            var parameters = new SqlParameter[] { new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom } };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        //Xóa sinh viên khỏi nhóm(dùng khi nhấn nút Xóa)
        public bool XoaSinhVienKhoiNhom(string maND, long maNhom)
        {
            string query = "DELETE FROM chi_tiet_nhom_hoc_phan WHERE ma_nd = @maND AND ma_nhom = @maNhom";
            var parameters = new SqlParameter[]
            {
                //new SqlParameter("@maND", maND),
                //new SqlParameter("@maNhom", maNhom)
                new SqlParameter("@maND", SqlDbType.VarChar) { Value = maND },
                new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom }
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //public bool XoaSinhVienKhoiNhom(string maND, long maNhom)
        //{
        //    // ✅ 1. KIỂM TRA ĐÃ CÓ BÀI LÀM CHƯA
        //    string checkQuery = @"
        //        SELECT TOP 1 1
        //        FROM bai_lam bl
        //        JOIN de_thi_nhom dtn ON bl.ma_de = dtn.ma_de
        //        WHERE bl.ma_nd = @maND
        //          AND dtn.ma_nhom = @maNhom
        //    ";

        //    var checkParams = new SqlParameter[]
        //    {
        //new SqlParameter("@maND", SqlDbType.VarChar) { Value = maND },
        //new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom }
        //    };

        //    object result = DatabaseHelper.ExecuteScalar(checkQuery, checkParams);

        //    // ✅ NẾU ĐÃ LÀM BÀI → KHÔNG ĐƯỢC XÓA
        //    if (result != null)
        //    {
        //        return false; // BLL sẽ dùng để báo: "Sinh viên đã làm bài, không thể xóa"
        //    }

        //    // ✅ 2. CHƯA LÀM BÀI → XÓA BÌNH THƯỜNG
        //    string deleteQuery = @"
        //        DELETE FROM chi_tiet_nhom_hoc_phan
        //        WHERE ma_nd = @maND AND ma_nhom = @maNhom
        //    ";

        //    int rows = DatabaseHelper.ExecuteNonQuery(deleteQuery, checkParams);
        //    return rows > 0;
        //}



        public int DemSinhVienTrongNhom(long maNhom)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM chi_tiet_nhom_hoc_phan ct
                JOIN nguoi_dung nd ON ct.ma_nd = nd.ma_nd 
                WHERE ct.ma_nhom = @maNhom 
                  AND nd.trang_thai = 1"; 

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@maNhom", SqlDbType.BigInt) { Value = maNhom }
            };

            try
            {
                object result = DatabaseHelper.ExecuteQuery(query, parameters).Rows[0][0];
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0; // Trả về 0 nếu có lỗi (an toàn)
            }
        }
    }
}
