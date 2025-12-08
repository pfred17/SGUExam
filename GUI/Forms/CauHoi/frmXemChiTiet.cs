using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI.Forms.CauHoi
{
    public partial class frmXemChiTiet : Form
    {
        private readonly long _maCauHoi;
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();

        public frmXemChiTiet(long maCauHoi)
        {
            InitializeComponent();
            _maCauHoi = maCauHoi;
            frmXemChiTiet_Load();
        }

        private void frmXemChiTiet_Load()
        {
            var cauHoi = _cauHoiBLL.GetById(_maCauHoi);
            if (cauHoi == null)
            {
                MessageBox.Show("Câu hỏi không tồn tại!");
                Close();
                return;
            }

            lblNoiDung.Text = $"Câu hỏi : {cauHoi.NoiDung}";
            lblMonHoc.Text = cauHoi.TenMonHoc;
            lblChuong.Text = new ChuongBLL().GetChuongByMonHoc(cauHoi.MaMonHoc)
                                .Find(ch => ch.MaChuong == cauHoi.MaChuong)?.TenChuong ?? "Chưa xác định";
            lblDoKho.Text = cauHoi.DoKho;

            var dapAnList = new CauHoiBLL().GetDapAn(cauHoi.MaCauHoi);

            lblA.Text = dapAnList.Count > 0 ? dapAnList[0].NoiDung : "";
            lblB.Text = dapAnList.Count > 1 ? dapAnList[1].NoiDung : "";
            lblC.Text = dapAnList.Count > 2 ? dapAnList[2].NoiDung : "";
            lblD.Text = dapAnList.Count > 3 ? dapAnList[3].NoiDung : "";

            var dapAnDung = dapAnList.Find(dapAn =>dapAn.Dung);
            lblDapAnDung.Text = dapAnDung != null ? $"Đáp án đúng: {dapAnDung.NoiDung}" : "Chưa xác định";
        }

    }

}
