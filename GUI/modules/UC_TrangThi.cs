using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace GUI.modules
{
    public partial class UC_TrangThi : UserControl
    {
        private readonly DeThiBLL _deThiBLL = new DeThiBLL();
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly DapAnBLL _dapAnBLL = new DapAnBLL();
        private readonly BaiLamBLL _baiLamBLL = new BaiLamBLL();
        private readonly ChiTietBaiLamBLL _chiTietBaiLamBLL = new ChiTietBaiLamBLL();
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly DeThiCauHinhBLL _deThiCauHinhBLL = new DeThiCauHinhBLL();

        private long _maDe;
        private string _userId;
        private List<CauHoiDTO> _dsCauHoi = new();
        private int _cauHienTai = 0;
        private Timer _timer;
        private TimeSpan _thoiGianConLai;
        private DeThiDTO _deThi;
        private UserDTO _user;
        private DeThiCauHinhDTO _cauHinh;

        public UC_TrangThi(long maDe, string userId)
        {
            InitializeComponent();
            _maDe = maDe;
            _userId = userId;
            _user = _userBLL.GetUserById(_userId);
            _cauHinh = _deThiCauHinhBLL.GetByMaDe(_maDe);
            LoadDeThi();
        }

        private void LoadDeThi()
        {
            _deThi = _deThiBLL.GetAll().FirstOrDefault(d => d.MaDe == _maDe);
            if (_deThi == null)
            {
                MessageBox.Show("Không tìm thấy đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách câu hỏi theo đề thi
            _dsCauHoi = _deThiBLL.GetCauHoiTheoDeThi(_maDe);

            // Gán đáp án cho từng câu hỏi
            foreach (var cauHoi in _dsCauHoi)
            {
                var dapAnList = _dapAnBLL.GetByCauHoi(cauHoi.MaCauHoi);
                cauHoi.DapAnList = dapAnList.Select(da => da.NoiDung).ToList();
                cauHoi.DapAnIds = dapAnList.Select(da => da.MaDapAn).ToList();
                cauHoi.DapAnChon = -1;
            }

            _thoiGianConLai = TimeSpan.FromMinutes(_deThi.ThoiGianLamBai);
            lblMaMon.Text = $"Mã môn: {_deThi.MaDe}";
            lblMon.Text = $"Môn: {_deThi.TenDe}";
            lblMSSV.Text = $"MSSV: {_user.MSSV}";
            lblHoTen.Text = $"Họ tên: {_user.HoTen}";
            lblSoCau.Text = $"Số câu: {_dsCauHoi.Count}";
            lblNgayThi.Text = $"Ngày thi: {DateTime.Now:dd-MM-yyyy}";
            lblThoiGian.Text = $"Thời gian còn lại: {_thoiGianConLai:hh\\:mm\\:ss}";

            btnTruoc.Click += (s, e) => ChuyenCau(-1);
            btnTiep.Click += (s, e) => ChuyenCau(1);
            btnNopBai.Click += (s, e) => NopBai();

            StartTimer();
            HienThiCauHoi();
        }

        private void HienThiCauHoi()
        {
            if (_dsCauHoi.Count == 0) return;
            var cau = _dsCauHoi[_cauHienTai];
            lblCauSo.Text = $"Câu {_cauHienTai + 1}";
            lblNoiDung.Text = cau.NoiDung;
            for (int i = 0; i < radioDapAn.Count; i++)
            {
                radioDapAn[i].Text = $"{(char)('A' + i)}. {cau.DapAnList.ElementAtOrDefault(i)}";
                radioDapAn[i].Checked = (cau.DapAnChon == i);
            }
            btnTruoc.Enabled = _cauHienTai > 0;
            btnTiep.Enabled = _cauHienTai < _dsCauHoi.Count - 1;
        }

        private void ChuyenCau(int delta)
        {
            for (int i = 0; i < radioDapAn.Count; i++)
                if (radioDapAn[i].Checked)
                    _dsCauHoi[_cauHienTai].DapAnChon = i;

            _cauHienTai += delta;
            HienThiCauHoi();
        }

        private void StartTimer()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) =>
            {
                _thoiGianConLai = _thoiGianConLai.Add(TimeSpan.FromSeconds(-1));
                lblThoiGian.Text = $"Thời gian còn lại: {_thoiGianConLai:hh\\:mm\\:ss}";
                if (_thoiGianConLai.TotalSeconds <= 0)
                {
                    _timer.Stop();
                    NopBai();
                }
            };
            _timer.Start();
        }

        private void NopBai()
        {
            // Kiểm tra đã chọn hết đáp án
            var cauChuaChon = _dsCauHoi.Where(c => c.DapAnChon < 0).ToList();
            if (cauChuaChon.Count > 0)
            {
                MessageBox.Show("Bạn phải chọn đáp án cho tất cả các câu hỏi trước khi nộp bài!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thời gian làm bài tối thiểu
            int thoiGianLam = (int)(_deThi.ThoiGianLamBai - _thoiGianConLai.TotalMinutes);
            if (thoiGianLam < _deThi.CanhBaoNeuDuoi)
            {
                MessageBox.Show($"Bạn phải làm bài ít nhất {_deThi.CanhBaoNeuDuoi} phút mới được nộp!\nThời gian bạn đã làm: {thoiGianLam} phút.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính điểm
            int soCauDung = 0;
            foreach (var cau in _dsCauHoi)
            {
                var dapAnList = _dapAnBLL.GetByCauHoi(cau.MaCauHoi);
                var dapAnChon = (cau.DapAnChon >= 0 && cau.DapAnIds.Count > cau.DapAnChon)
                    ? dapAnList.FirstOrDefault(da => da.MaDapAn == cau.DapAnIds[cau.DapAnChon])
                    : null;
                if (dapAnChon != null && dapAnChon.Dung)
                    soCauDung++;
            }
            decimal diem = Math.Round((decimal)soCauDung / _dsCauHoi.Count * 10, 2);

            _timer.Stop();
            var baiLam = new BaiLamDTO
            {
                MaDe = _maDe,
                MaNguoiDung = _userId,
                ThoiGianBatDau = DateTime.Now.Subtract(_thoiGianConLai),
                ThoiGianNop = DateTime.Now,
                Diem = diem
            };
            long maBai = _baiLamBLL.Insert(baiLam);

            foreach (var cau in _dsCauHoi)
            {
                var chiTiet = new ChiTietBaiLamDTO
                {
                    MaBai = maBai,
                    MaCauHoi = cau.MaCauHoi,
                    MaDapAnChon = (cau.DapAnChon >= 0 && cau.DapAnIds.Count > cau.DapAnChon)
                        ? cau.DapAnIds[cau.DapAnChon]
                        : (long?)null
                };
                _chiTietBaiLamBLL.Insert(chiTiet);
            }

            MessageBox.Show($"Bạn đã nộp bài!", "Thông báo", MessageBoxButtons.OK);
            this.ParentForm?.Close();
            var ketQuaForm = new GUI.forms.dethi.KetQuaBaiThi(_dsCauHoi, soCauDung, diem, _user, _cauHinh);
            ketQuaForm.ShowDialog();
        }


    }
}
