using BLL;
using DAL;
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
    public partial class UC_ThemNhomHocPhan : UserControl
    {
        private bool isEditMode = false;
        private long editingMaNhom = 0;
        private NhomHocPhanDTO nhomHocPhanEditing;
        public event EventHandler<NhomHocPhanDTO> NhomHocPhanUpdated;
        public event EventHandler? FormClosedEvent;
        public event EventHandler<NhomHocPhanDTO>? NhomHocPhanAdded;
        private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private MonHocBLL monHocBLL = new MonHocBLL();
        public UC_ThemNhomHocPhan()
        {
            InitializeComponent();
        }

        private void UC_ThemNhomHocPhan_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonHoc();
            LoadHocKy();
            LoadNamHoc();
        }
        //load comobox môn học
        private void LoadComboBoxMonHoc()
        {
            try
            {
                var dsMonHoc = monHocBLL.GetAllMonHocByStatus();

                // Gộp ma_mh + ten_mh thành 1 chuỗi để hiển thị
                var dsHienThi = dsMonHoc.Select(mh => new
                {
                    MaMonHoc = mh.MaMH,
                    TenHienThi = mh.MaMH + " - " + mh.TenMH
                }).ToList();

                cbMonHoc.DataSource = dsHienThi;
                cbMonHoc.DisplayMember = "TenHienThi";
                cbMonHoc.ValueMember = "MaMonHoc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu môn học: " + ex.Message);
            }
        }

        // load combobox học kỳ 
        private void LoadHocKy()
        {
            List<string> hocKyList = new List<string> { "HK1", "HK2", "HK3" };
            cbHocKy.DataSource = hocKyList;
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
            try
            {
                if (string.IsNullOrWhiteSpace(tbTenNhom.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbMonHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhomHocPhanDTO nhom = new NhomHocPhanDTO
                {
                    MaPc = Convert.ToInt64(cbMonHoc.SelectedValue),
                    TenNhom = tbTenNhom.Text.Trim(),
                    GhiChu = tbGhiChu.Text.Trim(),
                    HocKy = cbHocKy.Text,
                    NamHoc = cbNamHoc.Text,
                    TrangThai = 1
                };

                bool result;

                if (isEditMode)
                {
                    nhom.MaNhom = editingMaNhom;
                    result = nhomHocPhanBLL.Update(nhom);

                    if (result)
                    {
                        NhomHocPhanUpdated?.Invoke(this, nhom);
                        MessageBox.Show("Cập nhật nhóm học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Thay khối Insert cũ bằng InsertReturnId để lấy MaNhom thực từ DB
                    long newId = nhomHocPhanBLL.InsertReturnId(nhom);

                    if (newId > 0 )
                    {
                        nhom.MaNhom = newId; // gán id thực cho DTO
                        NhomHocPhanAdded?.Invoke(this, nhom);
                        MessageBox.Show("Thêm nhóm học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Đóng form thêm
                this.Visible = false;
                FormClosedEvent?.Invoke(this, EventArgs.Empty);

                // Reset trạng thái
                isEditMode = false;
                editingMaNhom = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhóm học phần: " + ex.Message);
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Ẩn usercontrol (không Remove)
            ResetFields();
            this.Visible = false;

            // Thông báo cho cha biết đã đóng (nếu cần)
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbTenNhom_TextChanged(object sender, EventArgs e)
        {

        }
        //Update nhomhocphan
        // Gọi khi muốn sửa 1 nhóm học phần
        public void SetEditMode(NhomHocPhanDTO nhom)
        {
            if (nhom == null) return;

            isEditMode = true;
            editingMaNhom = nhom.MaNhom;

            // Đảm bảo combobox đã load trước khi set
            if (cbMonHoc.DataSource == null)
                LoadComboBoxMonHoc();

            if (cbHocKy.DataSource == null)
                LoadHocKy();

            if (cbNamHoc.DataSource == null)
                LoadNamHoc();
            // Gán dữ liệu lên form
            tbTenNhom.Text = nhom.TenNhom;
            tbGhiChu.Text = nhom.GhiChu;
            cbMonHoc.SelectedValue = nhom.MaPc;
            cbHocKy.Text = nhom.HocKy;
            cbNamHoc.Text = nhom.NamHoc;
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

