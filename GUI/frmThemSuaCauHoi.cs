using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GUI.modules;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Drawing;

namespace GUI
{
    public partial class frmThemSuaCauHoi : Form
    {
        // === BIẾN SỬA ĐÁP ÁN ===
        private DapAnControl _currentEditingDapAn = null;
        private RichTextBox rtbEditDapAn;
        private System.Windows.Forms.CheckBox chkEditDung;
        private System.Windows.Forms.Button btnCapNhatDapAn;
        private Panel pnlEdit;

        // === BIẾN CŨ ===
        private FlowLayoutPanel flpDapAn;
        private List<DapAnControl> _dapAnControls = new List<DapAnControl>();
        private long _maCauHoi = 0;
        private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        private readonly ChuongBLL _chuongBLL = new ChuongBLL();
        private readonly DapAnBLL _dapAnBLL = new DapAnBLL();
        private string _filePath = "";

        public frmThemSuaCauHoi(long maCauHoi = 0)
        {
            InitializeComponent();
            _maCauHoi = maCauHoi;

            // === TẠO FLP ĐÁP ÁN ===
            flpDapAn = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5)
            };
            pnlDapAnContainer.Controls.Add(flpDapAn);

            // === PANEL SỬA ĐÁP ÁN ===
            pnlEdit = new Panel
            {
                Location = new Point(21, 530),
                Size = new Size(735, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            tabThuCong.Controls.Add(pnlEdit);

            var lblEdit = new Label { Text = "Nội dung trả lời", Location = new Point(10, 10), AutoSize = true };
            pnlEdit.Controls.Add(lblEdit);

            rtbEditDapAn = new RichTextBox { Location = new Point(10, 35), Size = new Size(600, 50) };
            pnlEdit.Controls.Add(rtbEditDapAn);

            chkEditDung = new System.Windows.Forms.CheckBox
            {
                Text = "Đáp án đúng",
                Location = new Point(620, 40),
                AutoSize = true
            };
            pnlEdit.Controls.Add(chkEditDung);

            btnCapNhatDapAn = new System.Windows.Forms.Button
            {
                Text = "Cập nhật",
                Location = new Point(620, 10),
                Size = new Size(100, 30),
                BackColor = System.Drawing.Color.FromArgb(46, 204, 113),  // <-- DÙNG System.Drawing.Color
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold)  // <-- DÙNG System.Drawing.Font
            };
            pnlEdit.Controls.Add(btnCapNhatDapAn);

            btnCapNhatDapAn.Click += (s, e) =>
            {
                if (_currentEditingDapAn == null) return;
                _currentEditingDapAn.NoiDung = rtbEditDapAn.Text;
                _currentEditingDapAn.Dung = chkEditDung.Checked;
                pnlEdit.Visible = false;
                _currentEditingDapAn = null;
                MessageBox.Show("Cập nhật thành công!", "Thành công");
            };
        }

        #region Load dữ liệu
        private void LoadMonHoc()
        {
            var list = _monHocBLL.GetAll();
            list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn môn học..." });
            cbMonHoc.DataSource = list;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
        }

        private void LoadMonHocFile()
        {
            var list = _monHocBLL.GetAll();
            list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn môn học..." });
            cbMonHocFile.DataSource = list;
            cbMonHocFile.DisplayMember = "TenMH";
            cbMonHocFile.ValueMember = "MaMH";
        }

        private void LoadChuong(long maMH, ComboBox cb)
        {
            if (maMH <= 0) { cb.DataSource = null; return; }
            var list = _chuongBLL.GetByMonHoc(maMH);
            list.Insert(0, new ChuongDTO { MaChuong = 0, TenChuong = "Chọn chương..." });
            cb.DataSource = list;
            cb.DisplayMember = "TenChuong";
            cb.ValueMember = "MaChuong";
        }

        private void LoadDoKho()
        {
            cbDoKho.Items.Clear();
            cbDoKho.Items.Add("Chọn độ khó...");
            cbDoKho.Items.Add("Dễ"); cbDoKho.Items.Add("Trung bình"); cbDoKho.Items.Add("Khó");
            cbDoKho.SelectedIndex = 0;
        }
        #endregion

        #region LoadForEdit
        private void LoadForEdit()
        {
            var ch = _cauHoiBLL.GetById(_maCauHoi);
            if (ch == null) { this.Close(); return; }

            rtbNoiDung.Text = ch.NoiDung;
            cbDoKho.Text = ch.DoKho;

            var mon = _monHocBLL.GetAll().FirstOrDefault(m => m.TenMH == ch.TenMonHoc);
            if (mon != null)
            {
                cbMonHoc.SelectedValue = mon.MaMH;
                LoadChuong(mon.MaMH, cbChuong);
                cbChuong.SelectedValue = ch.MaChuong;
            }

            var daList = _dapAnBLL.GetByCauHoi(_maCauHoi);
            foreach (var da in daList)
            {
                var ctrl = new DapAnControl(da.NoiDung, da.Dung);
                _dapAnControls.Add(ctrl);
                flpDapAn.Controls.Add(ctrl);
            }
        }
        #endregion

        #region Đáp án
        private void ThemDapAnMoi()
        {
            var ctrl = new DapAnControl();
            _dapAnControls.Add(ctrl);
            flpDapAn.Controls.Add(ctrl);
        }

