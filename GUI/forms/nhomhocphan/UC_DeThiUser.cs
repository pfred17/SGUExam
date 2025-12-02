using BLL;
using DTO;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_DeThiUser : UserControl
    {
        private readonly long _maNhom;

        private readonly string _userId;

        public UC_DeThiUser(long maNhom, string userId)
        {
            _maNhom = maNhom;
            _userId = userId;
            InitializeComponent();
            LoadDeThi();
        }
        private void LoadDeThi()
        {
            tabMain.Controls.Clear();
            tabKiemTra.Controls.Clear();
            tabLuyenTap.Controls.Clear();

            DeThiBLL deThiBLL = new DeThiBLL();
            NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();

            NhomHocPhanDTO nhom = nhomHocPhanBLL.GetById(_maNhom);
            lblTenNhom.Text = nhom.TenNhom;

            List<DeThiDTO> dsDeKiemTra = deThiBLL.GetDeKiemTraByMaNhom(_maNhom);

            foreach (DeThiDTO dethi in dsDeKiemTra)
            {
                UC_DeThiItem item = new UC_DeThiItem(_userId);
                item.SetData(dethi);
                item.Dock = DockStyle.Top;
                tabKiemTra.Controls.Add(item);
            }

            List<DeThiDTO> dsDeLuyenTap = deThiBLL.GetDeLuyenTapByMaNhom(_maNhom);
            foreach (DeThiDTO dethi in dsDeLuyenTap)
            {
                UC_DeThiItem item = new UC_DeThiItem(_userId);
                item.SetData(dethi);
                item.Dock = DockStyle.Top;
                tabLuyenTap.Controls.Add(item);
            }
            tabMain.Controls.Add(tabKiemTra);
            tabMain.Controls.Add(tabLuyenTap);

        }

        private void tabKiemTra_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
