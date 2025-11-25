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
        public bool DeleteChuong(long chuongId)
        {
            return _dal.DeleteChuong(chuongId);
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
