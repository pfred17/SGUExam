// BLL/DeThiBLL.cs
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

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

        public bool XoaDeThiKhoiNhom(long maDe, long maNhom)
        {
            return _dal.XoaDeThiKhoiNhom(maDe,maNhom);
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
