namespace GUI.modules
{
    partial class UC_CauHoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            txtTimKiem = new TextBox();
            cbDoKho = new ComboBox();
            cbChuong = new ComboBox();
            cbMonHoc = new ComboBox();
            dgvCauHoi = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colMonHoc = new DataGridViewTextBoxColumn();
            colDoKho = new DataGridViewTextBoxColumn();
            colHanhDong = new DataGridViewButtonColumn();
            label2 = new Label();
            btnTuDieuChinh = new Button();
            btnThemMoi = new Button();
            label1 = new Label();
            btnTimKiem = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvCauHoi).BeginInit();
            SuspendLayout();

            // txtTimKiem
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Location = new Point(25, 220);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(930, 34);
            txtTimKiem.TabIndex = 20;
            txtTimKiem.Text = "Nhập nội dung câu hỏi để tìm kiếm...";
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;
            txtTimKiem.KeyPress += txtTimKiem_KeyPress; // <-- event thêm ở đây

            // cbDoKho
            cbDoKho.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoKho.Font = new Font("Segoe UI", 10F);
            cbDoKho.FormattingEnabled = true;
            cbDoKho.Location = new Point(891, 160);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.Size = new Size(182, 36);
            cbDoKho.TabIndex = 19;
            cbDoKho.SelectedIndexChanged += cbDoKho_SelectedIndexChanged; // <-- event

            // cbChuong
            cbChuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuong.Font = new Font("Segoe UI", 10F);
            cbChuong.FormattingEnabled = true;
            cbChuong.Location = new Point(461, 160);
            cbChuong.Name = "cbChuong";
            cbChuong.Size = new Size(303, 36);
            cbChuong.TabIndex = 18;
            cbChuong.SelectedIndexChanged += cbChuong_SelectedIndexChanged; // <-- event

            // cbMonHoc
            cbMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHoc.Font = new Font("Segoe UI", 10F);
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(25, 160);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(395, 36);
            cbMonHoc.TabIndex = 17;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged; // <-- event

            // dgvCauHoi
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.AllowUserToDeleteRows = false;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCauHoi.BackgroundColor = Color.White;
            dgvCauHoi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCauHoi.Columns.AddRange(new DataGridViewColumn[] { colID, colNoiDung, colMonHoc, colDoKho, colHanhDong });
            dgvCauHoi.Location = new Point(25, 280);
            dgvCauHoi.Name = "dgvCauHoi";
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.RowHeadersVisible = false;
            dgvCauHoi.RowHeadersWidth = 62;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.Size = new Size(1050, 430);
            dgvCauHoi.TabIndex = 16;
            dgvCauHoi.CellContentClick += dgvCauHoi_CellContentClick; // <-- event

            // colID
            colID.DataPropertyName = "ID";
            colID.FillWeight = 50F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;

            // colNoiDung
            colNoiDung.DataPropertyName = "Nội dung câu hỏi";
            colNoiDung.FillWeight = 300F;
            colNoiDung.HeaderText = "Nội dung câu hỏi";
            colNoiDung.MinimumWidth = 8;
            colNoiDung.Name = "colNoiDung";
            colNoiDung.ReadOnly = true;

            // colMonHoc
            colMonHoc.DataPropertyName = "Môn học";
            colMonHoc.HeaderText = "Môn học";
            colMonHoc.MinimumWidth = 8;
            colMonHoc.Name = "colMonHoc";
            colMonHoc.ReadOnly = true;

            // colDoKho
            colDoKho.DataPropertyName = "Độ khó";
            colDoKho.FillWeight = 80F;
            colDoKho.HeaderText = "Độ khó";
            colDoKho.MinimumWidth = 8;
            colDoKho.Name = "colDoKho";
            colDoKho.ReadOnly = true;

            // colHanhDong
            colHanhDong.FillWeight = 70F;
            colHanhDong.HeaderText = "Hành động";
            colHanhDong.MinimumWidth = 8;
            colHanhDong.Name = "colHanhDong";
            colHanhDong.ReadOnly = true;
            colHanhDong.Text = "•••";
            colHanhDong.UseColumnTextForButtonValue = true;

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(213, 100);
            label2.Name = "label2";
            label2.Size = new Size(213, 32);
            label2.TabIndex = 15;
            label2.Text = "Câu hỏi trùng lặp";

            // btnTuDieuChinh
            btnTuDieuChinh.BackColor = Color.FromArgb(243, 156, 18);
            btnTuDieuChinh.FlatStyle = FlatStyle.Flat;
            btnTuDieuChinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTuDieuChinh.ForeColor = Color.White;
            btnTuDieuChinh.Location = new Point(766, 80);
            btnTuDieuChinh.Name = "btnTuDieuChinh";
            btnTuDieuChinh.Size = new Size(320, 56);
            btnTuDieuChinh.TabIndex = 14;
            btnTuDieuChinh.Text = "TỰ ĐIỀU CHỈNH ĐỘ KHÓ";
            btnTuDieuChinh.UseVisualStyleBackColor = false;
            btnTuDieuChinh.Click += btnTuDieuChinh_Click; // <-- event

            // btnThemMoi
            btnThemMoi.BackColor = Color.FromArgb(52, 152, 219);
            btnThemMoi.FlatStyle = FlatStyle.Flat;
            btnThemMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemMoi.ForeColor = Color.White;
            btnThemMoi.Location = new Point(441, 80);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(304, 56);
            btnThemMoi.TabIndex = 13;
            btnThemMoi.Text = "+ THÊM CÂU HỎI MỚI";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click_1;

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(25, 100);
            label1.Name = "label1";
            label1.Size = new Size(172, 32);
            label1.TabIndex = 12;
            label1.Text = "Tất cả câu hỏi";

            // btnTimKiem
            btnTimKiem.BackColor = Color.FromArgb(46, 204, 113);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(961, 220);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(112, 35);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click; // <-- event

            // UC_CauHoi
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(cbDoKho);
            Controls.Add(cbChuong);
            Controls.Add(cbMonHoc);
            Controls.Add(dgvCauHoi);
            Controls.Add(label2);
            Controls.Add(btnTuDieuChinh);
            Controls.Add(btnThemMoi);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            Name = "UC_CauHoi";
            Size = new Size(1100, 730);

            ((System.ComponentModel.ISupportInitialize)dgvCauHoi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbDoKho;
        private System.Windows.Forms.ComboBox cbChuong;
        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoKho;
        private System.Windows.Forms.DataGridViewButtonColumn colHanhDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTuDieuChinh;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
