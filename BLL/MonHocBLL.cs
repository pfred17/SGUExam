using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class MonHocBLL
    {
        private readonly MonHocDAL monHocDAL = new MonHocDAL();
        private readonly ChuongDAL chuongDAL = new ChuongDAL();
        public List<MonHocDTO> ListMonHoc()
        {
            return monHocDAL.GetAllMonHoc();
        }

        public bool AddMonHoc(MonHocDTO monHoc)
        {
            long newId = monHocDAL.AddMonHoc(monHoc);
            if (newId > 0)
            {
                chuongDAL.AddRandomChuongForMonHoc(newId);
                return true;
            }
            return false;
        }
    }
}
