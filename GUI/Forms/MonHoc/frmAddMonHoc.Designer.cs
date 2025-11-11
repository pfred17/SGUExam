namespace GUI.Forms
{
    partial class frmAddMonHoc
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
            btnSubmit = new Button();
            txtTenMonHoc = new TextBox();
            lblTenMonHoc = new Label();
            lblThongTinMonHoc = new Label();
            btnClose = new Button();
            txtSoTinChi = new TextBox();
            lblTongSoTinChi = new Label();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.Window;
            btnSubmit.Location = new Point(456, 292);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(76, 41);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtTenMonHoc
            // 
            txtTenMonHoc.BackColor = Color.LightGray;
            txtTenMonHoc.Font = new Font("Segoe UI", 12F);
            txtTenMonHoc.ForeColor = Color.Gray;
            txtTenMonHoc.Location = new Point(53, 108);
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.Size = new Size(479, 29);
            txtTenMonHoc.TabIndex = 1;
            txtTenMonHoc.Text = "Nhập tên môn học";
            txtTenMonHoc.TextChanged += textBox1_TextChanged;
            // 
            // lblTenMonHoc
            // 
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenMonHoc.Location = new Point(53, 79);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Size = new Size(98, 21);
            lblTenMonHoc.TabIndex = 2;
            lblTenMonHoc.Text = "Tên môn học";
            // 
            // lblThongTinMonHoc
            // 
            lblThongTinMonHoc.AutoSize = true;
            lblThongTinMonHoc.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongTinMonHoc.Location = new Point(190, 25);
            lblThongTinMonHoc.Name = "lblThongTinMonHoc";
            lblThongTinMonHoc.Size = new Size(204, 25);
            lblThongTinMonHoc.TabIndex = 2;
            lblThongTinMonHoc.Text = "THÔNG TIN MÔN HỌC";
            lblThongTinMonHoc.Click += label2_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(348, 292);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(76, 41);
            btnClose.TabIndex = 0;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += button1_Click;
            // 
            // txtSoTinChi
            // 
            txtSoTinChi.BackColor = Color.LightGray;
            txtSoTinChi.Font = new Font("Segoe UI", 12F);
            txtSoTinChi.ForeColor = Color.Gray;
            txtSoTinChi.Location = new Point(53, 186);
            txtSoTinChi.Name = "txtSoTinChi";
            txtSoTinChi.Size = new Size(479, 29);
            txtSoTinChi.TabIndex = 1;
            txtSoTinChi.Text = "Nhập số tín chỉ";
            txtSoTinChi.TextChanged += textBox1_TextChanged;
            // 
            // lblTongSoTinChi
            // 
            lblTongSoTinChi.AutoSize = true;
            lblTongSoTinChi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongSoTinChi.Location = new Point(53, 157);
            lblTongSoTinChi.Name = "lblTongSoTinChi";
            lblTongSoTinChi.Size = new Size(111, 21);
            lblTongSoTinChi.TabIndex = 2;
            lblTongSoTinChi.Text = "Tổng số tín chỉ";
            // 
            // frmAddMonHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(lblThongTinMonHoc);
            Controls.Add(lblTenMonHoc);
            Controls.Add(lblTongSoTinChi);
            Controls.Add(txtTenMonHoc);
            Controls.Add(txtSoTinChi);
            Controls.Add(btnSubmit);
            Controls.Add(btnClose);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm môn học";
            Load += frmAddMonHoc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private TextBox txtTenMonHoc;
        private Label lblTenMonHoc;
        private Label lblThongTinMonHoc;
        private Button btnClose;
        private TextBox txtSoTinChi;
        private Label lblTongSoTinChi;
    }
}