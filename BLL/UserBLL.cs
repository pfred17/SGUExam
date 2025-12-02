using DAL;
using DTO;
using System.Text.RegularExpressions;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();
        

        private EmailService emailService = new EmailService();
        private Dictionary<string, string> codeStorage = new Dictionary<string, string>();

        public bool SendVerificationCode(string email)
        {
            //string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            //if (!Regex.IsMatch(email, pattern)) return false;
            //if (!dal.EmailExists(email)) return false;

            string code = new Random().Next(100000, 999999).ToString();
            emailService.SendVerificationCode(email, code);

            if (codeStorage.ContainsKey(email)) codeStorage[email] = code;
            else codeStorage.Add(email, code);

            return true;
        }

        public bool VerifyCode(string email, string code)
        {
            return codeStorage.ContainsKey(email) && codeStorage[email] == code;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            return dal.UpdatePassword(email, newPassword);
        }

        public UserDTO Login(string username, string password)
        {
            return dal.CheckLogin(username, password);
        }
        public List<UserDTO> GetAllUsers()
        {
            return dal.getAllUsers();
        }
        public UserDTO GetUserById(string userId)
        {
            return dal.GetUserById(userId);
        }
        public List<UserDTO> GetAllUserByRole()
        {
            return dal.GetAllUserByRole();
        }
        public List<UserDTO> GetAllUserByRoleExcluding(string userId)
        {
            var allUsers = dal.GetAllUserByRole();
                
            return allUsers.Where(u => u.MSSV != userId).ToList();
        }
        public List<UserDTO> GetUserPaged(int page, int pageSize, string? keyword = null, int? option = 0)
        {
            return dal.GetUserPaged(page, pageSize, keyword, option);
        }
        public int GetTotalUser(string? keyword = null)
        {
            return dal.GetTotalUser(keyword);
        }
        public bool CreateNewUser(UserDTO userDTO)
        {
            bool isCreated = dal.CreateNewUser(userDTO);
            return isCreated;
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            return dal.UpdateUser(userDTO);
        }

        public bool LockUser(string userId, int status = 0)
        {
            return dal.LockUser(userId, status);
        }

        public UserDTO Register(string username,string hoten, string password, string email)
        {
            return dal.CreateUser(username, hoten, password, email);
        }

        public UserDTO GetUserByMSSV(string mssv, bool includeInactive = false)
        {
            return dal.GetUserByMSSV(mssv, includeInactive);
        }
    }
}
