using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI.forms.MonHoc
{
    public partial class SuaMonHoc : Form
    {
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private long _maMonHoc;
        private MonHocDTO? currentMonHoc;
        public SuaMonHoc(long maMonHoc)
        {
            InitializeComponent();
            _maMonHoc = maMonHoc;
            LoadData();
        }
        private void LoadData()
        {
            currentMonHoc = monHocBLL.GetMonHocById(_maMonHoc);

            if (currentMonHoc == null)
            {
                MessageBox.Show("Không tìm thấy môn học!");
                return;
            }
            txtMaMonHoc.Text = currentMonHoc.MaMH.ToString();
            txtTenMonHoc.Text = currentMonHoc.TenMH;
            txtSoTinChi.Text = currentMonHoc.SoTinChi.ToString();
            tsTrangThai.Checked = currentMonHoc.TrangThai == 1;
        }
        private void txtTenMonHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
