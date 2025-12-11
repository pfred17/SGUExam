// BLL/DeThiBLL.cs
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;

namespace BLL
{
    public class DeThiBLL
    {
        private readonly DeThiDAL _dal = new DeThiDAL();
        public List<DeThiDTO> GetAll() { return _dal.GetAll(); }
        public List<DeThiDTO> LayDeThiCuaNhom(long maNhom)
        {
      
            return _dal.LayDeThiCuaNhom(maNhom);
        }
        public List<BangDiemItemDTO> GetBangDiemByDeThi(long maDe) {
            return _dal.GetBangDiemByDeThi(maDe);
        }
        public List<BangDiemItemDTO> GetAllBangDiemByDeThi(long maDe)
        {
            return _dal.GetAllBangDiemByDeThi(maDe);
        }
        public long CreateDeThi(DeThiDTO deThi)
        {
            return _dal.InsertDeThi(deThi);
        }
        public List<DeThiDTO> GetAllWithNhomHocPhan()
        {
            return _dal.GetAllWithNhomHocPhan();
        }
        public List<CauHoiDTO> GetCauHoiTheoDeThi(long maDe)
        {
            return _dal.GetCauHoiTheoDeThi(maDe);
        }
        public int GetSoLuongCauHoiTheoDe(long maDe)
        {
            return _dal.GetSoLuongCauHoiTheoDe(maDe);
            
        }
        public void InsertDeThiChuong(long maDe, List<long> chuongIds)
        {
            _dal.InsertDeThiChuong(maDe, chuongIds);
        }

        public void InsertDeThiNhom(long maDe, List<long> nhomHocPhanIds)
        {
            _dal.InsertDeThiNhom(maDe, nhomHocPhanIds);
        }
        public void InsertDeThiCauHoi(long maDe, List<long> cauHoiIds)
        {
            _dal.InsertDeThiCauHoi(maDe, cauHoiIds);
        }
        public DeThiDTO GetFullDetailById(long maDe)
        {
            return _dal.GetFullDetailById(maDe);
        }
        public bool UpdateDeThi(DeThiDTO deThi)
        {
            return _dal.UpdateDeThi(deThi);
        }
        public bool UpdateDeThiStatus(DeThiDTO deThi)
        {
            // Gọi xuống DAL để cập nhật trạng thái đề thi
            return _dal.UpdateDeThiStatus(deThi.MaDe, deThi.TrangThai);
        }
        public void DeleteDeThiCauHoi(long maDe)
        {
            string sql = "DELETE FROM de_thi_cau_hoi WHERE ma_de = @maDe";
            DatabaseHelper.ExecuteNonQuery(sql, new Microsoft.Data.SqlClient.SqlParameter("@maDe", maDe));
        }
        public bool DeleteDeThi(long maDe)
        {
            return _dal.DeleteDeThi(maDe);
        }
        public KetQuaBaiThiDTO GetKetQuaBaiThi(long maDe, string mssv)
        {
            return _dal.GetKetQuaBaiThi(maDe, mssv);
        }
        public List<CauHoiThongKeDTO> GetThongKeCauHoi(long maDe)
        {
            return _dal.GetThongKeCauHoi(maDe);
        }
        public String GetTenMonHocByMaDe(long maDe)
        {
            return _dal.GetTenMonHocByMaDe(maDe);
        }

        // dal của bảo phan
        public List <DeThiDTO> GetDeKiemTraByMaNhom (long maNhom)
        {
            return _dal.GetDeKiemTraByMaNhom(maNhom);
        }

        public List<DeThiDTO> GetDeLuyenTapByMaNhom(long maNhom)
        {
            return _dal.GetDeLuyenTapByMaNhom(maNhom);
        }

        public List<DeThiDTO> GetDeThiByUserId(string userId)
    => _dal.GetDeThiByUserId(userId);


    }
}
