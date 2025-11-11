using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class PermissionBLL
    {
        private readonly PermissionDAL _dal = new PermissionDAL();

        // Lấy danh sách quyền của 1 user theo id
        public List<PermissionDTO> GetUserPermissions(string userId)
        {
            DataTable dt = _dal.GetPermissionsByUser(userId);
            var list = new List<PermissionDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PermissionDTO
                {
                    MaChucNang = Convert.ToInt32(row["ma_chuc_nang"]),
                    Quyen = row["ten_quyen"].ToString(),
                    DuocPhep = Convert.ToInt32(row["duoc_phep"]) == 1
                });
            }

            return list;
            // Kết quả mẫu
            //{
            //    1: { "Xem": true, "Thêm": true, "Sửa": false, "Xóa": false },
            //    3: { "Xem": true, "Thêm": false, "Sửa": false, "Xóa": false },
            //    5: { "Xem": true, "Thêm": false, "Sửa": false, "Xóa": false }
            //}
        }

        // Kiểm tra người dùng có quyền thao tác không
        public bool HasPermission(string userId, int  maChucNang, string quyen)
        {
            var permissions = GetUserPermissions(userId);

            foreach (var p in permissions)
            {
                if (p.MaChucNang == maChucNang
                    && p.Quyen.Equals(quyen, StringComparison.OrdinalIgnoreCase)
                    && p.DuocPhep)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
