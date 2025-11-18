using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    partial class frmThemSuaCauHoi
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
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            cbChuongFile = new ComboBox();
            cbMonHocFile = new ComboBox();
            tabThuCong = new TabPage();
            btnLuuCauHoi = new Button();
            pnlDapAnContainer = new Panel();
            btnThemCauTraLoi = new Button();
            label5 = new Label();
            label4 = new Label();
            rtbNoiDung = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbDoKho = new ComboBox();
            cbChuong = new ComboBox();
            cbMonHoc = new ComboBox();
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
            tabControl1.Size = new Size(800, 639);
            tabControl1.TabIndex = 0;
            // 
            // tabTuFile
            // 
            tabTuFile.Controls.Add(btnChonFile);
            tabTuFile.Controls.Add(label9);
            tabTuFile.Controls.Add(txtDuongDan);
            tabTuFile.Controls.Add(btnThemVaoHeThong);
            tabTuFile.Controls.Add(label8);
            tabTuFile.Controls.Add(label7);
            tabTuFile.Controls.Add(label6);
            tabTuFile.Controls.Add(cbChuongFile);
            tabTuFile.Controls.Add(cbMonHocFile);
            tabTuFile.Location = new Point(4, 34);
            tabTuFile.Name = "tabTuFile";
            tabTuFile.Padding = new Padding(20);
            tabTuFile.Size = new Size(792, 601);
            tabTuFile.TabIndex = 0;
            tabTuFile.Text = "Thêm từ file";
            tabTuFile.UseVisualStyleBackColor = true;
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(52, 152, 219);
            btnChonFile.FlatStyle = FlatStyle.Flat;
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(36, 158);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(120, 34);
            btnChonFile.TabIndex = 8;
            btnChonFile.Text = "Choose File";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += btnChonFile_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label9.ForeColor = Color.FromArgb(100, 100, 100);
            label9.Location = new Point(36, 215);
            label9.Name = "label9";
            label9.Size = new Size(522, 25);
            label9.TabIndex = 7;
            label9.Text = "Vui lòng soạn câu hỏi theo đúng định dạng. Tải về file mẫu Docx";
            // 
            // txtDuongDan
            // 
            txtDuongDan.Location = new Point(36, 161);
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.ReadOnly = true;
            txtDuongDan.Size = new Size(713, 31);
            txtDuongDan.TabIndex = 6;
            txtDuongDan.Text = "No file chosen";
            // 
            // btnThemVaoHeThong
            // 
            btnThemVaoHeThong.BackColor = Color.FromArgb(46, 204, 113);
            btnThemVaoHeThong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemVaoHeThong.ForeColor = Color.White;
            btnThemVaoHeThong.Location = new Point(510, 259);
            btnThemVaoHeThong.Name = "btnThemVaoHeThong";
            btnThemVaoHeThong.Size = new Size(239, 45);
            btnThemVaoHeThong.TabIndex = 5;
            btnThemVaoHeThong.Text = "THÊM VÀO HỆ THỐNG";
            btnThemVaoHeThong.UseVisualStyleBackColor = false;
            btnThemVaoHeThong.Click += btnThemVaoHeThong_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 112);
            label8.Name = "label8";
            label8.Size = new Size(87, 25);
            label8.TabIndex = 4;
            label8.Text = "Nội dung";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(402, 18);
            label7.Name = "label7";
            label7.Size = new Size(86, 28);
            label7.TabIndex = 3;
            label7.Text = "Chương";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(36, 18);
            label6.Name = "label6";
            label6.Size = new Size(95, 28);
            label6.TabIndex = 2;
            label6.Text = "Môn học";
            // 
            // cbChuongFile
            // 
            cbChuongFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuongFile.Location = new Point(415, 46);
            cbChuongFile.Name = "cbChuongFile";
            cbChuongFile.Size = new Size(290, 33);
            cbChuongFile.TabIndex = 1;
            // 
            // cbMonHocFile
            // 
            cbMonHocFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHocFile.Location = new Point(36, 46);
            cbMonHocFile.Name = "cbMonHocFile";
            cbMonHocFile.Size = new Size(303, 33);
            cbMonHocFile.TabIndex = 0;
            // 
            // tabThuCong
            // 
            tabThuCong.Controls.Add(btnLuuCauHoi);
            tabThuCong.Controls.Add(pnlDapAnContainer);
            tabThuCong.Controls.Add(btnThemCauTraLoi);
            tabThuCong.Controls.Add(label5);
            tabThuCong.Controls.Add(label4);
            tabThuCong.Controls.Add(rtbNoiDung);
            tabThuCong.Controls.Add(label3);
            tabThuCong.Controls.Add(label2);
            tabThuCong.Controls.Add(label1);
            tabThuCong.Controls.Add(cbDoKho);
            tabThuCong.Controls.Add(cbChuong);
            tabThuCong.Controls.Add(cbMonHoc);
            tabThuCong.Location = new Point(4, 34);
            tabThuCong.Name = "tabThuCong";
            tabThuCong.Padding = new Padding(20);
            tabThuCong.Size = new Size(792, 601);
            tabThuCong.TabIndex = 1;
            tabThuCong.Text = "Thêm thủ công";
            tabThuCong.UseVisualStyleBackColor = true;
            // 
            // btnLuuCauHoi
            // 
            btnLuuCauHoi.BackColor = SystemColors.HotTrack;
            btnLuuCauHoi.ForeColor = Color.White;
            btnLuuCauHoi.Location = new Point(21, 553);
            btnLuuCauHoi.Name = "btnLuuCauHoi";
            btnLuuCauHoi.Size = new Size(148, 40);
            btnLuuCauHoi.TabIndex = 11;
            btnLuuCauHoi.Text = "+ Lưu câu hỏi";
            btnLuuCauHoi.UseVisualStyleBackColor = false;
            btnLuuCauHoi.Click += btnLuuCauHoi_Click;
            // 
            // pnlDapAnContainer
            // 
            pnlDapAnContainer.AutoScroll = true;
            pnlDapAnContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlDapAnContainer.Location = new Point(21, 322);
            pnlDapAnContainer.Name = "pnlDapAnContainer";
            pnlDapAnContainer.Size = new Size(735, 200);
            pnlDapAnContainer.TabIndex = 10;
            // 
            // btnThemCauTraLoi
            // 
            btnThemCauTraLoi.BackColor = Color.FromArgb(0, 102, 204);
            btnThemCauTraLoi.FlatStyle = FlatStyle.Flat;
            btnThemCauTraLoi.ForeColor = Color.White;
            btnThemCauTraLoi.Location = new Point(28, 282);
            btnThemCauTraLoi.Name = "btnThemCauTraLoi";
            btnThemCauTraLoi.Size = new Size(147, 34);
            btnThemCauTraLoi.TabIndex = 9;
            btnThemCauTraLoi.Text = "THÊM CÂU TRẢ LỜI";
            btnThemCauTraLoi.UseVisualStyleBackColor = true;
            btnThemCauTraLoi.Click += btnThemCauTraLoi_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 254);
            label5.Name = "label5";
            label5.Size = new Size(154, 25);
            label5.TabIndex = 12;
            label5.Text = "Danh sách đáp án";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 93);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 13;
            label4.Text = "Nội dung câu hỏi";
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Location = new Point(21, 121);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(735, 115);
            rtbNoiDung.TabIndex = 14;
            rtbNoiDung.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(606, 8);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 15;
            label3.Text = "Độ khó";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 8);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 16;
            label2.Text = "Chương";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 8);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 17;
            label1.Text = "Môn học";
            // 
            // cbDoKho
            // 
            cbDoKho.Location = new Point(574, 36);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.Size = new Size(182, 33);
            cbDoKho.TabIndex = 18;
            // 
            // cbChuong
            // 
            cbChuong.Location = new Point(286, 36);
            cbChuong.Name = "cbChuong";
            cbChuong.Size = new Size(182, 33);
            cbChuong.TabIndex = 19;
            // 
            // cbMonHoc
            // 
            cbMonHoc.Location = new Point(21, 36);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(182, 33);
            cbMonHoc.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Word Documents|*.docx|All Files|*.*";
            openFileDialog1.Title = "Chọn file câu hỏi";
            // 
            // frmThemSuaCauHoi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 639);
            Controls.Add(tabControl1);
            Name = "frmThemSuaCauHoi";
            Text = "Thêm / Sửa câu hỏi";
            Load += frmThemSuaCauHoi_Load;
            tabControl1.ResumeLayout(false);
            tabTuFile.ResumeLayout(false);
            tabTuFile.PerformLayout();
            tabThuCong.ResumeLayout(false);
            tabThuCong.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTuFile;
        private System.Windows.Forms.TabPage tabThuCong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDoKho;
        private System.Windows.Forms.ComboBox cbChuong;
        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.Button btnLuuCauHoi;
        private System.Windows.Forms.Panel pnlDapAnContainer;
        private System.Windows.Forms.Button btnThemCauTraLoi;
        private System.Windows.Forms.Button btnThemVaoHeThong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMonHocFile;
        private System.Windows.Forms.ComboBox cbChuongFile;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Label label9;
    }
}