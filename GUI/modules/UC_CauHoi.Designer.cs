namespace GUI.modules
{
    partial class UC_CauHoi
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTimKiem = new TextBox();
            cbDoKho = new ComboBox();
            cbChuong = new ComboBox();
            cbMonHoc = new ComboBox();
            dgvCauHoi = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colMonHoc = new DataGridViewTextBoxColumn();
            colDoKho = new DataGridViewTextBoxColumn();
            xemCol = new DataGridViewImageColumn();
            SuaCol = new DataGridViewImageColumn();
            XoaCol = new DataGridViewImageColumn();
            label2 = new Label();
            btnTuDieuChinh = new Button();
            btnThemMoi = new Button();
            lbTatCaCauhoi = new Label();
            btnTimKiem = new Button();
            pnlContainer = new Panel();
            //cbSoDongTrang = new ComboBox();
            btnTrangSau = new Button();
            btnTrangTruoc = new Button();
            lblTrangHienTai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCauHoi).BeginInit();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Location = new Point(25, 217);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(930, 30);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.Text = "Nhập nội dung câu hỏi để tìm kiếm...";
            txtTimKiem.TextChanged += txtTimKiem_TextChanged_LiveSearch;
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.KeyPress += txtTimKiem_KeyPress;
            txtTimKiem.Leave += txtTimKiem_Leave;
            // 
            // cbDoKho
            // 
            cbDoKho.Location = new Point(902, 132);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.Size = new Size(182, 31);
            cbDoKho.TabIndex = 6;
            // 
            // cbChuong
            // 
            cbChuong.Location = new Point(462, 132);
            cbChuong.Name = "cbChuong";
            cbChuong.Size = new Size(303, 31);
            cbChuong.TabIndex = 5;
            cbChuong.SelectedIndexChanged += cbChuong_SelectedIndexChanged;
            // 
            // cbMonHoc
            // 
            cbMonHoc.Location = new Point(25, 132);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(395, 31);
            cbMonHoc.TabIndex = 4;
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            // 
            // dgvCauHoi
            // 
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.AllowUserToDeleteRows = false;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCauHoi.BackgroundColor = Color.White;
            dgvCauHoi.ColumnHeadersHeight = 29;
            dgvCauHoi.Columns.AddRange(new DataGridViewColumn[] { colID, colNoiDung, colMonHoc, colDoKho,xemCol, SuaCol, XoaCol });
            dgvCauHoi.Location = new Point(25, 280);
            dgvCauHoi.Name = "dgvCauHoi";
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.RowHeadersVisible = false;
            dgvCauHoi.RowHeadersWidth = 51;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.Size = new Size(1050, 370);
            dgvCauHoi.TabIndex = 1;
            dgvCauHoi.CellContentClick += dgvCauHoi_CellContentClick;
            dgvCauHoi.SelectionChanged += dgvCauHoi_SelectionChanged;
            // Tắt style hệ thống để custom header
            dgvCauHoi.EnableHeadersVisualStyles = false;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvCauHoi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgvCauHoi.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvCauHoi.GridColor = Color.FromArgb(235, 240, 245);

            // Custom style table
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.AllowUserToOrderColumns = false;
            dgvCauHoi.AllowUserToResizeColumns = false;
            dgvCauHoi.AllowUserToResizeRows = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCauHoi.MultiSelect = false;
            dgvCauHoi.ReadOnly = true;
            // 
            // colID
            // 
            colID.FillWeight = 50F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colNoiDung
            // 
            colNoiDung.FillWeight = 300F;
            colNoiDung.HeaderText = "Nội dung câu hỏi";
            colNoiDung.MinimumWidth = 6;
            colNoiDung.Name = "colNoiDung";
            colNoiDung.ReadOnly = true;
            // 
            // colMonHoc
            // 
            colMonHoc.HeaderText = "Môn học";
            colMonHoc.MinimumWidth = 6;
            colMonHoc.Name = "colMonHoc";
            colMonHoc.ReadOnly = true;
            // 
            // colDoKho
            // 
            colDoKho.FillWeight = 80F;
            colDoKho.HeaderText = "Độ khó";
            colDoKho.MinimumWidth = 6;
            colDoKho.Name = "colDoKho";
            colDoKho.ReadOnly = true;
            cbDoKho.SelectedIndexChanged += cbDoKho_SelectedIndexChanged;
            // 
            //xemcol

            xemCol.HeaderText = "";
            xemCol.MinimumWidth = 6;
            xemCol.Name = "xemCol";
            xemCol.ReadOnly = true;
            // SuaCol
            // 
            SuaCol.HeaderText = "";
            SuaCol.MinimumWidth = 6;
            SuaCol.Name = "SuaCol";
            SuaCol.ReadOnly = true;
            // 
            // XoaCol
            // 
            XoaCol.HeaderText = "";
            XoaCol.MinimumWidth = 6;
            XoaCol.Name = "XoaCol";
            XoaCol.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(214, 56);
            label2.Name = "label2";
            label2.Size = new Size(176, 28);
            label2.TabIndex = 8;
            label2.Text = "Câu hỏi trùng lặp";
            label2.Click += cauHoiTrungLap_Click;
            // 
            // btnTuDieuChinh
            // 
            btnTuDieuChinh.BackColor = Color.FromArgb(243, 156, 18);
            btnTuDieuChinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTuDieuChinh.ForeColor = Color.White;
            btnTuDieuChinh.Location = new Point(773, 44);
            btnTuDieuChinh.Name = "btnTuDieuChinh";
            btnTuDieuChinh.Size = new Size(320, 56);
            btnTuDieuChinh.TabIndex = 10;
            btnTuDieuChinh.Text = "TỰ ĐIỀU CHỈNH ĐỘ KHÓ";
            btnTuDieuChinh.UseVisualStyleBackColor = false;
            btnTuDieuChinh.Click += btnTuDieuChinh_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = Color.FromArgb(52, 152, 219);
            btnThemMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemMoi.ForeColor = Color.White;
            btnThemMoi.Location = new Point(443, 44);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(304, 56);
            btnThemMoi.TabIndex = 9;
            btnThemMoi.Text = "+ THÊM CÂU HỎI MỚI";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // lbTatCaCauhoi
            // 
            lbTatCaCauhoi.AutoSize = true;
            lbTatCaCauhoi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTatCaCauhoi.Location = new Point(25, 56);
            lbTatCaCauhoi.Name = "lbTatCaCauhoi";
            lbTatCaCauhoi.Size = new Size(145, 28);
            lbTatCaCauhoi.TabIndex = 7;
            lbTatCaCauhoi.Text = "Tất cả câu hỏi";
            lbTatCaCauhoi.Click += showAllCauHoi;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(46, 204, 113);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(972, 217);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(112, 35);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(btnTrangSau);
            pnlContainer.Controls.Add(btnTrangTruoc);
            pnlContainer.Controls.Add(lblTrangHienTai);
            pnlContainer.Dock = DockStyle.Bottom;
            pnlContainer.Location = new Point(0, 660);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1120, 70);
            pnlContainer.TabIndex = 0;
            // 
            // btnTrangSau
            // 
            btnTrangSau.Location = new Point(981, 14);
            btnTrangSau.Name = "btnTrangSau";
            btnTrangSau.Size = new Size(94, 29);
            btnTrangSau.TabIndex = 2;
            btnTrangSau.Text = ">>";
            btnTrangSau.UseVisualStyleBackColor = true;
            btnTrangSau.Click += btnNextPage_Click;
            // Custom màu xanh đẹp
            btnTrangTruoc.BackColor = Color.FromArgb(52, 152, 219);
            btnTrangTruoc.ForeColor = Color.White;
            btnTrangTruoc.FlatStyle = FlatStyle.Flat;
            btnTrangTruoc.FlatAppearance.BorderSize = 0;
            btnTrangTruoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTrangTruoc.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            pnlContainer.Controls.Add(btnTrangTruoc);
            // 
            // btnTrangTruoc
            // 
            btnTrangTruoc.Location = new Point(792, 17);
            btnTrangTruoc.Name = "btnTrangTruoc";
            btnTrangTruoc.Size = new Size(94, 29);
            btnTrangTruoc.TabIndex = 1;
            btnTrangTruoc.Text = "<<";
            btnTrangTruoc.UseVisualStyleBackColor = true;
            btnTrangTruoc.Click += btnPrevPage_Click;
            // Custom màu xanh đẹp
            btnTrangSau.BackColor = Color.FromArgb(52, 152, 219);
            btnTrangSau.ForeColor = Color.White;
            btnTrangSau.FlatStyle = FlatStyle.Flat;
            btnTrangSau.FlatAppearance.BorderSize = 0;
            btnTrangSau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTrangSau.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            pnlContainer.Controls.Add(btnTrangSau);
            // 
            // lblTrangHienTai
            // 
            lblTrangHienTai.AutoSize = true;
            lblTrangHienTai.Location = new Point(892, 20);
            lblTrangHienTai.Name = "lblTrangHienTai";
            lblTrangHienTai.Size = new Size(83, 23);
            lblTrangHienTai.TabIndex = 0;
            lblTrangHienTai.Text = "Trang 1/1";
            // 
            // UC_CauHoi
            // 
            BackColor = Color.White;
            Controls.Add(pnlContainer);
            Controls.Add(dgvCauHoi);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(cbMonHoc);
            Controls.Add(cbChuong);
            Controls.Add(cbDoKho);
            Controls.Add(lbTatCaCauhoi);
            Controls.Add(label2);
            Controls.Add(btnThemMoi);
            Controls.Add(btnTuDieuChinh);
            Font = new Font("Segoe UI", 10F);
            Name = "UC_CauHoi";
            Size = new Size(1120, 730);
            ((System.ComponentModel.ISupportInitialize)dgvCauHoi).EndInit();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private TextBox txtTimKiem = null!;
        private ComboBox cbDoKho = null!;
        private ComboBox cbChuong = null!;
        private ComboBox cbMonHoc = null!;
        private DataGridView dgvCauHoi = null!;
        private DataGridViewTextBoxColumn colID = null!;
        private DataGridViewTextBoxColumn colNoiDung = null!;
        private DataGridViewTextBoxColumn colMonHoc = null!;
        private DataGridViewTextBoxColumn colDoKho = null!;
        private DataGridViewImageColumn xemCol = null!;
        private DataGridViewImageColumn SuaCol = null!;
        private DataGridViewImageColumn XoaCol = null!;
        private Label lbTatCaCauhoi = null!;
        private Label label2 = null!;
        private Button btnThemMoi = null!;
        private Button btnTuDieuChinh = null!;
        private Button btnTimKiem = null!;
        private Panel pnlContainer = null!;
        private Label lblTrangHienTai;
        private Button btnTrangSau;
        private Button btnTrangTruoc;
        //private ComboBox cbSoDongTrang;
    }
}