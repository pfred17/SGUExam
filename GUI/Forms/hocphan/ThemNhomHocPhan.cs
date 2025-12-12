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
    public partial class ThemNhomHocPhan : Form
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
        public ThemNhomHocPhan(string maNguoiDung)
        {
            InitializeComponent();
            this.maUserDangNhap = maNguoiDung;

            this.AcceptButton = null;
            this.KeyPreview = true; 

            tbTenNhom.KeyDown += Input_KeyDown;
            tbGhiChu.KeyDown += Input_KeyDown;
            cbMonHoc.KeyDown += Input_KeyDown;
            cbNamHoc.KeyDown += Input_KeyDown;
            cbHocKy.KeyDown += Input_KeyDown;

            this.Shown += (s, e) => tbTenNhom.Focus();

        }
        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                Control current = sender as Control;
                if (current is Guna.UI2.WinForms.Guna2ComboBox combo && !combo.DroppedDown)
                {
                    combo.DroppedDown = true;
                    return;
                }
                Control[] order = new Control[]
                {
                    tbTenNhom,
                    cbMonHoc,
                    tbGhiChu,
                    cbNamHoc,
                    cbHocKy,
                    btnLuu  
                };
                int index = Array.IndexOf(order, current);
                if (index == -1) return;
                if (index < order.Length - 1)
                {
                    Control next = order[index + 1];
                    if (next.CanFocus)
                    {
                        next.Focus();
                        if (next is Guna.UI2.WinForms.Guna2ComboBox nextCombo)
                            nextCombo.DroppedDown = true; 
                    }
                }
                else
                {
                    btnLuu.PerformClick();
                }
            }
        }
        private void ThemNhomHocPhan_Load(object sender, EventArgs e)
        {
            LoadComboBoxMonHoc();
            LoadHocKy();
            LoadNamHoc();

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
            try
            {
                if (string.IsNullOrWhiteSpace(tbTenNhom.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbGhiChu.Text))
                {
                    MessageBox.Show("Vui lòng nhập ghi chú!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbGhiChu.Focus();
                    return;
                }
                if (cbMonHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cbNamHoc.Text) || cbNamHoc.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn năm học!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbNamHoc.DroppedDown = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(cbHocKy.Text) || cbHocKy.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbHocKy.DroppedDown = true;
                    return;
                }

                long maMH = Convert.ToInt64(cbMonHoc.SelectedValue);
                // TÌM ma_pc của giảng viên hiện tại với môn này
                long maPC = phanCongBLL.GetMaPCByGiangVienAndMonHoc(maMH, maUserDangNhap);
                if (maPC <= 0)
                {
                    MessageBox.Show("Bạn chưa Hinton được phân công giảng dạy môn này!", "Lỗi phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var nhom = new NhomHocPhanDTO
                {
                    MaPhanCong = maPC,  // ĐÚNG RỒI ĐÂY!
                    TenNhom = tbTenNhom.Text.Trim(),
                    GhiChu = tbGhiChu.Text.Trim(),
                    HocKy = cbHocKy.Text,
                    NamHoc = cbNamHoc.Text,
                    TrangThai = 1
                };

                bool result;

                if (isEditMode)
                {
                    // === KHI SỬA: DÙNG LẠI maPC CŨ (từ dữ liệu đang sửa) ===
                    nhom.MaNhom = editingMaNhom;
                    nhom.MaPhanCong = nhomHocPhanEditing.MaPhanCong; // Lấy trực tiếp từ DTO cũ

                    result = nhomHocPhanBLL.Update(nhom);
                    if (result)
                    {
                        NhomHocPhanUpdated?.Invoke(this, nhom);
                        MessageBox.Show("Cập nhật nhóm học phần thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // === KHI THÊM MỚI: DÙNG TÊN BIẾN KHÁC ĐỂ TRÁNH TRÙNG ===
                    long maMonHocMoi = Convert.ToInt64(cbMonHoc.SelectedValue);
                    long maPhanCongMoi = phanCongBLL.GetMaPCByGiangVienAndMonHoc(maMonHocMoi, maUserDangNhap);

                    if (maPhanCongMoi <= 0)
                    {
                        MessageBox.Show("Bạn chưa được phân công giảng dạy môn này!", "Lỗi phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nhom.MaPhanCong = maPhanCongMoi;

                    long newId = nhomHocPhanBLL.InsertReturnId(nhom);
                    if (newId > 0)
                    {
                        // Thêm dòng này: Load lại DTO đầy đủ từ DB theo ma_nhom vừa tạo
                        var nhomFull = nhomHocPhanBLL.GetById(newId);  // hoặc DAL.GetById(newId)

                        if (nhomFull != null)
                        {
                            NhomHocPhanAdded?.Invoke(this, nhomFull);  // Truyền đúng DTO đầy đủ
                            MessageBox.Show("Thêm nhóm học phần thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thành công nhưng không tải lại được dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
            this.Dispose();
        }

        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbTenNhom_TextChanged(object sender, EventArgs e)
        {

        }
        


        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
    