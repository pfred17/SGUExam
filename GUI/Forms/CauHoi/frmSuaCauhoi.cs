using BLL;
using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sysDraw = System.Drawing;

namespace GUI
{
    public partial class frmSuaCauHoi : Form
    {
        private readonly MonHocBLL _monHocBLL = new();
        private readonly ChuongBLL _chuongBLL = new();
        private readonly CauHoiBLL _cauHoiBLL = new();

        private readonly long _maCauHoi; // ID câu hỏi cần sửa
        private readonly List<DapAnDTO> _dapAnList = new(); // danh sách đáp án tạm thời
        private int _nextTempId = -1; // ID tạm cho đáp án mới

        public frmSuaCauHoi(long maCauHoi)
        {
            InitializeComponent();
            _maCauHoi = maCauHoi;
        }

        // thiết kế load
        private void FrmSuaCauHoi_Load(object? sender, EventArgs e)
        {
            InitCombos();
            pnlDapAnContainer.Controls.Clear();
            LoadCauHoiForEdit();
        }

        private void InitCombos()
        {
            var monList = _monHocBLL.GetAllMonHocByStatus(1);
            cbMonHoc.DataSource = new List<MonHocDTO>(monList);
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";

            cbMonHocFile.DataSource = new List<MonHocDTO>(monList);
            cbMonHocFile.DisplayMember = "TenMH";
            cbMonHocFile.ValueMember = "MaMH";

            LoadDoKhoToCombo(cbDoKho);
        }

        // hàm load câu hỏi để sửa (theo _maCauHoi)
        private void LoadCauHoiForEdit()
        {
            var cauHoi = _cauHoiBLL.GetById(_maCauHoi);
            if (cauHoi == null)
            {
                MessageBox.Show("Câu hỏi không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            cbMonHoc.SelectedIndexChanged -= CbMonHoc_SelectedIndexChanged;
            cbMonHoc.SelectedValue = cauHoi.MaMonHoc;
            LoadChuongToCombo(cbChuong, cauHoi.MaMonHoc);
            // Set chương đúng
            cbChuong.SelectedValue = cauHoi.MaChuong;

            // Delay chọn chương, đảm bảo combo đã có dữ liệu

            cbDoKho.SelectedItem = cbDoKho.Items.Contains(cauHoi.DoKho) ? cauHoi.DoKho : cbDoKho.Items[0];
            rtbNoiDung.Text = cauHoi.NoiDung;

            _dapAnList.Clear();
            _dapAnList.AddRange(_cauHoiBLL.GetDapAn(_maCauHoi));
            RefreshAnswerListUI();

            cbMonHoc.SelectedIndexChanged += CbMonHoc_SelectedIndexChanged;
        }

        private void LoadDoKhoToCombo(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.AddRange(new object[] { "Tất cả", "Dễ", "Trung bình", "Khó" });
            cb.SelectedIndex = 0;
        }

        private void LoadChuongToCombo(ComboBox cb, long maMonHoc)
        {
            var list = new List<ChuongDTO> { new ChuongDTO { MaChuong = 0, TenChuong = "Chọn chương" } };
            if (maMonHoc > 0) list.AddRange(_chuongBLL.GetChuongByMonHoc(maMonHoc));
            cb.DataSource = list;
            cb.DisplayMember = "TenChuong";
            cb.ValueMember = "MaChuong";
        }

        // -------------------------------------------
        // sự kiện form và nút bấm

        private void CbMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbMonHoc.SelectedItem is MonHocDTO m) LoadChuongToCombo(cbChuong, m.MaMH);
        }

        private void CbChuongFile_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // placeholder nếu cần
        }

