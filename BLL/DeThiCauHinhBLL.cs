using DTO;
using DAL;

namespace BLL
{
    public class DeThiCauHinhBLL
    {
        private readonly DeThiCauHinhDAL _dal = new DeThiCauHinhDAL();

        public DeThiCauHinhDTO? GetByMaDe(long maDe)
        {
            return _dal.GetByMaDe(maDe);
        }

        public bool Update(long maDe, DeThiCauHinhDTO cauHinh)
        {
            return _dal.Update(maDe, cauHinh);
        }
    }
}
