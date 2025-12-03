using BLL;
using DAL;
using DTO;
using GUI.forms.MonHoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.forms.PhanCong
{
    public partial class SuaPhanCong : Form
    {
        private readonly PhanCongBLL _phanCongBLL = new PhanCongBLL();
        private readonly UserBLL _userBLL = new UserBLL();

        private readonly string _userId;
        private readonly long _maPhanCong;
        private PhanCongDTO? currentPhanCong;

        private List<UserDTO> listUser;
        public SuaPhanCong(long maPhanCong, string userId)
        {
            _maPhanCong = maPhanCong;
            _userId = userId;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            currentPhanCong = _phanCongBLL.GetPhanCongById(_maPhanCong);

            if (currentPhanCong == null)
            {
                MessageBox.Show("Không tìm thấy mã phân công!");
                return;
            }
            txtMaPhanCong.Text = currentPhanCong.MaPhanCong.ToString();
            txtMonHoc.Text = currentPhanCong.TenMonHoc.ToString();
            LoadCbxGiangVien();
            cbxGiangVien.SelectedValue = currentPhanCong.MaNguoiDung;
            tsTrangThai.Checked = currentPhanCong.TrangThai == 1;
        }
        private void LoadCbxGiangVien()
        {
            listUser = _phanCongBLL.GetAllUserByRoleExcluding(_userId);
            var displayList = listUser
                .Select(u => new
                {
                    Text = u.MSSV == "" ? u.HoTen : $"{u.MSSV} - {u.HoTen}",
                    Value = u.MSSV
                })
                .ToList();
            cbxGiangVien.DataSource = displayList;
            cbxGiangVien.DisplayMember = "Text";
            cbxGiangVien.ValueMember = "Value";
            cbxGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGiangVien.MaxDropDownItems = 5;
            cbxGiangVien.DropDownHeight = cbxGiangVien.ItemHeight * Math.Min(listUser.Count, cbxGiangVien.MaxDropDownItems);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPhanCong == null)
                {
                    MessageBox.Show("Không tìm thấy phân công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbxGiangVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn giảng viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newGV = cbxGiangVien.SelectedValue.ToString()!;
                int newTT = tsTrangThai.Checked ? 1 : 0;

                string oldGV = currentPhanCong.MaNguoiDung;
                int oldTT = currentPhanCong.TrangThai;

                bool isReferenced = _phanCongBLL.IsPhanCongReferenced(currentPhanCong.MaPhanCong);

                if (newGV == oldGV && newTT == oldTT)
                {
                    MessageBox.Show("Bạn chưa thay đổi thông tin nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (isReferenced)
                {
                    if (newGV != oldGV)
                    {
                        cbxGiangVien.SelectedValue = oldGV;

                        MessageBox.Show(
                            "Phân công đang được sử dụng bởi nhóm học phần.\n" +
                            "Không thể thay đổi giảng viên!\n" +
                            "Chỉ được phép cập nhật trạng thái.",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (_phanCongBLL.UpdateStatus(currentPhanCong.MaPhanCong, newTT))
                    {
                        MessageBox.Show("Cập nhật trạng thái phân công thành công!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi");
                    }
                    return;
                }

                currentPhanCong.MaNguoiDung = newGV;
                currentPhanCong.TrangThai = newTT;

                if (_phanCongBLL.UpdatePhanCong(currentPhanCong))
                {
                    MessageBox.Show("Cập nhật phân công thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi");
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
