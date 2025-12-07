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
            string regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            string regexEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Mã số sinh viên không được để trống!");
                txtRegisterMssv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoten))
            {
                MessageBox.Show("Họ tên không được để trống!");
                txtFullname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!");
                txtRegisterPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Mật khẩu xác nhận không được để trống!");
                txtRegisterConfirmPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!");
                txtRegisterEmail.Focus();
                return;
            }
            if (userBLL.IsMssvExists(mssv))
            {
                MessageBox.Show("Mã số sinh viên đã được sử dụng.");
                txtRegisterMssv.Focus();
                return;
            }
            if (!Regex.IsMatch(password, regexPassword))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 số và ≥ 8 ký tự.");
                txtRegisterPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                txtRegisterConfirmPassword.Focus();
                return;
            }
            if (!Regex.IsMatch(email, regexEmail))
            {
                MessageBox.Show("Email không hợp lệ.");
                txtRegisterEmail.Focus();
                return;
            }
            if (userBLL.IsEmailExists(email))
            {
                MessageBox.Show("Email đã được sử dụng.");
                txtRegisterEmail.Focus();
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

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void txtRegisterPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox, e);
        }

        private void txtRegisterMssv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtFullname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtRegisterPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txtRegisterConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txtRegisterEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtRegisterConfirmPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtRegisterEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegisterEmail_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }

}
