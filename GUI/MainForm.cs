using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GUI.modules;

namespace GUI
{
    public partial class MainForm : Form
    {
        private string _role;
        private Dictionary<string, List<string>> roleModules;
        private List<ModuleItem> modules;
        private Guna2Button currentButton; // <-- Button đang được chọn

        public MainForm(string role)
        {
            InitializeComponent();
            _role = role;

            // Phân quyền theo role
            roleModules = new Dictionary<string, List<string>>
            {
                { "Quản trị", new List<string>{ "TongQuan", "NhomHocPhan", "CauHoi", "MonHoc", "DeKiemTra", "PhanCong", "DiemDanh", "NhomQuyen", "NguoiDung" } },
                { "Giảng viên", new List<string>{ "NhomHocPhan", "CauHoi", "DeKiemTra" } },
                { "Sinh viên",  new List<string>{ "NhomHocPhan", "DeKiemTra" } }
            };

            // Danh sách module đầy đủ
            modules = new List<ModuleItem>
            {
                new ModuleItem{ Name="NhomHocPhan", DisplayName="Nhóm học phần", Group="QUẢN LÝ", Icon=Properties.Resources.monhoc_dark, IconActive=Properties.Resources.monhoc_white, UserControlType=typeof(UC_NhomHocPhan) },
                new ModuleItem{ Name="CauHoi", DisplayName="Câu hỏi", Group="QUẢN LÝ", Icon=Properties.Resources.cauhoi_dark, IconActive=Properties.Resources.cauhoi_white,UserControlType=typeof(UC_CauHoi) },
                new ModuleItem{ Name="MonHoc", DisplayName="Môn học", Group="QUẢN LÝ", Icon=Properties.Resources.monhoc_dark,IconActive=Properties.Resources.monhoc_white, UserControlType=typeof(UC_MonHoc) },
                new ModuleItem{ Name="DeKiemTra", DisplayName="Đề kiểm tra", Group="QUẢN LÝ", Icon=Properties.Resources.kiemtra_dark, IconActive=Properties.Resources.kiemtra_white, UserControlType=typeof(UC_KiemTra) },
                new ModuleItem{ Name="PhanCong", DisplayName="Phân công", Group="QUẢN LÝ", Icon=Properties.Resources.phancong_dark, IconActive=Properties.Resources.phancong_white, UserControlType=typeof(UC_PhanCong) },
                new ModuleItem{ Name="DiemDanh", DisplayName="Điểm danh", Group="QUẢN LÝ", Icon=Properties.Resources.diemdanh_dark, IconActive=Properties.Resources.diemdanh_white, UserControlType=typeof(UC_DiemDanh) },
                new ModuleItem{ Name="NhomQuyen", DisplayName="Nhóm quyền", Group="QUẢN TRỊ", Icon=Properties.Resources.phanquyen_dark, IconActive=Properties.Resources.phanquyen_white, UserControlType=typeof(UC_NhomQuyen) },
                new ModuleItem{ Name="NguoiDung", DisplayName="Người dùng", Group="QUẢN TRỊ", Icon=Properties.Resources.nguoidung_dark, IconActive=Properties.Resources.nguoidung_white, UserControlType=typeof(UC_NguoiDung) }
            };
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GenerateSidebarModules();
        }

        private void GenerateSidebarModules()
        {
            panelSidebar.Controls.Clear();

            // Header logo + title
            var lblTitle = new Label
            {
                Text = "SGU Exam",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                AutoSize = true,
                Location = new Point(28, 15)
            };
            panelSidebar.Controls.Add(lblTitle);

            var lblSub = new Label
            {
                Text = "Hệ thống thi trực tuyến",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(20, 55)
            };
            panelSidebar.Controls.Add(lblSub);

            // === Nút Tổng quan ===
            Guna2Button btnTongQuan = new Guna2Button
            {
                Text = "Tổng quan",
                Image = Properties.Resources.tongquan_dark,
                ImageAlign = HorizontalAlignment.Left,
                TextAlign = HorizontalAlignment.Left,
                ImageSize = new Size(18, 18),
                Height = 40,
                Width = 190,
                BorderRadius = 2,
                FillColor = Color.FromArgb(116, 185, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(15, 100),
                Cursor = Cursors.Hand
            };

            currentButton = btnTongQuan;
            panelSidebar.Controls.Add(btnTongQuan);
            ActivateButton(btnTongQuan);
            LoadModule(typeof(UC_TongQuan));
            btnTongQuan.Click += (s, e) =>
            {
                ActivateButton(btnTongQuan);
                LoadModule(typeof(UC_TongQuan));
            };

            // === Lấy module theo role ===
            int top = 160;
            var allowedModules = modules
                .Where(m => roleModules[_role].Contains(m.Name))
                .GroupBy(m => m.Group)
                .ToList();

            foreach (var group in allowedModules)
            {
                Label lblGroup = new Label
                {
                    Text = group.Key,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    Location = new Point(20, top),
                    AutoSize = true
                };
                panelSidebar.Controls.Add(lblGroup);
                top += 25;

                foreach (var mod in group)
                {
                    Guna2Button btn = new Guna2Button
                    {
                        Text = "  " + mod.DisplayName,
                        Image = mod.Icon,
                        ImageAlign = HorizontalAlignment.Left,
                        TextAlign = HorizontalAlignment.Left,
                        ImageSize = new Size(18, 18),
                        Height = 40,
                        Width = 190,
                        BorderRadius = 2,
                        FillColor = Color.Transparent,
                        HoverState = {
                            FillColor = Color.FromArgb(116, 185, 255),
                            ForeColor = Color.White,
                            Image = mod.IconActive
                        },
                        ForeColor = Color.FromArgb(99, 110, 114),
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Location = new Point(15, top),
                        Tag = mod,
                        Cursor = Cursors.Hand
                    };

                    btn.Click += ModuleButton_Click;
                    panelSidebar.Controls.Add(btn);
                    top += 55;
                }

                top += 10;
            }
        }

        private void ModuleButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is ModuleItem module)
            {
                ActivateButton(btn);
                LoadModule(module.UserControlType);
            }
        }

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

        private void LoadModule(Type ucType)
        {
            panelMain.Controls.Clear();
            UserControl uc = (UserControl)Activator.CreateInstance(ucType);
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
