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

namespace GUI.forms.hocphan
{
    public partial class UC_ItemDeThi : UserControl
    {
        public event EventHandler<long> SuaDeThiClicked;
        public event EventHandler<long> XemChiTietClicked;
        public event EventHandler<long> XoaClicked;
        private long _maDe;
        private long _maNhom;
        public UC_ItemDeThi()
        {
            InitializeComponent();
        }
        public void SetData(DeThiDTO deThi, string tenNhom)
        {
            _maDe = deThi.MaDe;

            lbTenDe.Text = deThi.TenDe;
            lbNhom.Text = $"Nhóm: {tenNhom}";

            string thoiGian = "Chưa đặt thời gian";
            if (deThi.ThoiGianBatDau.HasValue && deThi.ThoiGianKetThuc.HasValue)
            {
                thoiGian = $"{deThi.ThoiGianBatDau:dd/MM/yyyy HH:mm} → {deThi.ThoiGianKetThuc:dd/MM/yyyy HH:mm}";
            }
            else if (deThi.ThoiGianBatDau.HasValue)
            {
                thoiGian = $"Bắt đầu: {deThi.ThoiGianBatDau:dd/MM/yyyy HH:mm}";
            }

            if (deThi.ThoiGianLamBai > 0)
                thoiGian += $" | Làm bài: {deThi.ThoiGianLamBai} phút";

            lbThoiGian.Text = thoiGian;

            // Đổi màu nếu đã hết hạn
            if (deThi.ThoiGianKetThuc.HasValue && deThi.ThoiGianKetThuc < DateTime.Now)
            {
                lbTenDe.ForeColor = Color.Gray;
                lbThoiGian.Text += " (Đã kết thúc)";
                lbThoiGian.ForeColor = Color.Red;
            }
        }

        private void UC_ItemDeThi_Load(object sender, EventArgs e)
        {

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaClicked?.Invoke(this, _maDe);
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            XemChiTietClicked?.Invoke(this, _maDe);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaDeThiClicked?.Invoke(this, _maDe);
        }
    }
}
