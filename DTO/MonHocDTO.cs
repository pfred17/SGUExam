using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHocDTO
    {
        public long MaMH { get; set; }
        public required string TenMH { get; set; }
        public int SoTinChi { get; set; }
        public required byte TrangThai { get; set; }

        public MonHocDTO() { }

        public MonHocDTO(long maMH, string tenMH, int soTinChi, byte trangThai)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTinChi = soTinChi;
            TrangThai = trangThai;
        }
    }
}
