using System;
using System.Text.RegularExpressions;

namespace BLL.Validator
{
    public static class InputValidator
    {

        private static readonly string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,10}$";
        private static readonly string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private static readonly string MssvPattern = @"^312\d{7}$";
        private static readonly string UsernamePattern = @"^[a-zA-Z0-9]{6,20}$";

        // Kiểm tra chuỗi rỗng hoặc chỉ chứa khoảng trắng
        public static bool IsEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }


        // Kiểm tra mssv có độ dài =10 ký tự
        public static bool IsValidMSSV(string mssv)
        {
            if(IsEmpty(mssv)) return false;
            return Regex.IsMatch(mssv, MssvPattern);
        }

        // Kiểm tra họ tên có độ dài lớn hơn 6 ký tự
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 6;
        }

        // Kiểm tra định dạng email
        public static bool IsValidEmail(string email)
        {
            if (IsEmpty(email)) return false;
            return Regex.IsMatch(email, EmailPattern);
        }

        // Kiểm tra tên đăng nhập (6 đến 20 ký tự chữ hoặc số)
        public static bool IsValidUsername(string username)
        {
            if (IsEmpty(username)) return false;
            return Regex.IsMatch(username, UsernamePattern);
        }

        // Kiểm tra mật khẩu ( 8 ->10 ký tự,ít nhất 1 ký tự hoa, 1 ký tự thường)
        public static bool IsValidPassword(string password)
        {
            if (IsEmpty(password)) return false;
            return Regex.IsMatch(password, PasswordPattern);
        }
        // kiểm tra xác nhận mật khẩu khớp với mật khẩu
        public static bool IsPasswordMatch(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        // Kiểm tra giới tính (0 hoặc 1)
        public static bool IsValidGender(int gender)
        {
            return gender == 0 || gender == 1;
        }

        // Kiểm tra trạng thái (1: hoạt động, 0: khóa)
        public static bool IsValidStatus(int status)
        {
            return status == 0 || status == 1;
        }
    }
}
