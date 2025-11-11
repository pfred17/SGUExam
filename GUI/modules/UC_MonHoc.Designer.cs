namespace GUI.modules
{
    partial class UC_MonHoc
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
            pnMonHoc = new Panel();
            txtSearchMonHoc = new TextBox();
            dgvMonHoc = new DataGridView();
            ma_mh = new DataGridViewTextBoxColumn();
            ten_mh = new DataGridViewTextBoxColumn();
            so_tin_chi = new DataGridViewTextBoxColumn();
            trang_thai = new DataGridViewTextBoxColumn();
            lblDanhSachMonHoc = new Label();
            btnThemMonHoc = new Button();
            pnHeader = new Panel();
            btnXoaMonHoc = new Button();
            btnSuaMonHoc = new Button();
            pnMonHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnMonHoc
            // 
            pnMonHoc.BackColor = Color.White;
            pnMonHoc.Controls.Add(txtSearchMonHoc);
            pnMonHoc.Controls.Add(dgvMonHoc);
            pnMonHoc.Dock = DockStyle.Fill;
            pnMonHoc.Location = new Point(0, 83);
            pnMonHoc.Margin = new Padding(0);
            pnMonHoc.Name = "pnMonHoc";
            pnMonHoc.Padding = new Padding(23, 27, 23, 27);
            pnMonHoc.Size = new Size(933, 570);
            pnMonHoc.TabIndex = 7;
            // 
            // txtSearchMonHoc
            // 
            txtSearchMonHoc.BackColor = Color.Gainsboro;
            txtSearchMonHoc.BorderStyle = BorderStyle.None;
            txtSearchMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchMonHoc.ForeColor = Color.Gray;
            txtSearchMonHoc.Location = new Point(11, 27);
            txtSearchMonHoc.Margin = new Padding(0);
            txtSearchMonHoc.Name = "txtSearchMonHoc";
            txtSearchMonHoc.Size = new Size(908, 27);
            txtSearchMonHoc.TabIndex = 4;
            txtSearchMonHoc.Text = "Tìm kiếm môn học...";
            txtSearchMonHoc.TextChanged += txtSearchMonHoc_TextChanged;
            txtSearchMonHoc.Enter += txtSearchMonHoc_Enter;
            txtSearchMonHoc.Leave += txtSearchMonHoc_Leave;
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.AllowUserToResizeColumns = false;
            dgvMonHoc.AllowUserToResizeRows = false;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonHoc.ColumnHeadersHeight = 32;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMonHoc.Columns.AddRange(new DataGridViewColumn[] { ma_mh, ten_mh, so_tin_chi, trang_thai });
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.GridColor = SystemColors.HighlightText;
            dgvMonHoc.Location = new Point(11, 76);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersVisible = false;
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMonHoc.Size = new Size(908, 464);
            dgvMonHoc.TabIndex = 5;
            dgvMonHoc.CellContentClick += dgvMonHoc_CellContentClick;
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;
            // 
            // ma_mh
            // 
            ma_mh.HeaderText = "Mã môn";
            ma_mh.MinimumWidth = 6;
            ma_mh.Name = "ma_mh";
            ma_mh.ReadOnly = true;
            ma_mh.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ten_mh
            // 
            ten_mh.HeaderText = "Tên môn học";
            ten_mh.MinimumWidth = 6;
            ten_mh.Name = "ten_mh";
            ten_mh.ReadOnly = true;
            ten_mh.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // so_tin_chi
            // 
            so_tin_chi.HeaderText = "Số tín chỉ";
            so_tin_chi.MinimumWidth = 6;
            so_tin_chi.Name = "so_tin_chi";
            so_tin_chi.ReadOnly = true;
            so_tin_chi.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // trang_thai
            // 
            trang_thai.HeaderText = "Trạng thái";
            trang_thai.MinimumWidth = 6;
            trang_thai.Name = "trang_thai";
            trang_thai.ReadOnly = true;
            trang_thai.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // lblDanhSachMonHoc
            // 
            lblDanhSachMonHoc.AutoSize = true;
            lblDanhSachMonHoc.BackColor = Color.Transparent;
            lblDanhSachMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDanhSachMonHoc.Location = new Point(22, 41);
            lblDanhSachMonHoc.Name = "lblDanhSachMonHoc";
            lblDanhSachMonHoc.Size = new Size(198, 28);
            lblDanhSachMonHoc.TabIndex = 1;
            lblDanhSachMonHoc.Text = "Danh sách môn học";
            // 
            // btnThemMonHoc
            // 
            btnThemMonHoc.AutoSize = true;
            btnThemMonHoc.BackColor = Color.DodgerBlue;
            btnThemMonHoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMonHoc.ForeColor = Color.White;
            btnThemMonHoc.Location = new Point(291, 16);
            btnThemMonHoc.Name = "btnThemMonHoc";
            btnThemMonHoc.Size = new Size(202, 64);
            btnThemMonHoc.TabIndex = 3;
            btnThemMonHoc.Text = "Thêm môn học";
            btnThemMonHoc.UseVisualStyleBackColor = false;
            btnThemMonHoc.Click += btnThemMonHoc_Click;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.WhiteSmoke;
            pnHeader.Controls.Add(lblDanhSachMonHoc);
            pnHeader.Controls.Add(btnXoaMonHoc);
            pnHeader.Controls.Add(btnSuaMonHoc);
            pnHeader.Controls.Add(btnThemMonHoc);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Margin = new Padding(0);
            pnHeader.Name = "pnHeader";
            pnHeader.Padding = new Padding(11, 13, 11, 13);
            pnHeader.Size = new Size(933, 83);
            pnHeader.TabIndex = 8;
            // 
            // btnXoaMonHoc
            // 
            btnXoaMonHoc.AutoSize = true;
            btnXoaMonHoc.BackColor = Color.Red;
            btnXoaMonHoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaMonHoc.ForeColor = Color.White;
            btnXoaMonHoc.Location = new Point(717, 16);
            btnXoaMonHoc.Name = "btnXoaMonHoc";
            btnXoaMonHoc.Size = new Size(202, 64);
            btnXoaMonHoc.TabIndex = 3;
            btnXoaMonHoc.Text = "Xóa môn học";
            btnXoaMonHoc.UseVisualStyleBackColor = false;
            // 
            // btnSuaMonHoc
            // 
            btnSuaMonHoc.AutoSize = true;
            btnSuaMonHoc.BackColor = Color.FromArgb(255, 255, 128);
            btnSuaMonHoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaMonHoc.ForeColor = Color.Black;
            btnSuaMonHoc.Location = new Point(509, 19);
            btnSuaMonHoc.Name = "btnSuaMonHoc";
            btnSuaMonHoc.Size = new Size(202, 64);
            btnSuaMonHoc.TabIndex = 3;
            btnSuaMonHoc.Text = "Sửa môn học";
            btnSuaMonHoc.UseVisualStyleBackColor = false;
            // 
            // UC_MonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnMonHoc);
            Controls.Add(pnHeader);
            Name = "UC_MonHoc";
            Size = new Size(933, 653);
            Load += UcMonHoc_Load;
            pnMonHoc.ResumeLayout(false);
            pnMonHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnMonHoc;
        private TextBox txtSearchMonHoc;
        private DataGridViewTextBoxColumn ma_mh;
        private DataGridViewTextBoxColumn ten_mh;
        private DataGridViewTextBoxColumn so_tin_chi;
        private DataGridViewTextBoxColumn trang_thai;
        private Label lblDanhSachMonHoc;
        private Button btnThemMonHoc;
        private Panel pnHeader;
        private Button btnXoaMonHoc;
        private Button btnSuaMonHoc;
        private DataGridView dgvMonHoc;
    }
}
