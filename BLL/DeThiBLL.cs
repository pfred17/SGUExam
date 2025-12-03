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
    }
}
