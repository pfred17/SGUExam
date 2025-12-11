using BLL;
using DAL;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using GUI.forms.nguoidung;
using GUI.Forms.nguoidung;
using Guna.UI2.WinForms;
using System.Collections.Generic;

namespace GUI.modules
{
    public partial class UC_NguoiDung : UserControl
    {

        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private readonly RoleBLL _roleBLL = new RoleBLL();
        private readonly UserBLL _userBLL = new UserBLL();

        private System.Threading.Timer? _debounceTimer;
        private const int DebounceDelay = 500;

        private int pageCurrent = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        public UC_NguoiDung(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void UC_NguoiDung_Load(object sender, EventArgs e)
        {
            loadPermission();
            loadRoleData();
            loadDataForTable();
        }

        private void loadPermission()
        {
            guna2Button1.Visible = _permissionBLL.HasPermission(_userId, 8, "Thêm");
            tableNguoiDung.Columns["detailCol"].Visible = _permissionBLL.HasPermission(_userId, 8, "Xem");
            tableNguoiDung.Columns["editCol"].Visible = _permissionBLL.HasPermission(_userId, 8, "Sửa");
            tableNguoiDung.Columns["deleteCol"].Visible = _permissionBLL.HasPermission(_userId, 8, "Xóa");
        }

        public void loadRoleData()
        {
            List<RoleDTO> roles = _roleBLL.getAllRole();

            List<RoleDTO> danhSachMoi = new List<RoleDTO>();

            // 1. Thêm mục "Tất cả" vào danh sách mới
            RoleDTO itemTatCa = new RoleDTO
            {
                MaNhomQuyen = 0,
                TenNhomQuyen = "Tất cả"
            };
            danhSachMoi.Add(itemTatCa);

            // 2. Thêm tất cả các mục từ danh sách gốc vào sau
            foreach (var role in roles)
            {
                if (role.TrangThai == 1)
                {
                    danhSachMoi.Add(role);
                }
            }

            // 3. Gán danh sách mới cho DataSource
            cbbFilter.DataSource = danhSachMoi;

            // 4. Thiết lập các thuộc tính hiển thị
            cbbFilter.DisplayMember = "TenNhomQuyen";
            cbbFilter.ValueMember = "MaNhomQuyen";

            // 5. Chọn mục đầu tiên ("Tất cả")
            cbbFilter.SelectedIndex = 0;
        }

        private void loadDataForTable()
        {

            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm...") keyword = "";

            int option = _roleBLL.GetRoleIdByName(cbbFilter.GetItemText(cbbFilter.SelectedItem));

            //totalRecords = _userBLL.GetAllUsers().Count;
            totalRecords = _userBLL.GetTotalUser(keyword, option, _userId);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (pageCurrent > totalPages) pageCurrent = totalPages;

            var users = _userBLL.GetUserPaged(pageCurrent, pageSize, keyword, option, _userId);

            tableNguoiDung.Rows.Clear();
            foreach (var user in users)
            {

                var roleDto = _roleBLL.GetRoleDTOById(user.Role);

                //if (roleDto.TrangThai == 0 || user.MSSV == _userId) continue;


                int rowIndex = tableNguoiDung.Rows.Add(
                    user.MSSV, user.HoTen,
                    user.Email, _roleBLL.GetRoleNameById(user.Role),
                    user.TrangThai == 1 ? "Hoạt động" : "Bị khóa",
                    Properties.Resources.icon_detail_user,
                    Properties.Resources.icon_edit,
                    Properties.Resources.icon_delete);

                DataGridViewRow row = tableNguoiDung.Rows[rowIndex];
                DataGridViewCell cellTrangThai = row.Cells[4]; // cột trạng thái

                if (user.TrangThai == 1)
                {
                    cellTrangThai.Style.ForeColor = System.Drawing.Color.Green;
                    cellTrangThai.Style.Font = new System.Drawing.Font(tableNguoiDung.Font, FontStyle.Bold);
                }
                else
                {
                    cellTrangThai.Style.ForeColor = System.Drawing.Color.Red;
                    cellTrangThai.Style.Font = new System.Drawing.Font(tableNguoiDung.Font, FontStyle.Bold);
                }
            }
            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            lblPage.Text = totalRecords == 0 ? "0" : $"{pageCurrent} / {totalPages}";
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            tableNguoiDung.Enabled = totalRecords > 0;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài phạm vi dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột được click
            string columnName = tableNguoiDung.Columns[e.ColumnIndex].Name;

            // Lấy ID của người dùng
            var userId = tableNguoiDung.Rows[e.RowIndex].Cells["MaNguoiDung"].Value.ToString();
            var userName = tableNguoiDung.Rows[e.RowIndex].Cells["HoVaTen"].Value.ToString();
            var status = tableNguoiDung.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

            // === Khi click vào icon SỬA ===
            if (columnName == "detailCol")
            {
                Info formSua = new Info(userId, true);

                formSua.ShowDialog();
            }

            // === Khi click vào icon SỬA ===
            if (columnName == "editCol")
            {
                Sua formSua = new Sua(userId);

                // Đăng ký lắng nghe sự kiện UserAdded từ form Them
                formSua.UserUpdated += (s, ev) =>
                {
                    loadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
                };

                formSua.ShowDialog();
            }

            // === Khi click vào icon XÓA ===
            else if (columnName == "deleteCol")
            {
                if (status == "Hoạt động")
                {
                    var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn KHÓA người dùng: {userName} không?",
                    "Xác nhận khóa",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _userBLL.LockUser(userId, 0);
                            loadDataForTable();
                            MessageBox.Show("Đã khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn MỞ KHÓA người dùng: {userName} không?",
                    "Xác nhận khóa",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _userBLL.LockUser(userId, 1);
                            loadDataForTable();
                            MessageBox.Show("Đã mở khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }



            }
        }

        // Hiển thị Cursor.Hand khi hover vào cột Sửa hoặc Xóa
        private void guna2DataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = tableNguoiDung.Columns[e.ColumnIndex].Name;

                // Nếu là cột Sửa hoặc Xóa => hiện bàn tay
                if (columnName == "editCol" || columnName == "deleteCol" || columnName == "detailCol")
                {
                    tableNguoiDung.Cursor = Cursors.Hand;
                }
                else
                {
                    tableNguoiDung.Cursor = Cursors.Default;
                } 
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Them formThem = new Them();

            // Đăng ký lắng nghe sự kiện UserAdded từ form Them
            formThem.UserAdded += (s, ev) =>
            {
                loadDataForTable(); // Gọi lại hàm load dữ liệu khi thêm thành công
            };

            formThem.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageCurrent < totalPages)
            {
                pageCurrent++;
                loadDataForTable();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_debounceTimer != null)
                _debounceTimer.Dispose();

            _debounceTimer = new System.Threading.Timer(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    pageCurrent = 1;
                    loadDataForTable();
                }));
            }, null, DebounceDelay, Timeout.Infinite);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Tìm kiếm...";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = "";
            }
        }

        private void cbbFilter_ValueChanged(object sender, EventArgs e)
        {
            loadDataForTable();
        }

        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            if (pageCurrent > 1)
            {
                pageCurrent--;
                loadDataForTable();
            }
        }

        /// <summary>
        /// XUẤT EXCEL
        /// </summary>
        private void ExportToExcel()
        {
            var users = _userBLL.GetAllUsers();
            if (users.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel File (*.xlsx)|*.xlsx";
            dialog.FileName = "DanhSachNguoiDung.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using (SpreadsheetDocument document =
                SpreadsheetDocument.Create(dialog.FileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();

                worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Users"
                };
                sheets.Append(sheet);

                // Header
                Row header = new Row();
                header.Append(
                    CreateCell("MSSV"),
                    CreateCell("Họ và tên"),
                    CreateCell("Email"),
                    CreateCell("Nhóm quyền"),
                    CreateCell("Trạng thái")
                );
                sheetData.Append(header);

                // Data
                foreach (var u in users)
                {
                    var role = _roleBLL.GetRoleNameById(u.Role);
                    Row row = new Row();
                    row.Append(
                        CreateCell(u.MSSV),
                        CreateCell(u.HoTen),
                        CreateCell(u.Email),
                        CreateCell(role),
                        CreateCell(u.TrangThai == 1 ? "Hoạt động" : "Bị khóa")
                    );
                    sheetData.Append(row);
                }

                workbookPart.Workbook.Save();
            }

            MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Cell CreateCell(string text)
        {
            return new Cell()
            {
                DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String,
                CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(text)
            };
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }


        /// <summary>
        /// NHẬP EXCEL
        /// </summary>
        private void ImportExcel()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel File (*.xlsx)|*.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(dialog.FileName, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().First();
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                // Lấy dòng tiêu đề → map vị trí cột
                Dictionary<string, int> columnIndex = new Dictionary<string, int>();
                Row headerRow = sheetData.Elements<Row>().First();
                int colIdx = 0;
                foreach (Cell cell in headerRow.Elements<Cell>())
                {
                    string header = GetCellValue(workbookPart, cell).Trim();
                    columnIndex[header] = colIdx;
                    colIdx++;
                }

                // Kiểm tra các cột bắt buộc
                string[] requiredColumns = { "MSSV", "Email", "Họ và tên", "Mật khẩu", "Giới tính", "Nhóm quyền", "Trạng thái" };

                foreach (var col in requiredColumns)
                {
                    if (!columnIndex.ContainsKey(col))
                    {
                        MessageBox.Show($"Thiếu cột bắt buộc: {col}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                HashSet<string> fileMSSV = new HashSet<string>();
                HashSet<string> fileEmail = new HashSet<string>();

                int rowNumber = 1;

                foreach (Row row in sheetData.Elements<Row>().Skip(1))
                {
                    rowNumber++;

                    var cells = row.Elements<Cell>().ToList();

                    string mssv = GetCellValue(workbookPart, cells[columnIndex["MSSV"]]).Trim();
                    string email = GetCellValue(workbookPart, cells[columnIndex["Email"]]).Trim();
                    string name = GetCellValue(workbookPart, cells[columnIndex["Họ và tên"]]).Trim();
                    string pass = GetCellValue(workbookPart, cells[columnIndex["Mật khẩu"]]).Trim();
                    string gender = GetCellValue(workbookPart, cells[columnIndex["Giới tính"]]).Trim();
                    string roleName = GetCellValue(workbookPart, cells[columnIndex["Nhóm quyền"]]).Trim();
                    string status = GetCellValue(workbookPart, cells[columnIndex["Trạng thái"]]).Trim();

                    // Validate dữ liệu
                    if (string.IsNullOrWhiteSpace(mssv))
                    {
                        ShowImportError("MSSV không được trống", rowNumber);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(email))
                    {
                        ShowImportError("Email không được trống", rowNumber);
                        return;
                    }

                    if (fileMSSV.Contains(mssv))
                    {
                        ShowImportError("MSSV bị trùng trong file", rowNumber);
                        return;
                    }

                    if (fileEmail.Contains(email))
                    {
                        ShowImportError("Email bị trùng trong file", rowNumber);
                        return;
                    }

                    if (_userBLL.IsMssvExists(mssv))
                    {
                        ShowImportError("MSSV đã tồn tại trong hệ thống", rowNumber);
                        return;
                    }

                    if (_userBLL.IsEmailExists(email))
                    {
                        ShowImportError("Email đã tồn tại trong hệ thống", rowNumber);
                        return;
                    }

                    if (gender != "0" && gender != "1")
                    {
                        ShowImportError("Giới tính chỉ được nhập 0 hoặc 1", rowNumber);
                        return;
                    }

                    if (status != "0" && status != "1")
                    {
                        ShowImportError("Trạng thái chỉ được nhập 0 hoặc 1", rowNumber);
                        return;
                    }

                    int roleId = _roleBLL.GetRoleIdByName(roleName);
                    if (roleId == -1)
                    {
                        ShowImportError($"Nhóm quyền '{roleName}' không tồn tại", rowNumber);
                        return;
                    }

                    // Add vào hash để chống trùng
                    fileMSSV.Add(mssv);
                    fileEmail.Add(email);

                    // Tạo user
                    UserDTO user = new UserDTO
                    {
                        MSSV = mssv, 
                        TenDangNhap = mssv, 
                        Email = email,
                        HoTen = name,
                        MatKhau = pass,
                        GioiTinh = Convert.ToInt32(gender),
                        Role = roleId,
                        TrangThai = Convert.ToInt32(status)
                    };

                    _userBLL.CreateNewUser(user);
                }
            }

            MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDataForTable();
        }


        private void ShowImportError(string message, int row)
        {
            MessageBox.Show($"Lỗi tại dòng {row}: {message}", "Lỗi nhập dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string GetCellValue(WorkbookPart wbPart, Cell cell)
        {
            if (cell == null || cell.CellValue == null)
                return "";

            string value = cell.CellValue.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return wbPart.SharedStringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
            }

            return value;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }
    }
}
