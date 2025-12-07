using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DapAnThongKeDTO
    {
        public string NoiDung { get; set; }
        public int SoLuongChon { get; set; }
        public double TiLeChon { get; set; } // 0.0 - 1.0
        public bool IsDung { get; set; }
    }
}
