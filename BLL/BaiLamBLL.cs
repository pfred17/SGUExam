using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BaiLamBLL
    {
        private readonly BaiLamDAL dal = new BaiLamDAL();

        public List<BaiLamDTO> GetByDeThi(long maDe) => dal.GetByDeThi(maDe);

        public BaiLamDTO GetById(long maBai) => dal.GetById(maBai);

        public long Insert(BaiLamDTO baiLam) => dal.Insert(baiLam);

        public bool Update(BaiLamDTO baiLam) => dal.Update(baiLam);
    }
}
