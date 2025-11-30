using ClosedXML.Parser;

namespace GUI.modules
{
    partial class UC_CauHoiTrungLap1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cboMonHoc = new ComboBox();
            btnTatCaCauHoi = new Button();
            dgvTrungLap = new DataGridView();
            panel1 = new Panel();
            btnReset = new Button();
            label1 = new Label();
            lblThongKe = new Label();
            MaCauHoi = new DataGridViewTextBoxColumn();
            NoiDung = new DataGridViewTextBoxColumn();
            MonHoc = new DataGridViewTextBoxColumn();
            DoKho = new DataGridViewTextBoxColumn();
            Loai = new DataGridViewTextBoxColumn();
            colView = new DataGridViewImageColumn();
            colDelete = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboMonHoc
            // 
            cboMonHoc.BackColor = Color.WhiteSmoke;
            cboMonHoc.Font = new Font("Segoe UI", 12F);
            cboMonHoc.ForeColor = Color.Black;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(24, 97);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(277, 36);
            cboMonHoc.TabIndex = 0;
            // 
            // btnTatCaCauHoi
            // 
            btnTatCaCauHoi.BackColor = Color.SteelBlue;
            btnTatCaCauHoi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTatCaCauHoi.ForeColor = Color.White;
            btnTatCaCauHoi.Location = new Point(522, 90);
            btnTatCaCauHoi.Name = "btnTatCaCauHoi";
            btnTatCaCauHoi.Size = new Size(150, 41);
            btnTatCaCauHoi.TabIndex = 1;
            btnTatCaCauHoi.Text = "Tất cả câu hỏi";
            btnTatCaCauHoi.UseVisualStyleBackColor = false;
            btnTatCaCauHoi.Click += BtnTatCaCauHoi_Click;
            // 
            // dgvTrungLap
            // 
            dgvTrungLap.AllowUserToAddRows = false;
            dgvTrungLap.AllowUserToResizeColumns = false;
            dgvTrungLap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 249, 253);
            dgvTrungLap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTrungLap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrungLap.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTrungLap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTrungLap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrungLap.Columns.AddRange(new DataGridViewColumn[] { MaCauHoi, NoiDung, MonHoc, DoKho, Loai, colView, colDelete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTrungLap.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTrungLap.Dock = DockStyle.Fill;
            dgvTrungLap.EnableHeadersVisualStyles = false;
            dgvTrungLap.GridColor = Color.FromArgb(235, 240, 245);
            dgvTrungLap.Location = new Point(0, 162);
            dgvTrungLap.MultiSelect = false;
            dgvTrungLap.Name = "dgvTrungLap";
            dgvTrungLap.ReadOnly = true;
            dgvTrungLap.RowHeadersVisible = false;
            dgvTrungLap.RowHeadersWidth = 51;
            dgvTrungLap.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTrungLap.Size = new Size(953, 335);
            dgvTrungLap.TabIndex = 2;
            dgvTrungLap.CellClick += dgvTrungLap_CellClick;
            dgvTrungLap.CellContentClick += dgvTrungLap_CellContentClick;
            dgvTrungLap.SelectionChanged += dgvCauHoiTrungLap1_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblThongKe);
            panel1.Controls.Add(cboMonHoc);
            panel1.Controls.Add(btnTatCaCauHoi);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 162);
            panel1.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.IndianRed;
            btnReset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(830, 92);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 39);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(24, 32);
            label1.Name = "label1";
            label1.Size = new Size(411, 37);
            label1.TabIndex = 3;
            label1.Text = "QUẢN LÝ CÂU HỎI TRÙNG LẶP";
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.Font = new Font("Segoe UI", 12F);
            lblThongKe.ForeColor = Color.DarkGreen;
            lblThongKe.Location = new Point(522, 41);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(411, 28);
            lblThongKe.TabIndex = 2;
            lblThongKe.Text = "Nhóm trùng: 0 | Câu trùng: 0 | Câu duy nhất: 0";
            // 
            // MaCauHoi
            // 
            MaCauHoi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MaCauHoi.FillWeight = 70F;
            MaCauHoi.HeaderText = "ID";
            MaCauHoi.MinimumWidth = 6;
            MaCauHoi.Name = "MaCauHoi";
            MaCauHoi.ReadOnly = true;
            // 
            // NoiDung
            // 
            NoiDung.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NoiDung.FillWeight = 200F;
            NoiDung.HeaderText = "Nội dung";
            NoiDung.MinimumWidth = 6;
            NoiDung.Name = "NoiDung";
            NoiDung.ReadOnly = true;
            // 
            // MonHoc
            // 
            MonHoc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc.HeaderText = "Môn học";
            MonHoc.MinimumWidth = 6;
            MonHoc.Name = "MonHoc";
            MonHoc.ReadOnly = true;
            // 
            // DoKho
            // 
            DoKho.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DoKho.FillWeight = 80F;
            DoKho.HeaderText = "Độ khó";
            DoKho.MinimumWidth = 6;
            DoKho.Name = "DoKho";
            DoKho.ReadOnly = true;
            // 
            // Loai
            // 
            Loai.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Loai.FillWeight = 120F;
            Loai.HeaderText = "Bản gốc / Bản sao";
            Loai.MinimumWidth = 6;
            Loai.Name = "Loai";
            Loai.ReadOnly = true;
            // 
            // colView
            // 
            colView.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colView.FillWeight = 40F;
            colView.HeaderText = "Xem";
            colView.Image = Properties.Resources.icon_eyes;
            colView.MinimumWidth = 6;
            colView.Name = "colView";
            colView.ReadOnly = true;
            // 
            // colDelete
            // 
            colDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDelete.FillWeight = 40F;
            colDelete.HeaderText = "Xóa";
            colDelete.Image = Properties.Resources.icon_delete;
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            // 
            // UC_CauHoiTrungLap1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTrungLap);
            Controls.Add(panel1);
            Name = "UC_CauHoiTrungLap1";
            Size = new Size(953, 497);
            Load += UC_CauHoiTrungLap1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private ComboBox cboMonHoc;
        private Button btnTatCaCauHoi;
        private DataGridView dgvTrungLap;
        private Panel panel1;
        private Button btnReset;
        private Label label1;
        private Label lblThongKe;
        private DataGridViewTextBoxColumn MaCauHoi;
        private DataGridViewTextBoxColumn NoiDung;
        private DataGridViewTextBoxColumn MonHoc;
        private DataGridViewTextBoxColumn DoKho;
        private DataGridViewTextBoxColumn Loai;
        private DataGridViewImageColumn colView;
        private DataGridViewImageColumn colDelete;
    }
}
