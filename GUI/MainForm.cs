using BLL;
using DTO;
using GUI.modules;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;

namespace GUI
{
    public partial class MainForm : Form
    {
        private UserDTO _userDTO;
        private readonly string _userId;
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();
        private List<PermissionDTO> _permissions;
        private List<ModuleItem> modules;
        private Guna2Button currentButton;
        private Guna2Panel pnlDropdown;

        public MainForm(UserDTO user)
        {
            InitializeComponent();
            _userDTO = user;
            _userId = user.MSSV;

            modules = InitializeModules();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //  Lấy toàn bộ quyền của user
            _permissions = _permissionBLL.GetUserPermissions(_userId);
            //{
            //    "Môn học": { "Xem": true, "Thêm": true, "Sửa": false, "Xóa": false },
            //    "Người dùng": { "Xem": true, "Thêm": false, "Sửa": false, "Xóa": false }
            //}

            // Header
            GenerateHeader();

            // Sidebar
            GenerateSidebarModules();

            // Dropdown
            InitDropdown();
        }

        private List<ModuleItem> InitializeModules()
        {
            return new List<ModuleItem>
            {
                new ModuleItem{ Id=0, Name="TongQuan", DisplayName="Tổng quan", Group="HỆ THỐNG", Icon=Properties.Resources.icon_tongquan, UserControlType=typeof(UC_TongQuan) },
                new ModuleItem{ Id=1, Name="NhomHocPhan", DisplayName="Nhóm học phần", Group="QUẢN LÝ", Icon=Properties.Resources.icon_nhomhocphan, UserControlType=typeof(UC_NhomHocPhan) },
                new ModuleItem{ Id=2, Name="CauHoi", DisplayName="Câu hỏi", Group="QUẢN LÝ", Icon=Properties.Resources.icon_cauhoi, UserControlType=typeof(UC_CauHoi) },
                new ModuleItem{ Id=3, Name="MonHoc", DisplayName="Môn học", Group="QUẢN LÝ", Icon=Properties.Resources.icon_monhoc, UserControlType=typeof(UC_MonHoc) },
                new ModuleItem{ Id=4, Name="PhanCong", DisplayName="Phân công", Group="QUẢN LÝ", Icon=Properties.Resources.icon_phancong, UserControlType=typeof(UC_PhanCong) },
                new ModuleItem{ Id=5, Name="DeKiemTra", DisplayName="Đề kiểm tra", Group="QUẢN LÝ", Icon=Properties.Resources.icon_dekiemtra, UserControlType=typeof(UC_KiemTra) },
                new ModuleItem{ Id=6, Name="DiemDanh", DisplayName="Điểm danh", Group="QUẢN LÝ", Icon=Properties.Resources.icon_diemdanh, UserControlType=typeof(UC_DiemDanh) },
                new ModuleItem{ Id=7, Name="NhomQuyen", DisplayName="Nhóm quyền", Group="QUẢN TRỊ", Icon=Properties.Resources.icon_phanquyencaidat, UserControlType=typeof(UC_NhomQuyen) },
                new ModuleItem{ Id=8, Name="NguoiDung", DisplayName="Người dùng", Group="QUẢN TRỊ", Icon=Properties.Resources.icon_nhomnguoidung, UserControlType=typeof(UC_NguoiDung) }
            };
        }

        private void GenerateSidebarModules()
        {
            panelSidebar.Controls.Clear();

            // === Nút Tổng quan ===
            var tongQuan = modules.First(m => m.Name == "TongQuan");
            var btnTongQuan = CreateSidebarButton("Tổng quan", tongQuan.Icon, 20);
            btnTongQuan.Tag = tongQuan;
            btnTongQuan.Click += ModuleButton_Click;
            panelSidebar.Controls.Add(btnTongQuan);

            currentButton = btnTongQuan;
            ActivateButton(btnTongQuan);
            LoadModule(typeof(UC_TongQuan));


            var lblRole = new Label
            {
                Text = _userDTO.Role.ToUpper(),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0, 10, 0, 0),
                Location = new Point(28, 80)
            };
            panelSidebar.Controls.Add(lblRole);

            // === Các module khác ===
            int top = 120;
            foreach (var mod in GetAccessibleModules().Where(m => m.Name != "TongQuan"))
            {
                var btn = CreateSidebarButton(mod.DisplayName, mod.Icon, top);
                btn.Tag = mod;
                btn.Click += ModuleButton_Click;
                panelSidebar.Controls.Add(btn);
                top += 55;
            }
        }


        private void GenerateHeader()
        {
            // === Label tiêu đề ===
            Label lblTitle = new Label
            {
                Text = "SGU Exam",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 15)
            };
            panelHeader.Controls.Add(lblTitle);

            // === Avatar ===
            var picAvatar = new Guna2CirclePictureBox
            {
                Size = new Size(40, 40),
                Image = Properties.Resources.avatar_default,
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                Margin = new Padding(10, 0, 0, 0)
            };

