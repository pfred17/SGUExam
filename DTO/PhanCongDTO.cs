using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanCongDTO
    {
        public long MaPhanCong {  get; set; }
        public long MaMonHoc { get; set; }
        public string TenMonHoc { get; set; } = "";
        public string MaNguoiDung { get; set; } = "";
        public string TenNguoiDung { get; set; } = "";
        public int TrangThai {  get; set; }
        public PhanCongDTO() { }
    }
}
