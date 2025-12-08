namespace GUI.forms.hocphan
{
    partial class frmChiTietSinhVien
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbHoTen = new Label();
            label7 = new Label();
            lbMSSV = new Label();
            lbEmail = new Label();
            lbGioiTinh = new Label();
            lbThongTin = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            label6 = new Label();
            lbDiem = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 57);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 109);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã sinh viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 155);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 201);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 3;
            label4.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(278, 9);
            label5.Name = "label5";
            label5.Size = new Size(221, 31);
            label5.TabIndex = 4;
            label5.Text = "Thông tin sinh viên";
            // 
            // lbHoTen
            // 
            lbHoTen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHoTen.Location = new Point(143, 57);
            lbHoTen.Name = "lbHoTen";
            lbHoTen.Size = new Size(550, 31);
            lbHoTen.TabIndex = 5;
            lbHoTen.Text = "lbHoTen";
            lbHoTen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(28, 252);
            label7.Name = "label7";
            label7.Size = new Size(262, 28);
            label7.TabIndex = 6;
            label7.Text = "Thông tin nhóm học phần:";
            // 
            // lbMSSV
            // 
            lbMSSV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMSSV.Location = new Point(172, 109);
            lbMSSV.Name = "lbMSSV";
            lbMSSV.Size = new Size(550, 31);
            lbMSSV.TabIndex = 7;
            lbMSSV.Text = "lbMSSV";
            lbMSSV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbEmail
            // 
            lbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(103, 152);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(550, 31);
            lbEmail.TabIndex = 8;
            lbEmail.Text = "lbEmail";
            lbEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbGioiTinh
            // 
            lbGioiTinh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGioiTinh.Location = new Point(134, 201);
            lbGioiTinh.Name = "lbGioiTinh";
            lbGioiTinh.Size = new Size(562, 31);
            lbGioiTinh.TabIndex = 9;
            lbGioiTinh.Text = "lbGIoiTinh";
            lbGioiTinh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbThongTin
            // 
            lbThongTin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbThongTin.Location = new Point(296, 252);
            lbThongTin.Name = "lbThongTin";
            lbThongTin.Size = new Size(448, 50);
            lbThongTin.TabIndex = 10;
            lbThongTin.Text = "lbThongTin";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(28, 304);
            label6.Name = "label6";
            label6.Size = new Size(195, 28);
            label6.TabIndex = 11;
            label6.Text = "Các đề đã kiểm tra:";
            // 
            // lbDiem
            // 
            lbDiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDiem.Location = new Point(28, 343);
            lbDiem.Name = "lbDiem";
            lbDiem.Size = new Size(478, 151);
            lbDiem.TabIndex = 12;
            lbDiem.Text = "lbDiem";
            // 
            // frmChiTietSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 503);
            Controls.Add(lbDiem);
            Controls.Add(label6);
            Controls.Add(lbThongTin);
            Controls.Add(lbGioiTinh);
            Controls.Add(lbEmail);
            Controls.Add(lbMSSV);
            Controls.Add(label7);
            Controls.Add(lbHoTen);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmChiTietSinhVien";
            Text = "frmChiTietSinhVien";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbHoTen;
        private Label label7;
        private Label lbMSSV;
        private Label lbEmail;
        private Label lbGioiTinh;
        private Label lbThongTin;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label label6;
        private Label lbDiem;
    }
}