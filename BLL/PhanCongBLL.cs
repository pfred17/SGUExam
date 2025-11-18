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
        public bool DeletePhanCong(long maPhanCong)
        {
            return _dal.DeletePhanCong(maPhanCong);
        }
        public PhanCongDTO? GetPhanCongById(long  maPhanCong)
        {
            return _dal.GetPhanCongById(maPhanCong);
        }
        public List<PhanCongDTO> getPhanCongPaged(int page, int pageSize)
        {
            return _dal.GetPhanCongPaged(page, pageSize);
        }

        public int GetTotalPhanCong()
        {
            return _dal.GetTotalPhanCong();
        }
    }
}
