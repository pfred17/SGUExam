using ClosedXML.Parser;

namespace GUI.modules
{
    partial class UC_CauHoiTrungLap1
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
            cboMonHoc = new ComboBox();
            btnTatCaCauHoi = new Button();
            dgvTrungLap = new DataGridView();
            panel1 = new Panel();
            btnReset = new Button();
            label1 = new Label();
            lblThongKe = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboMonHoc
            // 
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(49, 84);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(229, 28);
            cboMonHoc.TabIndex = 0;
            // 
            // btnTatCaCauHoi
            // 
            btnTatCaCauHoi.Location = new Point(531, 85);
            btnTatCaCauHoi.Name = "btnTatCaCauHoi";
            btnTatCaCauHoi.Size = new Size(131, 29);
            btnTatCaCauHoi.TabIndex = 1;
            btnTatCaCauHoi.Text = "Tất cả câu hỏi";
            btnTatCaCauHoi.UseVisualStyleBackColor = true;
            // 
            // dgvTrungLap
            // 
            dgvTrungLap.BackgroundColor = SystemColors.ButtonFace;
            dgvTrungLap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrungLap.Dock = DockStyle.Fill;
            dgvTrungLap.Location = new Point(0, 125);
            dgvTrungLap.Name = "dgvTrungLap";
            dgvTrungLap.RowHeadersWidth = 51;
            dgvTrungLap.Size = new Size(953, 372);
            dgvTrungLap.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblThongKe);
            panel1.Controls.Add(cboMonHoc);
            panel1.Controls.Add(btnTatCaCauHoi);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 125);
            panel1.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(416, 85);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 33);
            label1.Name = "label1";
            label1.Size = new Size(213, 20);
            label1.TabIndex = 3;
            label1.Text = "QUẢN LÝ CÂU HỎI TRÙNG LẶP";
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.Location = new Point(396, 33);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(308, 20);
            lblThongKe.TabIndex = 2;
            lblThongKe.Text = "Nhóm trùng: 0 | Câu trùng: 0 | Câu duy nhất: 0";
            // 
            // UC_CauHoiTrungLap1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTrungLap);
            Controls.Add(panel1);
            Name = "UC_CauHoiTrungLap1";
            Size = new Size(953, 497);
            ((System.ComponentModel.ISupportInitialize)dgvTrungLap).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboMonHoc;
        private Button btnTatCaCauHoi;
        private DataGridView dgvTrungLap;
        private Panel panel1;
        private Button btnReset;
        private Label label1;
        private Label lblThongKe;
    }
}
