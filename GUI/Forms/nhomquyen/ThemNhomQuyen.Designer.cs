namespace GUI.forms.nhomquyen
{
    partial class ThemNhomQuyen
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

        #region Windows Form Designer generated code

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tblThem = new Guna.UI2.WinForms.Guna2DataGridView();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label2 = new Label();
            tsThamGiaThi = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            tsThamGiaHocPhan = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            lbErrorTenNhomQuyen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            colId = new DataGridViewTextBoxColumn();
            colTenChucNang = new DataGridViewTextBoxColumn();
            colXem = new DataGridViewCheckBoxColumn();
            colThem = new DataGridViewCheckBoxColumn();
            colSua = new DataGridViewCheckBoxColumn();
            colXoa = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tblThem).BeginInit();
            SuspendLayout();
            // 
            // tblThem
            // 
            tblThem.AllowDrop = true;
            tblThem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            tblThem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tblThem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tblThem.ColumnHeadersHeight = 50;
            tblThem.Columns.AddRange(new DataGridViewColumn[] { colId, colTenChucNang, colXem, colThem, colSua, colXoa });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.Padding = new Padding(1);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tblThem.DefaultCellStyle = dataGridViewCellStyle3;
            tblThem.GridColor = Color.FromArgb(231, 229, 255);
            tblThem.Location = new Point(22, 104);
            tblThem.Name = "tblThem";
            tblThem.RowHeadersVisible = false;
            tblThem.RowHeadersWidth = 51;
            tblThem.RowTemplate.Height = 50;
            tblThem.Size = new Size(778, 371);
            tblThem.TabIndex = 7;
            tblThem.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tblThem.ThemeStyle.AlternatingRowsStyle.Font = null;
            tblThem.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tblThem.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tblThem.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tblThem.ThemeStyle.BackColor = Color.White;
            tblThem.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tblThem.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(242, 245, 250);
            tblThem.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tblThem.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tblThem.ThemeStyle.HeaderStyle.ForeColor = Color.Gray;
            tblThem.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tblThem.ThemeStyle.HeaderStyle.Height = 50;
            tblThem.ThemeStyle.ReadOnly = false;
            tblThem.ThemeStyle.RowsStyle.BackColor = Color.White;
            tblThem.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tblThem.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tblThem.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tblThem.ThemeStyle.RowsStyle.Height = 50;
            tblThem.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tblThem.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            btnAdd.Location = new Point(565, 557);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(225, 41);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "LƯU NHÓM QUYỀN";
            btnAdd.Click += btnAdd_Click;
            // 
            // txtName
            // 
            txtName.BorderRadius = 4;
            txtName.CustomizableEdges = customizableEdges3;
            txtName.DefaultText = "Nhập tên nhóm quyền...";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(25, 27);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(4);
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtName.Size = new Size(765, 44);
            txtName.TabIndex = 9;
            txtName.Enter += txtName_Enter;
            txtName.Leave += txtName_Leave;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 2;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges5;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.FromArgb(224, 224, 224);
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Gray;
            btnCancel.Location = new Point(440, 557);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancel.Size = new Size(106, 41);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "HỦY";
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(449, 495);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 14;
            label1.Text = "Tham gia thi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(648, 494);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 15;
            label2.Text = "Tham gia học phần";
            // 
            // tsThamGiaThi
            // 
            tsThamGiaThi.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            tsThamGiaThi.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            tsThamGiaThi.CheckedState.InnerBorderColor = Color.White;
            tsThamGiaThi.CheckedState.InnerColor = Color.White;
            tsThamGiaThi.Cursor = Cursors.Hand;
            tsThamGiaThi.CustomizableEdges = customizableEdges7;
            tsThamGiaThi.Location = new Point(404, 495);
            tsThamGiaThi.Name = "tsThamGiaThi";
            tsThamGiaThi.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tsThamGiaThi.Size = new Size(39, 21);
            tsThamGiaThi.TabIndex = 19;
            tsThamGiaThi.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            tsThamGiaThi.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            tsThamGiaThi.UncheckedState.InnerBorderColor = Color.White;
            tsThamGiaThi.UncheckedState.InnerColor = Color.White;
            // 
            // tsThamGiaHocPhan
            // 
            tsThamGiaHocPhan.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            tsThamGiaHocPhan.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            tsThamGiaHocPhan.CheckedState.InnerBorderColor = Color.White;
            tsThamGiaHocPhan.CheckedState.InnerColor = Color.White;
            tsThamGiaHocPhan.Cursor = Cursors.Hand;
            tsThamGiaHocPhan.CustomizableEdges = customizableEdges9;
            tsThamGiaHocPhan.Location = new Point(603, 494);
            tsThamGiaHocPhan.Name = "tsThamGiaHocPhan";
            tsThamGiaHocPhan.ShadowDecoration.CustomizableEdges = customizableEdges10;
            tsThamGiaHocPhan.Size = new Size(39, 21);
            tsThamGiaHocPhan.TabIndex = 20;
            tsThamGiaHocPhan.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            tsThamGiaHocPhan.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            tsThamGiaHocPhan.UncheckedState.InnerBorderColor = Color.White;
            tsThamGiaHocPhan.UncheckedState.InnerColor = Color.White;
            // 
            // lbErrorTenNhomQuyen
            // 
            lbErrorTenNhomQuyen.BackColor = Color.Transparent;
            lbErrorTenNhomQuyen.Font = new Font("Segoe UI", 8F);
            lbErrorTenNhomQuyen.ForeColor = Color.Red;
            lbErrorTenNhomQuyen.Location = new Point(25, 79);
            lbErrorTenNhomQuyen.Name = "lbErrorTenNhomQuyen";
            lbErrorTenNhomQuyen.Size = new Size(172, 19);
            lbErrorTenNhomQuyen.TabIndex = 22;
            lbErrorTenNhomQuyen.Text = "Message lỗi tên nhóm quyền";
            lbErrorTenNhomQuyen.Visible = false;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            // 
            // colTenChucNang
            // 
            colTenChucNang.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTenChucNang.FillWeight = 85.47237F;
            colTenChucNang.HeaderText = "Tên chức năng";
            colTenChucNang.MinimumWidth = 6;
            colTenChucNang.Name = "colTenChucNang";
            colTenChucNang.Resizable = DataGridViewTriState.False;
            colTenChucNang.Width = 150;
            // 
            // colXem
            // 
            colXem.FillWeight = 85.47237F;
            colXem.HeaderText = "Xem";
            colXem.MinimumWidth = 6;
            colXem.Name = "colXem";
            colXem.Resizable = DataGridViewTriState.True;
            colXem.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colThem
            // 
            colThem.FillWeight = 85.47237F;
            colThem.HeaderText = "Thêm";
            colThem.MinimumWidth = 6;
            colThem.Name = "colThem";
            colThem.Resizable = DataGridViewTriState.True;
            colThem.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colSua
            // 
            colSua.HeaderText = "Sửa";
            colSua.MinimumWidth = 6;
            colSua.Name = "colSua";
            // 
            // colXoa
            // 
            colXoa.HeaderText = "Xóa";
            colXoa.MinimumWidth = 6;
            colXoa.Name = "colXoa";
            // 
            // ThemNhomQuyen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 623);
            Controls.Add(lbErrorTenNhomQuyen);
            Controls.Add(tsThamGiaHocPhan);
            Controls.Add(tsThamGiaThi);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(tblThem);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ThemNhomQuyen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ThemNhomQuyen";
            ((System.ComponentModel.ISupportInitialize)tblThem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView tblThem;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsThamGiaThi;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsThamGiaHocPhan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbErrorTenNhomQuyen;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTenChucNang;
        private DataGridViewCheckBoxColumn colXem;
        private DataGridViewCheckBoxColumn colThem;
        private DataGridViewCheckBoxColumn colSua;
        private DataGridViewCheckBoxColumn colXoa;
    }
}