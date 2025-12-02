using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhanCongBLL
    { 
        private readonly PhanCongDAL _dal = new PhanCongDAL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        public List<PhanCongDTO> getAllPhanCong()
        {
            return _dal.getAllPhanCong();
        }
        public long AddPhanCong(PhanCongDTO phanCong)
        {
            return _dal.AddPhanCong(phanCong);
        }
        public bool UpdatePhanCong(PhanCongDTO phanCong)
        {
            if (IsPhanCongReferenced(phanCong.MaPhanCong))
            {
                return _dal.UpdateStatus(phanCong.MaPhanCong, phanCong.TrangThai);
            }
            else
            {
                return _dal.UpdatePhanCong(phanCong);
            }
        }
        public int GetStatus(long maPhanCong)
        {
            return _dal.GetStatus(maPhanCong);  
        }
        public bool UpdateStatus(long maPhanCong, int trangThai)
        {
            return _dal.UpdateStatus(maPhanCong, trangThai);
        }
        public bool DeletePhanCong(long maPhanCong)
        {
            return _dal.DeletePhanCong(maPhanCong);
        }
        public bool IsPhanCongReferenced(long maPhanCong)
        {
            return _dal.IsPhanCongReferenced(maPhanCong);
        }
        public PhanCongDTO? GetPhanCongById(long  maPhanCong)
        {
            return _dal.GetPhanCongById(maPhanCong);
        }
        public List<PhanCongDTO> getPhanCongPaged(int page, int pageSize, string? keyword = null)
        {
            return _dal.GetPhanCongPaged(page, pageSize, keyword);
        }

        public int GetTotalPhanCong(string? keyword = null)
        {
            return _dal.GetTotalPhanCong(keyword);
        }
        public MonHocDTO GetMonHocById(long maMonHoc)
        {
            return _monHocBLL.GetMonHocById(maMonHoc);
        }
        public List<MonHocDTO> GetAllMonHocByStatus(int? trangThai = null)
        {
            return _monHocBLL.GetAllMonHocByStatus(trangThai);
        }
        public List<MonHocDTO> GetMonHocForSelection(int page, int pageSize, string? keyword = null)
        {
            return _monHocBLL.GetMonHocPaged(page, pageSize, keyword, 1);
        }
        public int GetTotalMonHocForSelection(string? keyword = null)
        {
            return _monHocBLL.GetTotalMonHoc(keyword, 1);
        }
        public List<UserDTO> GetAllUserByRoleExcluding(string userId)
        {
            return _userBLL.GetAllUserByRoleExcluding(userId);
        }
        public UserDTO GetUserById(string userId)
        {
            return _userBLL.GetUserById(userId);
        }
        public List<UserDTO> GetUSerForSelection(int page, int pageSize, string userId, string? keyword = null)
        {
            return _userBLL.GetUserPaged(page, pageSize, userId, keyword, 1);
        }
        public int GetTotalUserForSelection(string userId, string? keyword = null)
        {
            return _userBLL.GetTotalUser(userId, keyword, 1);
               
        }
    }
}
