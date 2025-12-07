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
    public partial class ThemMonHoc : Form
    {
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        public ThemMonHoc()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtMaMonHoc_Leave(sender, e);
            txtTenMonHoc_Leave(sender, e);
            txtSoTinChi_Leave(sender, e);

            if (HasValidationErrors())
            {
                FocusFirstError();
                //MessageBox.Show("Vui lòng sửa các lỗi được đánh dấu màu đỏ.",
                //                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MonHocDTO newMH = new MonHocDTO
                {
                    MaMonHoc = long.Parse(txtMaMonHoc.Text.Trim()),
                    TenMonHoc = txtTenMonHoc.Text.Trim(),
                    SoTinChi = int.Parse(txtSoTinChi.Text.Trim()),
                    TrangThai = 1
                };

                long newId = monHocBLL.AddMonHoc(newMH);

                if (newId > 0)
                {
                    MessageBox.Show("Thêm môn học thành công!",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại.",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message,
                                "Lỗi hệ thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            Close();
        }
        private bool HasValidationErrors()
        {
            return !string.IsNullOrEmpty(lblErrorMaMonHoc.Text) ||
                   !string.IsNullOrEmpty(lblErrorTenMonHoc.Text) ||
                   !string.IsNullOrEmpty(lblErrorSoTinChi.Text);
        }
        private void FocusFirstError()
        {
            if (!string.IsNullOrEmpty(lblErrorMaMonHoc.Text)) txtMaMonHoc.Focus();
            else if (!string.IsNullOrEmpty(lblErrorTenMonHoc.Text)) txtTenMonHoc.Focus();
            else if (!string.IsNullOrEmpty(lblErrorSoTinChi.Text)) txtSoTinChi.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtMaMonHoc_TextChanged(object sender, EventArgs e)
        {
            lblErrorMaMonHoc.Visible = false;
        }
        private void txtMaMonHoc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMonHoc.Text))
            {
                lblErrorMaMonHoc.Text = "Mã môn học không được để trống.";
                lblErrorMaMonHoc.Visible = true;
            }
            else
            {
                if (!long.TryParse(txtMaMonHoc.Text.Trim(), out long maMH) || maMH <= 0)
                {
                    lblErrorMaMonHoc.Text = "Mã môn học phải là số nguyên dương hợp lệ.";
                    lblErrorMaMonHoc.Visible = true;

                }
                else if (maMH.ToString().Length != 6)
                {
                    lblErrorMaMonHoc.Text = "Mã môn học phải đủ 6 chữ số.";
                    lblErrorMaMonHoc.Visible = true;
                }
                else if (monHocBLL.IsMonHocExists(maMH))
                {
                    lblErrorMaMonHoc.Text = "Mã môn học đã tồn tại!";
                    lblErrorMaMonHoc.Visible = true;
                }
                else
                {
                    lblErrorMaMonHoc.Text = "";
                    lblErrorMaMonHoc.Visible = true;
                }
            }
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