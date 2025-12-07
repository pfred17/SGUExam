

using BLL;

namespace GUI.Forms.login
{
    public partial class UC_ForgotPassword : UserControl
    {
        public event EventHandler BackToLogin;

        private UserBLL userBLL = new UserBLL();

        public UC_ForgotPassword()
        {
            InitializeComponent();


        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmailFP.Text.Trim();
            if (userBLL.SendVerificationCode(email))
                MessageBox.Show("Mã xác thực đã gửi tới email của bạn!");
            else
                MessageBox.Show("Email không hợp lệ hoặc chưa đăng ký!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string email = txtEmailFP.Text.Trim();
            string code = txtCode.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email)){
                MessageBox.Show("Email không được để trống!");
                txtEmailFP.Focus();
                return;
            }

            if (!userBLL.VerifyCode(email, code))
            {
                MessageBox.Show("Mã xác thực không đúng!");
                txtCode.Focus();
                return;
            }

            if (newPass.Length < 8)
            {
                MessageBox.Show("Mật khẩu mới phải ≥ 8 ký tự!");
                txtNewPassword.Focus();
                return;
            }

            if (userBLL.ResetPassword(email, newPass))
                MessageBox.Show("Đổi mật khẩu thành công!");
            else
                MessageBox.Show("Đổi mật khẩu thất bại!");
        }

        private void linkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void txtEmailFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendCode.PerformClick();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCode.Text.Trim()))             
                btnSave.PerformClick();
            }
        }
    }
}