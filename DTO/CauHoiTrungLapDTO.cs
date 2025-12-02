
namespace DTO
{
    public class CauHoiTrungLapDTO
    {
        public string Key { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public List<CauHoiDTO> DanhSach { get; set; } = new();
        public bool IsBanSao { get; set; } = true; // mặc định true
        public string TacGia { get; set; } = "Chưa rõ tác giá";
    }
}
