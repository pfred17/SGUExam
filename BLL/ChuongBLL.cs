using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChuongBLL
    {
        private readonly ChuongDAL _dal = new ChuongDAL();
        public List<ChuongDTO> GetChuongByMonHoc(long maMonHoc)
        {
            return _dal.GetChuongByMonHoc(maMonHoc);
        }
        public bool IsChuongExists(string tenChuong)
        {
            return _dal.IsChuongExists(tenChuong);
        }
        public long AddChuong(ChuongDTO chuong, long maMonHoc)
        {
            return _dal.AddChuong(chuong, maMonHoc);
        }
        public bool UpdateChuong(ChuongDTO chuong)
        {
            return _dal.UpdateChuong(chuong);
        }
        public bool IsChuongReferenced(long maChuong)
        {
            return _dal.IsChuongReferenced(maChuong);
        }
        public bool UpdateStatus(long maChuong, int trangThai)
        {
            return _dal.UpdateStatus(maChuong, trangThai);
        }
        public int GetStatus(long maChuong)
        {
            return _dal.GetStatus(maChuong);
        }
        public bool DeleteChuong(long maChuong)
        {
            return _dal.DeleteChuong(maChuong);
        }
        public List<ChuongDTO> GetChuongPaged(long maMonHoc, int page, int pageSize)
        {
            return _dal.GetChuongPaged(maMonHoc, page, pageSize);
        }
        public int GetTotalChuongByMonHoc(long maMonHoc)
        {
            return _dal.GetTotalChuongByMonHoc(maMonHoc);
        }
    }
}
