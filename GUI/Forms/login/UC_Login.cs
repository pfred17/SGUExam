using BLL;
using DTO;
using Guna.UI2.WinForms;

namespace GUI.Forms.login
{
    public partial class UC_Login : UserControl
    {
        private UserBLL userBLL = new UserBLL();
        public event EventHandler SwitchToRegister;
        public event EventHandler SwitchToForgotPassword;
        public event EventHandler LoginSuccess;
        public event EventHandler TogglePassword;
      
        public UC_Login()
        {
            InitializeComponent();
          
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
            TogglePassword(sender as Guna2TextBox,e);
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtMssv.Text.Trim();
            string password = txtPassword.Text.Trim();

            UserDTO user = userBLL.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }

            if (user.TrangThai == 0)
            {
                MessageBox.Show("Tài khoản đã bị khóa!");
                return;
            }


            MainForm main = new MainForm(user);
            main.Show();
            this.Hide();
        }
        


        private void txtRegisterPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox,e);
        }

       
        private void txtMssv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(string.IsNullOrEmpty(txtPassword.Text))
                {
                    txtPassword.Focus();
                    return;
                }    
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMssv.Text))
                {
                    txtMssv.Focus();
                    return;
                }
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }
    }
}