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

namespace GUI.Forms
{
    public partial class frmAddMonHoc : Form
    {
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        public frmAddMonHoc()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MonHocDTO newMH = new MonHocDTO
            {
                TenMH = txtTenMonHoc.Text,
                SoTinChi = int.Parse(txtSoTinChi.Text),
                TrangThai = 1
            };

            if (monHocBLL.AddMonHoc(newMH))
            {
                MessageBox.Show("Thêm môn học thành công!");
            }
            else
            {
                MessageBox.Show("Thêm môn học thất bại.");
            }
        }

        private void frmAddMonHoc_Load(object sender, EventArgs e)
        {

        }
    }
}
