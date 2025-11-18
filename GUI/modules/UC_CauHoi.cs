using BLL;
using DTO;
using GUI.modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class UC_CauHoi : UserControl
    {
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private readonly ChuongBLL _chuongBLL = new ChuongBLL();
        private readonly DapAnBLL _dapAnBLL = new DapAnBLL();

        public UC_CauHoi()
        {
            InitializeComponent();
            LoadMonHoc();
            LoadDoKho();
            LoadData();

            // Gán sự kiện ComboBox
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            cbChuong.SelectedIndexChanged += cbChuong_SelectedIndexChanged;
            cbDoKho.SelectedIndexChanged += cbDoKho_SelectedIndexChanged;
        }

        #region Load dữ liệu

        private void LoadMonHoc()
        {
            var list = _monHocBLL.GetAll();
            list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn tất cả môn học" });
            cbMonHoc.DataSource = list;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
            cbMonHoc.SelectedIndex = 0;
        }

        private void LoadDoKho()
        {
            cbDoKho.Items.Clear();
            cbDoKho.Items.Add("Tất cả");
            cbDoKho.Items.Add("Dễ");
            cbDoKho.Items.Add("Trung bình");
            cbDoKho.Items.Add("Khó");
            cbDoKho.SelectedIndex = 0;
        }

        private void LoadChuongTheoMonHoc(long maMH)
        {
            if (maMH > 0)
            {
                var list = _chuongBLL.GetByMonHoc(maMH);
                list.Insert(0, new ChuongDTO { MaChuong = 0, TenChuong = "Chọn chương" });

                cbChuong.DataSource = list;
                cbChuong.DisplayMember = "TenChuong";
                cbChuong.ValueMember = "MaChuong";
            }
            else
            {
                cbChuong.DataSource = null;
                cbChuong.Text = "Chọn chương";
            }
        }

        private void LoadData()
        {
            long maMH = 0;
            long maChuong = 0;

            // Lấy MaMH từ SelectedItem
            if (cbMonHoc.SelectedItem is MonHocDTO monHoc)
                maMH = monHoc.MaMH;

            // Lấy MaChuong từ SelectedItem
            if (cbChuong.SelectedItem is ChuongDTO chuong)
                maChuong = chuong.MaChuong;

            string doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text.Trim();
            string tuKhoa = (txtTimKiem.Text.Trim() == "Nhập nội dung câu hỏi để tìm kiếm...") ? "" : txtTimKiem.Text.Trim();
            var filtered = _cauHoiBLL.GetAllForDisplay(maMH, maChuong, doKho, tuKhoa);


            colID.DataPropertyName = "MaCauHoi";
            colNoiDung.DataPropertyName = "NoiDung";
            colMonHoc.DataPropertyName = "TenMonHoc";
            colDoKho.DataPropertyName = "DoKho";

            dgvCauHoi.AutoGenerateColumns = false;
            dgvCauHoi.DataSource = filtered;
        }


        #endregion

        #region Sự kiện

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập nội dung câu hỏi để tìm kiếm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập nội dung câu hỏi để tìm kiếm...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonHoc.SelectedItem is MonHocDTO monHoc)
            {
                long maMH = monHoc.MaMH;
                LoadChuongTheoMonHoc(maMH);
                LoadData();
            }
        }

        private void cbChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbDoKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            var frm = new frmThemSuaCauHoi();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnTuDieuChinh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển...", "Thông báo");
        }

        private void dgvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCauHoi.Columns[e.ColumnIndex].Name != "colHanhDong") return;

            long maCH = Convert.ToInt64(dgvCauHoi.Rows[e.RowIndex].Cells["colID"].Value);

            var menu = new ContextMenuStrip();
            menu.Items.Add("Sửa", null, (s, a) =>
            {
                var frm = new frmThemSuaCauHoi(maCH);
                if (frm.ShowDialog() == DialogResult.OK) LoadData();
            });
            menu.Items.Add("Xóa", null, (s, a) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cauHoiBLL.Xoa(maCH);
                    LoadData();
                }
            });

            menu.Show(Cursor.Position);
        }

        #endregion
    }
}
