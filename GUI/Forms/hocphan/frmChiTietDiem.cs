using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace GUI.forms.hocphan
{
    public partial class frmChiTietDiem : Form
    {
        NhomHocPhanBLL bll = new NhomHocPhanBLL();
        private long _maNhom;

        public frmChiTietDiem(long maNhom)
        {
            InitializeComponent();
            _maNhom = maNhom;
            LoadBangDiem();
        }

        private void LoadBangDiem()
        {
            dgvBangDiem.DataSource = bll.LayBangDiemPivot(_maNhom);
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
