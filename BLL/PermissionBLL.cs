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
        // Loại bỏ: private static readonly Dictionary<...> _permissionsCache = new(); 
        // ...

        // Hàm công khai: Tải dữ liệu mới nhất từ DB và ánh xạ sang Dictionary
        public Dictionary<int, Dictionary<string, bool>> GetPermissionsDictionary(string userId)
        {
            // KHÔNG CÓ LOGIC KIỂM TRA CACHE NỮA

            DataTable dt = _dal.GetPermissionsByUser(userId);

            // Sử dụng Dictionary để nhóm và lưu trữ quyền (Tra cứu O(1) sau khi tải)
            var userPermissions = new Dictionary<int, Dictionary<string, bool>>();

            foreach (DataRow row in dt.Rows)
            {
                int maChucNang = Convert.ToInt32(row["ma_chuc_nang"]);
                string tenQuyen = row["ten_quyen"].ToString();
                bool duocPhep = Convert.ToInt32(row["duoc_phep"]) == 1;

                if (!userPermissions.ContainsKey(maChucNang))
                {
                    userPermissions[maChucNang] = new Dictionary<string, bool>();
                }

                // Lưu quyền (Key: "Xem", "Thêm",...) và trạng thái (Value: true/false)
                userPermissions[maChucNang][tenQuyen] = duocPhep;
            }

            // KHÔNG LƯU VÀO CACHE NỮA
            return userPermissions;
        }

        // === Hàm Kiểm tra Quyền (HasPermission) đã được điều chỉnh ===
        public bool HasPermission(string userId, int maChucNang, string quyen)
        {
            // 1. Tải và ánh xạ Quyền (LUÔN TRUY VẤN DB)
            var permissions = GetPermissionsDictionary(userId);

            // 2. Tra cứu Quyền trong cấu trúc Dictionary
            if (permissions.TryGetValue(maChucNang, out var modulePermissions))
            {
                // Tra cứu theo Tên Quyền (Không phân biệt chữ hoa/chữ thường)
                var matchingKey = modulePermissions.Keys
                                    .FirstOrDefault(k => k.Equals(quyen, StringComparison.OrdinalIgnoreCase));

                if (matchingKey != null && modulePermissions.ContainsKey(matchingKey))
                {
                    // Trả về giá trị DuocPhep (true/false)
                    return modulePermissions[matchingKey];
                }
            }

            return false;
        }

        // === Hàm GetUserPermissions giữ nguyên (vẫn gọi DB mỗi lần) ===
        public List<PermissionDTO> GetUserPermissions(string userId)
        {
            // ... (Giữ nguyên, vẫn gọi _dal.GetPermissionsByUser(userId))
            DataTable dt = _dal.GetPermissionsByUser(userId);
            var list = new List<PermissionDTO>();
            // ... (Logic ánh xạ DataRow sang List<PermissionDTO> giữ nguyên) ...
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
        }
    }
}
