using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ModulePermissionDTO
    {   
        // vd "MonHoc"
        public string ModuleName { get; set; }

        // Actions map: "Xem","Them","Sua","Xoa","TruyCap",...
        public Dictionary<string, bool> Actions { get; set; } = new Dictionary<string, bool>();
    }
}
