using BLL;
using DTO;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;

namespace GUI.Forms.login
{
    public partial class UC_Register : UserControl
    {

        public event EventHandler BackToLogin;
        public event EventHandler TogglePassword;

        private UserBLL userBLL = new UserBLL();

        public UC_Register()
        {
            InitializeComponent();
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string mssv = txtRegisterMssv.Text.Trim();
            string hoten = txtFullname.Text.Trim();
            string password = txtRegisterPassword.Text.Trim();
            string confirmPassword = txtRegisterConfirmPassword.Text.Trim();
            string email = txtRegisterEmail.Text.Trim();

            if (InputValidator.IsEmpty(mssv))
            {
                ShowError("Mã số sinh viên không được để trống!", txtRegisterMssv);
                return;
            }

            if (InputValidator.IsEmpty(hoten))
            {
                ShowError("Họ tên không được để trống!", txtFullname);
                return;
            }

            if (!InputValidator.IsValidPassword(password))
            {
                ShowError("Mật khẩu phải có ít nhất 1 ký tự hoa, thường, số và >= 8 ký tự.", txtRegisterPassword);
                return;
            }

            if (!InputValidator.IsPasswordMatch(password, confirmPassword))
            {
                ShowError("Mật khẩu xác nhận không khớp!", txtRegisterConfirmPassword);
                return;
            }

            if (!InputValidator.IsValidEmail(email))
            {
                ShowError("Email không đúng định dạng.", txtRegisterEmail);
                return;
            }

            if (userBLL.IsMssvExists(mssv))
            {
                ShowError("Mã số sinh viên đã được đăng ký.", txtRegisterMssv);
                return;
            }

            if (userBLL.IsEmailExists(email))
            {
                ShowError("Email đã được đăng ký.", txtRegisterEmail);
                return;
            }

            UserDTO user = userBLL.Register(mssv, hoten, password, email);

            if (user != null)
            {
                MessageBox.Show("Đăng ký thành công!");
                BackToLogin?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }
        }
        private void ShowError(string message, Control controlToFocus)
        {
            MessageBox.Show(message);
            controlToFocus.Focus();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void txtRegisterPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox, e);
        }

        private void Shared_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; 
                btnRegister.PerformClick();
            }
        }

        private void txtRegisterEmail_TextChanged(object sender, EventArgs e)
        {

        }

       
    }

}
