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
namespace GUI.forms.MonHoc
{
    public partial class SuaMonHoc : Form
    {
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private long _maMonHoc;
        private MonHocDTO? currentMonHoc;
        public SuaMonHoc(long maMonHoc)
        {
            _maMonHoc = maMonHoc;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            currentMonHoc = monHocBLL.GetMonHocById(_maMonHoc);

            if (currentMonHoc == null)
            {
                MessageBox.Show("Không tìm thấy môn học!");
                return;
            }
            txtMaMonHoc.Text = currentMonHoc.MaMH.ToString();
            txtTenMonHoc.Text = currentMonHoc.TenMH;
            txtSoTinChi.Text = currentMonHoc.SoTinChi.ToString();
            tsTrangThai.Checked = currentMonHoc.TrangThai == 1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentMonHoc == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin môn học để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtTenMonHoc_Leave(sender, e);
            txtSoTinChi_Leave(sender, e);

            if (HasValidationErrors())
            {
                FocusFirstError();
                return;
            }

            string newTenMonHoc = txtTenMonHoc.Text.Trim();
            int newSoTinChi = int.Parse(txtSoTinChi.Text.Trim());
            byte newTrangThai = tsTrangThai.Checked ? (byte)1 : (byte)0;

            if (newTenMonHoc == currentMonHoc.TenMH &&
                newSoTinChi == currentMonHoc.SoTinChi &&
                newTrangThai == currentMonHoc.TrangThai)
            {
                MessageBox.Show("Bạn chưa thay đổi thông tin nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentMonHoc.TenMH = newTenMonHoc;
            currentMonHoc.SoTinChi = newSoTinChi;
            currentMonHoc.TrangThai = newTrangThai;
            try
            {
                bool result = monHocBLL.UpdateMonHoc(currentMonHoc);

                if (result)
                {
                    MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool HasValidationErrors()
        {
            return !string.IsNullOrEmpty(lblErrorTenMonHoc.Text) ||
                   !string.IsNullOrEmpty(lblErrorSoTinChi.Text);
        }
        private void FocusFirstError()
        {
           if (!string.IsNullOrEmpty(lblErrorTenMonHoc.Text)) txtTenMonHoc.Focus();
            else if (!string.IsNullOrEmpty(lblErrorSoTinChi.Text)) txtSoTinChi.Focus();
        }
        private void txtTenMonHoc_TextChanged(object sender, EventArgs e)
        {
            lblErrorTenMonHoc.Visible = false;
        }
        private void txtTenMonHoc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMonHoc.Text))
            {
                lblErrorTenMonHoc.Text = "Tên môn học không được để trống.";
                lblErrorTenMonHoc.Visible = true;
            }
            else if (txtTenMonHoc.Text.Length < 5)
            {
                lblErrorTenMonHoc.Text = "Tên môn học tối thiểu 5 ký tự.";
                lblErrorTenMonHoc.Visible = true;
            }
            else if (txtTenMonHoc.Text.Length > 50)
            {
                lblErrorTenMonHoc.Text = "Tên môn học tối đa 50 ký tự.";
                lblErrorTenMonHoc.Visible = true;
            }
            else
            {
                lblErrorTenMonHoc.Text = "";
                lblErrorTenMonHoc.Visible = false;
            }
        }

        private void txtSoTinChi_TextChanged(object sender, EventArgs e)
        {
            lblErrorSoTinChi.Visible = false;
        }

        private void txtSoTinChi_Leave(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(txtSoTinChi.Text))
            {
                lblErrorSoTinChi.Text = "Số tín chỉ không được để trống.";
                lblErrorSoTinChi.Visible = true;

            }
            else if (!int.TryParse(txtSoTinChi.Text.Trim(), out int soTC) || soTC <= 0)
            {
                lblErrorSoTinChi.Text = "Số tín chỉ phải là số nguyên dương.";
                lblErrorSoTinChi.Visible = true;
            }
            else if (soTC > 10)
            {
                lblErrorSoTinChi.Text = "Số tín chỉ tối đa là 10!";
                lblErrorSoTinChi.Visible = true;
            }
            else
            {
                lblErrorSoTinChi.Text = "";
                lblErrorSoTinChi.Visible = false;
            }
        }
    }
}
