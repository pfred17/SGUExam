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
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private UC_CauHoi _parentUC; // lưu trữ tham chiếu tới UC_CauHoi mà nó “thuộc về”.
        public UC_CauHoiTrungLap(UC_CauHoi parent)
        {
            InitializeComponent();
            _parentUC = parent;
            this.Load += UC_CauHoiTrungLap_Load;
        }
        // load du lieu 
        public void UC_CauHoiTrungLap_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            LoadComboBox(); // load du lieu mon hc vao combobox 
        }
        public void LoadComboBox()
        {
            cboLoaiCauHoi.Items.Clear();
            cboLoaiCauHoi.Items.Add("Tất cả");
            cboLoaiCauHoi.SelectedIndex = 0;
            // load mon hoc
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add("Tất cả môn học");
            cboMonHoc.Items.AddRange(_monHocBLL.GetAllMonHoc().Select(m => m.TenMH).ToArray());
            cboMonHoc.SelectedIndex = 0;
        }

        public void LoadDuLieu()
        {
            flpMain.Controls.Clear();
            var (nhomTrung, cauTrung, cauDuyNhat) = _cauHoiBLL.LayThongKeTrungLap();
            var dsNhom = _cauHoiBLL.LayCauHoiTrungLap();
            // cap nhat thong ke 
            lblThongKe.Text = $"{nhomTrung} nhóm trùng lặp + {cauTrung} câu trùng + {cauDuyNhat} câu duy nhất";

            if (nhomTrung == 0)
            {
                flpMain.Controls.Add(new Label
                {
                    Text = "Tuyệt vời! Không có câu hỏi nào bị trùng lặp.",
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    ForeColor = Color.ForestGreen,
                    Margin = new Padding(30, 80, 0, 20),
                    AutoSize = true
                });
                return;
            }
            foreach (var nhom in dsNhom)
            {
                //flpMain.Controls.Add(CreateGroupCard(nhom));
                var card = CreateGroupCard(nhom);
                flpMain.Controls.Add(card);
            }
        }
        private Control CreateGroupCard(CauHoiTrungLapDTO nhom)
        {
            var card = new Panel
            {
                //Width = flpMain.ClientSize.Width - 50,
                Margin = new Padding(20, 10, 20, 25),
                BackColor = Color.White,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MaximumSize = new Size(1100, 0),
                MinimumSize = new Size(800, 0)
            };

            // Bóng đổ nhẹ
            card.Paint += (s, e) =>
            {
                if (card.Width < 20) return;
                using var brush = new SolidBrush(Color.FromArgb(35, 0, 0, 0));
                e.Graphics.FillRectangle(brush, 6, 8, card.Width - 6, card.Height - 8);
            };

            var header = CreateHeader(nhom);
            var detail = CreateDetail(nhom);

            card.Controls.Add(detail);
            card.Controls.Add(header);
            card.Controls.SetChildIndex(header, 0);

            return card;
        }
        private Panel CreateHeader(CauHoiTrungLapDTO nhom)
        {
            var header = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(255, 240, 225),
                Cursor = Cursors.Hand,
                Tag = false
            };

            var lblCount = new Label
            {
                Text = $"{nhom.SoLuong} câu hỏi giống nhau",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                AutoSize = true,
                Location = new Point(25, 23)
            };

            var tag = new Label
            {
                Text = "Trùng lặp",
                BackColor = Color.Crimson,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(12, 6, 12, 6),
                AutoSize = true
            };

            var btnToggle = new Button
            {
                Text = "Down Arrow",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.Maroon,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(60, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };

            void Toggle()
            {
                bool expanded = (bool)header.Tag;
                ((FlowLayoutPanel)header.Parent.Controls[1]).Visible = !expanded;
                btnToggle.Text = !expanded ? "Up Arrow" : "Down Arrow";
                header.Tag = !expanded;
            }

            header.Click += (s, e) => { if (e is MouseEventArgs m && m.Button == MouseButtons.Left) Toggle(); };
            btnToggle.Click += (s, e) => Toggle();

            header.Resize += (s, e) =>
            {
                btnToggle.Location = new Point(header.Width - 80, 5);
                tag.Location = new Point(header.Width - tag.Width - 95, 22);
            };

            header.Controls.AddRange(new Control[] { lblCount, tag, btnToggle });
            return header;
        }
        private FlowLayoutPanel CreateDetail(CauHoiTrungLapDTO nhom)
        {
            var detail = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(20, 15, 20, 30),
                BackColor = Color.FromArgb(255, 250, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            foreach (var ch in nhom.DanhSach)
                detail.Controls.Add(CreateQuestionItem(ch, ch.MaCauHoi == nhom.DanhSach.First().MaCauHoi));

            if (nhom.SoLuong > 1)
            {
                var btnDelete = new Button
                {
                    Text = $"Xóa {nhom.SoLuong - 1} câu trùng (giữ ID: {nhom.DanhSach[0].MaCauHoi})",
                    Height = 50,
                    Margin = new Padding(0, 25, 0, 0),
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 30, 40);

                btnDelete.Click += (s, e) =>
                {
                    if (MessageBox.Show($"Xác nhận xóa {nhom.SoLuong - 1} câu hỏi trùng lặp?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (var c in nhom.DanhSach.Skip(1))
                            _cauHoiBLL.Xoa(c.MaCauHoi);

                        LoadDuLieu();
                        _parentUC?.dispkayTatCaCauHoiFromTrungLap();
                    }
                };

                detail.Controls.Add(btnDelete);
            }

            return detail;
        }
        private Control CreateQuestionItem(CauHoiDTO ch, bool isKeep)
        {
            var item = new Panel
            {
                Height = 110,
                BackColor = isKeep ? Color.FromArgb(230, 245, 230) : Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 15),
                Padding = new Padding(15, 12, 15, 12)
            };

            item.Controls.AddRange(new Control[]
            {
                new Label { Text = isKeep ? "Kept" : "Removed", Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = isKeep ? Color.Green : Color.Gray, Location = new Point(12, 8), Size = new Size(30, 30), TextAlign = ContentAlignment.MiddleCenter },
                new Label { Text = ch.NoiDung.Length > 500 ? ch.NoiDung.Substring(0,500) + "..." : ch.NoiDung, Location = new Point(55, 8), MaximumSize = new Size(900, 0), AutoSize = true, Font = new Font("Segoe UI", 10.5F), ForeColor = Color.FromArgb(30,30,30) },
                new Label { Text = $"Môn: {ch.TenMonHoc} • Độ khó: {ch.DoKho} • Tác giả: {ch.TacGia} • ID: {ch.MaCauHoi}", Location = new Point(55, 70), ForeColor = Color.FromArgb(90,90,130), Font = new Font("Segoe UI", 9F, FontStyle.Italic), AutoSize = true },
                new Label { Text = "Sẽ giữ lại", BackColor = Color.FromArgb(40,167,69), ForeColor = Color.White, Font = new Font("Segoe UI", 8F, FontStyle.Bold), Padding = new Padding(8,3,8,3), AutoSize = true, Visible = isKeep, Location = new Point(800, 10) }
            });

            return item;
        }
        // === Sự kiện nút ===
        private void btnLoc_Click(object sender, EventArgs e) => LoadDuLieu();
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboLoaiCauHoi.SelectedIndex = 0;
            cboMonHoc.SelectedIndex = 0;
            LoadDuLieu();
        }

        private void loadTatCauHoi_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _parentUC.Visible = true;
            _parentUC.dispkayTatCaCauHoiFromTrungLap();
        }
    }

    //// Nút Lọc & Reset
    //private void btnLoc_Click(object sender, EventArgs e)
    //{
    //    LoadDuLieu();
    //}
    //private void btnReset_Click(object sender, EventArgs e)
    //{
    //    cboLoaiCauHoi.SelectedIndex = 0;
    //    cboMonHoc.SelectedIndex = 0;
    //    LoadDuLieu();
    //}

    //public void loadTatCauHoi_Click(object sender, EventArgs e)
    //{
    //    this.Visible = false;     // ẩn UC_TrungLap
    //    _parentUC.Visible = true; // hiện UC_CauHoi
    //    _parentUC.dispkayTatCaCauHoiFromTrungLap(); // load dữ liệu
    //}
    //private void label1_Click(object sender, EventArgs e)
    //{

    //}

    //private void btnTatCaCauHoi_Click(object sender, EventArgs e)
    //{

    //}

    //private void lblDescription_Click(object sender, EventArgs e)
    //{

    //}
}
