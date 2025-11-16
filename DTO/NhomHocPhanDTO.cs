
using System.Data;

namespace DTO
{
    public class NhomHocPhanDTO
    {
        public long MaNhom { get; set; }
        public long MaMH { get; set; }
        public string TenNhom { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty; 
        public string HocKy { get; set; } = string.Empty;
        public string NamHoc { get; set; } = string.Empty;
        public int TrangThai { get; set; }
    }
}
