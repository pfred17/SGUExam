using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        private UserBLL userBLL = new UserBLL();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string username = txtMssv.Text.Trim();
            //string password = txtPassword.Text.Trim();
            string username = "admin";
            string password = "admin";

            UserDTO user = userBLL.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }

            // Chuyển qua form chính 
            MainForm main = new MainForm(user);
            main.Show();
            this.Hide();
        }


        private void TogglePassword(Guna2TextBox txtBox)
        {
            if (txtBox.PasswordChar == '\0') // hiện text
            {
                txtBox.PasswordChar = '•';   // ẩn
                txtBox.IconRight = Properties.Resources.icon_blinds;
            }
            else
            {
                txtBox.PasswordChar = '\0';  // hiện
                txtBox.IconRight = Properties.Resources.icon_eyes;
            }
        }



        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox);
        }

        private void txtRegisterPassword_IconRightClick(object sender, EventArgs e)
        {
            TogglePassword(sender as Guna2TextBox);
        }


        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnLogin.Visible = true;
            pnRegister.Visible = false;
        }

        private void linkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnRegister.Visible = true;
            pnLogin.Visible = false;
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

            UserDTO user = userBLL.Register(mssv, hoten, password, email);

            if (user != null)
            {
                MessageBox.Show("Đăng ký thành công!");
                pnRegister.Visible = false;
                pnLogin.Visible = true;
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }

        }

        private void linkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnLogin.Visible = true;
            pnLogin.BringToFront();
            pnRegainPassword.Visible = false;
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnRegainPassword.Visible = true;
            pnRegainPassword.BringToFront();
            pnLogin.Visible = false;
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

        private void txtMssv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
