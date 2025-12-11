using BLL;
using BLL.Validator;
using DAL;
using DTO;

namespace GUI.forms.nguoidung
{
    public partial class Them : Form
    {
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly RoleBLL _roleBLL = new RoleBLL();
        public event EventHandler UserAdded;
        public Them()
        {
            InitializeComponent();
            loadRoleData();
        }

        public void loadRoleData()
        {
            List<String> roles = new List<String>();
            List<RoleDTO> roleDTOs = _roleBLL.getAllRole();

            roles.Add("--Chọn nhóm quyền");

            foreach (var role in roleDTOs)
            {
                roles.Add(role.TenNhomQuyen);
            }

            cbbNhomQuyen.DataSource = roles;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!checkAllInput()) return;

            int gioiTinh = 1;

            if (radioNam.Checked)
                gioiTinh = 1;
            else if (radioNu.Checked)
                gioiTinh = 0;

            int trangThai = 1;
            if (tsTrangThai.Checked)
                trangThai = 1;
            else
                trangThai = 0;

            if (cbbNhomQuyen.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new UserDTO
            {
                MSSV = txtMSSV.Text.Trim(),
                TenDangNhap = txtMSSV.Text.Trim(),
                MatKhau = txtPassword.Text.Trim(),
                HoTen = txtHoVaTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Role = _roleBLL.GetRoleIdByName(cbbNhomQuyen.Text),
                GioiTinh = gioiTinh,
                TrangThai = trangThai
            };

            try
            {
                _userBLL.CreateNewUser(user);
                MessageBox.Show("Thêm người dùng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Gọi event báo ra ngoài là đã thêm user thành công
                UserAdded?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidEmail(txtEmail.Text))
            {
                lbErrorEmail.Text = "Email không hợp lệ!";
                lbErrorEmail.Visible = true;
            }
            else
            {
                lbErrorEmail.Text = "";
                lbErrorEmail.Visible = false;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lbErrorEmail.Visible = false;
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            // Kiểm tra xem email có hợp lệ không
            if (!InputValidator.IsValidMSSV(txtMSSV.Text))
            {
                lbErrorMSSV.Text = "MSSV phải có đúng 10 ký tự và bắt đầu từ 312...)";
                lbErrorMSSV.Visible = true;
            }
            else
            {
                lbErrorMSSV.Text = "";
                lbErrorMSSV.Visible = false;
            }
        }
        private void txtMSSV_Enter(object sender, EventArgs e)
        {
            lbErrorMSSV.Visible = false;
        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
            lbErrorMSSV.Visible = false;
        }

        private void txtHoVaTen_Leave(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidName(txtHoVaTen.Text))
            {
                lbErrorHoVaTen.Text = "Họ tên có ít nhất 6 ký tự!";
                lbErrorHoVaTen.Visible = true;
            }
            else
            {
                lbErrorHoVaTen.Text = "";
                lbErrorHoVaTen.Visible = false;
            }
        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {
            lbErrorHoVaTen.Visible = false;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidPassword(txtPassword.Text))
            {
                lbErrorPassowrd.Text = "Mật khẩu phải có ít nhất 6 ký tự (bao gồm chữ hoa và thường)!";
                lbErrorPassowrd.Visible = true;
            }
            else
            {
                lbErrorPassowrd.Text = "";
                lbErrorPassowrd.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lbErrorPassowrd.Visible = false;
        }

        private bool checkAllInput()
        {
            if (InputValidator.IsEmpty(txtMSSV.Text))
            {
                OpenMessageBox("Vui lòng nhập MSSV!", "Thông báo");
                lbErrorMSSV.Text = "Vui lòng nhập MSSV!";
                lbErrorMSSV.Visible = true;
                return false;
            }
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
    }
}
