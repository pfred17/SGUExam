namespace GUI.modules
{
    partial class UC_NguoiDung
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
            tableNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            MaNguoiDung = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            editCol = new DataGridViewImageColumn();
            deleteCol = new DataGridViewImageColumn();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)tableNguoiDung).BeginInit();
            SuspendLayout();
            // 
            // tableNguoiDung
            // 
            tableNguoiDung.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            tableNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tableNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tableNguoiDung.ColumnHeadersHeight = 50;
            tableNguoiDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tableNguoiDung.Columns.AddRange(new DataGridViewColumn[] { MaNguoiDung, HoVaTen, Email, Role, TrangThai, editCol, deleteCol });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tableNguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            tableNguoiDung.GridColor = Color.FromArgb(231, 229, 255);
            tableNguoiDung.Location = new Point(38, 78);
            tableNguoiDung.Margin = new Padding(3, 2, 3, 2);
            tableNguoiDung.Name = "tableNguoiDung";
            tableNguoiDung.RowHeadersVisible = false;
            tableNguoiDung.RowHeadersWidth = 51;
            tableNguoiDung.RowTemplate.Height = 50;
            tableNguoiDung.Size = new Size(911, 445);
            tableNguoiDung.TabIndex = 0;
            tableNguoiDung.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tableNguoiDung.ThemeStyle.AlternatingRowsStyle.Font = null;
            tableNguoiDung.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tableNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tableNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tableNguoiDung.ThemeStyle.BackColor = Color.White;
            tableNguoiDung.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tableNguoiDung.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(242, 245, 250);
            tableNguoiDung.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tableNguoiDung.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableNguoiDung.ThemeStyle.HeaderStyle.ForeColor = Color.Gray;
            tableNguoiDung.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tableNguoiDung.ThemeStyle.HeaderStyle.Height = 50;
            tableNguoiDung.ThemeStyle.ReadOnly = false;
            tableNguoiDung.ThemeStyle.RowsStyle.BackColor = Color.White;
            tableNguoiDung.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tableNguoiDung.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tableNguoiDung.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tableNguoiDung.ThemeStyle.RowsStyle.Height = 50;
            tableNguoiDung.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tableNguoiDung.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            tableNguoiDung.CellContentClick += guna2DataGridView1_CellContentClick;
            tableNguoiDung.CellMouseMove += guna2DataGridView1_CellMouseMove;
            // 
            // MaNguoiDung
            // 
            MaNguoiDung.FillWeight = 85.47237F;
            MaNguoiDung.HeaderText = "Mã người dùng";
            MaNguoiDung.MinimumWidth = 6;
            MaNguoiDung.Name = "MaNguoiDung";
            // 
            // HoVaTen
            // 
            HoVaTen.FillWeight = 85.47237F;
            HoVaTen.HeaderText = "Họ và tên";
            HoVaTen.MinimumWidth = 6;
            HoVaTen.Name = "HoVaTen";
            // 
            // Email
            // 
            Email.FillWeight = 85.47237F;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // Role
            // 
            Role.FillWeight = 85.47237F;
            Role.HeaderText = "Nhóm quyền";
            Role.MinimumWidth = 6;
            Role.Name = "Role";
            // 
            // TrangThai
            // 
            TrangThai.FillWeight = 85.47237F;
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
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
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.BorderRadius = 2;
            guna2ComboBox1.Cursor = Cursors.Hand;
            guna2ComboBox1.CustomizableEdges = customizableEdges1;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Segoe UI", 10F);
            guna2ComboBox1.ForeColor = Color.FromArgb(68, 88, 112);
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Items.AddRange(new object[] { "Tất cả", "Quản trị", "Giảng viên", "Sinh viên" });
            guna2ComboBox1.Location = new Point(38, 28);
            guna2ComboBox1.Margin = new Padding(3, 2, 3, 2);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox1.Size = new Size(114, 36);
            guna2ComboBox1.StartIndex = 0;
            guna2ComboBox1.TabIndex = 1;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderRadius = 2;
            guna2TextBox1.CustomizableEdges = customizableEdges3;
            guna2TextBox1.DefaultText = "Tìm kiếm...";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(178, 28);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2TextBox1.Size = new Size(326, 27);
            guna2TextBox1.TabIndex = 2;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 2;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(6, 101, 208);
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(752, 28);
            guna2Button1.Margin = new Padding(3, 2, 3, 2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(197, 27);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "THÊM NGƯỜI DÙNG";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // UC_NguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Button1);
            Controls.Add(guna2TextBox1);
            Controls.Add(guna2ComboBox1);
            Controls.Add(tableNguoiDung);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UC_NguoiDung";
            Size = new Size(980, 548);
            Load += UC_NguoiDung_Load;
            ((System.ComponentModel.ISupportInitialize)tableNguoiDung).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView tableNguoiDung;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private DataGridViewTextBoxColumn MaNguoiDung;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewImageColumn editCol;
        private DataGridViewImageColumn deleteCol;
    }
}
