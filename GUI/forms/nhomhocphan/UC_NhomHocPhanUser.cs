using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_NhomHocPhanUser : UserControl
    {
        private readonly string _userId;
        public UC_NhomHocPhanUser(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

       
    }
}
