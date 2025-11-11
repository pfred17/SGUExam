using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_KiemTra : UserControl
    {
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        public UC_KiemTra(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }
    }
}
