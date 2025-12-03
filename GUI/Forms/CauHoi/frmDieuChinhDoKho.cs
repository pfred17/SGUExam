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

namespace GUI.Forms.CauHoi
{
    public partial class frmDieuChinhDoKho : Form
    {
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        public frmDieuChinhDoKho()
        {
            InitializeComponent();
            LoadMonHocData();
        }

        private void LoadMonHocData()
        {
            try
            {
                var list = _monHocBLL.GetAllMonHoc();
                list.Insert(0, new MonHocDTO { MaMonHoc = 0, TenMonHoc = "Chọn tất cả môn học" });
                cbMonHoc.DataSource = list;
                cbMonHoc.DisplayMember = "TenMonHoc";
                cbMonHoc.ValueMember = "MaMonHoc";
            } catch (Exception ex) {
                MessageBox.Show($"Lỗi tải danh sách môn học :{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPhanTich_Click(object sender, EventArgs e)
        {
            long maMonHoc = (long)cbMonHoc.SelectedValue;
            int minLuotLam = (int)numLuotLamToiThieu.Value;
            int nguongDe = (int)numNguongDe.Value;
            int nguongKho = (int)numNguongKho.Value;

            if (nguongKho < nguongDe) {
                MessageBox.Show("Ngưỡng khó phải lớn hơn Ngưỡng dễ.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var result = _cauHoiBLL.TinhToanVaDeXuatDoKho(maMonHoc, minLuotLam, nguongDe, nguongKho);
                if (result == null || result.Count == 0)
                {
                    dgvKetQuaPhanTich.Rows.Clear();
                    MessageBox.Show("Không có câu hỏi nào đạt đủ điều kiện để phân tích (Số lượt làm tối thiểu, Môn học).", "Không tìm thấy",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // hien thi kwt qua
                RenderKetQuaPhanTich(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi phân tích dữ liệu: {ex.Message}", "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RenderKetQuaPhanTich(List<CauHoiDTO> list)
        {
            dgvKetQuaPhanTich.Rows.Clear();
            if (list == null || list.Count == 0) return;
            for(int i=0;i< list.Count; i++)
            {
                var cauhoi = list[i];
                int rowIndex = dgvKetQuaPhanTich.Rows.Add();
                var row = dgvKetQuaPhanTich.Rows[rowIndex];

                row.Tag = cauhoi.MaCauHoi; // luu id 
                                           // gan du lieu vao cac cot (STT,NoiDung,số lượt làm , tỷ lệ sai ,độ khó hiện tại , gọi ý độ khó
                row.Cells[colSTT.Name].Value = cauhoi.MaCauHoi;
                row.Cells[colNoiDung.Name].Value = cauhoi.NoiDung;
                row.Cells[colSoLuotTraLoi.Name].Value = cauhoi.SoLuotLam;
                row.Cells[colTyLeSai.Name].Value = $"{cauhoi.TyLeSai:P2}";// Ví dụ: 0.75 -> 75.00%
                row.Cells[colDoKhoHienTai.Name].Value = cauhoi.DoKho;
                row.Cells[colGoiYDoKhoMoi.Name].Value = cauhoi.DoKhoGoiY;

                bool canChange = cauhoi.DoKho != cauhoi.DoKhoGoiY;
                row.Cells[colHanhDong.Name].Value = canChange ? "Áp dụng" : "Giữ nguyên";
                // Đổi màu nền cho những hàng cần thay đổi
                row.DefaultCellStyle.BackColor = canChange ? Color.FromArgb(255, 255, 192) : Color.White;
            }
        }
        private void dgvKetQuaPhanTich_SelectionChanged(object sender, EventArgs e)
        {
            dgvKetQuaPhanTich.ClearSelection();
        }

        private void dgvKetQuaPhanTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem có phải cột Hành động không
            if (e.RowIndex < 0 || dgvKetQuaPhanTich.Columns[e.ColumnIndex].Name != colHanhDong.Name)
                return;
            var row = dgvKetQuaPhanTich.Rows[e.RowIndex];
            long maCauHoi = (long)row.Tag;
            string doKhoHienTai = row.Cells[colDoKhoHienTai.Name].Value?.ToString();
            string doKhoGoiY = row.Cells[colGoiYDoKhoMoi.Name].Value?.ToString();

            // Kiểm tra đã áp dụng hay chưa
            if (doKhoHienTai == doKhoGoiY) {
                MessageBox.Show("Độ khó hiện tại đã phù hợp với gợi ý. Không cần thay đổi.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Hỏi xác nhận người dùng
            DialogResult confirm = MessageBox.Show(
                $"Bạn có muốn thay đổi độ khó của câu hỏi Mã {maCauHoi}:\n\n" +
                $"Từ: {doKhoHienTai} → {doKhoGoiY}?",
                "Xác nhận thay đổi độ khó",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // 3. Gọi BLL để cập nhật độ khó vào DB
                    _cauHoiBLL.CapNhatDoKho(maCauHoi, doKhoGoiY);

                    // 4. Cập nhật giao diện (UI)
                    CapNhatRowSauKhiApDung(e.RowIndex, doKhoGoiY);

                    MessageBox.Show($"Đã cập nhật độ khó thành công thành '{doKhoGoiY}'!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật độ khó: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Thêm hàm này vào Form
        private void CapNhatRowSauKhiApDung(int rowIndex, string doKhoMoi)
        {
            var row = dgvKetQuaPhanTich.Rows[rowIndex];

            // 1. Cập nhật độ khó hiện tại bằng độ khó mới
            row.Cells[colDoKhoHienTai.Name].Value = doKhoMoi;

            // 2. Đặt lại nút Hành động và màu nền
            row.Cells[colHanhDong.Name].Value = "Giữ nguyên";
            row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}
