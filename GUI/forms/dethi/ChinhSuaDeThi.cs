using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.modules
{
    public partial class ChinhSuaDeThi : UserControl
    {
        private readonly DeThiBLL deThiBLL = new DeThiBLL();
        private readonly MonHocBLL monHocBLL = new MonHocBLL();
        private readonly NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private readonly ChuongBLL chuongBLL = new ChuongBLL();
        private readonly long _maDe; 

        public ChinhSuaDeThi(long maDe)
        {
            _maDe = maDe;
            InitializeComponent();
            LoadData();
            btnTaoDe.Click += BtnTaoDe_Click;
        }

        private void LoadData()
        {
            // 1. Lấy dữ liệu đề thi từ maDe
            var deThi = deThiBLL.GetFullDetailById(_maDe);
            if (deThi == null)
            {
                MessageBox.Show("Không tìm thấy đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Load tất cả môn học
            var monList = monHocBLL.GetAllMonHocByStatus(1);
            cbMonHoc.DataSource = monList;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";

            // Gán event khi chọn môn học
            cbMonHoc.SelectedIndexChanged -= cbMonHoc_SelectedIndexChanged;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;

            // 3. Chọn môn học dựa vào nhóm học phần đầu tiên
            if (deThi.NhomHocPhanIds != null && deThi.NhomHocPhanIds.Count > 0)
            {
                var nhom = nhomHocPhanBLL.GetById(deThi.NhomHocPhanIds[0]);
                if (nhom != null)
                {
                    cbMonHoc.SelectedValue = nhom.MaMH;
                }
            }
            else
            {
                cbMonHoc.SelectedIndex = -1;
            }

            // 4. Load nhóm học phần và chương theo môn học đã chọn
            if (cbMonHoc.SelectedItem is MonHocDTO selectedMonHoc)
            {
                // Nhóm học phần
                var nhomList = nhomHocPhanBLL.GetByMonHoc(selectedMonHoc.MaMH)
                    .Where(x => x.TrangThai == 1)
                    .ToList();
                clbNhomHocPhan.Items.Clear();
                foreach (var nhom in nhomList)
                {
                    clbNhomHocPhan.Items.Add(nhom, deThi.NhomHocPhanIds != null && deThi.NhomHocPhanIds.Contains(nhom.MaNhom));
                }
                clbNhomHocPhan.DisplayMember = "TenNhom";

                // Chương
                var chuongList = chuongBLL.GetChuongByMonHoc(selectedMonHoc.MaMH);
                clbChuong.Items.Clear();
                foreach (var chuong in chuongList)
                {
                    clbChuong.Items.Add(chuong, deThi.ChuongIds != null && deThi.ChuongIds.Contains(chuong.MaChuong));
                }
                clbChuong.DisplayMember = "TenChuong";
            }
            else
            {
                clbNhomHocPhan.Items.Clear();
                clbChuong.Items.Clear();
            }

            // 5. Các trường thông tin đề thi
            txtTenDe.Text = deThi.TenDe ?? "";
            dtpTu.Value = deThi.ThoiGianBatDau ?? DateTime.Now;
            dtpDen.Value = deThi.ThoiGianKetThuc ?? DateTime.Now.AddHours(1);
            numThoiGianLamBai.Value = deThi.ThoiGianLamBai > 0 ? deThi.ThoiGianLamBai : 60;
            numCanhBao.Value = deThi.CanhBaoNeuDuoi > 0 ? deThi.CanhBaoNeuDuoi : 0;
            numDe.Value = deThi.SoCauDe > 0 ? deThi.SoCauDe : 0;
            numTrungBinh.Value = deThi.SoCauTrungBinh > 0 ? deThi.SoCauTrungBinh : 0;
            numKho.Value = deThi.SoCauKho > 0 ? deThi.SoCauKho : 0;

            // 6. Cấu hình đề thi
            if (deThi.CauHinh != null)
            {
                swTuDongLay.Checked = deThi.CauHinh.TuDongLay;
                swXemDiem.Checked = deThi.CauHinh.XemDiemSauThi;
                swXemDapAn.Checked = deThi.CauHinh.XemDapAnSauThi;
                swXemBaiLam.Checked = deThi.CauHinh.XemBaiLam;
                swDaoCauHoi.Checked = deThi.CauHinh.DaoCauHoi;
                swDaoDapAn.Checked = deThi.CauHinh.DaoDapAn;
                swTuDongNop.Checked = deThi.CauHinh.TuDongNop;
                // Nếu có thêm các switch khác, set ở đây
            }
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
                MaDe = _maDe, // Sử dụng mã đề hiện tại
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
                bool updateOk = deThiBLL.UpdateDeThi(deThi);
                if (!updateOk)
                {
                    MessageBox.Show("Cập nhật đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Cập nhật đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void BtnChinhSuaCauHoi_Click(object sender, EventArgs e)
        {
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

            // Tạo DTO đề thi với thông tin hiện tại
            var deThi = new DeThiDTO
            {
                MaDe = _maDe, // Sử dụng mã đề hiện tại
                TenDe = txtTenDe.Text.Trim(),
                ThoiGianBatDau = dtpTu.Value,
                ThoiGianKetThuc = dtpDen.Value,
                ThoiGianLamBai = (int)numThoiGianLamBai.Value,
                CanhBaoNeuDuoi = (int)numCanhBao.Value,
                SoCauDe = (int)numDe.Value,
                SoCauTrungBinh = (int)numTrungBinh.Value,
                SoCauKho = (int)numKho.Value,
                NhomHocPhanIds = clbNhomHocPhan.CheckedItems.Cast<NhomHocPhanDTO>().Select(x => x.MaNhom).ToList(),
                ChuongIds = clbChuong.CheckedItems.Cast<ChuongDTO>().Select(x => x.MaChuong).ToList(),
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

            // Chuyển sang giao diện chọn câu hỏi thủ công, truyền MaDe để update
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                var ucThemCauHoi = new SuaCauHoiVaoDeThi(deThi);
                mainForm.LoadModule(ucThemCauHoi);
            }
        }
    }
}
