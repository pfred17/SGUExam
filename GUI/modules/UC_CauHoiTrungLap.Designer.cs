namespace GUI.modules
{
    partial class UC_CauHoiTrungLap
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
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlTop = new Panel();
            btnTatCaCauHoi = new Button();
            lblThongKe = new Label();
            lblDescription = new Label();
            lblTitle = new Label();
            pnlFilter = new Panel();
            btnReset = new Button();
            btnLoc = new Button();
            cboMonHoc = new ComboBox();
            cboLoaiCauHoi = new ComboBox();
            flpMain = new FlowLayoutPanel();
            //button1 = new Button();
            pnlTop.SuspendLayout();
            pnlFilter.SuspendLayout();
            flpMain.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(46, 33);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(3, 2);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = null;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnTatCaCauHoi);
            pnlTop.Controls.Add(lblThongKe);
            pnlTop.Controls.Add(lblDescription);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1120, 125);
            pnlTop.TabIndex = 2;
            // 
            // btnTatCaCauHoi
            // 
            btnTatCaCauHoi.BackColor = Color.RoyalBlue;
            btnTatCaCauHoi.ForeColor = SystemColors.ControlLightLight;
            btnTatCaCauHoi.Location = new Point(278, 59);
            btnTatCaCauHoi.Name = "btnTatCaCauHoi";
            btnTatCaCauHoi.Size = new Size(114, 29);
            btnTatCaCauHoi.TabIndex = 3;
            btnTatCaCauHoi.Text = "Tất cả câu hỏi";
            btnTatCaCauHoi.UseVisualStyleBackColor = false;
            btnTatCaCauHoi.Click += loadTatCauHoi_Click;
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.ForeColor = Color.Crimson;
            lblThongKe.Location = new Point(665, 95);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(371, 20);
            lblThongKe.TabIndex = 2;
            lblThongKe.Text = "0 nhóm trùng lặp • 0 câu hỏi trùng • 0 câu hỏi duy nhất";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(30, 95);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(371, 17);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Lọc và xóa các câu hỏi trùng lặp trong ngân hàng câu hỏi";
            //lblDescription.Click += lblDescription_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Chocolate;
            lblTitle.Location = new Point(30, 63);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý câu hỏi trùng lặp";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(248, 249, 250);
            pnlFilter.Controls.Add(btnReset);
            pnlFilter.Controls.Add(btnLoc);
            pnlFilter.Controls.Add(cboMonHoc);
            pnlFilter.Controls.Add(cboLoaiCauHoi);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 125);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1120, 62);
            pnlFilter.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(897, 27);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(0, 123, 255);
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(759, 27);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(94, 29);
            btnLoc.TabIndex = 6;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(250, 25);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(151, 28);
            cboMonHoc.TabIndex = 5;
            // 
            // cboLoaiCauHoi
            // 
            cboLoaiCauHoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiCauHoi.FormattingEnabled = true;
            cboLoaiCauHoi.Location = new Point(30, 25);
            cboLoaiCauHoi.Name = "cboLoaiCauHoi";
            cboLoaiCauHoi.Size = new Size(151, 28);
            cboLoaiCauHoi.TabIndex = 4;
            // 
            // flpMain
            // 
            flpMain.AutoScroll = true;
            flpMain.BackColor = Color.White;
            //flpMain.Controls.Add(button1);
            flpMain.Dock = DockStyle.Fill;
            flpMain.FlowDirection = FlowDirection.TopDown;
            flpMain.Location = new Point(0, 187);
            flpMain.Name = "flpMain";
            flpMain.Size = new Size(1120, 543);
            flpMain.TabIndex = 4;
            flpMain.WrapContents = false;
            // 
            // button1
            // 
            //button1.Location = new Point(3, 3);
            //button1.Name = "button1";
            //button1.Size = new Size(94, 29);
            //button1.TabIndex = 0;
            //button1.Text = "button1";
            //button1.UseVisualStyleBackColor = true;
            // 
            // UC_CauHoiTrungLap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpMain);
            Controls.Add(pnlFilter);
            Controls.Add(pnlTop);
            Controls.Add(guna2HtmlLabel1);
            Name = "UC_CauHoiTrungLap";
            Size = new Size(1120, 730);
            Load += UC_CauHoiTrungLap_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilter.ResumeLayout(false);
            flpMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblThongKe;
        private Panel pnlFilter;
        private ComboBox cboLoaiCauHoi;
        private Button btnReset;
        private Button btnLoc;
        private ComboBox cboMonHoc;
        private FlowLayoutPanel flpMain;
        private Button btnTatCaCauHoi;
        //private Button button1;
    }
}

