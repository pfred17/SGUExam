using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace BLL
{
    public class NhomHocPhanBLL
    {
        private readonly NhomHocPhanDAL dal;
      
        public NhomHocPhanBLL()
        {
            dal = new NhomHocPhanDAL();
        }

        // Lấy danh sách tất cả nhóm học phần
        public List<NhomHocPhanDTO> GetAll()
        {
            return dal.GetAll();
        }
        // Search (business rule): tìm theo tên nhóm, tên môn, học kỳ, năm học
        public List<NhomHocPhanDTO> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return GetAll();

            string q = RemoveDiacritics(query).ToUpperInvariant();

            var all = dal.GetAll();

            var filtered = all.Where(n =>
            {
                string tenNhom = RemoveDiacritics(n.TenNhom ?? string.Empty).ToUpperInvariant();
                string hocKy = RemoveDiacritics(n.HocKy ?? string.Empty).ToUpperInvariant();
                string namHoc = RemoveDiacritics(n.NamHoc ?? string.Empty).ToUpperInvariant();
                // SỬ DỤNG TRỰC TIẾP TenMonHoc từ DTO
                string tenMon = RemoveDiacritics(n.TenMonHoc ?? string.Empty).ToUpperInvariant();

                return tenNhom.Contains(q) || hocKy.Contains(q) || namHoc.Contains(q) || tenMon.Contains(q);
            }).ToList();

            return filtered;
        }
        // helper: remove diacritics
        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        
        // Lấy nhóm học phần theo mã
        public NhomHocPhanDTO GetById(long maNhom)
        {
            return dal.GetById(maNhom);
        }

        // Thêm nhóm học phần mới
        public bool Insert(NhomHocPhanDTO nhom)
        {
            // Kiểm tra logic nếu cần (VD: không được trùng tên nhóm trong cùng môn học)
            if (string.IsNullOrEmpty(nhom.TenNhom))
                return false;

            return dal.Insert(nhom);
        }
        public long InsertReturnId(NhomHocPhanDTO nhom)
        {
            if (string.IsNullOrEmpty(nhom.TenNhom))
                return 0;

            return dal.InsertReturnId(nhom);
        }
        // Cập nhật nhóm học phần
        public bool Update(NhomHocPhanDTO nhom)
        {
            return dal.Update(nhom);
        }

        // Xóa nhóm học phần (soft delete)
        public bool Delete(long maNhom)
        {
            if (maNhom <= 0)
                return false;

            return dal.Delete(maNhom);
        }

        // Lọc nhóm học phần theo học kỳ hoặc năm học (tuỳ chọn thêm)
        public List<NhomHocPhanDTO> Filter(string hocKy = null, string namHoc = null)
        {
            var all = dal.GetAll();

            if (!string.IsNullOrEmpty(hocKy))
                all = all.FindAll(x => x.HocKy == hocKy);

            if (!string.IsNullOrEmpty(namHoc))
                all = all.FindAll(x => x.NamHoc == namHoc);
                
            return all;
        }
        public List<NhomHocPhanDTO> GetByMonHoc(long maMonHoc)
        {
            return dal.GetByMonHoc(maMonHoc);
        }


        // bll của bảo phan
        public List<NhomHocPhanDTO> GetNhomHocPhanByUserId(string userId)
        {
            return dal.GetNhomHocPhanByUserId(userId);
        }
        public string GetTenMonHocByMaNhom(long maNhom)
        {
            return dal.GetTenMonHocByMaNhom(maNhom);
        }
        public List<NhomHocPhanDTO> SearchNhomHocPhan(string userId, string keyword)
        {
            return dal.SearchNhomHocPhan(userId, keyword);
        }
        public DataTable LayBangDiemTheoNhom(long maNhom)
        {
            return dal.LayBangDiemTheoNhom(maNhom);
        }
        public DataTable LayBangDiemPivot(long maNhom)
        {
            return dal.LayBangDiemPivot(maNhom);
        }
    }
}