        private List<DapAnDTO> GetDapAnList()
        {
            return _dapAnControls
                .Where(c => !string.IsNullOrWhiteSpace(c.NoiDung))
                .Select(c => new DapAnDTO { NoiDung = c.NoiDung, Dung = c.Dung })
                .ToList();
        }
        #endregion

        #region Sự kiện
        private void frmThemSuaCauHoi_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            LoadMonHocFile();
            LoadDoKho();

            if (_maCauHoi > 0)
            {
                LoadForEdit();
                this.Text = "Sửa câu hỏi";
            }
            else
            {
                this.Text = "Thêm câu hỏi mới";
                ThemDapAnMoi();
            }
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonHoc.SelectedValue is long maMH && maMH > 0)
                LoadChuong(maMH, cbChuong);
        }

        private void cbMonHocFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonHocFile.SelectedValue is long maMH && maMH > 0)
                LoadChuong(maMH, cbChuongFile);
        }

        private void btnThemCauTraLoi_Click(object sender, EventArgs e) => ThemDapAnMoi();

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog1.FileName;
                txtDuongDan.Text = _filePath;
            }
        }

        private void btnLuuCauHoi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            long maChuong = (long)cbChuong.SelectedValue;
            string noiDung = rtbNoiDung.Text;
            string doKho = cbDoKho.Text;
            var dapAns = GetDapAnList();

            if (dapAns.Count(x => x.Dung) != 1)
            {
                MessageBox.Show("Chỉ được chọn 1 đáp án đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_maCauHoi == 0)
                    _cauHoiBLL.ThemMoi(maChuong, noiDung, doKho, dapAns);
                else
                    _cauHoiBLL.CapNhat(_maCauHoi, maChuong, noiDung, doKho, dapAns);

                MessageBox.Show(_maCauHoi == 0 ? "Thêm thành công!" : "Cập nhật thành công!", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnThemVaoHeThong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                MessageBox.Show("Chọn file hợp lệ!", "Lỗi"); return;
            }
            if (cbMonHocFile.SelectedIndex <= 0 || cbChuongFile.SelectedIndex <= 0)
            {
                MessageBox.Show("Chọn môn học và chương!", "Lỗi"); return;
            }

            long maChuong = (long)cbChuongFile.SelectedValue;
            string doKho = "Trung bình";
            try
            {
                var cauHoiList = DocFileWord(_filePath);
                int count = 0;
                foreach (var ch in cauHoiList)
                {
                    if (ch.DapAnList.Count(x => x.Dung) != 1) continue;
                    _cauHoiBLL.ThemMoi(maChuong, ch.NoiDung, doKho, ch.DapAnList);
                    count++;
                }
                MessageBox.Show($"Thêm thành công {count} câu hỏi!", "Thành công");
                _filePath = ""; txtDuongDan.Text = "No file chosen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(rtbNoiDung.Text)) { MessageBox.Show("Nhập nội dung!"); rtbNoiDung.Focus(); return false; }
            if (cbMonHoc.SelectedValue is not long || (long)cbMonHoc.SelectedValue == 0) { MessageBox.Show("Chọn môn học!"); return false; }
            if (cbChuong.SelectedValue is not long || (long)cbChuong.SelectedValue == 0) { MessageBox.Show("Chọn chương!"); return false; }
            if (cbDoKho.SelectedIndex == 0) { MessageBox.Show("Chọn độ khó!"); return false; }
            return true;
        }
        #endregion

        #region OpenXML
        private List<CauHoiImportDTO> DocFileWord(string filePath)
        {
            var result = new List<CauHoiImportDTO>();
            try
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
                {
                    var body = doc.MainDocumentPart?.Document?.Body;
                    if (body == null) return result;

                    var lines = body.Elements<Paragraph>().Select(p => p.InnerText).Where(t => !string.IsNullOrWhiteSpace(t));
                    CauHoiImportDTO current = null;
                    foreach (var line in lines)
                    {
                        string text = line.Trim();
                        if (string.IsNullOrWhiteSpace(text)) continue;

                        if (IsCauHoi(text))
                        {
                            if (current != null) result.Add(current);
                            current = new CauHoiImportDTO { NoiDung = text };
                        }
                        else if (current != null && IsDapAn(text))
                        {
                            bool dung = text.Contains("*");
                            string noiDung = text.Replace("*", "").Trim();
                            current.DapAnList.Add(new DapAnDTO { NoiDung = noiDung, Dung = dung });
                        }
                    }
                    if (current != null) result.Add(current);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi đọc file: " + ex.Message); }
            return result;
        }

        private bool IsCauHoi(string line) => line.StartsWith("Câu") || (char.IsDigit(line[0]) && line.Contains(".")) || line.Contains("?");
        private bool IsDapAn(string line) => line.StartsWith("A.") || line.StartsWith("B.") || line.StartsWith("C.") || line.StartsWith("D.") || line.Contains("*");
        #endregion

        public void StartEditDapAn(DapAnControl dapAn)
        {
            _currentEditingDapAn = dapAn;
            rtbEditDapAn.Text = dapAn.NoiDung;
            chkEditDung.Checked = dapAn.Dung;
            pnlEdit.Visible = true;
            pnlEdit.BringToFront();
        }
    }

    public class CauHoiImportDTO
    {
        public string NoiDung { get; set; } = "";
        public List<DapAnDTO> DapAnList { get; set; } = new List<DapAnDTO>();
    }
}