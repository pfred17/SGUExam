using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    partial class frmThemCauHoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabTuFile = new TabPage();
            btnChonFile = new Button();
            label9 = new Label();
            txtDuongDan = new TextBox();
            btnThemVaoHeThong = new Button();
            lblMonHocFile = new Label();
            lblChuongFile = new Label();
            cbChuongFile = new ComboBox();
            cbMonHocFile = new ComboBox();
            tabThuCong = new TabPage();
            labelMonHoc = new Label();
            cbMonHoc = new ComboBox();
            labelChuong = new Label();
            cbChuong = new ComboBox();
            labelDoKho = new Label();
            cbDoKho = new ComboBox();
            labelNoiDung = new Label();
            rtbNoiDung = new RichTextBox();
            labelDanhSach = new Label();
            btnThemCauTraLoi = new Button();
            pnlDapAnContainer = new FlowLayoutPanel();
            btnLuuCauHoi = new Button();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabTuFile.SuspendLayout();
            tabThuCong.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabTuFile);
            tabControl1.Controls.Add(tabThuCong);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(820, 640);
            tabControl1.TabIndex = 0;
            // 
            // tabTuFile
            // 
            tabTuFile.Controls.Add(btnChonFile);
            tabTuFile.Controls.Add(label9);
            tabTuFile.Controls.Add(txtDuongDan);
            tabTuFile.Controls.Add(btnThemVaoHeThong);
            tabTuFile.Controls.Add(lblMonHocFile);
            tabTuFile.Controls.Add(lblChuongFile);
            tabTuFile.Controls.Add(cbChuongFile);
            tabTuFile.Controls.Add(cbMonHocFile);
            tabTuFile.Location = new Point(4, 29);
            tabTuFile.Name = "tabTuFile";
            tabTuFile.Padding = new Padding(16);
            tabTuFile.Size = new Size(812, 607);
            tabTuFile.TabIndex = 0;
            tabTuFile.Text = "Thêm từ file";
            tabTuFile.UseVisualStyleBackColor = true;
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(52, 152, 219);
            btnChonFile.FlatStyle = FlatStyle.Flat;
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(29, 126);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(96, 27);
            btnChonFile.TabIndex = 8;
            btnChonFile.Text = "Choose File";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += BtnChonFile_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label9.ForeColor = Color.FromArgb(100, 100, 100);
            label9.Location = new Point(29, 172);
            label9.Name = "label9";
            label9.Size = new Size(421, 20);
            label9.TabIndex = 7;
            label9.Text = "Vui lòng soạn câu hỏi theo đúng định dạng. Tải về file mẫu Docx";
            // 
            // txtDuongDan
            // 
            txtDuongDan.Location = new Point(29, 129);
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.ReadOnly = true;
            txtDuongDan.Size = new Size(740, 27);
            txtDuongDan.TabIndex = 6;
            txtDuongDan.TextChanged += txtDuongDan_TextChanged;
            // 
            // btnThemVaoHeThong
            // 
            btnThemVaoHeThong.BackColor = Color.FromArgb(46, 204, 113);
            btnThemVaoHeThong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemVaoHeThong.ForeColor = Color.White;
            btnThemVaoHeThong.Location = new Point(544, 229);
            btnThemVaoHeThong.Name = "btnThemVaoHeThong";
            btnThemVaoHeThong.Size = new Size(215, 36);
            btnThemVaoHeThong.TabIndex = 5;
            btnThemVaoHeThong.Text = "THÊM VÀO HỆ THỐNG";
            btnThemVaoHeThong.UseVisualStyleBackColor = false;
            btnThemVaoHeThong.Click += BtnThemVaoHeThong_Click;
            // 
            // lblMonHocFile
            // 
            lblMonHocFile.Location = new Point(30, 18);
            lblMonHocFile.Name = "lblMonHocFile";
            lblMonHocFile.Size = new Size(100, 20);
            lblMonHocFile.TabIndex = 9;
            lblMonHocFile.Text = "Môn học";
            // 
            // lblChuongFile
            // 
            lblChuongFile.Location = new Point(320, 18);
            lblChuongFile.Name = "lblChuongFile";
            lblChuongFile.Size = new Size(100, 20);
            lblChuongFile.TabIndex = 10;
            lblChuongFile.Text = "Chương";
            // 
            // cbChuongFile
            // 
            cbChuongFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuongFile.Location = new Point(320, 40);
            cbChuongFile.Name = "cbChuongFile";
            cbChuongFile.Size = new Size(121, 28);
            cbChuongFile.TabIndex = 12;
            // 
            // cbMonHocFile
            // 
            cbMonHocFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHocFile.Location = new Point(30, 40);
            cbMonHocFile.Name = "cbMonHocFile";
            cbMonHocFile.Size = new Size(192, 28);
            cbMonHocFile.TabIndex = 13;
            // 
            // tabThuCong
            // 
            tabThuCong.Controls.Add(labelMonHoc);
            tabThuCong.Controls.Add(cbMonHoc);
            tabThuCong.Controls.Add(labelChuong);
            tabThuCong.Controls.Add(cbChuong);
            tabThuCong.Controls.Add(labelDoKho);
            tabThuCong.Controls.Add(cbDoKho);
            tabThuCong.Controls.Add(labelNoiDung);
            tabThuCong.Controls.Add(rtbNoiDung);
            tabThuCong.Controls.Add(labelDanhSach);
            tabThuCong.Controls.Add(btnThemCauTraLoi);
            tabThuCong.Controls.Add(pnlDapAnContainer);
            tabThuCong.Controls.Add(btnLuuCauHoi);
            tabThuCong.Location = new Point(4, 29);
            tabThuCong.Name = "tabThuCong";
            tabThuCong.Padding = new Padding(16);
            tabThuCong.Size = new Size(812, 607);
            tabThuCong.TabIndex = 1;
            tabThuCong.Text = "Thêm thủ công";
            tabThuCong.UseVisualStyleBackColor = true;
            // 
            // labelMonHoc
            // 
            labelMonHoc.AutoSize = true;
            labelMonHoc.Location = new Point(24, 18);
            labelMonHoc.Name = "labelMonHoc";
            labelMonHoc.Size = new Size(67, 20);
            labelMonHoc.TabIndex = 0;
            labelMonHoc.Text = "Môn học";
            // 
            // cbMonHoc
            // 
            cbMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHoc.Location = new Point(24, 40);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(260, 28);
            cbMonHoc.TabIndex = 1;
            cbMonHoc.SelectedIndexChanged += CbMonHoc_SelectedIndexChanged;
            // 
            // labelChuong
            // 
            labelChuong.AutoSize = true;
            labelChuong.Location = new Point(300, 18);
            labelChuong.Name = "labelChuong";
            labelChuong.Size = new Size(61, 20);
            labelChuong.TabIndex = 2;
            labelChuong.Text = "Chương";
            // 
            // cbChuong
            // 
            cbChuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuong.Location = new Point(300, 40);
            cbChuong.Name = "cbChuong";
            cbChuong.Size = new Size(220, 28);
            cbChuong.TabIndex = 3;
            // 
            // labelDoKho
            // 
            labelDoKho.AutoSize = true;
            labelDoKho.Location = new Point(540, 18);
            labelDoKho.Name = "labelDoKho";
            labelDoKho.Size = new Size(57, 20);
            labelDoKho.TabIndex = 4;
            labelDoKho.Text = "Độ khó";
            // 
            // cbDoKho
            // 
            cbDoKho.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoKho.Location = new Point(540, 40);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.Size = new Size(220, 28);
            cbDoKho.TabIndex = 5;
            // 
            // labelNoiDung
            // 
            labelNoiDung.AutoSize = true;
            labelNoiDung.Location = new Point(24, 80);
            labelNoiDung.Name = "labelNoiDung";
            labelNoiDung.Size = new Size(123, 20);
            labelNoiDung.TabIndex = 6;
            labelNoiDung.Text = "Nội dung câu hỏi";
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbNoiDung.BorderStyle = BorderStyle.FixedSingle;
            rtbNoiDung.Location = new Point(24, 105);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(736, 102);
            rtbNoiDung.TabIndex = 7;
            rtbNoiDung.Text = "";
            // 
            // labelDanhSach
            // 
            labelDanhSach.AutoSize = true;
            labelDanhSach.Location = new Point(24, 262);
            labelDanhSach.Name = "labelDanhSach";
            labelDanhSach.Size = new Size(127, 20);
            labelDanhSach.TabIndex = 8;
            labelDanhSach.Text = "Danh sách đáp án";
            // 
            // btnThemCauTraLoi
            // 
            btnThemCauTraLoi.BackColor = Color.FromArgb(0, 123, 255);
            btnThemCauTraLoi.FlatStyle = FlatStyle.Flat;
            btnThemCauTraLoi.ForeColor = Color.White;
            btnThemCauTraLoi.Location = new Point(24, 213);
            btnThemCauTraLoi.Name = "btnThemCauTraLoi";
            btnThemCauTraLoi.Size = new Size(160, 34);
            btnThemCauTraLoi.TabIndex = 9;
            btnThemCauTraLoi.Text = "THÊM CÂU TRẢ LỜI";
            btnThemCauTraLoi.UseVisualStyleBackColor = false;
            btnThemCauTraLoi.Click += BtnThemCauTraLoi_Click;
            // 
            // pnlDapAnContainer
            // 
            pnlDapAnContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDapAnContainer.AutoScroll = true;
            pnlDapAnContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlDapAnContainer.Location = new Point(24, 285);
            pnlDapAnContainer.Name = "pnlDapAnContainer";
            pnlDapAnContainer.Size = new Size(736, 245);
            pnlDapAnContainer.TabIndex = 10;
            // 
            // btnLuuCauHoi
            // 
            btnLuuCauHoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLuuCauHoi.BackColor = Color.FromArgb(0, 102, 204);
            btnLuuCauHoi.FlatStyle = FlatStyle.Flat;
            btnLuuCauHoi.ForeColor = Color.White;
            btnLuuCauHoi.Location = new Point(24, 540);
            btnLuuCauHoi.Name = "btnLuuCauHoi";
            btnLuuCauHoi.Size = new Size(140, 36);
            btnLuuCauHoi.TabIndex = 11;
            btnLuuCauHoi.Text = "+ Lưu câu hỏi";
            btnLuuCauHoi.UseVisualStyleBackColor = false;
            btnLuuCauHoi.Click += BtnLuuCauHoi_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Word Documents|*.docx|All Files|*.*";
            openFileDialog1.Title = "Chọn file câu hỏi";
            // 
            // frmThemCauHoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 640);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmThemCauHoi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm câu hỏi";
            Load += FrmThemCauHoi_Load;
            tabControl1.ResumeLayout(false);
            tabTuFile.ResumeLayout(false);
            tabTuFile.PerformLayout();
            tabThuCong.ResumeLayout(false);
            tabThuCong.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabTuFile;
        private TabPage tabThuCong;
        private Button btnChonFile;
        private Label label9;
        private TextBox txtDuongDan;
        private Button btnThemVaoHeThong;
        private Label lblMonHocFile;
        private Label lblChuongFile;
        private ComboBox cbChuongFile;
        private ComboBox cbMonHocFile;
        private Label labelMonHoc;
        private ComboBox cbMonHoc;
        private Label labelChuong;
        private ComboBox cbChuong;
        private Label labelDoKho;
        private ComboBox cbDoKho;
        private Label labelNoiDung;
        private RichTextBox rtbNoiDung;
        private Label labelDanhSach;
        private Button btnThemCauTraLoi;
        private FlowLayoutPanel pnlDapAnContainer;
        private Button btnLuuCauHoi;
        private OpenFileDialog openFileDialog1;
    }
}