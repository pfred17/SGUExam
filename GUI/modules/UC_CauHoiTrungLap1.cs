using BLL;
using DTO;
using System.Data;
namespace GUI.modules
{
    public partial class UC_CauHoiTrungLap1 : UserControl
    {
        private readonly CauHoiBLL _cauHoiBLL = new();
        private readonly MonHocBLL _monHocBLL = new();
        private readonly UC_CauHoi _parentUC;
        public UC_CauHoiTrungLap1(UC_CauHoi parent)
        {
            InitializeComponent();
            _parentUC = parent;
        }
        public void UC_CauHoiTrungLap1_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadCauHoiTrungLap();
            LoadMonHoc();
        }
        private void LoadThongKe()
        {
            var (nhom, cauTrung, duyNhat) = _cauHoiBLL.LayThongKeTrungLap();
            lblThongKe.Text = $"Nhóm trùng: {nhom} | Câu trùng: {cauTrung} | Câu duy nhất: {duyNhat}";
        }
        private void LoadMonHoc()
        {
            var list = _monHocBLL.GetAllMonHocByStatus(1);
            list.Insert(0, new MonHocDTO { MaMonHoc = 0, TenMonHoc = "Chọn tất cả môn học" });

            cboMonHoc.DataSource = list;
            cboMonHoc.DisplayMember = "TenMonHoc"; 
            cboMonHoc.ValueMember = "MaMonHoc";  
            // Reset chọn item đầu tiên (Chọn tất cả môn học)
            cboMonHoc.SelectedIndex = 0;
        }
        private void LoadCauHoiTrungLap()
        {
            dgvTrungLap.Rows.Clear();

            var list = _cauHoiBLL.LayCauHoiTrungLap();

            // Lấy môn học đã chọn
            long maMH = cboMonHoc.SelectedItem is MonHocDTO monHoc ? monHoc.MaMonHoc : 0;

            // Lọc câu theo môn học nếu có chọn
            if (maMH > 0)
            {
                list = list
                    .Select(g => new CauHoiTrungLapDTO
                    {
                        Key = g.Key,
                        SoLuong = g.SoLuong,
                        TacGia = g.TacGia,
                        DanhSach = g.DanhSach.Where(c => c.MaMonHoc == maMH).ToList()
                    })
                    .Where(g => g.DanhSach.Count > 1) // chỉ giữ group còn >1 câu trùng
                    .ToList();
            }

            // Nếu không còn group nào
            if (!list.Any())
            {
                int rowIndex = dgvTrungLap.Rows.Add();
                dgvTrungLap.Rows[rowIndex].Cells["NoiDung"].Value = "Không tìm thấy câu hỏi trùng lặp!";
                return;
            }

            // Thêm các câu trùng vào DataGridView
            foreach (var group in list)
            {
                if (group.DanhSach.Count <= 1) continue;

                long minMaCauHoi = group.DanhSach.Min(c => c.MaCauHoi);

                foreach (var cau in group.DanhSach)
                {
                    string loai = cau.MaCauHoi == minMaCauHoi ? "Bản gốc" : "Bản sao";

                    dgvTrungLap.Rows.Add(
                        cau.MaCauHoi,
                        cau.NoiDung,
                        cau.TenMonHoc,
                        cau.DoKho,
                        loai,
                        cau.TacGia,
                        Properties.Resources.icon_eyes,
                        Properties.Resources.icon_delete
                    );
                }
            }
        }


        private void dgvTrungLap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long maCauHoi = Convert.ToInt64(dgvTrungLap.Rows[e.RowIndex].Cells["MaCauHoi"].Value);

            if (e.ColumnIndex == 6) // Sửa
            {
                frmSuaCauHoi frm = new frmSuaCauHoi(maCauHoi);
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 7) // Xóa
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cauHoiBLL.Xoa(maCauHoi);
                    LoadCauHoiTrungLap(); // reload lại bảng
                }
            }
        }
        private void dgvCauHoiTrungLap1_SelectionChanged(object sender, EventArgs e)
        {
            dgvTrungLap.ClearSelection();
        }

        #region sự kiên button 
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Reset ComboBox về "Chọn tất cả môn học"
            cboMonHoc.SelectedIndex = 0;
            LoadCauHoiTrungLap();
        }
        public void BtnTatCaCauHoi_Click(object sender, EventArgs e)
        {
            // Nếu bạn muốn mở UC_CauHoi trong cùng một panel cha
            if (_parentUC != null)
            {
                // Ẩn UC_CauHoiTrungLap
                this.Visible = false;
                // Hiển thị UC_CauHoi
                _parentUC.Visible = true;
                // Load tất cả câu hỏi
                _parentUC.dispkayTatCaCauHoiFromTrungLap();
            }
        }

        private void cbMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
                LoadCauHoiTrungLap();
        }
        #endregion

        private void dgvTrungLap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
