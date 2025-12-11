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

namespace GUI.forms.PhanCong
{
    public partial class ChiTietPhanCong : Form
    {
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();
        private readonly long _maPhanCong;
        private PhanCongDTO? currentPhanCong;

        public ChiTietPhanCong(long maPhanCong)
        {
            InitializeComponent();
            _maPhanCong = maPhanCong;
        }

        private void ChiTietPhanCong_Load(object sender, EventArgs e)
        {
            currentPhanCong = _phanCongBLL.GetPhanCongById(_maPhanCong);
            if (currentPhanCong == null)
            {
                MessageBox.Show("Không tìm thấy mã phân công!");
                return;
            }
            txtMaPhanCong.Text = currentPhanCong.MaPhanCong.ToString();
            txtMaGiangVien.Text = currentPhanCong.MaNguoiDung.ToString();
            txtTenGiangVien.Text = currentPhanCong.TenNguoiDung.ToString();
            txtMaMonHoc.Text = currentPhanCong.MaMonHoc.ToString();
            txtTenMonHoc.Text = currentPhanCong.TenMonHoc.ToString();
            txtTrangThai.Text = currentPhanCong.TrangThai == 1 ? "Hoạt động" : "Đang khóa"; ;
        }
    }
}
