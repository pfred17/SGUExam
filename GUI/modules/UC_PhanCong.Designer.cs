namespace GUI.modules
{
    partial class UC_PhanCong
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnMain = new Panel();
            dgvPhanCong = new DataGridView();
            btnPrev = new Guna.UI2.WinForms.Guna2Button();
            lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            pnHeader = new Panel();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            MaPhanCong = new DataGridViewTextBoxColumn();
            MaMon = new DataGridViewTextBoxColumn();
            MonHoc = new DataGridViewTextBoxColumn();
            MaGiangVien = new DataGridViewTextBoxColumn();
            TenGiangVien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            EditCol = new DataGridViewImageColumn();
            DeleteCol = new DataGridViewImageColumn();
            pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).BeginInit();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnMain
            // 
            pnMain.BackColor = Color.White;
            pnMain.Controls.Add(dgvPhanCong);
            pnMain.Controls.Add(btnPrev);
            pnMain.Controls.Add(lblPage);
            pnMain.Controls.Add(btnNext);
            pnMain.Dock = DockStyle.Fill;
            pnMain.ForeColor = Color.Black;
            pnMain.Location = new Point(0, 0);
            pnMain.Margin = new Padding(0);
            pnMain.Name = "pnMain";
            pnMain.Padding = new Padding(23, 27, 23, 27);
            pnMain.Size = new Size(1600, 1217);
            pnMain.TabIndex = 1;
            // 
            // dgvPhanCong
            // 
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.AllowUserToDeleteRows = false;
            dgvPhanCong.AllowUserToResizeColumns = false;
            dgvPhanCong.AllowUserToResizeRows = false;
            dgvPhanCong.BackgroundColor = Color.White;
            dgvPhanCong.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhanCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhanCong.ColumnHeadersHeight = 40;
            dgvPhanCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhanCong.Columns.AddRange(new DataGridViewColumn[] { MaPhanCong, MaMon, MonHoc, MaGiangVien, TenGiangVien, TrangThai, EditCol, DeleteCol });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPhanCong.DefaultCellStyle = dataGridViewCellStyle5;
            dgvPhanCong.EnableHeadersVisualStyles = false;
            dgvPhanCong.GridColor = Color.FromArgb(231, 229, 255);
            dgvPhanCong.Location = new Point(26, 140);
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.Name = "dgvPhanCong";
            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.RowHeadersVisible = false;
            dgvPhanCong.RowHeadersWidth = 51;
            dgvPhanCong.RowTemplate.Height = 40;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPhanCong.Size = new Size(1068, 348);
            dgvPhanCong.TabIndex = 0;
            dgvPhanCong.CellContentClick += dgvPhanCong_CellContentClick;
            dgvPhanCong.CellFormatting += dgvPhanCong_CellFormatting;
            dgvPhanCong.CellMouseMove += dgvPhanCong_CellMouseMove;
            dgvPhanCong.SelectionChanged += dgvPhanCong_SelectionChanged;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges1;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(922, 640);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrev.Size = new Size(40, 40);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(968, 640);
            lblPage.Margin = new Padding(3, 4, 3, 4);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(80, 40);
            lblPage.TabIndex = 5;
            lblPage.Text = "1";
            lblPage.TextAlignment = ContentAlignment.MiddleCenter;
            lblPage.Click += lblPage_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DodgerBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges3;
            btnNext.FillColor = Color.FromArgb(6, 101, 208);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(1054, 640);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnNext.Size = new Size(40, 40);
            btnNext.TabIndex = 6;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.WhiteSmoke;
            pnHeader.Controls.Add(btnThem);
            pnHeader.Controls.Add(txtSearch);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Margin = new Padding(0);
            pnHeader.Name = "pnHeader";
            pnHeader.Padding = new Padding(11, 13, 11, 13);
            pnHeader.Size = new Size(1600, 80);
            pnHeader.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 15;
            btnThem.Cursor = Cursors.Hand;
            btnThem.CustomizableEdges = customizableEdges5;
            btnThem.FillColor = Color.FromArgb(6, 101, 208);
            btnThem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(886, 15);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThem.Size = new Size(210, 50);
            btnThem.TabIndex = 0;
            btnThem.Text = "+THÊM PHÂN CÔNG";
            btnThem.Click += btnThem_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Control;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(26, 15);
            txtSearch.Margin = new Padding(3, 5, 3, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.Gray;
            txtSearch.PlaceholderText = "Tìm kiếm giảng viên, môn học...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(275, 50);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // MaPhanCong
            // 
            MaPhanCong.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MaPhanCong.DefaultCellStyle = dataGridViewCellStyle2;
            MaPhanCong.FillWeight = 74.3705139F;
            MaPhanCong.HeaderText = "#";
            MaPhanCong.MinimumWidth = 6;
            MaPhanCong.Name = "MaPhanCong";
            MaPhanCong.ReadOnly = true;
            MaPhanCong.Resizable = DataGridViewTriState.False;
            MaPhanCong.SortMode = DataGridViewColumnSortMode.NotSortable;
            MaPhanCong.Width = 30;
            // 
            // MaMon
            // 
            MaMon.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MaMon.DefaultCellStyle = dataGridViewCellStyle3;
            MaMon.FillWeight = 74.3705139F;
            MaMon.HeaderText = "Mã môn";
            MaMon.MinimumWidth = 6;
            MaMon.Name = "MaMon";
            MaMon.ReadOnly = true;
            MaMon.Resizable = DataGridViewTriState.False;
            MaMon.SortMode = DataGridViewColumnSortMode.NotSortable;
            MaMon.Width = 94;
            // 
            // MonHoc
            // 
            MonHoc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MonHoc.DefaultCellStyle = dataGridViewCellStyle4;
            MonHoc.FillWeight = 74.3705139F;
            MonHoc.HeaderText = "Môn học";
            MonHoc.MinimumWidth = 6;
            MonHoc.Name = "MonHoc";
            MonHoc.ReadOnly = true;
            MonHoc.Resizable = DataGridViewTriState.False;
            MonHoc.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MaGiangVien
            // 
            MaGiangVien.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            MaGiangVien.FillWeight = 74.3705139F;
            MaGiangVien.HeaderText = "Mã giảng viên";
            MaGiangVien.MinimumWidth = 6;
            MaGiangVien.Name = "MaGiangVien";
            MaGiangVien.ReadOnly = true;
            MaGiangVien.Resizable = DataGridViewTriState.False;
            MaGiangVien.SortMode = DataGridViewColumnSortMode.NotSortable;
            MaGiangVien.Width = 147;
            // 
            // TenGiangVien
            // 
            TenGiangVien.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TenGiangVien.HeaderText = "Tên giảng viên";
            TenGiangVien.MinimumWidth = 6;
            TenGiangVien.Name = "TenGiangVien";
            TenGiangVien.ReadOnly = true;
            TenGiangVien.Resizable = DataGridViewTriState.False;
            TenGiangVien.SortMode = DataGridViewColumnSortMode.NotSortable;
            TenGiangVien.Width = 151;
            // 
            // TrangThai
            // 
            TrangThai.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            TrangThai.Width = 131;
            // 
            // EditCol
            // 
            EditCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EditCol.FillWeight = 152.284286F;
            EditCol.HeaderText = "";
            EditCol.MinimumWidth = 6;
            EditCol.Name = "EditCol";
            EditCol.ReadOnly = true;
            EditCol.Resizable = DataGridViewTriState.False;
            EditCol.Width = 50;
            // 
            // DeleteCol
            // 
            DeleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DeleteCol.FillWeight = 150.233688F;
            DeleteCol.HeaderText = "";
            DeleteCol.MinimumWidth = 6;
            DeleteCol.Name = "DeleteCol";
            DeleteCol.ReadOnly = true;
            DeleteCol.Resizable = DataGridViewTriState.False;
            DeleteCol.Width = 50;
            // 
            // UC_PhanCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnHeader);
            Controls.Add(pnMain);
            Name = "UC_PhanCong";
            Size = new Size(1600, 1217);
            pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).EndInit();
            pnHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnMain;
        private DataGridView dgvPhanCong;
        private Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private DataGridViewTextBoxColumn MaPhanCong;
        private DataGridViewTextBoxColumn MaMon;
        private DataGridViewTextBoxColumn MonHoc;
        private DataGridViewTextBoxColumn MaGiangVien;
        private DataGridViewTextBoxColumn TenGiangVien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewImageColumn EditCol;
        private DataGridViewImageColumn DeleteCol;
    }
}
