using DAL;
using DTO;
using System.Text.RegularExpressions;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();
        private static Random _random = new Random();
        private EmailService emailService = new EmailService();
        Dictionary<string, VerificationSession> codeStorage = new Dictionary<string, VerificationSession>();

        public bool SendVerificationCode(string email)
        {
           
            string code = _random.Next(100000, 999999).ToString();

            var session = new VerificationSession
            {
                Code = code,
                // 1 phút hết hạn
                ExpiryTime = DateTime.Now.AddMinutes(1) 
            };

            codeStorage[email] = session;

            try
            {
                emailService.SendVerificationCode(email, code);
                return true;
            }
            catch (Exception ex)
            {
               
                codeStorage.Remove(email);
                return false; 
            }

            return true;
        }

        public VerifyResult VerifyCode(string email, string inputCode)
        {
            
            if (!codeStorage.ContainsKey(email))
            {
                return VerifyResult.EmailNotFound; 
            }

           
            var session = codeStorage[email];

          
            if (session.Code != inputCode)
            {
                return VerifyResult.InvalidCode; 
            }

         
            if (DateTime.Now > session.ExpiryTime)
            {
                codeStorage.Remove(email); 
                return VerifyResult.Expired;
            }
        
            return VerifyResult.Success;
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
        public UserDTO GetUserByMSSV(string mssv, bool includeInactive = false)
        {
            return dal.GetUserByMSSV(mssv, includeInactive);
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
        public List<UserDTO> GetUserPaged(int page, int pageSize, string? keyword = null, int? option = 0, string? userId = "")
        {
            return dal.GetUserPaged(page, pageSize, keyword, option, userId);
        }

        public int GetTotalUser(string? keyword = null, int? option = 0, string? userId = "")
        {
            return dal.GetTotalUsers(keyword, option, userId);
        }
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
        public bool UpdateInfo(UserDTO userDTO)
        {
            return dal.UpdateInfo(userDTO);
        }
        public bool LockUser(string userId, int status = 0)
        {
            return dal.LockUser(userId, status);
        }

        public UserDTO Register(string username, string hoten, string password, string email)
        {
            return dal.CreateUser(username, hoten, password, email);
        }

        public bool QuyenThamGia(string maNd)
        {
            return dal.QuyenThamGia(maNd);
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