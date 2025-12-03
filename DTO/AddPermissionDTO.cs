
namespace DTO
{
    public class AddPermissionDTO
    {
        public int MaChucNang { get; set; }
        public Dictionary<int, int> Quyen_DuocPhep { get; set; } = new Dictionary<int, int>();
    }
}
