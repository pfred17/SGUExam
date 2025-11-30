namespace GUI.modules
{
    partial class UC_CauHoiTrungLap
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
            pnlTop = new Panel();
            btnTatCaCauHoi = new Button();
            lblThongKe = new Label();
            lblTitle = new Label();
            pnlFilter = new Panel();
            btnReset = new Button();
            btnLoc = new Button();
            cboMonHoc = new ComboBox();
            cboLoaiCauHoi = new ComboBox();
            dgvTrungLap = new DataGridView();
            pnlTop.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.WhiteSmoke;
            pnlTop.Controls.Add(btnTatCaCauHoi);
            pnlTop.Controls.Add(lblThongKe);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Size = new Size(1120, 100);
            // 
            // btnTatCaCauHoi
            // 
            btnTatCaCauHoi.BackColor = Color.RoyalBlue;
            btnTatCaCauHoi.FlatStyle = FlatStyle.Flat;
            btnTatCaCauHoi.ForeColor = Color.White;
            btnTatCaCauHoi.Location = new Point(364, 3);
            btnTatCaCauHoi.Size = new Size(130, 32);
            btnTatCaCauHoi.Text = "Tất cả câu hỏi";
            btnTatCaCauHoi.Click += loadTatCauHoi_Click;
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.Font = new Font("Segoe UI", 10F);
            lblThongKe.ForeColor = Color.Crimson;
            lblThongKe.Location = new Point(30, 60);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkOrange;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Quản lý câu hỏi trùng lặp";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(248, 249, 250);
            pnlFilter.Controls.Add(btnReset);
            pnlFilter.Controls.Add(btnLoc);
            pnlFilter.Controls.Add(cboMonHoc);
            pnlFilter.Controls.Add(cboLoaiCauHoi);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Size = new Size(1120, 65);
            pnlFilter.Padding = new Padding(20, 10, 20, 10);
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(560, 20);
            btnReset.Size = new Size(90, 28);
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(0, 123, 255);
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(450, 20);
            btnLoc.Size = new Size(90, 28);
            btnLoc.Text = "Lọc";
            btnLoc.Click += btnLoc_Click;
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.Location = new Point(240, 20);
            cboMonHoc.Size = new Size(180, 28);
            // 
            // cboLoaiCauHoi
            // 
            cboLoaiCauHoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiCauHoi.Location = new Point(30, 20);
            cboLoaiCauHoi.Size = new Size(180, 28);
            // 
            // dgvTrungLap
            // 
            dgvTrungLap.AllowUserToAddRows = false;
            dgvTrungLap.AllowUserToDeleteRows = false;
            dgvTrungLap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrungLap.BackgroundColor = Color.White;
            dgvTrungLap.ColumnHeadersHeight = 29;
            dgvTrungLap.Dock = DockStyle.Fill;
            dgvTrungLap.MultiSelect = false;
            dgvTrungLap.ReadOnly = true;
            dgvTrungLap.RowHeadersWidth = 51;
            dgvTrungLap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvTrungLap.CellContentClick += dgvTrungLap_CellContentClick;
            // 
            // UC_CauHoiTrungLap
            // 
            BackColor = Color.White;
            Controls.Add(dgvTrungLap);
            Controls.Add(pnlFilter);
            Controls.Add(pnlTop);
            Size = new Size(1120, 730);
            Load += UC_CauHoiTrungLap_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblThongKe;
        private Button btnTatCaCauHoi;
        private Panel pnlFilter;
        private ComboBox cboLoaiCauHoi;
        private Button btnReset;
        private Button btnLoc;
        private ComboBox cboMonHoc;
        private DataGridView dgvTrungLap;
    }
}
