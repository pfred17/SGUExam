using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.modules
{
    public partial class SuaCauHoiVaoDeThi : UserControl
    {
        private readonly DeThiDTO _deThi;
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly DeThiBLL _deThiBLL = new DeThiBLL();

        private List<CauHoiDTO> _allQuestions = new();      // chỉ câu hỏi theo bộ lọc hiện tại
        private List<CauHoiDTO> _questionPool = new();      // toàn bộ câu hỏi thuộc đề thi
        private List<long> _selectedQuestionIds = new();    // danh sách câu hỏi đã chọn

        // Paging fields
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 1;

        private Label lblPaging = new Label();

        public SuaCauHoiVaoDeThi(DeThiDTO deThi)
        {
            InitializeComponent();
            _deThi = deThi;

            // Event bindings
            cbChuong.SelectedIndexChanged += (s, e) => { _currentPage = 1; LoadQuestions(); };
            cbDoKho.SelectedIndexChanged += (s, e) => { _currentPage = 1; LoadQuestions(); };
            txtSearch.TextChanged += (s, e) => { _currentPage = 1; LoadQuestions(); };

            btnTaoDeThi.Click += btnTaoDeThi_Click;

            btnFirst.Click += btnFirst_Click;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
            btnLast.Click += btnLast_Click;

            this.Load += SuaCauHoiVaoDeThi_Load;
        }

        private void SuaCauHoiVaoDeThi_Load(object sender, EventArgs e)
        {
            LoadChuongToCombo();
            LoadDoKhoToCombo();

            // 🔥 Load toàn bộ câu hỏi một lần duy nhất
            _questionPool = _cauHoiBLL.GetCauHoiByChuongAndTrangThai(_deThi.ChuongIds, 1);

            // Load các câu hỏi đã chọn của đề thi (nếu có)
            var currentQuestions = _deThiBLL.GetCauHoiTheoDeThi(_deThi.MaDe);
            _selectedQuestionIds = currentQuestions.Select(q => q.MaCauHoi).ToList();

            UpdateDeThiInfoLabels();
            UpdateSelectedQuestionLabel();
            LoadQuestions();
        }

        private void LoadChuongToCombo()
        {
            cbChuong.Items.Clear();
            var chuongBLL = new ChuongBLL();

            var chuongList = _deThi.ChuongIds
                .Select(id => chuongBLL.GetChuongById(id))
                .Where(c => c != null)
                .ToList();

            foreach (var chuong in chuongList)
                cbChuong.Items.Add(chuong);

            cbChuong.DisplayMember = "TenChuong";
            cbChuong.ValueMember = "MaChuong";

            if (cbChuong.Items.Count > 0)
                cbChuong.SelectedIndex = 0;
        }

        private void LoadDoKhoToCombo()
        {
            cbDoKho.Items.Clear();
            cbDoKho.Items.AddRange(new object[] { "Tất cả", "Dễ", "Trung bình", "Khó" });
            cbDoKho.SelectedIndex = 0;
        }

        private void LoadQuestions()
        {
            var selectedChuong = cbChuong.SelectedItem as ChuongDTO;

            var chuongIds = selectedChuong != null
                ? new List<long> { selectedChuong.MaChuong }
                : _deThi.ChuongIds;

            string doKho = cbDoKho.SelectedItem?.ToString() ?? "";
            string keyword = txtSearch.Text.Trim();

            // Lọc câu hỏi theo chương
            var filteredQuestions = _cauHoiBLL.GetCauHoiByChuongAndTrangThai(chuongIds, 1);

            // Lọc độ khó
            if (doKho != "Tất cả")
                filteredQuestions = filteredQuestions.Where(q => q.DoKho == doKho).ToList();

            // Lọc tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
                filteredQuestions = filteredQuestions
                    .Where(q => q.NoiDung.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            _allQuestions = filteredQuestions;

            // Paging
            int totalQuestions = _allQuestions.Count;
            _totalPages = (int)Math.Ceiling((double)totalQuestions / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            var pagedQuestions = _allQuestions
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            DisplayQuestions(pagedQuestions);
            UpdatePagingControls();
        }

        private void DisplayQuestions(List<CauHoiDTO> questions)
        {
            flpQuestions.Controls.Clear();

            foreach (var q in questions)
            {
                var chk = new CheckBox
                {
                    Text = $"[{q.DoKho}] {q.NoiDung}",
                    Tag = q.MaCauHoi,
                    Checked = _selectedQuestionIds.Contains(q.MaCauHoi),
                    AutoSize = true
                };

                chk.CheckedChanged += (s, e) =>
                {
                    int max = q.DoKho switch
                    {
                        "Dễ" => _deThi.SoCauDe,
                        "Trung bình" => _deThi.SoCauTrungBinh,
                        "Khó" => _deThi.SoCauKho,
                        _ => 0
                    };

                    int current = GetSelectedCount(q.DoKho);

                    if (chk.Checked)
                    {
                        if (current >= max)
                        {
                            MessageBox.Show($"Chỉ được chọn tối đa {max} câu {q.DoKho.ToLower()}!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            chk.Checked = false;
                            return;
                        }

                        if (!_selectedQuestionIds.Contains(q.MaCauHoi))
                            _selectedQuestionIds.Add(q.MaCauHoi);
                    }
                    else
                    {
                        _selectedQuestionIds.Remove(q.MaCauHoi);
                    }

                    UpdateDeThiInfoLabels();
                    UpdateSelectedQuestionLabel()
                };

                flpQuestions.Controls.Add(chk);
            }
        }

        private int GetSelectedCount(string doKho)
        {
            return _selectedQuestionIds
                .Select(id => _questionPool.FirstOrDefault(q => q.MaCauHoi == id))
                .Count(q => q != null && q.DoKho == doKho);
        }

        private void UpdateDeThiInfoLabels()
        {
            lblSoLuongDe.Text = $"DỄ {GetSelectedCount("Dễ")}/{_deThi.SoCauDe}";
            lblSoLuongTB.Text = $"TB {GetSelectedCount("Trung bình")}/{_deThi.SoCauTrungBinh}";
            lblSoLuongKho.Text = $"KHÓ {GetSelectedCount("Khó")}/{_deThi.SoCauKho}";

            lblTenDeThi.Text = _deThi.TenDe ?? "";
            lblThoiGian.Text = $"Thời gian: {_deThi.ThoiGianLamBai} phút";
        }
        private void UpdateSelectedQuestionLabel()
        {
            lblChuaCoCauHoi.Text = _selectedQuestionIds.Count == 0
                ? "Chưa có câu hỏi nào được chọn"
                : $"Đã chọn {_selectedQuestionIds.Count} câu hỏi";
        }
        // Paging handlers
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (_currentPage != 1)
            {
                _currentPage = 1;
                LoadQuestions();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadQuestions();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadQuestions();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (_currentPage != _totalPages)
            {
                _currentPage = _totalPages;
                LoadQuestions();
            }
        }

        private void UpdatePagingControls()
        {
            lblPaging.Text = $"Trang {_currentPage}/{_totalPages}";

            btnFirst.Enabled = _currentPage > 1;
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
            btnLast.Enabled = _currentPage < _totalPages;
        }

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            int de = GetSelectedCount("Dễ");
            int tb = GetSelectedCount("Trung bình");
            int kho = GetSelectedCount("Khó");

            if (de != _deThi.SoCauDe || tb != _deThi.SoCauTrungBinh || kho != _deThi.SoCauKho)
            {
                MessageBox.Show("Số lượng câu hỏi đã chọn chưa đủ theo cấu hình đề thi!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa toàn bộ câu hỏi cũ của đề thi và thêm mới
            _deThiBLL.DeleteDeThiCauHoi(_deThi.MaDe);
            _deThiBLL.InsertDeThiCauHoi(_deThi.MaDe, _selectedQuestionIds);

            MessageBox.Show("Cập nhật câu hỏi cho đề thi thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
