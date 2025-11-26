using GUI.modules;
using System.Windows.Forms;

namespace GUI
{
    partial class frmSuaCauhoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            btnThemDapAn = new Button();
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
            flpDanhSachDapAn = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
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
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(640, 511);
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
            tabTuFile.Location = new Point(4, 29);
            tabTuFile.Margin = new Padding(2);
            tabTuFile.Name = "tabTuFile";
            tabTuFile.Padding = new Padding(16);
            tabTuFile.Size = new Size(632, 478);
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
            btnChonFile.Margin = new Padding(2);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(96, 27);
            btnChonFile.TabIndex = 8;
            btnChonFile.Text = "Choose File";
            btnChonFile.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label9.ForeColor = Color.FromArgb(100, 100, 100);
            label9.Location = new Point(29, 172);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(421, 20);
            label9.TabIndex = 7;
            label9.Text = "Vui lòng soạn câu hỏi theo đúng định dạng. Tải về file mẫu Docx";
            // 
            // txtDuongDan
            // 
            txtDuongDan.Location = new Point(29, 129);
            txtDuongDan.Margin = new Padding(2);
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.ReadOnly = true;
            txtDuongDan.Size = new Size(571, 27);
            txtDuongDan.TabIndex = 6;
            txtDuongDan.Text = "No file chosen";
            // 
            // btnThemVaoHeThong
            // 
            btnThemVaoHeThong.BackColor = Color.FromArgb(46, 204, 113);
            btnThemVaoHeThong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemVaoHeThong.ForeColor = Color.White;
            btnThemVaoHeThong.Location = new Point(408, 207);
            btnThemVaoHeThong.Margin = new Padding(2);
            btnThemVaoHeThong.Name = "btnThemVaoHeThong";
            btnThemVaoHeThong.Size = new Size(191, 36);
            btnThemVaoHeThong.TabIndex = 5;
            btnThemVaoHeThong.Text = "THÊM VÀO HỆ THỐNG";
            btnThemVaoHeThong.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 90);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(71, 20);
            label8.TabIndex = 4;
            label8.Text = "Nội dung";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(322, 14);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(74, 23);
            label7.TabIndex = 3;
            label7.Text = "Chương";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(29, 14);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(79, 23);
            label6.TabIndex = 2;
            label6.Text = "Môn học";
            // 
            // cbChuongFile
            // 
            cbChuongFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuongFile.Location = new Point(332, 37);
            cbChuongFile.Margin = new Padding(2);
            cbChuongFile.Name = "cbChuongFile";
            cbChuongFile.Size = new Size(233, 28);
            cbChuongFile.TabIndex = 1;
            // 
            // cbMonHocFile
            // 
            cbMonHocFile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHocFile.Location = new Point(29, 37);
            cbMonHocFile.Margin = new Padding(2);
            cbMonHocFile.Name = "cbMonHocFile";
            cbMonHocFile.Size = new Size(243, 28);
            cbMonHocFile.TabIndex = 0;
            // 
            // tabThuCong
            // 
            tabThuCong.Controls.Add(groupBox1);
            tabThuCong.Controls.Add(flpDanhSachDapAn);
            tabThuCong.Controls.Add(btnLuuCauHoi);
            tabThuCong.Controls.Add(btnThemDapAn);
            tabThuCong.Controls.Add(label5);
            tabThuCong.Controls.Add(label4);
            tabThuCong.Controls.Add(rtbNoiDung);
            tabThuCong.Controls.Add(label3);
            tabThuCong.Controls.Add(label2);
            tabThuCong.Controls.Add(label1);
            tabThuCong.Controls.Add(cbDoKho);
            tabThuCong.Controls.Add(cbChuong);
            tabThuCong.Controls.Add(cbMonHoc);
            tabThuCong.Location = new Point(4, 29);
            tabThuCong.Margin = new Padding(2);
            tabThuCong.Name = "tabThuCong";
            tabThuCong.Padding = new Padding(16);
            tabThuCong.Size = new Size(632, 478);
            tabThuCong.TabIndex = 1;
            tabThuCong.Text = "Thêm thủ công";
            tabThuCong.UseVisualStyleBackColor = true;
            // 
            // btnLuuCauHoi
            // 
            btnLuuCauHoi.BackColor = SystemColors.HotTrack;
            btnLuuCauHoi.ForeColor = Color.White;
            btnLuuCauHoi.Location = new Point(17, 442);
            btnLuuCauHoi.Margin = new Padding(2);
            btnLuuCauHoi.Name = "btnLuuCauHoi";
            btnLuuCauHoi.Size = new Size(118, 32);
            btnLuuCauHoi.TabIndex = 11;
            btnLuuCauHoi.Text = "+ Lưu câu hỏi";
            btnLuuCauHoi.UseVisualStyleBackColor = false;
            // 
            // btnThemDapAn
            // 
            btnThemDapAn.BackColor = Color.FromArgb(0, 102, 204);
            btnThemDapAn.FlatStyle = FlatStyle.Flat;
            btnThemDapAn.ForeColor = Color.White;
            btnThemDapAn.Location = new Point(17, 303);
            btnThemDapAn.Margin = new Padding(2);
            btnThemDapAn.Name = "btnThemDapAn";
            btnThemDapAn.Size = new Size(167, 27);
            btnThemDapAn.TabIndex = 9;
            btnThemDapAn.Text = "thêm đáp án mới";
            btnThemDapAn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 203);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 12;
            label5.Text = "Danh sách đáp án";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 74);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 13;
            label4.Text = "Nội dung câu hỏi";
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Location = new Point(17, 97);
            rtbNoiDung.Margin = new Padding(2);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(589, 93);
            rtbNoiDung.TabIndex = 14;
            rtbNoiDung.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 6);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 15;
            label3.Text = "Độ khó";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 6);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 16;
            label2.Text = "Chương";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 17;
            label1.Text = "Môn học";
            // 
            // cbDoKho
            // 
            cbDoKho.Location = new Point(459, 29);
            cbDoKho.Margin = new Padding(2);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.Size = new Size(146, 28);
            cbDoKho.TabIndex = 18;
            // 
            // cbChuong
            // 
            cbChuong.Location = new Point(229, 29);
            cbChuong.Margin = new Padding(2);
            cbChuong.Name = "cbChuong";
            cbChuong.Size = new Size(146, 28);
            cbChuong.TabIndex = 19;
            // 
            // cbMonHoc
            // 
            cbMonHoc.Location = new Point(17, 29);
            cbMonHoc.Margin = new Padding(2);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(146, 28);
            cbMonHoc.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Word Documents|*.docx|All Files|*.*";
            openFileDialog1.Title = "Chọn file câu hỏi";
            // 
            // flpDanhSachDapAn
            // 
            flpDanhSachDapAn.Location = new Point(19, 226);
            flpDanhSachDapAn.Name = "flpDanhSachDapAn";
            flpDanhSachDapAn.Size = new Size(586, 72);
            flpDanhSachDapAn.TabIndex = 21;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(19, 365);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(586, 40);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // frmSuaCauhoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 511);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "frmSuaCauhoi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sữa câu hỏi";
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
        private System.Windows.Forms.Button btnThemDapAn;
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
        private FlowLayoutPanel flpDanhSachDapAn;
        private GroupBox groupBox1;
    }
}