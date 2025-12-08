using BLL;
using DTO;
using GUI.forms.nguoidung;

namespace GUI.Forms.nguoidung
{
    public partial class Info : Form
    {
        private readonly string _userId;

        private  UserBLL userBLL = new UserBLL();
        public Info(string userId)
        {
            InitializeComponent();
            _userId = userId;          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetUserById(_userId);
            UpdateInfo frm = new UpdateInfo(user);

            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }

        }
        private void LoadUserData()
        {
            UserDTO user = userBLL.GetUserById(_userId);

            if (user != null)
            {
                showUsename.Text = "@" + user.TenDangNhap;
                showName.Text = user.HoTen;
                showEmail.Text = user.Email;
                showGender.Text = user.GioiTinh == 1 ? "Nam" : "Nữ";

                showRole.Text = user.Role.ToString();
            }
        }
        private void Info_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
