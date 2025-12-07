using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQuaBaiThiDTO
    {
        public List<CauHoiDTO> DsCauHoi { get; set; }
        public int SoCauDung { get; set; }
        public decimal Diem { get; set; }
    }

}
