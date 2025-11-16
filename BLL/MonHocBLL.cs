using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class MonHocBLL
    {
        private MonHocDAL monHocDAL = new MonHocDAL();

        public List<MonHocDTO> GetAllMonHoc()
        {
            return monHocDAL.GetAllMonHoc();
        }

        public MonHocDTO GetById(long id)
        {
            return monHocDAL.GetById(id);
        }

        public bool AddMonHoc(MonHocDTO mh)
        {
            return monHocDAL.InsertMonHoc(mh);
        }
    }
}
