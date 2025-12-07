namespace GUI.Forms.CauHoi
{
    partial class frmXemChiTiet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Định nghĩa màu sắc chuyên nghiệp
            System.Drawing.Color primaryColor = System.Drawing.Color.FromArgb(52, 73, 94);
            System.Drawing.Color backgroundColor = System.Drawing.Color.FromArgb(236, 240, 241); 
            System.Drawing.Color textColor = System.Drawing.Color.FromArgb(44, 62, 80); 
            System.Drawing.Color titleColor = System.Drawing.Color.FromArgb(41, 128, 185);
            System.Drawing.Color answerPanelColor = System.Drawing.Color.White; 

            lblMonHocTitle = new Label();
            lblChuongTitle = new Label();
            lblDoKhoTitle = new Label();
            lblDapAnTitle = new Label();
            lblMonHoc = new Label();
            lblChuong = new Label();
            lblDoKho = new Label();
            lblNoiDung = new Label();
            lblDapAnDung = new Label();
            pnlA = new Panel();
            lblA = new Label();
            pnlB = new Panel();
            lblB = new Label();
            pnlC = new Panel();
            lblC = new Label();
            pnlD = new Panel();
            lblD = new Label();
            pnlA.SuspendLayout();
            pnlB.SuspendLayout();
            pnlC.SuspendLayout();
            pnlD.SuspendLayout();
            SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = backgroundColor; 
            this.ClientSize = new Size(760, 430);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xem chi tiết câu hỏi";
            // 
            // lblMonHocTitle
            // 
            lblMonHocTitle.AutoSize = true;
            lblMonHocTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMonHocTitle.ForeColor = titleColor; 
            lblMonHocTitle.Location = new Point(12, 9);
            lblMonHocTitle.Name = "lblMonHocTitle";
            lblMonHocTitle.Text = "Môn học :";
            // 
            // lblChuongTitle
            // 
            lblChuongTitle.AutoSize = true;
            lblChuongTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChuongTitle.ForeColor = titleColor;
            lblChuongTitle.Location = new Point(323, 9);
            lblChuongTitle.Name = "lblChuongTitle";
            lblChuongTitle.Text = "Chương :";
            // 
            // lblDoKhoTitle
            // 
            lblDoKhoTitle.AutoSize = true;
            lblDoKhoTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoKhoTitle.ForeColor = titleColor; 
            lblDoKhoTitle.Location = new Point(583, 9);
            lblDoKhoTitle.Name = "lblDoKhoTitle";
            lblDoKhoTitle.Text = "Độ khó :";
            // 
            // lblDapAnTitle
            // 
            lblDapAnTitle.AutoSize = true;
            lblDapAnTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDapAnTitle.ForeColor = titleColor; 
            lblDapAnTitle.Location = new Point(12, 115); 
            lblDapAnTitle.Name = "lblDapAnTitle";
            lblDapAnTitle.Text = "Danh sách đáp án:";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 10F);
            lblMonHoc.ForeColor = textColor; 
            lblMonHoc.Location = new Point(98, 9);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Text = "text mon hoc";
            // 
            // lblChuong
            // 
            lblChuong.AutoSize = true;
            lblChuong.Font = new Font("Segoe UI", 10F);
            lblChuong.ForeColor = textColor; 
            lblChuong.Location = new Point(404, 9);
            lblChuong.Name = "lblChuong";
            lblChuong.Text = "ten chuong";
            // 
            // lblDoKho
            // 
            lblDoKho.AutoSize = true;
            lblDoKho.Font = new Font("Segoe UI", 10F);
            lblDoKho.ForeColor = textColor; 
            lblDoKho.Location = new Point(659, 9);
            lblDoKho.Name = "lblDoKho";
            lblDoKho.Text = "ten do kho";
            // 
            // lblNoiDung
            // 
            lblNoiDung.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNoiDung.ForeColor = primaryColor; 
            lblNoiDung.Location = new Point(12, 44);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(700, 50); 
            lblNoiDung.Text = "ten noi dung";
            // 
            // lblDapAnDung
            // 
            lblDapAnDung.AutoSize = true;
            lblDapAnDung.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDapAnDung.ForeColor = System.Drawing.Color.ForestGreen; 
            lblDapAnDung.Location = new Point(30, 380);
            lblDapAnDung.Name = "lblDapAnDung";
            lblDapAnDung.Text = "";
            // 
            // pnlA
            // 
            pnlA.BackColor = answerPanelColor;
            pnlA.BorderStyle = BorderStyle.FixedSingle;
            pnlA.Controls.Add(lblA);
            pnlA.Location = new Point(30, 145);
            pnlA.Name = "pnlA";
            pnlA.Size = new Size(700, 45); 
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Font = new Font("Segoe UI", 10F);
            lblA.ForeColor = textColor;
            lblA.Location = new Point(10, 12);
            lblA.Name = "lblA";
            lblA.Text = "";
            // 
            // pnlB
            // 
            pnlB.BackColor = answerPanelColor;
            pnlB.BorderStyle = BorderStyle.FixedSingle;
            pnlB.Controls.Add(lblB);
            pnlB.Location = new Point(30, 195);
            pnlB.Name = "pnlB";
            pnlB.Size = new Size(700, 45); 
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Font = new Font("Segoe UI", 10F);
            lblB.ForeColor = textColor;
            lblB.Location = new Point(10, 12);
            lblB.Name = "lblB";
            lblB.Text = "";
            // 
            // pnlC
            // 
            pnlC.BackColor = answerPanelColor;
            pnlC.BorderStyle = BorderStyle.FixedSingle;
            pnlC.Controls.Add(lblC);
            pnlC.Location = new Point(30, 245);
            pnlC.Name = "pnlC";
            pnlC.Size = new Size(700, 45);
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Font = new Font("Segoe UI", 10F);
            lblC.ForeColor = textColor;
            lblC.Location = new Point(10, 12);
            lblC.Name = "lblC";
            lblC.Text = "";
            // 
            // pnlD
            // 
            pnlD.BackColor = answerPanelColor;
            pnlD.BorderStyle = BorderStyle.FixedSingle;
            pnlD.Controls.Add(lblD);
            pnlD.Location = new Point(30, 295);
            pnlD.Name = "pnlD";
            pnlD.Size = new Size(700, 45); 
            // 
            // lblD
            // 
            lblD.AutoSize = true;
            lblD.Font = new Font("Segoe UI", 10F);
            lblD.ForeColor = textColor;
            lblD.Location = new Point(10, 12);
            lblD.Name = "lblD";
            lblD.Text = "";
            // 
            // Add Controls to Form
            // 
            Controls.Add(lblMonHocTitle);
            Controls.Add(lblChuongTitle);
            Controls.Add(lblDoKhoTitle);
            Controls.Add(lblDapAnTitle);
            Controls.Add(lblMonHoc);
            Controls.Add(lblChuong);
            Controls.Add(lblDoKho);
            Controls.Add(lblNoiDung);
            Controls.Add(pnlA);
            Controls.Add(pnlB);
            Controls.Add(pnlC);
            Controls.Add(pnlD);
            Controls.Add(lblDapAnDung);

            pnlA.ResumeLayout(false);
            pnlA.PerformLayout();
            pnlB.ResumeLayout(false);
            pnlB.PerformLayout();
            pnlC.ResumeLayout(false);
            pnlC.PerformLayout();
            pnlD.ResumeLayout(false);
            pnlD.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ================= Labels =================
        private Label lblNoiDung;
        private Label lblMonHoc;
        private Label lblChuong;
        private Label lblDoKho;
        private Label lblDapAnDung;

        // ================= Panels =================
        private Panel pnlA;
        private Panel pnlB;
        private Panel pnlC;
        private Panel pnlD;

        // ================= Answer Labels =================
        private Label lblA;
        private Label lblB;
        private Label lblC;
        private Label lblD;

        // ================= Title Labels =================
        private Label lblMonHocTitle;
        private Label lblChuongTitle;
        private Label lblDoKhoTitle;
        private Label lblDapAnTitle;
    }
}