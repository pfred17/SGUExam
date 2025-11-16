using System.Collections.Generic;
using DTO;
using DAL;

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
