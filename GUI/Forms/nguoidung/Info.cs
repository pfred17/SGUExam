using BLL;
using DTO;
using GUI.forms.nguoidung;

namespace GUI.Forms.nguoidung
{
    public partial class Info : Form
    {
        private readonly string _userId;
        private readonly bool _isXemChiTiet;

        private  UserBLL userBLL = new UserBLL();
        private  RoleBLL roleBLL = new RoleBLL();
        public Info(string userId, bool isXemChiTiet)
        {
            InitializeComponent();
            _userId = userId;
            _isXemChiTiet = isXemChiTiet;
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

                showRole.Text = roleBLL.GetRoleNameById(user.Role);
            }
        }
        private void Info_Load(object sender, EventArgs e)
        {
            if (_isXemChiTiet)
            {
                btnUpdate.Visible = false;  
            }
            LoadUserData();
        }
    }
}
