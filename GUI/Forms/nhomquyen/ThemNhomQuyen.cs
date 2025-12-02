using BLL;
using DAL;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text;

namespace GUI.forms.nhomquyen
{
    public partial class ThemNhomQuyen : Form
    {
        // Khai báo BLLs và Event
        public readonly RolePermissionBLL _rolePermissionBLL = new RolePermissionBLL();
        public readonly RoleBLL _roleBLL = new RoleBLL();
        public readonly PermissionBLL _permissionBLL = new PermissionBLL();
        public readonly ChucNangBLL _chucNangBLL = new ChucNangBLL();
        public event EventHandler UserAdded;

        public ThemNhomQuyen()
        {
            InitializeComponent();
            loadDataForTable();
            // Gán sự kiện cho nút Lưu (giả định tên là btnLuu)
            // Nếu bạn có nút Lưu, hãy tạo sự kiện Click cho nó.
            // this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
        }

        // Hàm tải dữ liệu (Đã sửa lỗi logic)
        public void loadDataForTable()
        {
            var listChucNang = _chucNangBLL.GetAllChucNang();
            tblThem.Rows.Clear();

            // Khuyến nghị: Tạo 2 cột ẩn/hiện:
            // Cột 0: colMaChucNang (ẩn)
            // Cột 1: colTenChucNang (hiện)
            // Các cột tiếp theo: colXem, colThem, colSua, colXoa

            foreach (var cn in listChucNang)
            {
                // Thêm Mã Chức Năng vào cột đầu tiên (để có thể lấy ID khi lưu)
                // và Tên Chức Năng vào cột thứ hai
                tblThem.Rows.Add(
                    cn.MaChucNang, // Giá trị cột 0: Mã Chức Năng (ID)
                    cn.TenChucNang // Giá trị cột 1: Tên Chức Năng (Hiển thị)
                                   // ... các cột checkbox sẽ là False mặc định
                );
            }
        }

        // --- Hàm trích xuất dữ liệu phân quyền ---
        public List<AddPermissionDTO> LayDanhSachQuyenTuDataGridView(DataGridView dgv)
        {
            List<AddPermissionDTO> danhSachQuyen = new List<AddPermissionDTO>();

            // Định nghĩa các cột Action (Quyền) cần lấy
            string[] actionColumns = { "colXem", "colThem", "colSua", "colXoa" };

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                AddPermissionDTO dto = new AddPermissionDTO();
                // Khởi tạo Dictionary để theo dõi các quyền được check
                dto.Quyen_DuocPhep = new Dictionary<int, int>();

                try
                {
                    // Lấy MÃ CHỨC NĂNG từ cột đã định nghĩa (Giả sử tên cột là "colId")
                    object maChucNangValue = row.Cells["colId"].Value;
                    if (maChucNangValue == null || maChucNangValue == DBNull.Value) continue;

                    // Chuyển đổi sang int (Đây là Mã Chức Năng)
                    dto.MaChucNang = Convert.ToInt32(maChucNangValue);

                    // 3. Duyệt qua các cột Action và lấy giá trị Checkbox
                    foreach (string colName in actionColumns)
                    {
                        object cellValue = row.Cells[colName].Value;

                        // 1. Ép kiểu an toàn sang boolean
                        bool isChecked = (cellValue != null && cellValue != DBNull.Value) && (bool)cellValue;

                        // 2. Chuyển đổi boolean sang int (1 hoặc 0)
                        int permissionValue = isChecked ? 1 : 0;

                        // CHỈ THÊM VÀO DICTIONARY NẾU QUYỀN ĐÓ ĐƯỢC CHECK (permissionValue == 1)
                        if (permissionValue == 1)
                        {
                            string actionKey = colName.Substring(3); // Trích xuất tên Action
                            int maQuyen = GetMaQuyen(actionKey); // Dùng hàm trợ giúp

                            if (maQuyen > 0)
                            {
                                dto.Quyen_DuocPhep.Add(maQuyen, permissionValue);
                            }
                        }
                    }

                    // ----------------------------------------------------
                    // 4. KIỂM TRA ĐIỀU KIỆN VÀ THÊM VÀO DANH SÁCH CUỐI CÙNG
                    // Chỉ thêm DTO vào danh sách nếu nó có ít nhất 1 quyền được check
                    if (dto.Quyen_DuocPhep.Count > 0)
                    {
                        danhSachQuyen.Add(dto);
                    }
                    // ----------------------------------------------------
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý hàng DataGridView: {ex.Message}");
                }
            }

            return danhSachQuyen;
        }
        // Hàm trợ giúp: Chuyển tên quyền sang Mã Quyền
        private int GetMaQuyen(string actionName)
        {
            switch (actionName)
            {
                case "Xem": return 1;
                case "Them": return 2;
                case "Sua": return 3;
                case "Xoa": return 4;
                default: return 0;
            }
        }

        // Hàm Format để hiển thị kết quả dễ đọc

        private string GetTenQuyen(int maQuyen)
        {
            switch (maQuyen)
            {
                case 1: return "Xem";
                case 2: return "Thêm";
                case 3: return "Sửa";
                case 4: return "Xóa";
                default: return "Khác";
            }
        }


        public string FormatDanhSachQuyen(List<AddPermissionDTO> danhSachQuyen)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- KẾT QUẢ ADDPERMISSIONDTO ---");

            foreach (var dto in danhSachQuyen)
            {
                sb.AppendLine($"[Module ID: {dto.MaChucNang}]");

                foreach (var action in dto.Quyen_DuocPhep)
                {
                    sb.AppendLine($"  - {action.Key,-5}: {action.Value}");
                }
                sb.AppendLine("------------------");
            }

            return sb.ToString();
        }

        // Hàm trợ giúp: Chuyển Mã Quyền (1, 2, 3, 4) thành Tên ("Xem", "Them",...)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView của Form (tblThem)
            List<AddPermissionDTO> danhSachQuyen = LayDanhSachQuyenTuDataGridView(tblThem);

            // Hiển thị kết quả ra MessageBox để kiểm tra
            //string ketQua = FormatDanhSachQuyen(danhSachQuyen);
            //MessageBox.Show(ketQua, "Dữ liệu AddPermissionDTO Trích Xuất", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Bắt đầu logic lưu dữ liệu vào BLL/DB tại đây
            // ...

            string ten_nhom_quyen = txtName.Text;

            if (!_rolePermissionBLL.CreateRolePermission(ten_nhom_quyen, danhSachQuyen))
            {
                MessageBox.Show("Thêm nhóm quyền thất bại", "Thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm nhóm quyền thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Gọi event báo ra ngoài là đã thêm user thành công
            UserAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}