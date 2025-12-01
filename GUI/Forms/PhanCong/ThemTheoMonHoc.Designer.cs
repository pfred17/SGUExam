namespace GUI.forms.PhanCong
{
    partial class ThemTheoMonHoc
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblMonHoc = new Label();
            cbxMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            dgv = new DataGridView();
            MSSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            NhomQuyen = new DataGridViewTextBoxColumn();
            CheckCol = new DataGridViewCheckBoxColumn();
            btnPrev = new Guna.UI2.WinForms.Guna2Button();
            lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(30, 43);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(90, 28);
            lblMonHoc.TabIndex = 13;
            lblMonHoc.Text = "Môn học";
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.BackColor = Color.Transparent;
            cbxMonHoc.Cursor = Cursors.Hand;
            cbxMonHoc.CustomizableEdges = customizableEdges11;
            cbxMonHoc.DrawMode = DrawMode.OwnerDrawFixed;
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.Font = new Font("Segoe UI", 10F);
            cbxMonHoc.ForeColor = Color.FromArgb(68, 88, 112);
            cbxMonHoc.ItemHeight = 30;
            cbxMonHoc.Location = new Point(155, 40);
            cbxMonHoc.Margin = new Padding(3, 4, 3, 4);
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbxMonHoc.Size = new Size(671, 36);
            cbxMonHoc.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Control;
            txtSearch.CustomizableEdges = customizableEdges13;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(30, 123);
            txtSearch.Margin = new Padding(3, 5, 3, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.Gray;
            txtSearch.PlaceholderText = "Tìm kiếm giảng viên...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(798, 48);
            txtSearch.TabIndex = 15;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new DataGridViewColumn[] { MSSV, HoTen, Email, NhomQuyen, CheckCol });
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(231, 229, 255);
            dgv.Location = new Point(30, 199);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.RowTemplate.Height = 40;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.Size = new Size(798, 280);
            dgv.TabIndex = 16;
            dgv.CellContentClick += dgv_CellContentClick;
            dgv.CellValueChanged += dgv_CellValueChanged;
            dgv.SelectionChanged += dgv_SelectionChanged;
            // 
            // MSSV
            // 
            MSSV.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            MSSV.DataPropertyName = "MSSV";
            MSSV.FillWeight = 74.3705139F;
            MSSV.HeaderText = "Mã giảng viên";
            MSSV.MinimumWidth = 6;
            MSSV.Name = "MSSV";
            MSSV.ReadOnly = true;
            MSSV.Resizable = DataGridViewTriState.False;
            MSSV.SortMode = DataGridViewColumnSortMode.NotSortable;
            MSSV.Width = 147;
            // 
            // HoTen
            // 
            HoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HoTen.DataPropertyName = "HoTen";
            HoTen.FillWeight = 74.3705139F;
            HoTen.HeaderText = "Tên giảng viên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Resizable = DataGridViewTriState.False;
            HoTen.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Email.DataPropertyName = "Email";
            Email.FillWeight = 74.3705139F;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Resizable = DataGridViewTriState.False;
            Email.SortMode = DataGridViewColumnSortMode.NotSortable;
            Email.Width = 66;
            // 
            // NhomQuyen
            // 
            NhomQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            NhomQuyen.DataPropertyName = "Role";
            NhomQuyen.HeaderText = "Nhóm quyền";
            NhomQuyen.MinimumWidth = 6;
            NhomQuyen.Name = "NhomQuyen";
            NhomQuyen.ReadOnly = true;
            NhomQuyen.Resizable = DataGridViewTriState.False;
            NhomQuyen.SortMode = DataGridViewColumnSortMode.NotSortable;
            NhomQuyen.Width = 138;
            // 
            // CheckCol
            // 
            CheckCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CheckCol.HeaderText = "Chọn";
            CheckCol.MinimumWidth = 6;
            CheckCol.Name = "CheckCol";
            CheckCol.Resizable = DataGridViewTriState.False;
            CheckCol.Width = 66;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges15;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(657, 580);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrev.Size = new Size(40, 40);
            btnPrev.TabIndex = 17;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(702, 580);
            lblPage.Margin = new Padding(3, 4, 3, 4);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(80, 40);
            lblPage.TabIndex = 19;
            lblPage.Text = "1";
            lblPage.TextAlignment = ContentAlignment.MiddleCenter;
            lblPage.Click += lblPage_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DodgerBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges17;
            btnNext.FillColor = Color.FromArgb(6, 101, 208);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(787, 580);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnNext.Size = new Size(40, 40);
            btnNext.TabIndex = 18;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DodgerBlue;
            btnThem.Cursor = Cursors.Hand;
            btnThem.CustomizableEdges = customizableEdges19;
            btnThem.FillColor = Color.FromArgb(6, 101, 208);
            btnThem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(630, 660);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnThem.Size = new Size(200, 40);
            btnThem.TabIndex = 20;
            btnThem.Text = "+LƯU PHÂN CÔNG";
            btnThem.Click += btnThem_Click;
            // 
            // ThemTheoMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMonHoc);
            Controls.Add(cbxMonHoc);
            Controls.Add(txtSearch);
            Controls.Add(dgv);
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnThem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ThemTheoMonHoc";
            Size = new Size(857, 747);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbxMonHoc;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private DataGridView dgv;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private DataGridViewTextBoxColumn MSSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn NhomQuyen;
        private DataGridViewCheckBoxColumn CheckCol;
    }
}
