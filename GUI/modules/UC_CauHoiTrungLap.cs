using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_CauHoiTrungLap : UserControl
    {
        private readonly CauHoiBLL _bll = new CauHoiBLL();
        public UC_CauHoiTrungLap()
        {
            InitializeComponent();
        }
        // load du lieu 
        public void UC_CauHoiTrungLap_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            LoadComboBox(); // load du lieu mon hc vao combobox 
        }
        public void LoadComboBox()
        {
            cboLoaiCauHoi.Items.Add("Tất cả");
            cboLoaiCauHoi.SelectedIndex = 0;
            // load mon hoc
            cboMonHoc.Items.Add("Tất cả môn học");
            var dsMon = new MonHocBLL().GetAllMonHoc();
            foreach (var mon in dsMon)
            {
                cboMonHoc.Items.Add(mon.TenMH);
                cboMonHoc.SelectedIndex = 0;
            }
        }

        public void LoadDuLieu()
        {
            flpMain.Controls.Clear();
            var (nhomTrung, cauTrung, cauDuyNhat) = _bll.LayThongKeTrungLap();
            var dsNhom = _bll.LayCauHoiTrungLap();
            // cap nhat thong ke 
            lblThongKe.Text = $"{nhomTrung} nhóm trùng lặp + {cauTrung} câu trùng + {cauDuyNhat} câu duy nhất";

            if (nhomTrung == 0)
            {
                var lbl = new Label
                {
                    Text = "Tuyệt vời! Không có câu hỏi nào bị trùng lặp.",
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    ForeColor = Color.ForestGreen,
                    Margin = new Padding(30, 50, 0, 20),
                    AutoSize = true
                };
                flpMain.Controls.Add(lbl);
                return;
            }
            foreach (var nhom in dsNhom)
            {
                flpMain.Controls.Add(TaoNhomTrungLap(nhom));
            }
        }

        public Control TaoNhomTrungLap(CauHoiTrungLapDTO nhom)
        {
            // Header
            var header = new Panel
            {
                Height = 60,
                BackColor = Color.FromArgb(210, 170, 130),
                Margin = new Padding(20, 15, 20, 0),
                Cursor = Cursors.Hand,
                Tag = false // false = đang thu gọn
            };

            var lblSoLuong = new Label
            {
                Text = $"{nhom.SoLuong} câu hỏi giống nhau",
                Location = new Point(25, 20),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                AutoSize = true
            };

            var btnToggle = new Button
            {
                Text = "Down Arrow",
                Size = new Size(45, 45),
                Location = new Point(header.Width - 100, 8),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 18F),
                ForeColor = Color.Maroon,
                BackColor = Color.Transparent
            };

            var tagTrungLap = new Label
            {
                Text = "Trùng lặp",
                BackColor = Color.Crimson,
                ForeColor = Color.White,
                Padding = new Padding(12, 6, 12, 6),
                Location = new Point(header.Width - 220, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            header.Controls.AddRange(new Control[] { lblSoLuong, btnToggle, tagTrungLap });

            // Detail
            var detail = new FlowLayoutPanel
            {
                AutoSize = true,
                Padding = new Padding(25),
                Margin = new Padding(20, 5, 20, 25),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(255, 248, 240),
                Visible = false
            };

            foreach (var ch in nhom.DanhSach)
            {
                detail.Controls.Add(TaoItemCauHoi(ch));
            }

            // Nút xóa nhóm
            var btnXoa = new Button
            {
                Text = $"Xóa {nhom.SoLuong - 1} câu trùng (giữ lại mới nhất - ID: {nhom.DanhSach[0].MaCauHoi})",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Height = 50,
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0, 20, 0, 0),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnXoa.Click += (s, e) =>
            {
                if (MessageBox.Show($"Bạn chắc chắn muốn xóa {nhom.SoLuong - 1} câu hỏi trùng lặp?\n" +
                    $"Giữ lại câu mới nhất (ID: {nhom.DanhSach[0].MaCauHoi})",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (var ch in nhom.DanhSach.Skip(1))
                        _bll.Xoa(ch.MaCauHoi);
                    LoadDuLieu(); // refresh
                }
            };
            detail.Controls.Add(btnXoa);

            // Sự kiện mở rộng
            Action toggleAction = () =>
            {
                bool expanded = (bool)header.Tag;
                detail.Visible = !expanded;
                btnToggle.Text = !expanded ? "Up Arrow" : "Down Arrow";
                header.Tag = !expanded;
            };

            header.MouseClick += (s, e) => toggleAction();
            btnToggle.Click += (s, e) => toggleAction(); // không cần e.Handled,

            // Container
            var container = new Panel { AutoSize = true };
            container.Controls.Add(header);
            container.Controls.Add(detail);
            return container;
        }
        private Panel TaoItemCauHoi(CauHoiDTO ch)
        {
            var p = new Panel
            {
                Height = 120,
                Margin = new Padding(0, 0, 0, 18),
                BorderStyle = BorderStyle.None
            };

            var chk = new CheckBox { Location = new Point(10, 45) };

            var lblNoiDung = new Label
            {
                Text = ch.NoiDung.Length > 300 ? ch.NoiDung.Substring(0, 300) + "..." : ch.NoiDung,
                Location = new Point(55, 12),
                Size = new Size(900, 70),
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.Black
            };

            var lblInfo = new Label
            {
                Text = $"Môn: {ch.TenMonHoc}   |   Độ khó: {ch.DoKho}   |   Tác giả: {ch.TacGia}",
                Location = new Point(55, 85),
                ForeColor = Color.MidnightBlue,
                Font = new Font("Segoe UI", 9.5F),
                AutoSize = true
            };

            p.Controls.AddRange(new Control[] { chk, lblNoiDung, lblInfo });
            return p;
        }

        private void Toggle(Panel header, FlowLayoutPanel detail, Button btn)
        {
            bool expanded = (bool)header.Tag;
            detail.Visible = !expanded;
            btn.Text = !expanded ? "Up Arrow" : "Down Arrow";
            header.Tag = !expanded;
        }
        // Nút Lọc & Reset
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboLoaiCauHoi.SelectedIndex = 0;
            cboMonHoc.SelectedIndex = 0;
            LoadDuLieu();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
