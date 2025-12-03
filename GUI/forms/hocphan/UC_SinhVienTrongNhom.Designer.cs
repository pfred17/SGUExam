namespace GUI
{
    partial class UC_SinhVienTrongNhom
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SinhVienTrongNhom));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnThemSV = new Guna.UI2.WinForms.Guna2Button();
            btnXemDiem = new Guna.UI2.WinForms.Guna2Button();
            btnXuatDL = new Guna.UI2.WinForms.Guna2Button();
            tbTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lblPagination = new Label();
            flpPage = new FlowLayoutPanel();
            btnNext = new Button();
            btnPrev = new Button();
            dgvSinhVien = new Guna.UI2.WinForms.Guna2DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colMaSinhVien = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colHanhDong = new DataGridViewButtonColumn();
            guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lbThongTinNhom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label1 = new Label();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            guna2CustomGradientPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnThemSV
            // 
            btnThemSV.BorderRadius = 4;
            btnThemSV.CustomizableEdges = customizableEdges1;
            btnThemSV.DisabledState.BorderColor = Color.DarkGray;
            btnThemSV.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemSV.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemSV.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemSV.ForeColor = Color.White;
            btnThemSV.Location = new Point(908, 23);
            btnThemSV.Name = "btnThemSV";
            btnThemSV.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThemSV.Size = new Size(180, 45);
            btnThemSV.TabIndex = 0;
            btnThemSV.Text = "Thêm sinh viên";
            btnThemSV.Click += btnThemSV_Click;
            // 
            // btnXemDiem
            // 
            btnXemDiem.BorderRadius = 4;
            btnXemDiem.CustomizableEdges = customizableEdges3;
            btnXemDiem.DisabledState.BorderColor = Color.DarkGray;
            btnXemDiem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXemDiem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXemDiem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXemDiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemDiem.ForeColor = Color.White;
            btnXemDiem.Location = new Point(441, 23);
            btnXemDiem.Name = "btnXemDiem";
            btnXemDiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnXemDiem.Size = new Size(212, 45);
            btnXemDiem.TabIndex = 1;
            btnXemDiem.Text = "Xem chi tiết điểm";
            btnXemDiem.Click += btnXemDiem_Click;
            // 
            // btnXuatDL
            // 
            btnXuatDL.BorderRadius = 4;
            btnXuatDL.CustomizableEdges = customizableEdges5;
            btnXuatDL.DisabledState.BorderColor = Color.DarkGray;
            btnXuatDL.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXuatDL.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXuatDL.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXuatDL.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatDL.ForeColor = Color.White;
            btnXuatDL.Location = new Point(694, 23);
            btnXuatDL.Name = "btnXuatDL";
            btnXuatDL.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnXuatDL.Size = new Size(180, 45);
            btnXuatDL.TabIndex = 2;
            btnXuatDL.Text = "Xuất dữ liệu";
            btnXuatDL.Click += btnXuatDL_Click;
            // 
            // tbTimKiem
            // 
            tbTimKiem.CustomizableEdges = customizableEdges7;
            tbTimKiem.DefaultText = "";
            tbTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTimKiem.Font = new Font("Segoe UI", 9F);
            tbTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTimKiem.Location = new Point(124, 23);
            tbTimKiem.Margin = new Padding(4, 5, 4, 5);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.PlaceholderText = "";
            tbTimKiem.SelectedText = "";
            tbTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbTimKiem.Size = new Size(300, 45);
            tbTimKiem.TabIndex = 3;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(lblPagination);
            guna2CustomGradientPanel1.Controls.Add(flpPage);
            guna2CustomGradientPanel1.Controls.Add(btnNext);
            guna2CustomGradientPanel1.Controls.Add(btnPrev);
            guna2CustomGradientPanel1.Controls.Add(dgvSinhVien);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges9;
            guna2CustomGradientPanel1.Location = new Point(0, 169);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2CustomGradientPanel1.Size = new Size(1120, 561);
            guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // lblPagination
            // 
            lblPagination.AutoSize = true;
            lblPagination.Location = new Point(742, 478);
            lblPagination.Name = "lblPagination";
            lblPagination.Size = new Size(27, 25);
            lblPagination.TabIndex = 4;
            lblPagination.Text = "lb";
            lblPagination.Click += lblPagination_Click;
            // 
            // flpPage
            // 
            flpPage.Location = new Point(815, 429);
            flpPage.Name = "flpPage";
            flpPage.Size = new Size(200, 36);
            flpPage.TabIndex = 3;
            flpPage.WrapContents = false;
            flpPage.Click += BtnPage_Click;
            flpPage.Paint += flpPage_Paint;
            // 
            // btnNext
            // 
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(1021, 429);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(67, 36);
            btnNext.TabIndex = 2;
            btnNext.TextAlign = ContentAlignment.MiddleLeft;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.Location = new Point(742, 429);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(67, 36);
            btnPrev.TabIndex = 1;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // dgvSinhVien
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvSinhVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSinhVien.ColumnHeadersHeight = 27;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colSTT, colHoTen, colMaSinhVien, colGioiTinh, colHanhDong });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSinhVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSinhVien.GridColor = Color.FromArgb(231, 229, 255);
            dgvSinhVien.Location = new Point(25, 37);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 62;
            dgvSinhVien.Size = new Size(1063, 376);
            dgvSinhVien.TabIndex = 0;
            dgvSinhVien.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSinhVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvSinhVien.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvSinhVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvSinhVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvSinhVien.ThemeStyle.BackColor = Color.White;
            dgvSinhVien.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvSinhVien.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvSinhVien.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSinhVien.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSinhVien.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvSinhVien.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSinhVien.ThemeStyle.HeaderStyle.Height = 27;
            dgvSinhVien.ThemeStyle.ReadOnly = false;
            dgvSinhVien.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvSinhVien.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSinhVien.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSinhVien.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvSinhVien.ThemeStyle.RowsStyle.Height = 33;
            dgvSinhVien.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvSinhVien.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 8;
            colSTT.Name = "colSTT";
            // 
            // colHoTen
            // 
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 8;
            colHoTen.Name = "colHoTen";
            // 
            // colMaSinhVien
            // 
            colMaSinhVien.HeaderText = "Mã sinh viên";
            colMaSinhVien.MinimumWidth = 8;
            colMaSinhVien.Name = "colMaSinhVien";
            // 
            // colGioiTinh
            // 
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 8;
            colGioiTinh.Name = "colGioiTinh";
            // 
            // colHanhDong
            // 
            colHanhDong.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colHanhDong.HeaderText = "Xóa";
            colHanhDong.MinimumWidth = 7;
            colHanhDong.Name = "colHanhDong";
            colHanhDong.Resizable = DataGridViewTriState.True;
            colHanhDong.SortMode = DataGridViewColumnSortMode.Automatic;
            colHanhDong.Text = "Xóa";
            colHanhDong.UseColumnTextForButtonValue = true;
            colHanhDong.Width = 106;
            // 
            // guna2CustomGradientPanel2
            // 
            guna2CustomGradientPanel2.Controls.Add(lbThongTinNhom);
            guna2CustomGradientPanel2.CustomizableEdges = customizableEdges11;
            guna2CustomGradientPanel2.Location = new Point(0, 92);
            guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            guna2CustomGradientPanel2.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2CustomGradientPanel2.Size = new Size(1120, 71);
            guna2CustomGradientPanel2.TabIndex = 6;
            guna2CustomGradientPanel2.Paint += guna2CustomGradientPanel2_Paint;
            // 
            // lbThongTinNhom
            // 
            lbThongTinNhom.BackColor = Color.Transparent;
            lbThongTinNhom.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThongTinNhom.Location = new Point(25, 23);
            lbThongTinNhom.Name = "lbThongTinNhom";
            lbThongTinNhom.Size = new Size(169, 30);
            lbThongTinNhom.TabIndex = 0;
            lbThongTinNhom.Text = "lbThongTinNhom";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 23);
            label1.Name = "label1";
            label1.Size = new Size(102, 45);
            label1.TabIndex = 7;
            label1.Text = "Tìm kiếm";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UC_SinhVienTrongNhom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(guna2CustomGradientPanel2);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(tbTimKiem);
            Controls.Add(btnXuatDL);
            Controls.Add(btnXemDiem);
            Controls.Add(btnThemSV);
            Name = "UC_SinhVienTrongNhom";
            Size = new Size(1120, 730);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            guna2CustomGradientPanel2.ResumeLayout(false);
            guna2CustomGradientPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnThemSV;
        private Guna.UI2.WinForms.Guna2Button btnXemDiem;
        private Guna.UI2.WinForms.Guna2Button btnXuatDL;
        private Guna.UI2.WinForms.Guna2TextBox tbTimKiem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbThongTinNhom;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSinhVien;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colMaSinhVien;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewButtonColumn colHanhDong;
        private Button btnPrev;
        private Button btnNext;
        private FlowLayoutPanel flpPage;
        private Label lblPagination;
        private Label label1;
    }
}
