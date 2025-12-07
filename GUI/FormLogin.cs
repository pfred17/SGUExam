using GUI.Forms.login;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            LoadLoginControl();
        }

        private void LoadUserControl(UserControl uc)
        {
            pnBackgroundLogin.Controls.Clear();

            pnBackgroundLogin.Controls.Add(uc);
            uc.Location = new Point(
                (pnBackgroundLogin.Width - uc.Width) / 2,
                (pnBackgroundLogin.Height - uc.Height) / 2
            );

            uc.BringToFront();
            uc.Focus();
        }

        private void LoadLoginControl()
        {
            UC_Login ucLogin = new UC_Login();
            ucLogin.SwitchToRegister += SwitchToRegister;
            ucLogin.SwitchToForgotPassword += SwitchToForgotPassword;
            ucLogin.TogglePassword += (s, e) => TogglePassword(s as Guna2TextBox);
            LoadUserControl(ucLogin);
        }
        private void LoadRegisterControl()
        {
            UC_Register ucRegister = new UC_Register();
            ucRegister.BackToLogin += SwitchToLogin;
            ucRegister.TogglePassword += (s, e) => TogglePassword(s as Guna2TextBox);
            LoadUserControl(ucRegister);
        }

        private void LoadForgotPasswordControl()
        {
            UC_ForgotPassword ucForgotPassword = new UC_ForgotPassword();
            ucForgotPassword.BackToLogin += SwitchToLogin;
            ucForgotPassword.TogglePassword += (s, e) => TogglePassword(s as Guna2TextBox);
            LoadUserControl(ucForgotPassword);
        }
        private void SwitchToForgotPassword(object? sender, EventArgs e)
        {
            LoadForgotPasswordControl();
        }

        private void SwitchToRegister(object? sender, EventArgs e)
        {
            LoadRegisterControl();
        }

        private void SwitchToLogin(object? sender, EventArgs e)
        {
            LoadLoginControl();
        }
        private void TogglePassword(Guna2TextBox txtBox)
        {
            if (txtBox.PasswordChar == '\0')
            {
                txtBox.PasswordChar = '●';
                txtBox.IconRight = Properties.Resources.icon_blinds;
            }
            else
            {
                txtBox.PasswordChar = '\0';
                txtBox.IconRight = Properties.Resources.icon_eyes;
            }
        }

        private void pnBackgroundLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
