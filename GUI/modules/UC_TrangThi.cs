using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Timer = System.Windows.Forms.Timer;

namespace GUI.modules
{
    public partial class UC_TrangThi : UserControl
    {
        // BLL instances
        private readonly DeThiBLL _deThiBLL = new DeThiBLL();
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly DapAnBLL _dapAnBLL = new DapAnBLL();
        private readonly BaiLamBLL _baiLamBLL = new BaiLamBLL();
        private readonly ChiTietBaiLamBLL _chiTietBaiLamBLL = new ChiTietBaiLamBLL();
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly DeThiCauHinhBLL _deThiCauHinhBLL = new DeThiCauHinhBLL();

        // State
        private long _maDe;
        private string _userId;
        private List<CauHoiDTO> _dsCauHoi = new List<CauHoiDTO>();
        private int _cauHienTai = 0;
        private Timer _timer;
        private TimeSpan _thoiGianConLai;
        private DeThiDTO _deThi;
        private UserDTO _user;
        private DeThiCauHinhDTO _cauHinh;

        // Dynamic controls
        private List<(Guna2Panel panel, Guna2RadioButton radio, Label lbl)> radioDapAnPanels = new();
        private List<Guna2CircleButton> _btnDanhSachCau = new List<Guna2CircleButton>();

        public UC_TrangThi(long maDe, string userId)
        {
            InitializeComponent();

            _maDe = maDe;
            _userId = userId;

            // Prepare events
            //this.Load += UC_TrangThi_Load;
            btnTruoc.Click += BtnTruoc_Click;
            btnTiep.Click += BtnTiep_Click;
            btnNopBai.Click += BtnNopBai_Click;
        }

        //private void UC_TrangThi_Load(object sender, EventArgs e)
        //{
        //    _user = _userBLL.GetUserById(_userId);
        //    _cauHinh = _deThiCauHinhBLL.GetByMaDe(_maDe);

        //    LoadDeThi();
        //    CreateNavigationButtons();
        //    UpdateNavigationVisuals();
        //    StartTimer();
        //    CenterSubmitButton();
        //}

