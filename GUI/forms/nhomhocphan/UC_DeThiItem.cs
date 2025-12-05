using DTO;
using GUI.forms.dethi;

namespace GUI.Forms.nhomhocphan
{

    public partial class UC_DeThiItem : UserControl
    {
        private readonly string _userId;
        public UC_DeThiItem(string userId)
        {
            InitializeComponent();
            _userId = userId; 
        }

        public void SetData(DeThiDTO dethi)
        {
            linkDeKiemTra.Text = dethi.TenDe;
            lblStart.Text = "Bắt đầu: " + dethi.ThoiGianBatDau.ToString();
            lblEnd.Text = "Kết thúc: " + dethi.ThoiGianKetThuc.ToString();
            lblTime.Text = "Thời gian làm bài: " + dethi.ThoiGianLamBai + " phút";
            int trangThaiCode = dethi.TrangThai;
            linkDeKiemTra.Tag = dethi;
            switch (trangThaiCode)
            {
                case 1:
                    lblStatus.Text = "CHƯA MỞ";
                    lblStatus.ForeColor = Color.DarkGray;
                    break;

                case 2:
                    lblStatus.Text = "CHƯA LÀM";
                    lblStatus.ForeColor = Color.Orange;
                    break;
                case 3:
                    lblStatus.Text = "ĐÃ HOÀN THÀNH";
                    lblStatus.ForeColor = Color.Green;
                    break;
                case 4:
                    lblStatus.Text = "QUÁ HẠN";
                    lblStatus.ForeColor = Color.Red;
                    break;
                default:
                    lblStatus.Text = "KHÔNG XÁC ĐỊNH";
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        private void linkDeKiemTra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel clickedLink = (LinkLabel)sender;
            
            DeThiDTO deThiDuocChon = (DeThiDTO)clickedLink.Tag;

            ChiTietDeThi ctdt = new ChiTietDeThi(deThiDuocChon, _userId);

            ctdt.ShowDialog();
        }
    }
}
