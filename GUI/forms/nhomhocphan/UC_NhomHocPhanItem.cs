using BLL;
using DAL;
using DTO;
using System.Windows.Forms;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_NhomHocPhanItem : UserControl
    {
        // Sự kiện cần tải lại danh sách nhóm (Sau khi thoát nhóm)
        public event EventHandler? NhomReloadRequired;
        public event EventHandler? DetailsButtonClicked;

        private long _maNhom;
        private readonly string _userId;
        private NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();

        // Constructor để nhận UserId
        public UC_NhomHocPhanItem(string userId,long maNhom)
        {
            _userId = userId;
            _maNhom = maNhom;
            InitializeComponent();

            this.thoatNhomToolStripMenuItem.Click += new System.EventHandler(this.ThoatNhomToolStripMenuItem_Click);
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            contextMenuStripThoat.Show(btnSetting, new Point(0, btnSetting.Height));
        }

        private void ThoatNhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi nhóm học phần này không?",
                "Xác nhận thoát nhóm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = ChiTietNhomHocPhanBLL.XoaSinhVienKhoiNhom(_userId, _maNhom);

                if (success)
                {
                    MessageBox.Show("Đã thoát khỏi nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    NhomReloadRequired?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Thoát nhóm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}