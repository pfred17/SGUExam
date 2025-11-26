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
    }
}