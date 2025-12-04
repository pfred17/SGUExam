using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhanCongBLL
    { 
        private readonly PhanCongDAL _dal = new PhanCongDAL();
        public List<PhanCongDTO> getAllPhanCong()
        {
            return _dal.getAllPhanCong();
        }
        public long AddPhanCong(PhanCongDTO phanCong)
        {
            return _dal.AddPhanCong(phanCong);
        }
        public bool UpdatePhanCong(PhanCongDTO phanCong)
        {
            return _dal.UpdatePhanCong(phanCong);
        }
        public bool DeletePhanCong(long maPhanCong)
        {
            return _dal.DeletePhanCong(maPhanCong);
        }
        public bool IsPhanCongReferenced(long maPhanCong)
        {
            return _dal.IsPhanCongReferenced(maPhanCong);
        }
        public PhanCongDTO? GetPhanCongById(long  maPhanCong)
        {
            return _dal.GetPhanCongById(maPhanCong);
        }
        public List<PhanCongDTO> getPhanCongPaged(int page, int pageSize, string? keyword = null)
        {
            return _dal.GetPhanCongPaged(page, pageSize, keyword);
        }
        public int GetTotalPhanCong(string? keyword = null)
        {
            return _dal.GetTotalPhanCong(keyword);
        }
        public long GetValidMaPCForGroup(long maMH, string maND)
        {
            return _dal.GetMaPCByCriteria(maMH, maND);
        }
        public long GetMaPCByGiangVienAndMonHoc(long maMH, string maND)
        {
            return _dal.GetMaPCByGiangVienAndMonHoc(maMH, maND);
        }
        public List<MonHocDTO> GetMonHocByGiangVien(string maND)
        {
            return _dal.GetMonHocByGiangVien(maND);
        }

    }
}
