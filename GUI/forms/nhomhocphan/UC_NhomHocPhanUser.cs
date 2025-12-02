using BLL;
using DTO;

namespace GUI.Forms.nhomhocphan
{
    public partial class UC_NhomHocPhanUser : UserControl
    {
        private NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();

        private readonly string _userId;


        public UC_NhomHocPhanUser(string userId)
        {
            _userId = userId;
            InitializeComponent();
            LoadNhomHocPhan();
        }

        private void LoadNhomHocPhan()
        {
            List<NhomHocPhanDTO> nhomHocPhanList = nhomHocPhanBLL.GetNhomHocPhanByUserId(_userId);

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
                UC_NhomHocPhanItem item = new UC_NhomHocPhanItem();
                item.SetData(nhom);
                // Use a lambda to capture the current 'nhom' value for the event handler
                item.DetailsButtonClicked += (sender, e) => Item_DetailsButtonClicked(nhom);
                flpNhomHocPhan.Controls.Add(item);
            }

        }

        private void Item_DetailsButtonClicked(NhomHocPhanDTO nhom)
        {
            ShowDeThi(nhom.MaNhom);
        }

        private void ShowDeThi(long maNhom)
        {
            UC_DeThiUser uc = new UC_DeThiUser(maNhom, _userId);
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormThamGia form = new FormThamGia(_userId);
            form.ShowDialog();
        }
    }
}
