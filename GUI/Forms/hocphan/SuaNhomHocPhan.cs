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

namespace GUI.forms.hocphan
{
    public partial class SuaNhomHocPhan : Form
    {
        private bool isEditMode = false;
        private long editingMaNhom = 0;
        private NhomHocPhanDTO nhomHocPhanEditing;
        public event EventHandler<NhomHocPhanDTO> NhomHocPhanUpdated;
        public event EventHandler? FormClosedEvent;
        public event EventHandler<NhomHocPhanDTO>? NhomHocPhanAdded;
        private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private MonHocBLL monHocBLL = new MonHocBLL();
        private readonly PhanCongBLL phanCongBLL = new PhanCongBLL();
        private readonly string maUserDangNhap;

        private NhomHocPhanDTO nhomDangSua;

        public SuaNhomHocPhan(string maNguoiDung)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.maUserDangNhap = maNguoiDung;
        }

        private void ThemNhomHocPhan_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonHoc();
            LoadHocKy();
            LoadNamHoc();
            //ResetFields(); // ✅ Mở form mặc định là THÊM
        }

        private void LoadComboBoxMonHoc()
        {
            try
            {
                if (string.IsNullOrEmpty(maUserDangNhap))
                {
                    MessageBox.Show("Không xác định được người dùng hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // LẤY DANH SÁCH MÔN HỌC ĐÃ ĐƯỢC PHÂN CÔNG CHO GIẢNG VIÊN NÀY
                var dsMonHocPhanCong = phanCongBLL.GetMonHocByGiangVien(maUserDangNhap);

                if (dsMonHocPhanCong == null || dsMonHocPhanCong.Count == 0)
                {
                    MessageBox.Show("Bạn chưa được phân công giảng dạy môn học nào!\nVui lòng liên hệ quản trị viên.",
                                  "Chưa có phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMonHoc.DataSource = null;
                    cbMonHoc.Items.Clear();
                    cbMonHoc.Text = "Chưa có môn học nào được phân công";
                    cbMonHoc.Enabled = false;
                    return;
                }

                // Tạo danh sách hiển thị đẹp: IT001 - Lập trình C#
                var dsHienThi = dsMonHocPhanCong.Select(mh => new
                {
                    MaMonHoc = mh.MaMonHoc,
                    TenHienThi = $"{mh.MaMonHoc} - {mh.TenMonHoc}"
                }).OrderBy(x => x.TenHienThi).ToList();

                cbMonHoc.DataSource = dsHienThi;
                cbMonHoc.DisplayMember = "TenHienThi";
                cbMonHoc.ValueMember = "MaMonHoc";
                cbMonHoc.Enabled = true;
                cbMonHoc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMonHoc.Enabled = false;
            }
        }

        // load combobox học kỳ 
        private void LoadHocKy()
        {
            List<string> hocKyList = new List<string> { "HK1", "HK2", "HK3" };
            cbHocKy.DataSource = hocKyList;
            cbHocKy.SelectedIndex = -1;

        }
        // load combo box năm học
        private void LoadNamHoc()
        {
            List<string> namHocList = new List<string>();

            int startYear = 2023; // hoặc DateTime.Now.Year - 1 nếu muốn tự động
            for (int i = 0; i < 7; i++)
            {
                string nh = $"{startYear + i}-{startYear + i + 1}";
                namHocList.Add(nh);
            }
            cbNamHoc.DataSource = namHocList;
            cbNamHoc.SelectedIndex = -1;

        }



        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Ẩn usercontrol (không Remove)
            ResetFields();
            this.Visible = false;
            // Thông báo cho cha biết đã đóng (nếu cần)
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }




        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTenNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm!");
                return;
            }

            nhomDangSua.TenNhom = tbTenNhom.Text.Trim();
            nhomDangSua.GhiChu = tbGhiChu.Text.Trim();
            nhomDangSua.HocKy = cbHocKy.Text;
            nhomDangSua.NamHoc = cbNamHoc.Text;

            bool result = nhomHocPhanBLL.Update(nhomDangSua);

            if (result)
            {
                NhomHocPhanUpdated?.Invoke(this, nhomDangSua);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        public void ResetFields()
        {
            // Clear input fields
            tbTenNhom.Text = string.Empty;
            tbGhiChu.Text = string.Empty;

            // Reset comboboxes safely
            if (cbMonHoc.DataSource != null) cbMonHoc.SelectedIndex = -1;
            else cbMonHoc.Text = string.Empty;

            if (cbHocKy.DataSource != null) cbHocKy.SelectedIndex = -1;
            else cbHocKy.Text = string.Empty;

            if (cbNamHoc.DataSource != null) cbNamHoc.SelectedIndex = -1;
            else cbNamHoc.Text = string.Empty;

            // Reset edit mode flags so the UC is in "Thêm mới" state
            isEditMode = false;
            editingMaNhom = 0;
            nhomHocPhanEditing = null;

            // Optionally focus the first input
            tbTenNhom.Focus();
        }
        public void LoadDuLieuSua(NhomHocPhanDTO nhom)
        {
            nhomDangSua = nhom;

            LoadComboBoxMonHoc();
            LoadHocKy();
            LoadNamHoc();

            tbTenNhom.Text = nhom.TenNhom;
            tbGhiChu.Text = nhom.GhiChu;
            cbHocKy.Text = nhom.HocKy;
            cbNamHoc.Text = nhom.NamHoc;

            txtTenMonHoc.Text = nhom.TenMonHoc;

            cbMonHoc.Enabled = false; // không cho sửa môn
        }
    }
}
