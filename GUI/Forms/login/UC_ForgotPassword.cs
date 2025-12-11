

using BLL;
using BLL.Validator;
using DTO;
using Guna.UI2.WinForms;

namespace GUI.Forms.login
{
    public partial class UC_ForgotPassword : UserControl
    {
        public event EventHandler BackToLogin;
        public event EventHandler TogglePassword;

        private UserBLL userBLL = new UserBLL();

        public UC_ForgotPassword()
        {
            InitializeComponent();


        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmailFP.Text.Trim();

            if (InputValidator.IsEmpty(email)){
                MessageBox.Show("Email không được để trống.");
                txtEmailFP.Focus();
                return;
            }

            if (!InputValidator.IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ");
                txtEmailFP.Focus();
                return;
            }
           
            if (!userBLL.IsEmailExists(email))
            {
                MessageBox.Show("Email chưa được đăng ký.");
                txtEmailFP.Focus();
                return;
            }

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

            var result = userBLL.VerifyCode(email, code);

            switch (result)
            {
                case VerifyResult.EmailNotFound:
                    MessageBox.Show("Email này chưa yêu cầu gửi mã.");
                    return; 

                case VerifyResult.InvalidCode:
                    MessageBox.Show("Mã xác thực không đúng!");
                    txtCode.Focus();
                    return; 

                case VerifyResult.Expired:
                    MessageBox.Show("Mã xác thực đã hết hạn! Vui lòng lấy mã mới.");
                    txtCode.Clear();
                    return; 

                case VerifyResult.Success:
                    break;
            }

            if (!InputValidator.IsValidPassword(newPass))
            {
                MessageBox.Show("Mật khẩu mới phải ≥ 8 ký tự, ít nhất 1 ký tự chữ hoa, thường");
                txtNewPassword.Focus();
                return;
            }

            if (userBLL.ResetPassword(email, newPass))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                 BackToLogin?.Invoke(this, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại! Có lỗi hệ thống.");
            }
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

   
        

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
                    btnSave.PerformClick();
            }
        }

      

        private void txtNewPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox, e);
        }
    }
}