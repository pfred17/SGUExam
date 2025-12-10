using BLL;
using BLL.Validator;
using DTO;
using Guna.UI2.WinForms;

namespace GUI.Forms.login
{
    public partial class UC_Login : UserControl
    {
        private UserBLL userBLL = new UserBLL();
        public event EventHandler SwitchToRegister;
        public event EventHandler SwitchToForgotPassword;
        public event EventHandler TogglePassword;
        
        private Color defaultBorderColor = Color.FromArgb(226, 232, 240);
        private Color errorColor = Color.Red;

        public UC_Login()
        {
            InitializeComponent();
        }

        private void ShowError(Label lbl, Guna2TextBox txt, string message)
        {
            lbl.Text = message;
            lbl.Visible = true;
            txt.BorderColor = errorColor;
            txt.FocusedState.BorderColor = errorColor; 
        }

        private void ClearError(Label lbl, Guna2TextBox txt)
        {
            lbl.Text = "";
            txt.BorderColor = defaultBorderColor;
            txt.FocusedState.BorderColor = Color.FromArgb(79, 70, 229); 
        }

        private void ResetAllErrors()
        {
            ClearError(lbErrorMSSV, txtMssv);
            ClearError(lbErrorMatKhau, txtPassword);
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ResetAllErrors();

            string mssv = txtMssv.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool hasError = false;

            if (InputValidator.IsEmpty(mssv))
            {
                ShowError(lbErrorMSSV, txtMssv, "Mã số sinh viên không được để trống!");
                if (!hasError) txtMssv.Focus(); 
                hasError = true;
            }

            if (InputValidator.IsEmpty(password))
            {
                ShowError(lbErrorMatKhau, txtPassword, "Mật khẩu không được để trống!");
                if (!hasError) txtPassword.Focus();
                hasError = true;
            }

            if (hasError) return;

            UserDTO user = userBLL.Login(mssv, password, out LoginResult result);

            switch (result)
            {
                case LoginResult.Success:
                    MainForm main = new MainForm(user);
                    main.Show();
                    this.FindForm().Hide();
                    break;

                case LoginResult.UserNotFound:
                    ShowError(lbErrorMSSV, txtMssv, "Mã số sinh viên không tồn tại!");
                    txtMssv.Focus();
                    break;

                case LoginResult.InvalidPassword:
                    ShowError(lbErrorMatKhau, txtPassword, "Mật khẩu không chính xác!");
                    txtPassword.Focus();
                    break;

                case LoginResult.AccountLocked:
                    ShowError(lbErrorMSSV, txtMssv, "Tài khoản đang bị khóa!");
                    break;
            }
        }

        private void txtMssv_KeyDown(object sender, KeyEventArgs e)
        {
            ClearError(lbErrorMSSV, txtMssv);

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    txtPassword.Focus();
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            ClearError(lbErrorMatKhau, txtPassword);

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (string.IsNullOrEmpty(txtMssv.Text))
                {
                    txtMssv.Focus();
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }

        private void linkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SwitchToRegister?.Invoke(this, EventArgs.Empty);
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SwitchToForgotPassword?.Invoke(this, EventArgs.Empty);
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox, e);
        }
    }
}