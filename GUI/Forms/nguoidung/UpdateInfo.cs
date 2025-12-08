using BLL;
using BLL.Validator;
using DTO;

namespace GUI.Forms.nguoidung
{
    public partial class UpdateInfo : Form
    {
        private UserBLL userBLL = new UserBLL();
        private UserDTO currentUser;
        public UpdateInfo(UserDTO user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(currentUser == null)
            {
                MessageBox.Show("Lỗi người dùng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string HoTen = txtHoTen.Text.Trim();
            string MatKhau = txtPassword.Text.Trim();
            string Email = txtEmail.Text.Trim();

            string GioiTinh = null;
            if (radioNam.Checked)
                GioiTinh = "Nam";
            else if (radioNu.Checked)
                GioiTinh = "Nữ";
            if (InputValidator.IsEmpty(HoTen)) { 
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return;
            }
            if (!InputValidator.IsValidName(HoTen))
            {
                MessageBox.Show("Họ tên phải có độ dài lớn hơn 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return;
            }
            if (InputValidator.IsEmpty(MatKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (!InputValidator.IsValidPassword(MatKhau))
            {
                MessageBox.Show("Mật khẩu phải có độ dài từ 6 ->8 ký tự, 1 ký tự hoa , 1 ký tự thường !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (InputValidator.IsEmpty(Email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (!InputValidator.IsValidEmail(Email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (GioiTinh == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserDTO newUser = userBLL.GetUserByMSSV(currentUser.MSSV);

            newUser.HoTen = HoTen;
            newUser.MatKhau = MatKhau;
            newUser.Email = Email;
            newUser.GioiTinh = GioiTinh == "Nam" ? 1 : 0;

            if (userBLL.UpdateInfo(newUser))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
