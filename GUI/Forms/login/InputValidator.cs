using BLL;
using System.Text.RegularExpressions;

namespace GUI.Forms.login 
{
    public static class InputValidator
    {
        private static readonly string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        private static readonly string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public static bool IsEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool IsValidPassword(string password)
        {
            if (IsEmpty(password)) return false;
            return Regex.IsMatch(password, PasswordPattern);
        }

        public static bool IsValidEmail(string email)
        {
            if (IsEmpty(email)) return false;
            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool IsPasswordMatch(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }
            
    }
}