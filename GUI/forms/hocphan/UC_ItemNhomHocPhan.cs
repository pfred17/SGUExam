using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI.modules
{
    public partial class UC_ItemNhomHocPhan : UserControl
    {
        private NhomHocPhanDTO _nhom;
        private MonHocDTO _monHoc;
        public event EventHandler<NhomHocPhanDTO> ViewStudentClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler EditClicked;
        private NhomHocPhanDTO currentData;
        public UC_ItemNhomHocPhan()
        {
            InitializeComponent();
        }

        public void SetData(NhomHocPhanDTO nhom, MonHocDTO monHoc)
        {
            currentData = nhom;
            lbTenNhom.Text = nhom.TenNhom;
            //lbMonHoc.Text = $"{monHoc.MaMonHoc} - {monHoc.TenMonHoc} - {nhom.HocKy} - {nhom.NamHoc}";
            lbMonHoc.Text =$" {monHoc.TenMonHoc} - {nhom.HocKy} - {nhom.NamHoc}";

            lbGhiChu.Text = nhom.GhiChu;
        }

        public NhomHocPhanDTO GetCurrentData() => currentData;

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            menuChucNang.Show(btnSetting, new Point(0, btnSetting.Height));
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void menuChucNang_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void lbGhiChu_Click(object sender, EventArgs e)
        {

        }

        private void menuXemSinhVien_Click(object sender, EventArgs e)
        {
            ViewStudentClicked?.Invoke(this, currentData);
        }
    }
    
}
