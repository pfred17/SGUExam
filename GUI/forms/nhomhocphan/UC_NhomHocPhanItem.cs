using BLL;
using DTO;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_NhomHocPhanItem : UserControl
    {
        private NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();

        public event EventHandler? DetailsButtonClicked;
        public UC_NhomHocPhanItem()
        {
            InitializeComponent();
        }

        public void SetData(NhomHocPhanDTO nhom)
        {
            lblTenMonHoc.Text = nhomHocPhanBLL.GetTenMonHocByMaNhom(nhom.MaNhom);
            lblTenNhom.Text = nhom.TenNhom;
            lblThoiGian.Text = $"{nhom.HocKy} - {nhom.NamHoc}";
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
                DetailsButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
