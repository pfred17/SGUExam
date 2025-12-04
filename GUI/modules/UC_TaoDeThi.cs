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
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private readonly ChuongBLL chuongBLL = new ChuongBLL();

        public UC_TaoDeThi()
        {
            InitializeComponent();
            LoadData();
            btnTaoDe.Click += BtnTaoDe_Click;
        }

        private void LoadData()
        {
            // Load tất cả môn học
            var monList = monHocBLL.GetAllMonHocByStatus(1);
            cbMonHoc.DataSource = monList;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
            cbMonHoc.SelectedIndex = -1;

            // Clear nhóm học phần và chương
            clbNhomHocPhan.Items.Clear();
            clbChuong.Items.Clear();

            // Gán event khi chọn môn học
            cbMonHoc.SelectedIndexChanged -= cbMonHoc_SelectedIndexChanged;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonHoc.SelectedItem is MonHocDTO monHoc)
            {
                // Lấy nhóm học phần qua bảng phân công
                var nhomList = nhomHocPhanBLL.GetByMonHoc(monHoc.MaMH)
                    .Where(x => x.TrangThai == 1)
                    .ToList();
                clbNhomHocPhan.Items.Clear();
                foreach (var nhom in nhomList)
                {
                    clbNhomHocPhan.Items.Add(nhom, false);  // THÊM OBJECT
                }
                clbNhomHocPhan.DisplayMember = "TenNhom";   // HIỂN THỊ


                // Load chương của môn học
                var chuongList = chuongBLL.GetChuongByMonHoc(monHoc.MaMH);
                clbChuong.Items.Clear();
                clbChuong.Items.Clear();
                foreach (var chuong in chuongList)
                {
                    clbChuong.Items.Add(chuong, false);  // THÊM OBJECT
                }
                clbChuong.DisplayMember = "TenChuong";

            }
            else
            {
                clbNhomHocPhan.Items.Clear();
                clbChuong.Items.Clear();
            }
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
            if (cbMonHoc.SelectedIndex < 0 || cbMonHoc.SelectedItem is not MonHocDTO monHoc)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var nhomHocPhanIds = clbNhomHocPhan.CheckedItems.Cast<NhomHocPhanDTO>().Select(x => x.MaNhom).ToList();
            if (nhomHocPhanIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhóm học phần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var chuongIds = clbChuong.CheckedItems.Cast<ChuongDTO>().Select(x => x.MaChuong).ToList();
            if (chuongIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo DTO đề thi
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
                NhomHocPhanIds = nhomHocPhanIds,
                ChuongIds = chuongIds,
                CauHinh = new DeThiCauHinhDTO
                {
                    TuDongLay = swTuDongLay.Checked,
                    XemDiemSauThi = swXemDiem.Checked,
                    XemDapAnSauThi = swXemDapAn.Checked,
                    XemBaiLam = swXemBaiLam.Checked,
                    DaoCauHoi = swDaoCauHoi.Checked,
                    DaoDapAn = swDaoDapAn.Checked,
                    TuDongNop = swTuDongNop.Checked,
                }
            };

            // Bước 1: Insert de_thi
            long maDe = deThiBLL.CreateDeThi(deThi);
            if (maDe <= 0)
            {
                MessageBox.Show("Tạo đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bước 5: Nếu tự động lấy câu hỏi
            if (deThi.CauHinh.TuDongLay)
            {
                var cauHoiBLL = new CauHoiBLL();
                // Lấy câu hỏi theo chương và trạng thái = 1
                var allCauHoi = cauHoiBLL.GetCauHoiByChuongAndTrangThai(chuongIds, 1);

                // Lấy random theo độ khó
                var cauDe = allCauHoi.Where(x => x.DoKho == "Dễ").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauDe).ToList();
                var cauTB = allCauHoi.Where(x => x.DoKho == "Trung bình").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauTrungBinh).ToList();
                var cauKho = allCauHoi.Where(x => x.DoKho == "Khó").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauKho).ToList();

                var cauHoiIds = cauDe.Concat(cauTB).Concat(cauKho).Select(x => x.MaCauHoi).ToList();

                // Bước 7: Insert vào de_thi_cau_hoi
                var deThiCauHoiBLL = new DeThiBLL();
                deThiCauHoiBLL.InsertDeThiCauHoi(maDe, cauHoiIds);
            }
            else
            {
                // Nếu thủ công: chuyển sang trang chọn câu hỏi cho đề thi
                MessageBox.Show("Chuyển sang trang chọn câu hỏi thủ công (chưa triển khai).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Hiển thị giao diện chọn câu hỏi thủ công
            }

            MessageBox.Show("Tạo đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
