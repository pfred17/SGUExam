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
        public required string TenChuong { get; set; }
        public long MaMonHoc { get; set; }

        public ChuongDTO() { }

        public ChuongDTO(long maChuong, string tenChuong, long maMonHoc)
        {
            MaChuong = maChuong;
            TenChuong = tenChuong;
            MaMonHoc = maMonHoc;
        }
    }
}
