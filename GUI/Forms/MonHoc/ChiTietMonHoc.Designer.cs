namespace GUI.forms.MonHoc
{
    partial class ChiTietMonHoc
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblThongTinMonHoc = new Label();
            lblDanhSachChuong = new Label();
            dgvChuong = new DataGridView();
            MaChuong = new DataGridViewTextBoxColumn();
            TenChuong = new DataGridViewTextBoxColumn();
            EditCol = new DataGridViewImageColumn();
            DeleteCol = new DataGridViewImageColumn();
            lblThemChuong = new Label();
            txtInput = new Guna.UI2.WinForms.Guna2TextBox();
            lblError = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            btnPrev = new Guna.UI2.WinForms.Guna2Button();
            lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvChuong).BeginInit();
            SuspendLayout();
            // 
            // lblThongTinMonHoc
            // 
            lblThongTinMonHoc.AutoSize = true;
            lblThongTinMonHoc.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongTinMonHoc.Location = new Point(190, 26);
            lblThongTinMonHoc.Name = "lblThongTinMonHoc";
            lblThongTinMonHoc.Size = new Size(204, 25);
            lblThongTinMonHoc.TabIndex = 0;
            lblThongTinMonHoc.Text = "THÔNG TIN MÔN HỌC";
            // 
            // lblDanhSachChuong
            // 
            lblDanhSachChuong.AutoSize = true;
            lblDanhSachChuong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDanhSachChuong.Location = new Point(12, 54);
            lblDanhSachChuong.Name = "lblDanhSachChuong";
            lblDanhSachChuong.Size = new Size(139, 21);
            lblDanhSachChuong.TabIndex = 1;
            lblDanhSachChuong.Text = "Danh sách chương";
            // 
            // dgvChuong
            // 
            dgvChuong.AllowUserToAddRows = false;
            dgvChuong.AllowUserToDeleteRows = false;
            dgvChuong.AllowUserToResizeColumns = false;
            dgvChuong.AllowUserToResizeRows = false;
            dgvChuong.BackgroundColor = Color.White;
            dgvChuong.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(116, 185, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChuong.ColumnHeadersHeight = 40;
            dgvChuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChuong.Columns.AddRange(new DataGridViewColumn[] { MaChuong, TenChuong, EditCol, DeleteCol });
            dgvChuong.EnableHeadersVisualStyles = false;
            dgvChuong.GridColor = Color.FromArgb(231, 229, 255);
            dgvChuong.Location = new Point(12, 84);
            dgvChuong.Margin = new Padding(3, 2, 3, 2);
            dgvChuong.MultiSelect = false;
            dgvChuong.Name = "dgvChuong";
            dgvChuong.ReadOnly = true;
            dgvChuong.RowHeadersVisible = false;
            dgvChuong.RowHeadersWidth = 50;
            dgvChuong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvChuong.Size = new Size(560, 125);
            dgvChuong.TabIndex = 2;
            dgvChuong.CellContentClick += dgvChuong_CellContentClick;
            dgvChuong.CellMouseMove += dgvChuong_CellMouseMove;
            dgvChuong.SelectionChanged += dgvChuong_SelectionChanged;
            // 
            // MaChuong
            // 
            MaChuong.FillWeight = 74.3705139F;
            MaChuong.HeaderText = "#";
            MaChuong.MinimumWidth = 6;
            MaChuong.Name = "MaChuong";
            MaChuong.ReadOnly = true;
            MaChuong.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // TenChuong
            // 
            TenChuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TenChuong.FillWeight = 74.3705139F;
            TenChuong.HeaderText = "Tên chương";
            TenChuong.MinimumWidth = 6;
            TenChuong.Name = "TenChuong";
            TenChuong.ReadOnly = true;
            TenChuong.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // EditCol
            // 
            EditCol.FillWeight = 152.284286F;
            EditCol.HeaderText = "";
            EditCol.MinimumWidth = 6;
            EditCol.Name = "EditCol";
            EditCol.ReadOnly = true;
            EditCol.Resizable = DataGridViewTriState.True;
            EditCol.Width = 50;
            // 
            // DeleteCol
            // 
            DeleteCol.FillWeight = 150.233688F;
            DeleteCol.HeaderText = "";
            DeleteCol.MinimumWidth = 6;
            DeleteCol.Name = "DeleteCol";
            DeleteCol.ReadOnly = true;
            DeleteCol.Resizable = DataGridViewTriState.True;
            DeleteCol.Width = 50;
            // 
            // lblThemChuong
            // 
            lblThemChuong.AutoSize = true;
            lblThemChuong.Cursor = Cursors.Hand;
            lblThemChuong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThemChuong.ForeColor = Color.DodgerBlue;
            lblThemChuong.Location = new Point(12, 295);
            lblThemChuong.Name = "lblThemChuong";
            lblThemChuong.Size = new Size(153, 21);
            lblThemChuong.TabIndex = 3;
            lblThemChuong.Text = "+ Thêm chương mới";
            lblThemChuong.Click += lblThemChuong_Click;
            // 
            // txtInput
            // 
            txtInput.BackColor = SystemColors.Control;
            txtInput.CustomizableEdges = customizableEdges1;
            txtInput.DefaultText = "";
            txtInput.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtInput.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtInput.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtInput.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtInput.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInput.Font = new Font("Segoe UI", 9F);
            txtInput.ForeColor = Color.Black;
            txtInput.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInput.Location = new Point(12, 328);
            txtInput.Margin = new Padding(3, 4, 3, 4);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderForeColor = Color.Gray;
            txtInput.PlaceholderText = "Nhập tên chương";
            txtInput.SelectedText = "";
            txtInput.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtInput.Size = new Size(352, 36);
            txtInput.TabIndex = 4;
            txtInput.TextChanged += txtInputChuong_TextChanged;
            txtInput.Leave += txtInputChuong_Leave;
            // 
            // lblError
            // 
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Segoe UI", 8F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(12, 369);
            lblError.Margin = new Padding(3, 2, 3, 2);
            lblError.Name = "lblError";
            lblError.Size = new Size(64, 15);
            lblError.TabIndex = 7;
            lblError.Text = "Message lỗi";
            lblError.Visible = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.CustomizableEdges = customizableEdges3;
            btnSubmit.FillColor = Color.FromArgb(6, 101, 208);
            btnSubmit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(407, 328);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSubmit.Size = new Size(71, 36);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Thêm";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges5;
            btnCancel.FillColor = Color.Silver;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(487, 328);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancel.Size = new Size(64, 36);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DodgerBlue;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges7;
            btnClose.FillColor = Color.FromArgb(6, 101, 208);
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(486, 414);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClose.Size = new Size(86, 36);
            btnClose.TabIndex = 11;
            btnClose.Text = "Thoát";
            btnClose.Click += btnClose_Click;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DodgerBlue;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.CustomizableEdges = customizableEdges9;
            btnPrev.FillColor = Color.FromArgb(6, 101, 208);
            btnPrev.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(453, 269);
            btnPrev.Margin = new Padding(3, 2, 3, 2);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnPrev.Size = new Size(30, 29);
            btnPrev.TabIndex = 12;
            btnPrev.Text = "<";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = false;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(486, 269);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(50, 29);
            lblPage.TabIndex = 14;
            lblPage.Text = "1/1";
            lblPage.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DodgerBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges11;
            btnNext.FillColor = Color.FromArgb(6, 101, 208);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(539, 269);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnNext.Size = new Size(30, 29);
            btnNext.TabIndex = 13;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // ChiTietMonHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(584, 461);
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnClose);
            Controls.Add(lblError);
            Controls.Add(lblThongTinMonHoc);
            Controls.Add(lblDanhSachChuong);
            Controls.Add(dgvChuong);
            Controls.Add(lblThemChuong);
            Controls.Add(txtInput);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChiTietMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết";
            ((System.ComponentModel.ISupportInitialize)dgvChuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblThongTinMonHoc;
        private Label lblDanhSachChuong;
        private DataGridView dgvChuong;
        private Label lblThemChuong;
        private Guna.UI2.WinForms.Guna2TextBox txtInput;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblError;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private DataGridViewTextBoxColumn MaChuong;
        private DataGridViewTextBoxColumn TenChuong;
        private DataGridViewImageColumn EditCol;
        private DataGridViewImageColumn DeleteCol;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
    }
}