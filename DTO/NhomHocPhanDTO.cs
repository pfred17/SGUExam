
using System.Data;

namespace DTO
{
    public class NhomHocPhanDTO
    {
        public long MaNhom { get; set; }
        public long MaPhanCong { get; set; }
        public string TenNhom { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty; 
        public string HocKy { get; set; } = string.Empty;
        public string NamHoc { get; set; } = string.Empty;
        public int TrangThai { get; set; }
        public String MaMonHoc { get; set; }  // ← Tên môn (lấy từ phan_cong → mon_hoc)
        public string TenMonHoc { get; set; } // ← Tên môn (lấy từ phan_cong → mon_hoc)
    }
}
