using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietBaiLamBLL
    {
        private readonly ChiTietBaiLamDAL dal = new ChiTietBaiLamDAL();

        public List<ChiTietBaiLamDTO> GetByMaBai(long maBai) => dal.GetByMaBai(maBai);

        public bool Insert(ChiTietBaiLamDTO chiTiet) => dal.Insert(chiTiet);

        public bool Update(ChiTietBaiLamDTO chiTiet) => dal.Update(chiTiet);
    }
}
