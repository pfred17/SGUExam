using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public UserDTO Login(string username, string password)
        {
            return dal.CheckLogin(username, password);
        }

        public List<UserDTO> GetAllUsers()
        {
            return dal.getAllUsers();
        }
    }
}
