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
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();

        private readonly string _userId;
        private readonly long _maPhanCong;
        private PhanCongDTO? currentPhanCong;

        private List<UserDTO> listUser;
        private List<MonHocDTO> listMonHoc;
        public SuaPhanCong(long maPhanCong, long maMonHoc, string userId)
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
            LoadCbxMonHoc();
            LoadCbxGiangVien();

            cbxMonHoc.SelectedValue = currentPhanCong.MaMonHoc;
            cbxGiangVien.SelectedValue = currentPhanCong.MaNguoiDung;
        }
        private void LoadCbxMonHoc()
        {
            listMonHoc = _monHocBLL.GetAllMonHoc();
            var displayList = listMonHoc
                .Select(mh => new
                {
                    Text = mh.MaMH == 0 ? mh.TenMH : $"{mh.MaMH} - {mh.TenMH}",
                    Value = mh.MaMH
                })
                .ToList();
            cbxMonHoc.DataSource = displayList;
            cbxMonHoc.DisplayMember = "Text";
            cbxMonHoc.ValueMember = "Value";
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.DropDownHeight = cbxMonHoc.ItemHeight * Math.Min(listMonHoc.Count, cbxMonHoc.MaxDropDownItems);
        }
        private void LoadCbxGiangVien()
        {
            listUser = _userBLL.GetAllUserByRole().Where(gv => gv.MSSV != _userId).ToList();
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
            if (currentPhanCong == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin phân công để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbxMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxGiangVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn giảng viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                long newMaMonHoc = Convert.ToInt64(cbxMonHoc.SelectedValue);
                string? newMaGiangVien = cbxGiangVien.SelectedValue.ToString();

                long oldMaMonHoc = currentPhanCong.MaMonHoc;
                string oldMaGiangVien = currentPhanCong.MaNguoiDung;

                if (newMaMonHoc == oldMaMonHoc && newMaGiangVien == oldMaGiangVien)
                {
                    MessageBox.Show("Bạn chưa thay đổi thông tin nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                currentPhanCong.MaMonHoc = newMaMonHoc;
                currentPhanCong.MaNguoiDung = newMaGiangVien ?? "";

                bool result = _phanCongBLL.UpdatePhanCong(currentPhanCong);
                if (result)
                {
                    MessageBox.Show("Cập nhật phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
