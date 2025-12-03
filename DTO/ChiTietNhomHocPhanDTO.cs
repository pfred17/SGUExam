using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietNhomHocPhanDTO
    {
        public string MaND { get; set; }        // ma_nd VARCHAR(255)
        public long MaNhom { get; set; }        // ma_nhom BIGINT
        public long? MaDiemDanh { get; set; }   // có thể NULL
    }
}