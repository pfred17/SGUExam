using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.modules
{
    public partial class UC_TaoDeThi : UserControl
    {
        private readonly DeThiBLL deThiBLL = new DeThiBLL();
        //private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        //private readonly ChuongBLL chuongBLL = new ChuongBLL();

        public UC_TaoDeThi()
        {
            InitializeComponent();
            LoadData();
            btnTaoDe.Click += BtnTaoDe_Click;
        }

        private void LoadData()
        {
            //// Load nhóm học phần
            //var nhoms = nhomHocPhanBLL.GetAll();
            //cbNhomHocPhan.DataSource = nhoms;
            //cbNhomHocPhan.DisplayMember = "TenNhom";
            //cbNhomHocPhan.ValueMember = "MaNhom";
            //cbNhomHocPhan.SelectedIndex = -1;

            //// Load chương
            //clbChuong.Items.Clear();
            //foreach (var chuong in chuongBLL.GetAll())
            //    clbChuong.Items.Add(chuong, false);
        }

        private void BtnTaoDe_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtTenDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpTu.Value >= dtpDen.Value)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbNhomHocPhan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm học phần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clbChuong.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách id nhóm học phần và chương
            //var nhomHocPhanIds = new List<long> { ((NhomHocPhanDTO)cbNhomHocPhan.SelectedItem).MaNhom };
            //var chuongIds = clbChuong.CheckedItems.Cast<ChuongDTO>().Select(x => x.MaChuong).ToList();

            // Tạo DTO
            var deThi = new DeThiDTO
            {
                TenDe = txtTenDe.Text.Trim(),
                ThoiGianBatDau = dtpTu.Value,
                ThoiGianKetThuc = dtpDen.Value,
                ThoiGianLamBai = (int)numThoiGianLamBai.Value,
                CanhBaoNeuDuoi = (int)numCanhBao.Value,
                SoCauDe = (int)numDe.Value,
                SoCauTrungBinh = (int)numTrungBinh.Value,
                SoCauKho = (int)numKho.Value,
                //NhomHocPhanIds = nhomHocPhanIds,
                //ChuongIds = chuongIds,
                CauHinh = new DeThiCauHinhDTO
                {
                    TuDongLay = swTuDongLay.Checked,
                    XemDiemSauThi = swXemDiem.Checked,
                    XemDapAnSauThi = swXemDapAn.Checked,
                    XemBaiLam = swXemBaiLam.Checked,
                    DaoCauHoi = swDaoCauHoi.Checked,
                    DaoDapAn = swDaoDapAn.Checked,
                    TuDongNop = swTuDongNop.Checked,
                    DeLuyenTap = swDeLuyenTap.Checked,
                    TinhDiem = swTinhDiem.Checked
                }
            };

            long maDe = deThiBLL.CreateDeThi(deThi);
            if (maDe > 0)
                MessageBox.Show("Tạo đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Tạo đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