        private void BtnChonFile_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtDuongDan.Text = openFileDialog1.FileName;
        }

        private void BtnThemVaoHeThong_Click(object? sender, EventArgs e)
        {
            var path = txtDuongDan.Text?.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Vui lòng chọn file .docx chứa câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(cbMonHocFile.SelectedItem is MonHocDTO))
            {
                MessageBox.Show("Vui lòng chọn Môn học cho bộ câu hỏi import.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Import từ file đang được triển khai. (TODO: parse .docx và gọi BLL)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thêm editor panel (gộp trong form để giảm file)
        private void BtnThemCauTraLoi_Click(object? sender, EventArgs e)
        {
            if (_dapAnList.Count >= 4)
            {
                MessageBox.Show("Đã có đủ 4 đáp án. Không thể thêm nữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowAnswerEditor();
        }

        // Hiển thị panel chỉnh sửa/nhập đáp án; gộp để không tạo nhiều file

        private void ShowAnswerEditor(DapAnDTO? editing = null)
        {
            // nếu editor đang mở thì focus
            if (pnlDapAnContainer.Controls.OfType<Panel>().Any(p => p.Tag?.ToString() == "editor")) return;

            var panel = CreateEditorPanel(editing);
            pnlDapAnContainer.Controls.Add(panel);
            panel.BringToFront();
            panel.Focus();
        }
        // ------------------------- Tạo UI panel chỉnh sửa/nhập đáp án ------------------
        private Panel CreateEditorPanel(DapAnDTO? editing) //  tạo UI panel chỉnh sửa/nhập đáp án
        {
            var panel = new Panel
            {
                Width = pnlDapAnContainer.ClientSize.Width - 8,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = sysDraw.Color.White,
                Padding = new Padding(8),
                Tag = "editor"
            };

            var rtb = new RichTextBox { Width = panel.Width - 16, Height = 50, Left = 8, Top = 8, Text = editing?.NoiDung ?? string.Empty };
            panel.Controls.Add(rtb);

            var rbCorrect = new RadioButton { Text = "Đáp án đúng", Left = 8, Top = rtb.Bottom + 8, Checked = editing?.Dung ?? false, AutoSize = true };
            panel.Controls.Add(rbCorrect);

            var btnSave = new Button { Text = "Lưu câu trả lời", BackColor = sysDraw.Color.FromArgb(0, 123, 255), ForeColor = sysDraw.Color.White, FlatStyle = FlatStyle.Flat, Left = panel.Width - 140, Top = rtb.Bottom + 6, Width = 120, Height = 30 };
            panel.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "Hủy", Left = btnSave.Left - 80, Top = btnSave.Top, Width = 60 };
            panel.Controls.Add(btnCancel);

            // nút lưu
            btnSave.Click += (s, ev) =>
            {
                var content = rtb.Text.Trim();
                if (string.IsNullOrWhiteSpace(content))
                {
                    MessageBox.Show("Nội dung đáp án không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (editing != null)
                {
                    var target = _dapAnList.FirstOrDefault(x => x.MaDapAn == editing.MaDapAn);
                    if (target != null)
                    {
                        target.NoiDung = content;
                        if (rbCorrect.Checked) { _dapAnList.ForEach(d => d.Dung = false); target.Dung = true; }
                        else target.Dung = false;
                    }
                }
                else
                {
                    var dto = new DapAnDTO { MaDapAn = _nextTempId--, MaCauHoi = 0, NoiDung = content, Dung = rbCorrect.Checked };
                    if (dto.Dung) _dapAnList.ForEach(d => d.Dung = false);
                    _dapAnList.Add(dto);
                }

                RemoveEditor(panel);
                RefreshAnswerListUI();
            };

            btnCancel.Click += (s, ev) => { RemoveEditor(panel); };

            panel.SizeChanged += (s, e) =>
            {
                rtb.Width = panel.ClientSize.Width - 16;
                btnSave.Left = panel.ClientSize.Width - 140;
                btnCancel.Left = btnSave.Left - 80;
            };

            return panel;
        }
        private void RemoveEditor(Panel panel)
        {
            if (pnlDapAnContainer.Controls.Contains(panel))
            {
                pnlDapAnContainer.Controls.Remove(panel);
                panel.Dispose();
            }
        }

        // Thêm summary panel UI (gọn) cho mỗi đáp án
        private void AddAnswerSummary(DapAnDTO dto)
        {
            var summary = new Panel { Width = pnlDapAnContainer.ClientSize.Width - 8, Height = 80, BorderStyle = BorderStyle.FixedSingle, BackColor = sysDraw.Color.FromArgb(250, 250, 250), Padding = new Padding(8), Tag = dto.MaDapAn };

            var lbl = new Label { AutoSize = false, Width = summary.Width - 200, Height = 48, Left = 8, Top = 8, Text = TruncatePlainText(dto.NoiDung, 300) };
            summary.Controls.Add(lbl);

            var rb = new RadioButton { Text = "Đáp án đúng", Checked = dto.Dung, Left = lbl.Right + 8, Top = 8, AutoSize = true };
            summary.Controls.Add(rb);

            var btnEdit = new Button { Text = "Sửa", Left = lbl.Right + 8, Top = rb.Bottom + 6, Width = 60 };
            summary.Controls.Add(btnEdit);

            var btnDelete = new Button { Text = "Xóa", Left = btnEdit.Right + 8, Top = btnEdit.Top, Width = 60, BackColor = sysDraw.Color.IndianRed, ForeColor = sysDraw.Color.White };
            summary.Controls.Add(btnDelete);

            rb.CheckedChanged += (s, e) =>
            {
                if (rb.Checked)
                {
                    _dapAnList.ForEach(d => d.Dung = false);
                    var target = _dapAnList.FirstOrDefault(x => x.MaDapAn == dto.MaDapAn);
                    if (target != null) target.Dung = true;
                    RefreshAnswerListUI();
                }
            };

            btnEdit.Click += (s, e) =>
            {
                var dtoToEdit = _dapAnList.FirstOrDefault(x => x.MaDapAn == dto.MaDapAn);
                if (dtoToEdit != null)
                {

                    pnlDapAnContainer.Controls.Remove(summary); //  để tránh trùng lặp UI khi chỉnh sửa
                    var editor = CreateEditorPanel(dtoToEdit);
                    pnlDapAnContainer.Controls.Add(editor);
                    editor.BringToFront();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Xóa đáp án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dapAnList.RemoveAll(x => x.MaDapAn == dto.MaDapAn);
                    RefreshAnswerListUI();
                }
            };

            pnlDapAnContainer.Controls.Add(summary);
        }

        private void RefreshAnswerListUI() // Cập nhật UI danh sách đáp án , chỉ có 1 đáp án đúng tránh trùng
        {
            pnlDapAnContainer.Controls.Clear();
            foreach (var dto in _dapAnList.AsEnumerable().Reverse())
                AddAnswerSummary(dto); // AddAnswerSummary là hàm tạo UI cho mỗi đáp án
        }

        // Lưu câu hỏi -> gọi BLL
        private void BtnSuaCauHoi_Click(object? sender, EventArgs e)
        {
            if (!ValidateBeforeSave(out string noiDung, out long maChuong, out string doKho)) return;

            foreach (var da in _dapAnList) da.MaCauHoi = _maCauHoi;

            btnSuaCauHoi.Enabled = false;
            var prevCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                _cauHoiBLL.CapNhat(_maCauHoi,maChuong, noiDung, doKho, _dapAnList);
                MessageBox.Show($"Sữa câu hỏi thành công (ID: {_maCauHoi})", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu câu hỏi thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = prevCursor;
                btnSuaCauHoi.Enabled = true;
            }
        }

        // Validate trước khi lưu
        private bool ValidateBeforeSave(out string noiDung, out long maChuong, out string doKho)
        {
            noiDung = rtbNoiDung.Text.Trim();
            maChuong = (cbChuong.SelectedItem as ChuongDTO)?.MaChuong ?? 0;
            doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text.Trim();

            bool ShowWarning(string msg)
            {
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(noiDung)) return ShowWarning("Nội dung câu hỏi không được để trống.");
            //if (_dapAnList.Count != 4) return ShowWarning("Vui lòng nhập đủ 4 đáp án.");
            if (!_dapAnList.Any(x => x.Dung)) return ShowWarning("Vui lòng đánh dấu ít nhất một đáp án đúng.");
            if (maChuong == 0) return ShowWarning("Vui lòng chọn Chương hợp lệ.");
            if (string.IsNullOrEmpty(doKho)) return ShowWarning("Vui lòng chọn Độ khó cho câu hỏi.");

            return true;
        }

        // Helper: rút bớt text
        private string TruncatePlainText(string text, int maxLen)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var s = text.Replace("\r", " ").Replace("\n", " ").Trim();
            return s.Length <= maxLen ? s : s.Substring(0, maxLen) + "...";
        }

    }
}