using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHocDTO
    {
        public long MaMonHoc {  get; set; }
        public string TenMonHoc { get; set; } = "";
        public int SoTinChi { get; set; }
        public byte TrangThai { get; set; }
        public MonHocDTO() { }
    }
}
