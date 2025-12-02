using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Forms.CauHoi
{
    public partial class frmDieuChinhDoKho : Form
    {
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách môn học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhanTich_Click(object sender, EventArgs e)
        {
            dgvKetQuaPhanTich.Rows.Clear();

            long maMonHoc = (long)cbMonHoc.SelectedValue;
            int minLuotLam = (int)numLuotLamToiThieu.Value;
            int nguongDe = (int)numNguongDe.Value;
            int nguongKho = (int)numNguongKho.Value;

            if (nguongKho <= nguongDe)
            {
                MessageBox.Show("Ngưỡng khó phải lớn hơn Ngưỡng dễ.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var result = _cauHoiBLL.TinhToanVaDeXuatDoKho(maMonHoc, minLuotLam, nguongDe, nguongKho);
                RenderKetQuaPhanTich(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra khi phân tích dữ liệu: {ex.Message}",
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderKetQuaPhanTich(List<CauHoiDTO> list)
        {
            dgvKetQuaPhanTich.Rows.Clear();

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi nào đạt đủ điều kiện để phân tích.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                var ch = list[i];
                int rowIndex = dgvKetQuaPhanTich.Rows.Add();

                var row = dgvKetQuaPhanTich.Rows[rowIndex];
                row.Tag = ch.MaCauHoi;

                row.Cells[colSTT.Name].Value = i + 1;
                row.Cells[colNoiDung.Name].Value = ch.NoiDung;
                row.Cells[colSoLuotTraLoi.Name].Value = ch.SoLuotLam;
                row.Cells[colTyLeSai.Name].Value = $"{ch.TyLeSai:P2}"; // Đẹp hơn: 75,50%
                row.Cells[colDoKhoHienTai.Name].Value = ch.DoKho;
                row.Cells[colGoiYDoKhoMoi.Name].Value = ch.DoKhoGoiY;

                bool canChange = ch.DoKho != ch.DoKhoGoiY;
                row.Cells[colHanhDong.Name].Value = canChange ? "Áp dụng" : "Giữ nguyên";
                row.DefaultCellStyle.BackColor = canChange
                    ? Color.FromArgb(255, 255, 192)
                    : Color.White;
            }
        }

        private void dgvKetQuaPhanTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQuaPhanTich.Columns[e.ColumnIndex].Name != colHanhDong.Name)
                return;

            var row = dgvKetQuaPhanTich.Rows[e.RowIndex];
            long maCauHoi = (long)row.Tag;
            string doKhoHienTai = row.Cells[colDoKhoHienTai.Name].Value?.ToString();
            string doKhoGoiY = row.Cells[colGoiYDoKhoMoi.Name].Value?.ToString();

            if (doKhoHienTai == doKhoGoiY)
            {
                MessageBox.Show("Độ khó hiện tại đã phù hợp với gợi ý. Không cần thay đổi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                $"Bạn có muốn thay đổi độ khó của câu hỏi này:\n\n" +
                $"Từ: {doKhoHienTai} → {doKhoGoiY}?",
                "Xác nhận thay đổi độ khó",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _cauHoiBLL.CapNhatDoKho(maCauHoi, doKhoGoiY);
                    CapNhatRowSauKhiApDung(e.RowIndex, doKhoGoiY);

                    MessageBox.Show($"Đã cập nhật độ khó thành công thành '{doKhoGoiY}'!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //cập nhật UI
        private void CapNhatRowSauKhiApDung(int rowIndex, string doKhoMoi)
        {
            var row = dgvKetQuaPhanTich.Rows[rowIndex];
            row.Cells[colDoKhoHienTai.Name].Value = doKhoMoi;
            row.Cells[colGoiYDoKhoMoi.Name].Value = doKhoMoi;
            row.Cells[colHanhDong.Name].Value = "Giữ nguyên";
            row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}