using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoleDTO
    {
        public long MaNhomQuyen { get; set; }              // id nhóm quyền (tùy chọn)
        public string TenNhomQuyen { get; set; }          // "Quản trị", "Giảng viên", ...
        public List<ModulePermissionDTO> Modules { get; set; } = new List<ModulePermissionDTO>();

        // helper: nhanh lấy actions của 1 module
        public ModulePermissionDTO GetModule(string moduleName)
            => Modules.FirstOrDefault(m => string.Equals(m.ModuleName, moduleName, StringComparison.OrdinalIgnoreCase));
    }

}
