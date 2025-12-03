namespace GUI.modules
{
    partial class UC_NhomQuyen
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            tblNhomQuyen = new Guna.UI2.WinForms.Guna2DataGridView();
            MaNhomQuyen = new DataGridViewTextBoxColumn();
            TenNhom = new DataGridViewTextBoxColumn();
            SoNguoiDung = new DataGridViewTextBoxColumn();
            editCol = new DataGridViewImageColumn();
            deleteCol = new DataGridViewImageColumn();
            btnPrev = new Guna.UI2.WinForms.Guna2Button();
            lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)tblNhomQuyen).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 2;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(6, 101, 208);
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(856, 28);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(225, 36);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "THÊM MỚI";
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 2;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "Tìm kiếm...";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(40, 28);
            txtSearch.Margin = new Padding(3, 5, 3, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(373, 36);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // tblNhomQuyen
            // 
            tblNhomQuyen.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            tblNhomQuyen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tblNhomQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tblNhomQuyen.ColumnHeadersHeight = 50;
            tblNhomQuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblNhomQuyen.Columns.AddRange(new DataGridViewColumn[] { MaNhomQuyen, TenNhom, SoNguoiDung, editCol, deleteCol });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tblNhomQuyen.DefaultCellStyle = dataGridViewCellStyle3;
            tblNhomQuyen.GridColor = Color.FromArgb(231, 229, 255);
            tblNhomQuyen.Location = new Point(40, 90);
            tblNhomQuyen.Name = "tblNhomQuyen";
            tblNhomQuyen.RowHeadersVisible = false;
            tblNhomQuyen.RowHeadersWidth = 51;
            tblNhomQuyen.RowTemplate.Height = 50;
            tblNhomQuyen.ScrollBars = ScrollBars.None;
            tblNhomQuyen.Size = new Size(1041, 545);
            tblNhomQuyen.TabIndex = 6;
            tblNhomQuyen.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tblNhomQuyen.ThemeStyle.AlternatingRowsStyle.Font = null;
            tblNhomQuyen.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tblNhomQuyen.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tblNhomQuyen.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tblNhomQuyen.ThemeStyle.BackColor = Color.White;
            tblNhomQuyen.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tblNhomQuyen.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(242, 245, 250);
            tblNhomQuyen.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tblNhomQuyen.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tblNhomQuyen.ThemeStyle.HeaderStyle.ForeColor = Color.Gray;
            tblNhomQuyen.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblNhomQuyen.ThemeStyle.HeaderStyle.Height = 50;
            tblNhomQuyen.ThemeStyle.ReadOnly = false;
            tblNhomQuyen.ThemeStyle.RowsStyle.BackColor = Color.White;
            tblNhomQuyen.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tblNhomQuyen.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tblNhomQuyen.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tblNhomQuyen.ThemeStyle.RowsStyle.Height = 50;
            tblNhomQuyen.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tblNhomQuyen.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // MaNhomQuyen
            // 
            MaNhomQuyen.FillWeight = 85.47237F;
            MaNhomQuyen.HeaderText = "Mã nhóm quyền";
            MaNhomQuyen.MinimumWidth = 6;
            MaNhomQuyen.Name = "MaNhomQuyen";
            // 
            // TenNhom
            // 
            TenNhom.FillWeight = 85.47237F;
            TenNhom.HeaderText = "Tên nhóm";
            TenNhom.MinimumWidth = 6;
            TenNhom.Name = "TenNhom";
            // 
            // SoNguoiDung
            // 
            SoNguoiDung.FillWeight = 85.47237F;
            SoNguoiDung.HeaderText = "Số người dùng";
            SoNguoiDung.MinimumWidth = 6;
            SoNguoiDung.Name = "SoNguoiDung";
            // 
            // editCol
            // 
            editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            editCol.FillWeight = 85.47237F;
            editCol.HeaderText = "";
            editCol.MinimumWidth = 6;
            editCol.Name = "editCol";
            editCol.Resizable = DataGridViewTriState.True;
            editCol.SortMode = DataGridViewColumnSortMode.Automatic;
            editCol.Width = 50;
            // 
            // deleteCol
            // 
            deleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            deleteCol.FillWeight = 187.165771F;
            deleteCol.HeaderText = "";
            deleteCol.MinimumWidth = 6;
            deleteCol.Name = "deleteCol";
            deleteCol.Resizable = DataGridViewTriState.True;
            deleteCol.SortMode = DataGridViewColumnSortMode.Automatic;
            deleteCol.Width = 50;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges5;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(944, 656);
            btnPrev.Margin = new Padding(2);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrev.Size = new Size(32, 32);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(980, 656);
            lblPage.Margin = new Padding(2, 3, 2, 3);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(64, 32);
            lblPage.TabIndex = 8;
            lblPage.Text = "1";
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
            btnNext.Location = new Point(1049, 656);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnNext.Size = new Size(32, 32);
            btnNext.TabIndex = 9;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // UC_NhomQuyen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(tblNhomQuyen);
            Controls.Add(btnAdd);
            Controls.Add(txtSearch);
            Name = "UC_NhomQuyen";
            Size = new Size(1120, 730);
            ((System.ComponentModel.ISupportInitialize)tblNhomQuyen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView tblNhomQuyen;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private DataGridViewTextBoxColumn MaNhomQuyen;
        private DataGridViewTextBoxColumn TenNhom;
        private DataGridViewTextBoxColumn SoNguoiDung;
        private DataGridViewImageColumn editCol;
        private DataGridViewImageColumn deleteCol;
    }
}
