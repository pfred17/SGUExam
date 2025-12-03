using BLL;
using DTO;

namespace GUI.forms.nguoidung
{
    public partial class Sua : Form
    {
        private readonly UserDTO user;
        private readonly UserBLL userBLL = new UserBLL();
        private readonly RoleBLL roleBLL = new RoleBLL();
        public event EventHandler UserUpdated;
        public Sua(string userId)
        {
            InitializeComponent();
            this.user = userBLL.GetUserById(userId);
            loadDataToInput(user);
            loadRoleData();
        }
        private void loadDataToInput(UserDTO user)
        {
            txtMSSV.Text = user.MSSV;
            txtHoVaTen.Text = user.HoTen;
            txtEmail.Text = user.Email;
            txtUsername.Text = user.TenDangNhap;
            txtPassword.Text = user.MatKhau;
            cbbNhomQuyen.Text = roleBLL.GetRoleNameById(user.Role);
            if (user.GioiTinh == 1)
                radioNam.Checked = true;
            else
                radioNu.Checked = true;
        }

        public void loadRoleData()
        {
            List<String> roles = new List<String>();
            List<RoleDTO> roleDTOs = roleBLL.getAllRole();

            foreach (var role in roleDTOs)
            {
                roles.Add(role.TenNhomQuyen);
            }

            cbbNhomQuyen.DataSource = roles;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var userUpdate = this.user;
            userUpdate.TenDangNhap = txtUsername.Text.Trim();
            userUpdate.MatKhau = txtPassword.Text.Trim();
            userUpdate.HoTen = txtHoVaTen.Text.Trim();
            userUpdate.Role = Convert.ToInt32(roleBLL.GetRoleIdByName(cbbNhomQuyen.Text));
            userUpdate.Email = txtEmail.Text.Trim();
            userUpdate.GioiTinh = radioNam.Checked ? 1 : 0;
            try
            {
                userBLL.UpdateUser(userUpdate);
                MessageBox.Show("Cập nhật người dùng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
