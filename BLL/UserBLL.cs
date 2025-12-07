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

        public UserDTO Login(string mssv, string password, out LoginResult result)
        {
            UserDTO user = dal.GetUserByMSSV(mssv);

            if (user == null)
            {
                result = LoginResult.UserNotFound;
                return null;
            }

            if (user.MatKhau != password)
            {
                result = LoginResult.InvalidPassword;
                return null;
            }

            if (user.TrangThai == 0)
            {
                result = LoginResult.AccountLocked;
                return null;
            }

            result = LoginResult.Success;
            return user;
        }
        
        public List<UserDTO> GetAllUsers()
        {
            return dal.getAllUsers();
        }
        public UserDTO GetUserById(string userId)
        {
            return dal.GetUserById(userId);
        }
        public List<UserDTO> GetAllAssignableUsers()
        {
            return dal.GetAllAssignableUsers();
        }
        public List<UserDTO> GetUserPaged(int page, int pageSize, string? keyword = null, int? option = 0)
        {
            return dal.GetUserPaged(page, pageSize, keyword, option);
        }
        //public int GetTotalUser(string? userId, string? keyword = null, int? trangThai = null)
        //{
        //    return dal.GetTotalUser(userId, keyword, trangThai);
        //}
        public List<UserDTO> GetAssignableUsersPaged(int page, int pageSize, string? userId, string? keyword = null)
        {
            return dal.GetAssignableUsersPaged(page, pageSize, userId, keyword);
        }
        public int GetTotalAssignableUsers(string? userId, string? keyword = null)
        {
            return dal.GetTotalAssignableUsers(userId, keyword);
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

        public UserDTO Register(string username, string hoten, string password, string email)
        {
            return dal.CreateUser(username, hoten, password, email);
        }

        public UserDTO GetUserByMSSV(string mssv, bool includeInactive = false)
        {
            return dal.GetUserByMSSV(mssv, includeInactive);
        }
        public bool IsEmailExists(string email)
        {
            return dal.EmailExists(email);
        }
        public bool IsMssvExists(string username)
        {
            return dal.MssvExists(username);
        }
    }
}