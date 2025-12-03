using BLL;
using DTO;
using System.Windows.Forms;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_NhomHocPhanUser : UserControl
    {
        private readonly NhomHocPhanBLL _nhomHocPhanBLL = new NhomHocPhanBLL();

        private readonly string _userId;

        public UC_NhomHocPhanUser(string userId)
        {
            _userId = userId;
            InitializeComponent();
            LoadNhomHocPhan();
        }

        public void LoadNhomHocPhan()
        {
            string keyword= txtSearch.Text.Trim();
            List<NhomHocPhanDTO> nhomHocPhanList;

            if (string.IsNullOrEmpty(keyword))
            {
             nhomHocPhanList = _nhomHocPhanBLL.GetNhomHocPhanByUserId(_userId);
            }
             nhomHocPhanList = _nhomHocPhanBLL.SearchNhomHocPhan(_userId, keyword);

            flpNhomHocPhan.Controls.Clear();

            if (nhomHocPhanList == null || nhomHocPhanList.Count == 0)
            {
                Label lblNoData = new Label();
                lblNoData.Text = "Không có nhóm học phần nào";
                lblNoData.AutoSize = true;
                lblNoData.Font = new Font(lblNoData.Font.FontFamily, 10, FontStyle.Italic);
                flpNhomHocPhan.Controls.Add(lblNoData);
                return;
            }

            foreach (NhomHocPhanDTO nhom in nhomHocPhanList)
            {
                UC_NhomHocPhanItem item = new UC_NhomHocPhanItem(_userId, nhom.MaNhom);
                item.SetData(nhom);

                item.DetailsButtonClicked += (sender, e) => Item_DetailsButtonClicked(nhom);

                item.NhomReloadRequired += FormThamGia_InsertSuccess;

                flpNhomHocPhan.Controls.Add(item);
            }
        }

        private void Item_DetailsButtonClicked(NhomHocPhanDTO nhom)
        {
            ShowListDeThi(nhom.MaNhom);
        }

        private void HandlerBackButtonClicked(object? sender, EventArgs e)
        {
            UC_DeThiUser? currentDeThiUserControl = sender as UC_DeThiUser;
            if (currentDeThiUserControl != null)
            {
                currentDeThiUserControl.BackButtonClicked -= HandlerBackButtonClicked;
                this.Controls.Remove(currentDeThiUserControl);
                currentDeThiUserControl.Dispose();
            }
            flpNhomHocPhan.Visible = true;
            flpNhomHocPhan.Enabled = true;
        }

        private void ShowListDeThi(long maNhom)
        {
            UC_DeThiUser uc = new UC_DeThiUser(maNhom, _userId);
            uc.BackButtonClicked += HandlerBackButtonClicked;

            flpNhomHocPhan.Visible = false;
            flpNhomHocPhan.Enabled = false;

            this.Controls.Add(uc);
            uc.Dock = DockStyle.Right;
            uc.BringToFront();
        }

        private void FormThamGia_InsertSuccess(object? sender, EventArgs e)
        {
            LoadNhomHocPhan();

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            FormThamGia form = new FormThamGia(_userId);

            form.InsertSuccess += FormThamGia_InsertSuccess;

            form.ShowDialog();

            form.InsertSuccess -= FormThamGia_InsertSuccess;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadNhomHocPhan();
        }
    }
}