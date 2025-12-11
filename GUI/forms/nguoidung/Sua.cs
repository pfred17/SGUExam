using BLL;
using BLL.Validator;
using DTO;

namespace GUI.forms.nguoidung
{
    public partial class Sua : Form
    {
        private readonly UserDTO user;
        private readonly UserBLL userBLL = new UserBLL();
        private readonly RoleBLL roleBLL = new RoleBLL();
        public event EventHandler UserUpdated;

        private string originalHoTen;
        private string originalEmail;
        private string originalPassword;
        private bool originalGioiTinh;
        private string originalNhomQuyen;
        public Sua(string userId)
        {
            InitializeComponent();
            this.user = userBLL.GetUserById(userId);
            loadDataToInput(user);
            loadRoleData();
        }

        private void Sua_Load(object sender, EventArgs e)
        {
            originalHoTen = txtHoVaTen.Text;
            originalEmail = txtEmail.Text;
            originalPassword = txtPassword.Text;
            originalGioiTinh = user.GioiTinh == 1;
            originalNhomQuyen = cbbNhomQuyen.Text;

            btnSubmit.Cursor = Cursors.No;
            btnSubmit.Enabled = false;
        }
        private void  CheckForChanges()
        {
            bool currentGioiTinh = radioNam.Checked;

            bool isChanged =
                txtHoVaTen.Text != originalHoTen ||
                txtEmail.Text != originalEmail ||
                txtPassword.Text != originalPassword ||
                cbbNhomQuyen.Text != originalNhomQuyen ||
                currentGioiTinh != originalGioiTinh;

            btnSubmit.Enabled = isChanged;
            btnSubmit.Cursor = isChanged ? Cursors.Hand : Cursors.No;
        }

        private void loadDataToInput(UserDTO user)
        {
            txtMSSV.Text = user.MSSV;
            txtHoVaTen.Text = user.HoTen;
            txtEmail.Text = user.Email;
            txtPassword.Text = user.MatKhau;
            if (user.GioiTinh == 1)
                radioNam.Checked = true;
            else
                radioNu.Checked = true;
            loadRoleData();
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
            cbbNhomQuyen.Text = roleBLL.GetRoleNameById(user.Role);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!checkAllInput()) return;
            var userUpdate = this.user;
            userUpdate.TenDangNhap = txtMSSV.Text.Trim();
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

        private bool checkAllInput()
        {
            if (InputValidator.IsEmpty(txtEmail.Text))
            {
                OpenMessageBox("Vui lòng nhập email!", "Thông báo");
                lbErrorEmail.Text = "Vui lòng nhập email!";
                lbErrorEmail.Visible = true;
                return false;
            }
            if (InputValidator.IsEmpty(txtHoVaTen.Text))
            {
                OpenMessageBox("Vui lòng nhập họ và tên!", "Thông báo");
                lbErrorHoVaTen.Text = "Vui lòng nhập họ và tên!";
                lbErrorHoVaTen.Visible = true;
                return false;
            }
            if (InputValidator.IsEmpty(txtPassword.Text))
            {
                OpenMessageBox("Vui lòng nhập mật khẩu!", "Thông báo");
                lbErrorPassowrd.Text = "Vui lòng nhập mật khẩu!";
                lbErrorPassowrd.Visible = true;
                return false;
            }
            return true;
        }
        private void OpenMessageBox(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void txtHoVaTen_Leave(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void radioNam_CheckedChanged(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void radioNu_CheckedChanged(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void cbbNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForChanges();
        }
    }
}
