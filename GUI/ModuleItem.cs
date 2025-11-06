using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class ModuleItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Group { get; set; }
        public Image Icon { get; set; }
        public Image IconActive { get; set; }
        public Type UserControlType { get; set; }
    }
}
