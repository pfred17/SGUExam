using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaiLamDTO
    {
        public long MaBai { get; set; }
        public long MaDe { get; set; }
        public string MaNguoiDung { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianNop { get; set; }
        public decimal? Diem { get; set; }
    }
}
