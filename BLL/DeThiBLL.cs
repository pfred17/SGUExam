// BLL/DeThiBLL.cs
using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class DeThiBLL
    {
        private readonly DeThiDAL _dal = new DeThiDAL();
        public List<DeThiDTO> GetAll()
        {
            return _dal.GetAll();
        }
        public List<BangDiemItemDTO> GetBangDiemByDeThi(long maDe)
        {
            return _dal.GetBangDiemByDeThi(maDe);
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

        // dal của bảo phan
        public List <DeThiDTO> GetDeKiemTraByMaNhom (long maNhom)
        {
            return _dal.GetDeKiemTraByMaNhom(maNhom);
        }

        public List<DeThiDTO> GetDeLuyenTapByMaNhom(long maNhom)
        {
            return _dal.GetDeLuyenTapByMaNhom(maNhom);
        }


    }
}
