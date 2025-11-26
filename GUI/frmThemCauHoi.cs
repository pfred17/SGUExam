
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThemCauHoi : Form
    {
        private readonly MonHocBLL _monHocBLL = new();
        private readonly ChuongBLL _chuongBLL = new();
        private readonly CauHoiBLL _cauHoiBLL = new();

        // Danh sách đáp án tạm giữ trước khi nhấn lưu câu hỏi
        private readonly List<DapAnDTO> _dapAnList = new();
        private int _nextTempId = -1; // id tạm: -1, -2, ...

        public frmThemCauHoi()
        {
            InitializeComponent();
        }

        private void frmThemCauHoi_Load(object? sender, EventArgs e)
        {
            // Load combobox môn học, chương, độ khó vào 2 tab thêm thủ công và thêm từ file
            var monList = _monHocBLL.GetAllMonHoc();
            cbMonHoc.DataSource = new List<DTO.MonHocDTO>(monList);
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";

            cbMonHocFile.DataSource = new List<DTO.MonHocDTO>(monList);
            cbMonHocFile.DisplayMember = "TenMH";
            cbMonHocFile.ValueMember = "MaMH";

            // Chỉ gọi 1 lần LoadDoKho
            LoadDoKhoToCombo(cbDoKho);

            // Khi thay môn học -> load chương tương ứng
            cbMonHoc.SelectedIndexChanged += (s, ev) =>
            {
                if (cbMonHoc.SelectedItem is DTO.MonHocDTO m)
                    LoadChuongToCombo(cbChuong, m.MaMH);
            };

            cbMonHocFile.SelectedIndexChanged += (s, ev) =>
            {
                if (cbMonHocFile.SelectedItem is DTO.MonHocDTO m)
                    LoadChuongToCombo(cbChuongFile, m.MaMH);
            };

            // --------------------------------------tab "Thủ công" ---------------------------------------
            // Nút thêm câu trả lời (tab Thủ công)
            btnThemCauTraLoi.Click += BtnThemCauTraLoi_Click;
            // Nút lưu câu hỏi (gộp câu + đáp án)
            btnLuuCauHoi.Click += BtnLuuCauHoi_Click;
            // ----------------------------------------tab "từ file" ---------------------------------
            // Tab "Thêm từ file": nút chọn file + nút thêm vào hệ thống
            btnChonFile.Click += BtnChonFile_Click;
            btnThemVaoHeThong.Click += BtnThemVaoHeThong_Click;

            // Clear panel danh sách khi load
            pnlDapAnContainer.Controls.Clear();
        }

        #region UI helpers (combo, chương, độ khó)

        private void LoadDoKhoToCombo(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add("Tất cả");
            cb.Items.Add("Dễ");
            cb.Items.Add("Trung bình");
            cb.Items.Add("Khó");
            cb.SelectedIndex = 0;
        }

        private void LoadChuongToCombo(ComboBox cb, long maMonHoc)
        {
            var list = new List<DTO.ChuongDTO> { new DTO.ChuongDTO { MaChuong = 0, TenChuong = "Chọn chương" } };
            if (maMonHoc > 0)
                list.AddRange(_chuongBLL.GetChuongByMonHoc(maMonHoc));
            cb.DataSource = list;
            cb.DisplayMember = "TenChuong";
            cb.ValueMember = "MaChuong";
        }

        #endregion

        #region Thêm / sửa / xóa đáp án (tab Thủ công)

        // Sự kiện: thêm vùng nhập đáp án mới
        private void BtnThemCauTraLoi_Click(object? sender, EventArgs e)
        {
            if (_dapAnList.Count >= 4)
            {
                MessageBox.Show("Đã có đủ 4 đáp án. Không thể thêm nữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowAnswerEditor();
        }

        // Tạo vùng nhập đáp án (nếu editing != null => sửa)
        // UI chỉ thao tác trên _dapAnList, ko gọi DB trực tiếp 
        private void ShowAnswerEditor(DapAnDTO? editing = null) // hàm hiển thị trình chỉnh sửa đáp án
        {
            var panel = new Panel
            {
                Width = pnlDapAnContainer.ClientSize.Width - 8,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Padding = new Padding(8),
                Tag = editing // giữ dto nếu đang sửa
            };

            var rtb = new RichTextBox
            {
                Width = panel.Width - 16,
                Height = 50,
                Left = 8,
                Top = 8,
                Text = editing?.NoiDung ?? string.Empty
            };
            panel.Controls.Add(rtb);

            // RadioButton chọn đáp án đúng (ở editor)
            var rbCorrect = new RadioButton
            {
                Text = "Đáp án đúng",
                Left = 8,
                Top = rtb.Bottom + 8,
                Checked = editing?.Dung ?? false,
                AutoSize = true
            };
            panel.Controls.Add(rbCorrect);

            var btnSave = new Button
            {
                Text = "Lưu câu trả lời",
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Left = panel.Width - 140,
                Top = rtb.Bottom + 6,
                Width = 120,
                Height = 30
            };
            panel.Controls.Add(btnSave);

            var btnCancel = new Button
            {
                Text = "Hủy",
                Left = btnSave.Left - 80,
                Top = btnSave.Top,
                Width = 60
            };
            panel.Controls.Add(btnCancel);

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
                        if (rbCorrect.Checked)
                        {
                            foreach (var da in _dapAnList) da.Dung = false;
                            target.Dung = true;
                        }
                        else
                        {
                            target.Dung = false;
                        }
                        RefreshAnswerListUI();
                    }
                }
                else
                {
                    var dto = new DapAnDTO
                    {
                        MaDapAn = _nextTempId--, // id tạm , DAL sẽ gán id mới khi lưu
                        MaCauHoi = 0,
                        NoiDung = content,
                        Dung = rbCorrect.Checked
                    };

                    if (dto.Dung)
                        foreach (var da in _dapAnList) da.Dung = false;

                    _dapAnList.Add(dto); // chỉ thêm vào list tạm , ko gọi DB trực tiếp
                    AddAnswerSummary(dto);
                }

                pnlDapAnContainer.Controls.Remove(panel);
                panel.Dispose();
            };

            btnCancel.Click += (s, ev) =>
            {
                pnlDapAnContainer.Controls.Remove(panel);
                panel.Dispose();
            };

            pnlDapAnContainer.Controls.Add(panel);
            panel.BringToFront();
            panel.Focus();
        }

        // thêm tóm tắt đáp án vào panel danh sách UI 
        private void AddAnswerSummary(DapAnDTO dto)
        {
            var summary = new Panel
            {
                Width = pnlDapAnContainer.ClientSize.Width - 8,
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(8),
                Tag = dto.MaDapAn
            };

            var lbl = new Label
            {
                AutoSize = false,
                Width = summary.Width - 200,
                Height = 48,
                Left = 8,
                Top = 8,
                Text = TruncatePlainText(dto.NoiDung, 300),
            };
            summary.Controls.Add(lbl);

            var rb = new RadioButton
            {
                Text = "Đáp án đúng",
                Checked = dto.Dung,
                Left = lbl.Right + 8,
                Top = 8,
                AutoSize = true
            };
            summary.Controls.Add(rb);

            var btnEdit = new Button
            {
                Text = "Sửa",
                Left = lbl.Right + 8,
                Top = rb.Bottom + 6,
                Width = 60,
            };
            summary.Controls.Add(btnEdit);

            var btnDelete = new Button
            {
                Text = "Xóa",
                Left = btnEdit.Right + 8,
                Top = btnEdit.Top,
                Width = 60,
                BackColor = Color.IndianRed,
                ForeColor = Color.White
            };
            summary.Controls.Add(btnDelete);

            rb.CheckedChanged += (s, e) =>
            {
                if (rb.Checked)
                {
                    foreach (var da in _dapAnList) da.Dung = false;
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
                    ShowAnswerEditor(dtoToEdit);
                    pnlDapAnContainer.Controls.Remove(summary);
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Xóa đáp án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dapAnList.RemoveAll(x => x.MaDapAn == dto.MaDapAn);
                    pnlDapAnContainer.Controls.Remove(summary);
                }
            };

            pnlDapAnContainer.Controls.Add(summary);
            //summary.BringToFront();
        }

        // Giữ vị trí cuộn khi refresh UI
        private void RefreshAnswerListUI()
        {
            //int scrollPos = 0;
            //try { scrollPos = pnlDapAnContainer.VerticalScroll.Value; } catch { }
            pnlDapAnContainer.Controls.Clear();
            foreach (var da in _dapAnList)
                AddAnswerSummary(da);

            //try { pnlDapAnContainer.VerticalScroll.Value = Math.Min(scrollPos, pnlDapAnContainer.VerticalScroll.Maximum); } catch { }
        }

        #endregion
        // phần này lưu câu hỏi + đáp án vào DB (tab Thủ công) và import từ file (tab Thêm từ file)
        #region Lưu câu hỏi / import từ file (tab Thêm từ file)

        private void BtnLuuCauHoi_Click(object? sender, EventArgs e)
        {
            // Validate UI (như đã có)
            var noiDung = rtbNoiDung.Text.Trim();
            if (string.IsNullOrWhiteSpace(noiDung))
            {
                MessageBox.Show("Nội dung câu hỏi không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dapAnList.Count != 4)
            {
                MessageBox.Show("Vui lòng nhập đủ 4 đáp án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_dapAnList.Any(x => x.Dung)) // không có đáp án đúng
            {
                MessageBox.Show("Vui lòng đánh dấu ít nhất một đáp án đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin để lưu
            long maChuong = 0;
            if (cbChuong.SelectedItem is DTO.ChuongDTO chosenChuong)
                maChuong = chosenChuong.MaChuong;

            if (maChuong == 0)
            {
                MessageBox.Show("Vui lòng chọn Chương hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string doKho = cbDoKho.Text == "Tất cả" ? "" : cbDoKho.Text.Trim();

            // Chuẩn bị dữ liệu: đảm bảo _MaCauHoi trong _dapAnList = 0 (chưa có câu hỏi id) DAL sẽ gán id mới
            foreach (var da in _dapAnList)
            {
                da.MaCauHoi = 0;
            }

            // Disable UI / show waiting
            btnLuuCauHoi.Enabled = false;
            Cursor previousCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Gọi BLL để lưu. CauHoiBLL.ThemMoi thực hiện transaction trong DAL và trả về ID câu hỏi mới
                long newId = _cauHoiBLL.ThemMoi(maChuong, noiDung, doKho, _dapAnList);

                MessageBox.Show("Lưu câu hỏi thành công (ID: " + newId + ")", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu câu hỏi thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = previousCursor;
                btnLuuCauHoi.Enabled = true;
            }
        }

        // ------------------------------------- Tab "Thêm từ file" ---------------------------------------
        // Chọn file .docx trên tab "Thêm từ file"
        private void BtnChonFile_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = openFileDialog1.FileName;
            }
        }

        // Thêm câu hỏi từ file (thực hiện validate cơ bản và gọi logic import)
        private void BtnThemVaoHeThong_Click(object? sender, EventArgs e)
        {
            var path = txtDuongDan.Text?.Trim();
            if (string.IsNullOrEmpty(path) || path == "No file chosen")
            {
                MessageBox.Show("Vui lòng chọn file .docx chứa câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cbMonHocFile.SelectedItem is DTO.MonHocDTO mon))
            {
                MessageBox.Show("Vui lòng chọn Môn học cho bộ câu hỏi import.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // TODO: parse file .docx thành danh sách câu hỏi + đáp án, sau đó gọi BLL (
            MessageBox.Show("Import từ file đang được triển khai. (TODO: parse .docx và gọi BLL)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        // Helper: rút bớt text RichText về plain text tóm tắt
        private string TruncatePlainText(string text, int maxLen)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var s = text.Replace("\r", " ").Replace("\n", " ").Trim();
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen) + "...";
        }

        private void cbChuongFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            // placeholder nếu cần xử lý
        }

        private void btnThemCauTraLoi_Click_1(object sender, EventArgs e)
        {

        }
    }
}