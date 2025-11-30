using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class CauHoiTrungLapDTO
    {
        public string NoiDung { get; set; } = "";
        public int SoLuong { get; set; }
        public List<CauHoiDTO> DanhSach { get; set; } = new();
    }
}
