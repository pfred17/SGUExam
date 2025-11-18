using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class MonHocBLL
    {
        private readonly MonHocDAL _dal = new MonHocDAL();

        public List<MonHocDTO> GetAll()
        {
            return _dal.GetAll();
        }
    }
}