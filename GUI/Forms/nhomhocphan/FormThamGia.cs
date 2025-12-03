using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.nhomhocphan
{
    public partial class FormThamGia : Form
    {
        private readonly string _userId;

        public event EventHandler? InsertSuccess;
        public FormThamGia(string userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtMaThamGia.Text.Trim(), out long maThamGia))
            {
                MessageBox.Show("Mã tham gia không hợp lệ. Vui lòng nhập ký tự số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            bool checkExist = ChiTietNhomHocPhanBLL.DaTonTaiTrongNhom(_userId, maThamGia);

            if (checkExist)
            {
                MessageBox.Show("Đã tham gia nhóm học phần này!", "Đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
               bool success = ChiTietNhomHocPhanBLL.ThemSinhVienVaoNhom(_userId, maThamGia);
                if (success)
                {
                    MessageBox.Show("Tham gia nhóm học phần thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsertSuccess?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tham gia nhóm học phần thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
