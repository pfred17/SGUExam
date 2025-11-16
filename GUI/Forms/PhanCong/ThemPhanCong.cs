using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.forms.PhanCong
{
    public partial class ThemPhanCong : Form
    {
        public ThemPhanCong()
        {
            InitializeComponent();
        }
        private void ThemPhanCong_Load(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            lblTheoGiangVien.ForeColor = Color.Black;
            lblTheoMonHoc.ForeColor = Color.DodgerBlue;
            ThemTheoGiangVien frm = new ThemTheoGiangVien();
            pnMain.Controls.Add(frm);
        }
        private void lblTheoGiangVien_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            lblTheoGiangVien.ForeColor = Color.Black;
            lblTheoMonHoc.ForeColor = Color.DodgerBlue;
            ThemTheoGiangVien frm = new ThemTheoGiangVien();
            pnMain.Controls.Add(frm);
        }
        private void lblTheoMonHoc_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            lblTheoMonHoc.ForeColor = Color.Black;
            lblTheoGiangVien.ForeColor = Color.DodgerBlue;
            ThemTheoMonHoc frm = new ThemTheoMonHoc();
            pnMain.Controls.Add(frm);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
