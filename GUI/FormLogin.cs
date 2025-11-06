using BLL;
using DTO;

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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            UserDTO user = userBLL.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }

            // Chuyển qua form chính và truyền role
            MainForm main = new MainForm(user);
            main.Show();
            this.Hide();
        }
    }
}
