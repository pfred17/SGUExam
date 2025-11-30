
namespace DTO
{
    public class CauHoiTrungLapDTO
    {
        public string Key { get; set; } = string.Empty;
        public string NoiDung { get; set; } = "";
        public int SoLuong { get; set; }
        public List<CauHoiDTO> DanhSach { get; set; } = new();
    }
}
