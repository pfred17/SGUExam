using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauHoiThongKeDTO
    {
        public long MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public List<DapAnThongKeDTO> DapAns { get; set; }
        public int Index { get; set; }
        public int DapAnDungIndex { get; set; }
    }
}
