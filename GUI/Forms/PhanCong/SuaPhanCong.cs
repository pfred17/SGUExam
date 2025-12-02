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

        private long _maPhanCong;
        private PhanCongDTO? currentPhanCong;

        private List<UserDTO> listUser;
        private List<MonHocDTO> listMonHoc;
        public SuaPhanCong(long maPhanCong)
        {
            InitializeComponent();
            _maPhanCong = maPhanCong;
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
        }
        private void LoadCbxMonHoc()
        {
            listMonHoc = _monHocBLL.GetAllMonHoc();
            var displayList = listMonHoc
                .Select(mh => new
                {
                    Text = mh.MaMonHoc == 0 ? mh.TenMonHoc : $"{mh.MaMonHoc} - {mh.TenMonHoc}",
                    Value = mh.MaMonHoc
                })
                .ToList();
            cbxMonHoc.DataSource = displayList;
            cbxMonHoc.DisplayMember = "Text";
            cbxMonHoc.ValueMember = "Value";
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.DropDownHeight = cbxMonHoc.ItemHeight * Math.Min(listMonHoc.Count, cbxMonHoc.MaxDropDownItems);
            cbxMonHoc.SelectedIndex = 0;
        }
        private void LoadCbxGiangVien()
        {
            listUser = _userBLL.GetAllUserByRole();
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
            cbxGiangVien.SelectedIndex = 0;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
