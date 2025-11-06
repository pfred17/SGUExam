using System;
using System.Text.RegularExpressions;

namespace BLL.Validator
{
    public static class InputValidator
    {
        // Kiểm tra họ tên có độ dài lớn hơn 6 ký tự
        public static bool IsValidMSSV(string mssv)
        {
            return !string.IsNullOrWhiteSpace(mssv) && mssv.Length == 10;
        }

        // Kiểm tra họ tên có độ dài lớn hơn 6 ký tự
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 6;
        }

        // Kiểm tra định dạng email
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // Kiểm tra tên đăng nhập (ít nhất 6 ký tự)
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 6)
                return false;

            return true;
        }

        // Kiểm tra mật khẩu (ít nhất 6 ký tự)
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                return false;

            return true;
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
