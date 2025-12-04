using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class DeThiNhomBLL
    {
        private readonly DeThiNhomDAL _dalNhom = new DeThiNhomDAL();
        private readonly DeThiDAL _dalDeThi = new DeThiDAL(); 

        public bool ThemDeThiVaoNhom(long maDe, long maNhom)
        {
            if (maDe <= 0 || maNhom <= 0)
            {
                return false;
            }
            return _dalNhom.ThemDeThiVaoNhom(maDe, maNhom);
        }
        public List<DeThiDTO> LayDanhSachDeThiTheoNhom(long maNhom)
        {
            return _dalDeThi.LayDeThiCuaNhom(maNhom);
        }
        public bool XoaDeThiKhoiNhom(long maDe, long maNhom)
        {
            return _dalDeThi.XoaDeThiKhoiNhom(maDe, maNhom);
        }
    }
}