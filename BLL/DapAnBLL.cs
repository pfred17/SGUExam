using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class DapAnBLL
    {
        private readonly DapAnDAL _dal = new DapAnDAL();

        public List<DapAnDTO> GetByCauHoi(long maCauHoi)
        {
            return _dal.GetByCauHoi(maCauHoi);
        }

    }
}

