using DAL;
using DTO;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BLL
{
    public class NhomHocPhanBLL
    {
        private readonly NhomHocPhanDAL dal;
        private readonly DAL.MonHocDAL monDal = new DAL.MonHocDAL();
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

            // Cache tên môn để tránh gọi DB nhiều lần
            var monCache = all.Select(x => x.MaMH).Distinct()
                .ToDictionary(id => id, id =>
                {
                    var m = monDal.GetById(id);
                    return m?.TenMonHoc ?? string.Empty;
                });

            var filtered = all.Where(n =>
            {
                string tenNhom = RemoveDiacritics(n.TenNhom ?? string.Empty).ToUpperInvariant();
                string hocKy = RemoveDiacritics(n.HocKy ?? string.Empty).ToUpperInvariant();
                string namHoc = RemoveDiacritics(n.NamHoc ?? string.Empty).ToUpperInvariant();
                string tenMon = monCache.ContainsKey(n.MaMH) ? RemoveDiacritics(monCache[n.MaMH] ?? string.Empty).ToUpperInvariant() : string.Empty;

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
        // lấy danh sách học kỳ
        public List<string> GetDistinctHocKy()
        {
            return dal.GetDistinctHocKy();
        }
        // lấy danh sách năm học 
        public List<string> GetDistinctNamHoc()
        {
            return dal.GetDistinctNamHoc();
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


    }
}