        private void LoadDeThi()
        {
            _deThi = _deThiBLL.GetAll().FirstOrDefault(d => d.MaDe == _maDe);
            if (_deThi == null)
            {
                MessageBox.Show("Không tìm thấy đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dsCauHoi = _deThiBLL.GetCauHoiTheoDeThi(_maDe);

            // Xóa radio đáp án cũ
            foreach (var item in radioDapAnPanels) panelCauHoi.Controls.Remove(item.panel);
            radioDapAnPanels.Clear();

            int radioStartY = lblNoiDung.Location.Y + lblNoiDung.Size.Height + 20;

            for (int i = 0; i < 4; i++)
            {
                var pnl = new Guna2Panel
                {
                    Width = 900,
                    Height = 60,
                    Location = new Point(40, radioStartY + i * 70),
                    BorderColor = Color.Silver,
                    BorderThickness = 1,
                    BorderRadius = 8,
                    FillColor = Color.Transparent
                };

                var radio = new Guna2RadioButton
                {
                    Font = new Font("Segoe UI", 14),
                    Location = new Point(18, 18),
                    Width = 30,
                    Height = 30,
                    Tag = i
                };

                var lbl = new Label
                {
                    Font = new Font("Segoe UI", 14),
                    AutoSize = false,
                    Location = new Point(60, 10),
                    Width = pnl.Width - 80,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                pnl.Click += PnlOrLbl_Click;
                lbl.Click += PnlOrLbl_Click;
                radio.CheckedChanged += RadioDapAn_CheckedChanged;

                pnl.Controls.Add(radio);
                pnl.Controls.Add(lbl);
                panelCauHoi.Controls.Add(pnl);


                radioDapAnPanels.Add((pnl, radio, lbl));
            }

            foreach (var cau in _dsCauHoi)
            {
                var dapAnList = _dapAnBLL.GetByCauHoi(cau.MaCauHoi);
                cau.DapAnList = dapAnList.Select(da => da.NoiDung).ToList();
                cau.DapAnIds = dapAnList.Select(da => da.MaDapAn).ToList();
                cau.DapAnChon = -1;
            }

            lblMaMon.Text = $"Mã đề: {_deThi.MaDe}";
            lblMon.Text = $"Tên đề: {_deThi.TenDe}";
            lblMSSV.Text = _user != null ? $"MSSV: {_user.MSSV}" : "MSSV: -";
            lblHoTen.Text = _user != null ? $"Họ tên: {_user.HoTen}" : "Họ tên: -";
            lblSoCau.Text = $"Số câu: {_dsCauHoi.Count}";
            lblNgayThi.Text = $"Ngày thi: {DateTime.Now:dd/MM/yyyy}";
            _thoiGianConLai = TimeSpan.FromMinutes(_deThi.ThoiGianLamBai > 0 ? _deThi.ThoiGianLamBai : 60);
            lblThoiGian.Text = $"Thời gian còn: {_thoiGianConLai:hh\\:mm\\:ss}";

            _cauHienTai = 0;
            HienThiCauHoi();
        }

        private void HienThiCauHoi()
        {
            if (_dsCauHoi == null || _dsCauHoi.Count == 0)
            {
                lblCauSo.Text = "";
                lblNoiDung.Text = "Không có câu hỏi nào.";
                foreach (var item in radioDapAnPanels) item.panel.Visible = false;
                return;
            }

            var cau = _dsCauHoi[_cauHienTai];

            lblCauSo.Text = $"Câu {_cauHienTai + 1}/{_dsCauHoi.Count}";
            lblNoiDung.Text = cau.NoiDung;

            for (int i = 0; i < radioDapAnPanels.Count; i++)
            {
                var item = radioDapAnPanels[i];
                bool visible = i < cau.DapAnList.Count;
                item.panel.Visible = visible;
                if (visible)
                {
                    item.lbl.Text = $"{(char)('A' + i)}. {cau.DapAnList[i]}";
                    item.radio.Checked = (cau.DapAnChon == i);
                    item.panel.BorderColor = (cau.DapAnChon == i) ? Color.LimeGreen : Color.Silver;
                    item.panel.BorderThickness = (cau.DapAnChon == i) ? 2 : 1;
                }
            }

            btnTruoc.Enabled = _cauHienTai > 0;
            btnTiep.Enabled = _cauHienTai < _dsCauHoi.Count - 1;

            UpdateNavigationVisuals();
        }

        private void CreateNavigationButtons()
        {
            flowPanelSoCau.Controls.Clear();
            _btnDanhSachCau.Clear();

            if (_dsCauHoi == null) return;

            for (int i = 0; i < _dsCauHoi.Count; i++)
            {
                var btn = new Guna2CircleButton
                {
                    Text = (i + 1).ToString(),
                    Size = new Size(60, 60),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    FillColor = Color.White,
                    ForeColor = Color.FromArgb(30, 30, 30),
                    BorderColor = Color.FromArgb(0, 122, 255),
                    BorderThickness = 2,
                    ShadowDecoration = { Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle },
                    Cursor = Cursors.Hand,
                    Margin = new Padding(6)
                };

                btn.HoverState.FillColor = Color.FromArgb(0, 122, 255);
                btn.HoverState.ForeColor = Color.White;
                btn.HoverState.BorderColor = Color.FromArgb(0, 122, 255);

                int index = i;
                btn.Click += (s, e) => NavigateToQuestion(index);

                _btnDanhSachCau.Add(btn);
                flowPanelSoCau.Controls.Add(btn);
            }
        }

        private void NavigateToQuestion(int index)
        {
            SaveCurrentSelectedAnswer();
            _cauHienTai = Math.Max(0, Math.Min(index, _dsCauHoi.Count - 1));
            HienThiCauHoi();
        }

        private void UpdateNavigationVisuals()
        {
            if (_dsCauHoi == null || _dsCauHoi.Count == 0)
                return;

            if (_btnDanhSachCau == null || _btnDanhSachCau.Count != _dsCauHoi.Count)
                CreateNavigationButtons();

            for (int i = 0; i < _dsCauHoi.Count; i++)
            {
                var btn = _btnDanhSachCau[i];
                btn.FillColor = Color.White;
                btn.ForeColor = Color.Black;

                if (_dsCauHoi[i].DapAnChon >= 0)
                {
                    btn.FillColor = Color.FromArgb(132, 209, 132); // Correctly answered/selected
                    btn.ForeColor = Color.Black;
                }
                else
                {
                    btn.FillColor = Color.White; // Not yet selected
                }

                if (i == _cauHienTai)
                {
                    btn.FillColor = Color.FromArgb(255, 223, 93); // Current question
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void RadioDapAn_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as Guna2RadioButton;
            // Kiểm tra nếu sự kiện này được kích hoạt bởi việc uncheck, thì bỏ qua.
            if (radio == null || !radio.Checked) return;

            // Chỉ cho chọn 1 đáp án
            for (int i = 0; i < radioDapAnPanels.Count; i++)
            {
                var item = radioDapAnPanels[i];
                if (item.radio == radio)
                {
                    // Radio đang được chọn
                    item.panel.BorderColor = Color.LimeGreen;
                    item.panel.BorderThickness = 2;
                    _dsCauHoi[_cauHienTai].DapAnChon = i;
                }
                else
                {
                    // Radio KHÔNG được chọn -> Bắt buộc uncheck và reset giao diện
                    item.radio.Checked = false; // <--- DÒNG CẦN THIẾT ĐỂ BẮT BUỘC BỎ CHỌN CÁC RADIO KHÁC
                    item.panel.BorderColor = Color.Silver;
                    item.panel.BorderThickness = 1;
                }
            }

            UpdateNavigationVisuals();
        }

        private void SaveCurrentSelectedAnswer()
        {
            // The DapAnChon state is already updated in RadioDapAn_CheckedChanged,
            // but this ensures the state is saved when navigating away (e.g., using 'Trước' or 'Tiếp')
            // by explicitly checking the state one last time.

            // Reset selection first
            _dsCauHoi[_cauHienTai].DapAnChon = -1;

            for (int i = 0; i < radioDapAnPanels.Count; i++)
            {
                // Check the radio button component in the tuple
                if (radioDapAnPanels[i].radio.Checked)
                {
                    _dsCauHoi[_cauHienTai].DapAnChon = i;
                    return;
                }
            }
        }
        private void PnlOrLbl_Click(object sender, EventArgs e)
        {
            Guna2Panel panelContainer = null;

            if (sender is Guna2Panel pnl)
            {
                // Người dùng click vào Panel
                panelContainer = pnl;
            }
            else if (sender is Label lbl)
            {
                // Người dùng click vào Label, tìm Panel cha (Parent)
                panelContainer = lbl.Parent as Guna2Panel;
            }

            if (panelContainer != null)
            {
                // Tìm Guna2RadioButton bên trong Panel
                var radio = panelContainer.Controls.OfType<Guna2RadioButton>().FirstOrDefault();

                if (radio != null && !radio.Checked)
                {
                    // Nếu RadioButton chưa được chọn, thì chọn nó.
                    radio.Checked = true;

                    // Logic trong RadioDapAn_CheckedChanged sẽ tự động xử lý việc uncheck các radio khác.
                }
            }
        }

        private void BtnTruoc_Click(object sender, EventArgs e)
        {
            SaveCurrentSelectedAnswer();
            if (_cauHienTai > 0)
            {
                _cauHienTai--;
                HienThiCauHoi();
            }
        }

        private void BtnTiep_Click(object sender, EventArgs e)
        {
            SaveCurrentSelectedAnswer();
            if (_cauHienTai < _dsCauHoi.Count - 1)
            {
                _cauHienTai++;
                HienThiCauHoi();
            }
        }

        private void StartTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= Timer_Tick;
                _timer.Dispose();
            }

            _timer = new Timer { Interval = 1000 };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_thoiGianConLai.TotalSeconds <= 0)
            {
                _timer.Stop();
                MessageBox.Show("Hết giờ. Bài thi sẽ được nộp tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitAndClose();
                return;
            }

            _thoiGianConLai = _thoiGianConLai.Add(TimeSpan.FromSeconds(-1));
            lblThoiGian.Text = $"Thời gian còn: {_thoiGianConLai:hh\\:mm\\:ss}";
        }

        private void BtnNopBai_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc muốn nộp bài không?", "Xác nhận nộp bài", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            SubmitAndClose();
        }

        private void SubmitAndClose()
        {
            // Always save the current answer before submission
            SaveCurrentSelectedAnswer();

            var chuaChon = _dsCauHoi.Where(c => c.DapAnChon < 0).ToList();
            if (chuaChon.Count > 0)
            {
                // Note: The original code forces answering all questions before submission.
                // If this is the desired business logic, this check is correct.
                MessageBox.Show($"Bạn phải trả lời tất cả các câu hỏi trước khi nộp bài!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soCauDung = 0;
            for (int i = 0; i < _dsCauHoi.Count; i++)
            {
                var cau = _dsCauHoi[i];
                if (cau.DapAnChon >= 0 && cau.DapAnChon < cau.DapAnIds.Count)
                {
                    long maDachon = cau.DapAnIds[cau.DapAnChon];
                    var dapAnList = _dapAnBLL.GetByCauHoi(cau.MaCauHoi);
                    var dapAn = dapAnList.FirstOrDefault(da => da.MaDapAn == maDachon);
                    if (dapAn != null && dapAn.Dung) soCauDung++;
                }
            }

            decimal diem = Math.Round((decimal)soCauDung / (_dsCauHoi.Count == 0 ? 1 : _dsCauHoi.Count) * 10, 2);

            var baiLam = new BaiLamDTO
            {
                MaDe = _maDe,
                MaNguoiDung = _userId,
                // The original code calculated ThoiGianBatDau as Now - ThoiGianConLai, which seems correct for a running timer
                ThoiGianBatDau = DateTime.Now.Subtract(_thoiGianConLai),
                ThoiGianNop = DateTime.Now,
                Diem = diem
            };

            long maBai = _baiLamBLL.Insert(baiLam);

            foreach (var cau in _dsCauHoi)
            {
                long? maDapAnChon = null;
                if (cau.DapAnChon >= 0 && cau.DapAnChon < cau.DapAnIds.Count)
                    maDapAnChon = cau.DapAnIds[cau.DapAnChon];

                var ct = new ChiTietBaiLamDTO
                {
                    MaBai = maBai,
                    MaCauHoi = cau.MaCauHoi,
                    MaDapAnChon = maDapAnChon
                };
                _chiTietBaiLamBLL.Insert(ct);
            }

            _timer?.Stop();
            MessageBox.Show($"Nộp bài thành công! Điểm của bạn: {diem}", "Kết thúc", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                // Assuming GUI.forms.dethi.KetQuaBaiThi is a valid form class
                var form = new GUI.forms.dethi.KetQuaBaiThi(_dsCauHoi, soCauDung, diem, _user, _cauHinh);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                // Handle potential error in showing the results form
                Console.WriteLine($"Error showing results form: {ex.Message}");
            }

            this.ParentForm?.Close();
        }

        // Center submit button inside panelSubmitHolder
        private void CenterSubmitButton()
        {
            if (panelSubmitHolder == null || btnNopBai == null) return;
            int left = (panelSubmitHolder.ClientSize.Width - btnNopBai.Width) / 2;
            int top = (panelSubmitHolder.ClientSize.Height - btnNopBai.Height) / 2;
            btnNopBai.Location = new Point(Math.Max(8, left), Math.Max(6, top));
            panelSubmitHolder.Resize -= PanelSubmitHolder_Resize;
            panelSubmitHolder.Resize += PanelSubmitHolder_Resize;
        }

        private void PanelSubmitHolder_Resize(object sender, EventArgs e)
        {
            CenterSubmitButton();
        }
    }
}