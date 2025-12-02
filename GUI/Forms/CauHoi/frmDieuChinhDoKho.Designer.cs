namespace GUI.Forms.CauHoi
{
    partial class frmDieuChinhDoKho
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
            pnlInput = new Panel();
            lblSubtitle2 = new Label();
            lblSubtitle1 = new Label();
            btnPhanTich = new Button();
            lblNguongKho = new Label();
            numNguongKho = new NumericUpDown();
            numNguongDe = new NumericUpDown();
            lblNguongDe = new Label();
            numLuotLamToiThieu = new NumericUpDown();
            lblLuotLam = new Label();
            lblMonHoc = new Label();
            cbMonHoc = new ComboBox();
            pnlResults = new Panel();
            dgvKetQuaPhanTich = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colSoLuotTraLoi = new DataGridViewTextBoxColumn();
            colTyLeSai = new DataGridViewTextBoxColumn();
            colDoKhoHienTai = new DataGridViewTextBoxColumn();
            colGoiYDoKhoMoi = new DataGridViewTextBoxColumn();
            colHanhDong = new DataGridViewButtonColumn();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNguongKho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNguongDe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLuotLamToiThieu).BeginInit();
            pnlResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQuaPhanTich).BeginInit();
            SuspendLayout();
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.Controls.Add(lblSubtitle2);
            pnlInput.Controls.Add(lblSubtitle1);
            pnlInput.Controls.Add(btnPhanTich);
            pnlInput.Controls.Add(lblNguongKho);
            pnlInput.Controls.Add(numNguongKho);
            pnlInput.Controls.Add(numNguongDe);
            pnlInput.Controls.Add(lblNguongDe);
            pnlInput.Controls.Add(numLuotLamToiThieu);
            pnlInput.Controls.Add(lblLuotLam);
            pnlInput.Controls.Add(lblMonHoc);
            pnlInput.Controls.Add(cbMonHoc);
            pnlInput.Dock = DockStyle.Top;
            pnlInput.Location = new Point(0, 0);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(15);
            pnlInput.Size = new Size(1000, 240);
            pnlInput.TabIndex = 0;
            // 
            // lblSubtitle2
            // 
            lblSubtitle2.AutoSize = true;
            lblSubtitle2.Font = new Font("Segoe UI", 8F);
            lblSubtitle2.ForeColor = Color.Gray;
            lblSubtitle2.Location = new Point(597, 151);
            lblSubtitle2.Name = "lblSubtitle2";
            lblSubtitle2.Size = new Size(385, 19);
            lblSubtitle2.TabIndex = 10;
            lblSubtitle2.Text = "Nếu tỷ lệ sai lớn hơn giá trị này, câu hỏi được xem là quá khó.";
            // 
            // lblSubtitle1
            // 
            lblSubtitle1.AutoSize = true;
            lblSubtitle1.Font = new Font("Segoe UI", 8F);
            lblSubtitle1.ForeColor = Color.Gray;
            lblSubtitle1.Location = new Point(21, 151);
            lblSubtitle1.Name = "lblSubtitle1";
            lblSubtitle1.Size = new Size(318, 38);
            lblSubtitle1.TabIndex = 9;
            lblSubtitle1.Text = "Chỉ phân tích các câu hỏi đã có ít nhất số lượt làm \r\nnày.";
            // 
            // btnPhanTich
            // 
            btnPhanTich.BackColor = Color.FromArgb(0, 122, 204);
            btnPhanTich.FlatAppearance.BorderSize = 0;
            btnPhanTich.FlatStyle = FlatStyle.Flat;
            btnPhanTich.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPhanTich.ForeColor = Color.White;
            btnPhanTich.ImageAlign = ContentAlignment.MiddleLeft;
            btnPhanTich.Location = new Point(806, 189);
            btnPhanTich.Name = "btnPhanTich";
            btnPhanTich.Padding = new Padding(10, 0, 0, 0);
            btnPhanTich.Size = new Size(174, 45);
            btnPhanTich.TabIndex = 8;
            btnPhanTich.Text = "Phân tích câu hỏi";
            btnPhanTich.TextAlign = ContentAlignment.MiddleRight;
            btnPhanTich.UseVisualStyleBackColor = false;
            // ************ GÁN SỰ KIỆN ************
            btnPhanTich.Click += btnPhanTich_Click;
            // ************ GÁN SỰ KIỆN ************
            // 
            // lblNguongKho
            // 
            lblNguongKho.AutoSize = true;
            lblNguongKho.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNguongKho.Location = new Point(668, 93);
            lblNguongKho.Name = "lblNguongKho";
            lblNguongKho.Size = new Size(104, 20);
            lblNguongKho.TabIndex = 7;
            lblNguongKho.Text = "% sai > (Khó)";
            // 
            // numNguongKho
            // 
            numNguongKho.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numNguongKho.Location = new Point(670, 116);
            numNguongKho.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNguongKho.Name = "numNguongKho";
            numNguongKho.Size = new Size(150, 30);
            numNguongKho.TabIndex = 6;
            numNguongKho.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // numNguongDe
            // 
            numNguongDe.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numNguongDe.Location = new Point(345, 116);
            numNguongDe.Name = "numNguongDe";
            numNguongDe.Size = new Size(150, 30);
            numNguongDe.TabIndex = 5;
            numNguongDe.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblNguongDe
            // 
            lblNguongDe.AutoSize = true;
            lblNguongDe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNguongDe.Location = new Point(343, 93);
            lblNguongDe.Name = "lblNguongDe";
            lblNguongDe.Size = new Size(95, 20);
            lblNguongDe.TabIndex = 4;
            lblNguongDe.Text = "% sai < (Dễ)";
            // 
            // numLuotLamToiThieu
            // 
            numLuotLamToiThieu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numLuotLamToiThieu.Location = new Point(23, 116);
            numLuotLamToiThieu.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLuotLamToiThieu.Name = "numLuotLamToiThieu";
            numLuotLamToiThieu.Size = new Size(150, 30);
            numLuotLamToiThieu.TabIndex = 3;
            numLuotLamToiThieu.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblLuotLam
            // 
            lblLuotLam.AutoSize = true;
            lblLuotLam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLuotLam.Location = new Point(21, 93);
            lblLuotLam.Name = "lblLuotLam";
            lblLuotLam.Size = new Size(152, 20);
            lblLuotLam.TabIndex = 2;
            lblLuotLam.Text = "Số lượt làm tối thiểu";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMonHoc.Location = new Point(21, 25);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(110, 20);
            lblMonHoc.TabIndex = 1;
            lblMonHoc.Text = "Chọn môn học";
            // 
            // cbMonHoc
            // 
            cbMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonHoc.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbMonHoc.FormattingEnabled = true;
            cbMonHoc.Location = new Point(23, 48);
            cbMonHoc.Name = "cbMonHoc";
            cbMonHoc.Size = new Size(957, 31);
            cbMonHoc.TabIndex = 0;
            // 
            // pnlResults
            // 
            pnlResults.Controls.Add(dgvKetQuaPhanTich);
            pnlResults.Dock = DockStyle.Fill;
            pnlResults.Location = new Point(0, 240);
            pnlResults.Name = "pnlResults";
            pnlResults.Padding = new Padding(15);
            pnlResults.Size = new Size(1000, 410);
            pnlResults.TabIndex = 1;
            // 
            // dgvKetQuaPhanTich
            // 
            dgvKetQuaPhanTich.AllowUserToAddRows = false;
            dgvKetQuaPhanTich.AllowUserToDeleteRows = false;
            dgvKetQuaPhanTich.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQuaPhanTich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQuaPhanTich.BackgroundColor = Color.White;
            dgvKetQuaPhanTich.BorderStyle = BorderStyle.None;
            dgvKetQuaPhanTich.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKetQuaPhanTich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKetQuaPhanTich.ColumnHeadersHeight = 35;
            dgvKetQuaPhanTich.Columns.AddRange(new DataGridViewColumn[] { colSTT, colNoiDung, colSoLuotTraLoi, colTyLeSai, colDoKhoHienTai, colGoiYDoKhoMoi, colHanhDong });
            // ************ GÁN SỰ KIỆN ************
            dgvKetQuaPhanTich.CellContentClick += dgvKetQuaPhanTich_CellContentClick;
            // ************ GÁN SỰ KIỆN ************
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 235, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvKetQuaPhanTich.DefaultCellStyle = dataGridViewCellStyle2;
            dgvKetQuaPhanTich.EnableHeadersVisualStyles = false;
            dgvKetQuaPhanTich.Location = new Point(18, 6);
            dgvKetQuaPhanTich.MultiSelect = false;
            dgvKetQuaPhanTich.Name = "dgvKetQuaPhanTich";
            dgvKetQuaPhanTich.ReadOnly = true;
            dgvKetQuaPhanTich.RowHeadersVisible = false;
            dgvKetQuaPhanTich.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKetQuaPhanTich.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvKetQuaPhanTich.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQuaPhanTich.Size = new Size(964, 386);
            dgvKetQuaPhanTich.TabIndex = 0;
            // 
            // colSTT
            // 
            colSTT.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colSTT.FillWeight = 30F;
            colSTT.HeaderText = "#";
            colSTT.MinimumWidth = 30;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            colSTT.Width = 30;
            // 
            // colNoiDung
            // 
            colNoiDung.FillWeight = 170F;
            colNoiDung.HeaderText = "Nội dung";
            colNoiDung.MinimumWidth = 6;
            colNoiDung.Name = "colNoiDung";
            colNoiDung.ReadOnly = true;
            // 
            // colSoLuotTraLoi
            // 
            colSoLuotTraLoi.FillWeight = 50F;
            colSoLuotTraLoi.HeaderText = "Số lượt trả lời";
            colSoLuotTraLoi.MinimumWidth = 6;
            colSoLuotTraLoi.Name = "colSoLuotTraLoi";
            colSoLuotTraLoi.ReadOnly = true;
            // 
            // colTyLeSai
            // 
            colTyLeSai.FillWeight = 70F;
            colTyLeSai.HeaderText = "Tỷ lệ sai (%)";
            colTyLeSai.MinimumWidth = 6;
            colTyLeSai.Name = "colTyLeSai";
            colTyLeSai.ReadOnly = true;
            // 
            // colDoKhoHienTai
            // 
            colDoKhoHienTai.FillWeight = 80F;
            colDoKhoHienTai.HeaderText = "Độ khó hiện tại";
            colDoKhoHienTai.MinimumWidth = 6;
            colDoKhoHienTai.Name = "colDoKhoHienTai";
            colDoKhoHienTai.ReadOnly = true;
            // 
            // colGoiYDoKhoMoi
            // 
            colGoiYDoKhoMoi.FillWeight = 90F;
            colGoiYDoKhoMoi.HeaderText = "Gợi ý độ khó mới";
            colGoiYDoKhoMoi.MinimumWidth = 6;
            colGoiYDoKhoMoi.Name = "colGoiYDoKhoMoi";
            colGoiYDoKhoMoi.ReadOnly = true;
            // 
            // colHanhDong
            // 
            colHanhDong.FillWeight = 60F;
            colHanhDong.HeaderText = "Hành động";
            colHanhDong.MinimumWidth = 6;
            colHanhDong.Name = "colHanhDong";
            colHanhDong.ReadOnly = true;
            // 
            // frmDieuChinhDoKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlResults);
            Controls.Add(pnlInput);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(850, 550);
            Name = "frmDieuChinhDoKho";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gợi ý điều chỉnh độ khó tự động";
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNguongKho).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNguongDe).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLuotLamToiThieu).EndInit();
            pnlResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKetQuaPhanTich).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlInput;
        private ComboBox cbMonHoc;
        private NumericUpDown numNguongDe;
        private Label lblNguongDe;
        private NumericUpDown numLuotLamToiThieu;
        private Label lblLuotLam;
        private Label lblMonHoc;
        private Button btnPhanTich;
        private Label lblNguongKho;
        private NumericUpDown numNguongKho;
        private Panel pnlResults;
        private DataGridView dgvKetQuaPhanTich;
        private System.Windows.Forms.Label lblSubtitle2;
        private System.Windows.Forms.Label lblSubtitle1;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colNoiDung;
        private DataGridViewTextBoxColumn colSoLuotTraLoi;
        private DataGridViewTextBoxColumn colTyLeSai;
        private DataGridViewTextBoxColumn colDoKhoHienTai;
        private DataGridViewTextBoxColumn colGoiYDoKhoMoi;
        private DataGridViewButtonColumn colHanhDong;
    }
}