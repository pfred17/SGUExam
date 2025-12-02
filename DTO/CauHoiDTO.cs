namespace DTO
{
    public class CauHoiDTO
    {
        public long MaCauHoi { get; set; } 
        public long MaChuong { get; set; }
        public long MaMonHoc { get; set; }
        public string NoiDung { get; set; } = "";
        public string DoKho { get; set; } = "";
        public string TenMonHoc { get; set; } = "";
        public string TacGia { get; set; } = "Chưa xác định";
        public bool IsBanSao { get; set; } // mặc định true
        public int SoLuotLam { get; set; }  
        public double TyLeSai { get; set; }
        public string DoKhoGoiY { get; set; } = ""; 
    }
}