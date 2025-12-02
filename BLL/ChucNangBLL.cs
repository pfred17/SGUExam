using DAL;
using DTO;

namespace BLL
{
    public class ChucNangBLL
    {
        private readonly ChucNangDAL _chucNangDAL = new ChucNangDAL();   

        public List<ChucNangDTO> GetAllChucNang()
        {
            return _chucNangDAL.getAllCHucNang();
        }
    }
}
