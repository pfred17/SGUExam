using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuongDTO
    {
        public long MaChuong { get; set; }
        public long MaMonHoc { get; set; }
        public string TenChuong { get; set; } = "";
        public int TrangThai { get; set; }
        public ChuongDTO() { }
    }
}
