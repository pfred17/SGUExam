namespace GUI.modules
{
    partial class UC_PhanQuyen
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tablePhanQuyen = new Guna.UI2.WinForms.Guna2DataGridView();
            MaNhomQuyen = new DataGridViewTextBoxColumn();
            TenNhomQuyen = new DataGridViewTextBoxColumn();
            SoNguoiDung = new DataGridViewTextBoxColumn();
            editCol = new DataGridViewImageColumn();
            deleteCol = new DataGridViewImageColumn();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            btnPrev = new Guna.UI2.WinForms.Guna2Button();
            lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)tablePhanQuyen).BeginInit();
            SuspendLayout();
            // 
            // tablePhanQuyen
            // 
            tablePhanQuyen.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            tablePhanQuyen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tablePhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tablePhanQuyen.ColumnHeadersHeight = 50;
            tablePhanQuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tablePhanQuyen.Columns.AddRange(new DataGridViewColumn[] { MaNhomQuyen, TenNhomQuyen, SoNguoiDung, editCol, deleteCol });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tablePhanQuyen.DefaultCellStyle = dataGridViewCellStyle3;
            tablePhanQuyen.GridColor = Color.FromArgb(231, 229, 255);
            tablePhanQuyen.Location = new Point(40, 90);
            tablePhanQuyen.Name = "tablePhanQuyen";
            tablePhanQuyen.RowHeadersVisible = false;
            tablePhanQuyen.RowHeadersWidth = 51;
            tablePhanQuyen.RowTemplate.Height = 50;
            tablePhanQuyen.Size = new Size(1041, 550);
            tablePhanQuyen.TabIndex = 10;
            tablePhanQuyen.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tablePhanQuyen.ThemeStyle.AlternatingRowsStyle.Font = null;
            tablePhanQuyen.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tablePhanQuyen.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tablePhanQuyen.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tablePhanQuyen.ThemeStyle.BackColor = Color.White;
            tablePhanQuyen.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tablePhanQuyen.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(242, 245, 250);
            tablePhanQuyen.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tablePhanQuyen.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tablePhanQuyen.ThemeStyle.HeaderStyle.ForeColor = Color.Gray;
            tablePhanQuyen.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tablePhanQuyen.ThemeStyle.HeaderStyle.Height = 50;
            tablePhanQuyen.ThemeStyle.ReadOnly = false;
            tablePhanQuyen.ThemeStyle.RowsStyle.BackColor = Color.White;
            tablePhanQuyen.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tablePhanQuyen.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tablePhanQuyen.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tablePhanQuyen.ThemeStyle.RowsStyle.Height = 50;
            tablePhanQuyen.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tablePhanQuyen.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            tablePhanQuyen.CellContentClick += tablePhanQuyen_CellContentClick;
            tablePhanQuyen.CellMouseMove += tablePhanQuyen_CellMouseMove;
            // 
            // MaNhomQuyen
            // 
            MaNhomQuyen.HeaderText = "Mã nhóm quyền";
            MaNhomQuyen.MinimumWidth = 6;
            MaNhomQuyen.Name = "MaNhomQuyen";
            // 
            // TenNhomQuyen
            // 
            TenNhomQuyen.HeaderText = "Tên nhóm quyên";
            TenNhomQuyen.MinimumWidth = 6;
            TenNhomQuyen.Name = "TenNhomQuyen";
            // 
            // SoNguoiDung
            // 
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
            btnAdd.Location = new Point(856, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(225, 36);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "THÊM NHÓM QUYỀN";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges3;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(909, 655);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPrev.Size = new Size(40, 40);
            btnPrev.TabIndex = 11;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(955, 655);
            lblPage.Margin = new Padding(3, 4, 3, 4);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(80, 40);
            lblPage.TabIndex = 12;
            lblPage.Text = "1";
            lblPage.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DodgerBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges5;
            btnNext.FillColor = Color.FromArgb(6, 101, 208);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(1041, 655);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNext.Size = new Size(40, 40);
            btnNext.TabIndex = 13;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderRadius = 2;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(126, 24);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(376, 36);
            txtSearch.TabIndex = 14;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 33);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 15;
            label1.Text = "Tìm kiếm";
            // 
            // UC_PhanQuyen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnAdd);
            Controls.Add(tablePhanQuyen);
            Name = "UC_PhanQuyen";
            Size = new Size(1120, 730);
            ((System.ComponentModel.ISupportInitialize)tablePhanQuyen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView tablePhanQuyen;
        private DataGridViewTextBoxColumn MaNhomQuyen;
        private DataGridViewTextBoxColumn TenNhomQuyen;
        private DataGridViewTextBoxColumn SoNguoiDung;
        private DataGridViewImageColumn editCol;
        private DataGridViewImageColumn deleteCol;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Label label1;
    }
}
