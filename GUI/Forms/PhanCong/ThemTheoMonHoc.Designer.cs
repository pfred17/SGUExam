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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            lblMonHoc.Location = new Point(26, 40);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(71, 21);
            lblMonHoc.TabIndex = 13;
            lblMonHoc.Text = "Môn học";
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.BackColor = Color.Transparent;
            cbxMonHoc.Cursor = Cursors.Hand;
            cbxMonHoc.CustomizableEdges = customizableEdges1;
            cbxMonHoc.DrawMode = DrawMode.OwnerDrawFixed;
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.Font = new Font("Segoe UI", 10F);
            cbxMonHoc.ForeColor = Color.FromArgb(68, 88, 112);
            cbxMonHoc.ItemHeight = 30;
            cbxMonHoc.Location = new Point(136, 33);
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbxMonHoc.Size = new Size(588, 36);
            cbxMonHoc.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Control;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(26, 92);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.Gray;
            txtSearch.PlaceholderText = "Tìm kiếm giảng viên...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(698, 36);
            txtSearch.TabIndex = 15;
            txtSearch.TextChanged += txtSearch_TextChanged;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new DataGridViewColumn[] { MSSV, HoTen, Email, NhomQuyen, CheckCol });
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(231, 229, 255);
            dgv.Location = new Point(26, 149);
            dgv.Margin = new Padding(3, 2, 3, 2);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.RowTemplate.Height = 40;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.Size = new Size(698, 210);
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
            MSSV.Width = 118;
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
            Email.Width = 54;
            // 
            // NhomQuyen
            // 
            NhomQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            NhomQuyen.DataPropertyName = "Role";
            NhomQuyen.HeaderText = "Nhóm quyền";
            NhomQuyen.Name = "NhomQuyen";
            NhomQuyen.ReadOnly = true;
            NhomQuyen.Resizable = DataGridViewTriState.False;
            NhomQuyen.SortMode = DataGridViewColumnSortMode.NotSortable;
            NhomQuyen.Width = 110;
            // 
            // CheckCol
            // 
            CheckCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CheckCol.HeaderText = "Chọn";
            CheckCol.Name = "CheckCol";
            CheckCol.Resizable = DataGridViewTriState.False;
            CheckCol.Width = 54;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges5;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(608, 434);
            btnPrev.Margin = new Padding(3, 2, 3, 2);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrev.Size = new Size(30, 29);
            btnPrev.TabIndex = 17;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(641, 434);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(50, 29);
            lblPage.TabIndex = 19;
            lblPage.Text = "1/1";
            lblPage.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DodgerBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges7;
            btnNext.FillColor = Color.FromArgb(6, 101, 208);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(694, 434);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnNext.Size = new Size(30, 29);
            btnNext.TabIndex = 18;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DodgerBlue;
            btnThem.Cursor = Cursors.Hand;
            btnThem.CustomizableEdges = customizableEdges9;
            btnThem.FillColor = Color.FromArgb(6, 101, 208);
            btnThem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(567, 499);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnThem.Size = new Size(157, 29);
            btnThem.TabIndex = 20;
            btnThem.Text = "+LƯU PHÂN CÔNG";
            btnThem.Click += btnThem_Click;
            // 
            // ThemTheoMonHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMonHoc);
            Controls.Add(cbxMonHoc);
            Controls.Add(txtSearch);
            Controls.Add(dgv);
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnThem);
            Name = "ThemTheoMonHoc";
            Size = new Size(750, 560);
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
