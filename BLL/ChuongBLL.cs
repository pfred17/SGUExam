using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class ChuongBLL
    {
        private readonly ChuongDAL _dal = new ChuongDAL();

        public List<ChuongDTO> GetByMonHoc(long maMH)
        {
            return _dal.GetByMonHoc(maMH);
        }
    }
}
