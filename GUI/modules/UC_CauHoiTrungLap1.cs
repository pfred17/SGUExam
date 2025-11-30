using BLL;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
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
            var list = _monHocBLL.GetAllMonHoc();
            list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn tất cả môn học" });

            // Gán DataSource 
            cboMonHoc.DataSource = list;
            cboMonHoc.DisplayMember = "TenMH"; // tên hiển thị cb
            cboMonHoc.ValueMember = "MaMH";    // giá trị ẩn
            // Reset chọn item đầu tiên (Chọn tất cả môn học)
            cboMonHoc.SelectedIndex = 0;
        }
        private void LoadCauHoiTrungLap()
        {
            dgvTrungLap.Rows.Clear(); // chỉ xóa dữ liệu, giữ nguyên cột Designer

            var list = _cauHoiBLL.LayCauHoiTrungLap();
            if (!list.Any())
            {
                dgvTrungLap.Rows.Add("Không tìm thấy câu hỏi trùng lặp!");
                return;
            }

            foreach (var group in list)
            {
                long minMaCauHoi = group.DanhSach.Min(c => c.MaCauHoi);

                foreach (var cau in group.DanhSach)
                {
                    string loai = cau.MaCauHoi == minMaCauHoi ? "Bản gốc" : "Bản sao";

                    dgvTrungLap.Rows.Add(
                        cau.MaCauHoi,              // MaCauHoi
                        cau.NoiDung,               // NoiDung
                        cau.TenMonHoc,             // MonHoc
                        cau.DoKho,                 // DoKho
                        loai,                      // Loai
                        Properties.Resources.icon_eyes,   // colView (nếu muốn override)
                        Properties.Resources.icon_delete  // colDelete
                    );
                }
            }
        }

        private void dgvTrungLap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            long maCauHoi = Convert.ToInt64(dgvTrungLap.Rows[e.RowIndex].Cells["MaCauHoi"].Value);

            if (e.ColumnIndex == 5) // Sửa
            {
                frmSuaCauHoi frm = new frmSuaCauHoi(maCauHoi);
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 6) // Xóa
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
        #endregion

        private void dgvTrungLap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
