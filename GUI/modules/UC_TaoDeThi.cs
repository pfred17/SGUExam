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
        private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private readonly DeThiBLL deThiBLL = new DeThiBLL();
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
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
            cbMonHoc.DisplayMember = "TenMonHoc";
            cbMonHoc.ValueMember = "MaMonHoc";
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
                var nhomList = nhomHocPhanBLL.GetByMonHoc(monHoc.MaMonHoc)
                    .Where(x => x.TrangThai == 1)
                    .ToList();
                clbNhomHocPhan.Items.Clear();
                foreach (var nhom in nhomList)
                {
                    clbNhomHocPhan.Items.Add(nhom, false);  // THÊM OBJECT
                }
                clbNhomHocPhan.DisplayMember = "TenNhom";   // HIỂN THỊ


                // Load chương của môn học
                var chuongList = chuongBLL.GetChuongByMonHoc(monHoc.MaMonHoc);
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
            if (dtpTu.Value < DateTime.Now)
            {
                MessageBox.Show("Thời gian bắt đầu không được nhỏ hơn thời điểm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            int soCauDe = (int)numDe.Value;
            int soCauTrungBinh = (int)numTrungBinh.Value;
            int soCauKho = (int)numKho.Value;

            if (soCauDe <= 0 || soCauTrungBinh <= 0 || soCauKho <= 0)
            {
                MessageBox.Show("Số lượng câu hỏi Dễ, Trung bình, Khó không được để trống hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (deThi.CauHinh.TuDongLay)
            {
                // Bước 1: Insert de_thi ngay
                long maDe = deThiBLL.CreateDeThi(deThi);
                if (maDe <= 0)
                {
                    MessageBox.Show("Tạo đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cauHoiBLL = new CauHoiBLL();
                // Lấy câu hỏi theo chương và trạng thái = 1
                var allCauHoi = cauHoiBLL.GetCauHoiByChuongAndTrangThai(chuongIds, 1);

                // Lấy random theo độ khó
                var cauDe = allCauHoi.Where(x => x.DoKho == "Dễ").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauDe).ToList();
                var cauTB = allCauHoi.Where(x => x.DoKho == "Trung bình").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauTrungBinh).ToList();
                var cauKho = allCauHoi.Where(x => x.DoKho == "Khó").OrderBy(x => Guid.NewGuid()).Take(deThi.SoCauKho).ToList();

                var cauHoiIds = cauDe.Concat(cauTB).Concat(cauKho).Select(x => x.MaCauHoi).ToList();

                // Bước 7: Insert vào de_thi_cau_hoi
                deThiBLL.InsertDeThiCauHoi(maDe, cauHoiIds);

                MessageBox.Show("Tạo đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Quay về UC_KiemTra
                var mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    var ucKiemTra = new GUI.modules.UC_KiemTra("0000000000");
                    ucKiemTra.Dock = DockStyle.Fill;
                    var panelMain = mainForm.Controls["panelMain"];
                    if (panelMain is Panel p)
                    {
                        p.Controls.Clear();
                        p.Controls.Add(ucKiemTra);
                    }
                }
            }
            else
            {
                // Chưa insert de_thi, chuyển sang giao diện chọn câu hỏi thủ công
                var mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    var ucThemCauHoi = new ThemCauHoiVaoDeThi(deThi); // deThi chưa có MaDe
                    mainForm.LoadModule(ucThemCauHoi);

                }
            }
        }
        

    }
}