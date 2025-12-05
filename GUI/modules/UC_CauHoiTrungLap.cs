using BLL;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_CauHoiTrungLap : UserControl
    {
        private readonly CauHoiBLL _cauHoiBLL = new();
        private readonly MonHocBLL _monHocBLL = new();
        private readonly UC_CauHoi _parentUC;

        public UC_CauHoiTrungLap(UC_CauHoi parent)
        {
            InitializeComponent();
            _parentUC = parent;
        }

        private void UC_CauHoiTrungLap_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadDuLieu();
        }

        private void LoadComboBox()
        {
            cboLoaiCauHoi.Items.Clear();
            cboLoaiCauHoi.Items.Add("Tất cả");
            cboLoaiCauHoi.SelectedIndex = 0;

            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add("Tất cả môn học");
            cboMonHoc.Items.AddRange(_monHocBLL.GetAllMonHocByStatus(1).Select(x => x.TenMonHoc).ToArray());
            cboMonHoc.SelectedIndex = 0;
        }

        private void LoadDuLieu()
        {
            var (nhom, trung, duyNhat) = _cauHoiBLL.LayThongKeTrungLap();
            lblThongKe.Text = $"{nhom} nhóm trùng lặp • {trung} câu trùng • {duyNhat} câu duy nhất";

            var ds = _cauHoiBLL.LayCauHoiTrungLap();

            dgvTrungLap.Columns.Clear();
            dgvTrungLap.DataSource = null;

            if (!ds.Any())
            {
                dgvTrungLap.Columns.Add("ThongBao", "Thông báo");
                dgvTrungLap.Rows.Add("Không tìm thấy câu hỏi trùng lặp!");
                return;
            }

            // Tạo danh sách hiển thị với sửa/xóa
            var listDisplay = ds.SelectMany(g =>
            {
                var minId = g.DanhSach.Min(c => c.MaCauHoi);
                return g.DanhSach.Select(c => new
                {
                    c.MaCauHoi,
                    c.NoiDung,
                    c.TenMonHoc,
                    c.DoKho,
                    c.TacGia,
                    ThuocNhom = c.MaCauHoi == minId ? "Câu gốc" : "Bản sao",
                    Sua = "✎",
                    Xoa = "🗑"
                });
            }).ToList();

            dgvTrungLap.DataSource = listDisplay;

            // Thêm cột nút sửa/xóa
            if (!dgvTrungLap.Columns.Contains("Sua"))
                dgvTrungLap.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Sua",
                    HeaderText = "Sửa",
                    Text = "✎",
                    UseColumnTextForButtonValue = true
                });

            if (!dgvTrungLap.Columns.Contains("Xoa"))
                dgvTrungLap.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Xoa",
                    HeaderText = "Xóa",
                    Text = "🗑",
                    UseColumnTextForButtonValue = true
                });
        }

        private void dgvTrungLap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTrungLap.Rows[e.RowIndex];
            long maCauHoi = Convert.ToInt64(row.Cells["MaCauHoi"].Value);

            if (dgvTrungLap.Columns[e.ColumnIndex].Name == "Sua")
            {
                var frm = new frmSuaCauHoi(maCauHoi);
                frm.ShowDialog();
                LoadDuLieu();
            }
            else if (dgvTrungLap.Columns[e.ColumnIndex].Name == "Xoa")
            {
                if (MessageBox.Show("Xóa câu hỏi này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _cauHoiBLL.Xoa(maCauHoi);
                    LoadDuLieu();
                }
            }
        }

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
            _parentUC?.dispkayTatCaCauHoiFromTrungLap();
        }
    }
}