            // === Tên người dùng ===
            var lblUser = new Label
            {
                Text = _userDTO.HoTen,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0, 10, 0, 0),
                MaximumSize = new Size(200, 0), // tránh quá dài
            };

            // === Gộp label + avatar vào FlowLayoutPanel ===
            FlowLayoutPanel userPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 15, 15, 0),
                WrapContents = false,
                BackColor = Color.Transparent // cùng màu header
            };

            userPanel.Controls.Add(lblUser);
            userPanel.Controls.Add(picAvatar);

            // === Xử lý click avatar mở dropdown ===
            picAvatar.Click += (s, e) =>
            {
                pnlDropdown.Visible = !pnlDropdown.Visible;
                if (pnlDropdown.Visible)
                {
                    var screenPoint = panelHeader.PointToScreen(picAvatar.Location);
                    var formPoint = this.PointToClient(screenPoint);
                    pnlDropdown.Location = new Point(
                        1200,
                        formPoint.Y + picAvatar.Height + 5
                    );
                    pnlDropdown.BringToFront();
                }
            };

            panelHeader.Controls.Add(userPanel);
        }

        // Dropdown
        private void InitDropdown()
        {
            pnlDropdown = new Guna2Panel
            {
                Size = new Size(150, 105),
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderColor = Color.Transparent,
                BorderThickness = 2,
                BorderRadius = 5,
                Padding = new Padding(5),
                Visible = false,
                ShadowDecoration = { Depth = 15 }
            };

            var btnProfile = new Guna2Button
            {
                Text = "Hồ sơ",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Image = Properties.Resources.icon_user,
                ImageAlign = HorizontalAlignment.Left,
                TextAlign = HorizontalAlignment.Left,
                ImageSize = new Size(18, 18),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 5),
                BorderRadius = 4,
                FillColor = Color.White,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
                HoverState = {
                    FillColor = Color.FromArgb(116, 185, 255),
                    ForeColor = Color.White
                }
            };

            var btnLogout = new Guna2Button
            {
                Text = "Đăng xuất",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Image = Properties.Resources.icon_logout,
                ImageAlign = HorizontalAlignment.Left,
                TextAlign = HorizontalAlignment.Left,
                ImageSize = new Size(18, 18),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 5),
                BorderRadius = 4,
                FillColor = Color.White,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
                HoverState = {
                    FillColor = Color.FromArgb(116, 185, 255),
                    ForeColor = Color.White
                }
            };

            var spacing = new Guna2Panel
            {
                Height = 5,
                Dock = DockStyle.Top,
                FillColor = Color.White
            };

            btnLogout.Click += (s, e) => handleLogout();

            pnlDropdown.Controls.Add(btnLogout);
            pnlDropdown.Controls.Add(spacing);
            pnlDropdown.Controls.Add(btnProfile);

            this.Controls.Add(pnlDropdown);
        }
        private void ModuleButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is ModuleItem module)
            {
                ActivateButton(btn);
                LoadModule(module.UserControlType);
            }
        }

        // Xử lý đăng xuất
        private void handleLogout()
        {
            var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn đăng xuất không?",
                    "Xác nhận đăng xuất",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Mở lại form đăng nhập
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }

        // Kích hoạt button được chọn
        private void ActivateButton(Guna2Button btn)
        {
            // Reset lại button cũ
            if (currentButton != null)
            {
                currentButton.FillColor = Color.Transparent;
                currentButton.ForeColor = Color.FromArgb(99, 110, 114);
            }

            // Đặt button mới làm active
            currentButton = btn;
            btn.FillColor = Color.FromArgb(116, 185, 255);
            btn.ForeColor = Color.White;
        }

        // Tải UserControl tương ứng vào panel chính
        private void LoadModule(Type ucType)
        {
            panelMain.Controls.Clear();
            UserControl uc = (UserControl)Activator.CreateInstance(ucType, _userId); // truyền userId
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private IEnumerable<ModuleItem> GetAccessibleModules()
        {
            var accessibleNames = _permissions
                .GroupBy(p => p.MaChucNang)
                .Where(g => g.Any(p => p.DuocPhep))
                .Select(g => g.Key)
                .ToList();

            return modules.Where(m => accessibleNames.Contains(m.Id));
        }

        // Tạo button sidebar
        private Guna2Button CreateSidebarButton(string text, Image icon, int top)
        {
            return new Guna2Button
            {
                Text = "  " + text,
                Image = icon,
                ImageAlign = HorizontalAlignment.Left,
                TextAlign = HorizontalAlignment.Left,
                ImageSize = new Size(18, 18),
                Height = 40,
                Width = 190,
                BorderRadius = 2,
                FillColor = Color.Transparent,
                HoverState = {
                FillColor = Color.FromArgb(116, 185, 255),
                ForeColor = Color.White
            },
                ForeColor = Color.FromArgb(99, 110, 114),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(28, top),
                Cursor = Cursors.Hand,
            };
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
