using DTO;
using GUI.forms.dethi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

      

        public void SetData(DeThiDTO deThi)
        {

            
            linkDeKiemTra.Text = deThi.TenDe;
            lblStart.Text = "Bắt đầu: " + deThi.ThoiGianBatDau.ToString();
            lblEnd.Text = "Kết thúc: " + deThi.ThoiGianKetThuc.ToString();
            lblTime.Text = "Thời gian làm bài: " + deThi.ThoiGianLamBai + " phút";
            int trangThaiCode = deThi.TrangThai;
            linkDeKiemTra.Tag = deThi;

            var now = DateTime.Now;

            if (deThi.ThoiGianBatDau != null && now < deThi.ThoiGianBatDau)
                lblStatus.Text = "Chưa mở";
            else if (deThi.ThoiGianBatDau != null && deThi.ThoiGianKetThuc != null &&
                 now >= deThi.ThoiGianBatDau && now <= deThi.ThoiGianKetThuc)
                lblStatus.Text = "Đang thi";
            else if (deThi.ThoiGianKetThuc != null && now > deThi.ThoiGianKetThuc)
                lblStatus.Text = "Kết thúc";
            else
                lblStatus.Text = "Không xác đinh";

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
