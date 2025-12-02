namespace GUI.Forms.nhomhocphan
{
    partial class FormThamGia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMaThamGia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtMaThamGia = new Guna.UI2.WinForms.Guna2TextBox();
            lblGuideline1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblGuideline2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblGuideline3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnJoin = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 45);
            lblTitle.Location = new Point(254, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(283, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THAM GIA NHÓM LỚP";
            // 
            // lblMaThamGia
            // 
            lblMaThamGia.BackColor = Color.Transparent;
            lblMaThamGia.Font = new Font("Segoe UI", 10F);
            lblMaThamGia.ForeColor = Color.FromArgb(30, 30, 45);
            lblMaThamGia.Location = new Point(60, 110);
            lblMaThamGia.Name = "lblMaThamGia";
            lblMaThamGia.Size = new Size(109, 25);
            lblMaThamGia.TabIndex = 1;
            lblMaThamGia.Text = "Mã Tham Gia:";
            // 
            // txtMaThamGia
            // 
            txtMaThamGia.AutoRoundedCorners = true;
            txtMaThamGia.BorderRadius = 18;
            txtMaThamGia.CustomizableEdges = customizableEdges1;
            txtMaThamGia.DefaultText = "";
            txtMaThamGia.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMaThamGia.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMaThamGia.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMaThamGia.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMaThamGia.FocusedState.BorderColor = Color.DodgerBlue;
            txtMaThamGia.Font = new Font("Segoe UI", 10F);
            txtMaThamGia.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMaThamGia.Location = new Point(180, 105);
            txtMaThamGia.Margin = new Padding(3, 4, 3, 4);
            txtMaThamGia.Name = "txtMaThamGia";
            txtMaThamGia.PlaceholderText = "Nhập mã lớp học hoặc mã nhóm...";
            txtMaThamGia.SelectedText = "";
            txtMaThamGia.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMaThamGia.Size = new Size(560, 39);
            txtMaThamGia.TabIndex = 2;
            txtMaThamGia.TextOffset = new Point(10, 0);
            // 
            // lblGuideline1
            // 
            lblGuideline1.BackColor = Color.Transparent;
            lblGuideline1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblGuideline1.Location = new Point(180, 190);
            lblGuideline1.Name = "lblGuideline1";
            lblGuideline1.Size = new Size(453, 22);
            lblGuideline1.TabIndex = 3;
            lblGuideline1.Text = "Đề nghị giảng viên của bạn cung cấp mã lớp rồi nhập mã vào đây";
            // 
            // lblGuideline2
            // 
            lblGuideline2.BackColor = Color.Transparent;
            lblGuideline2.Font = new Font("Segoe UI", 9F);
            lblGuideline2.ForeColor = Color.Gray;
            lblGuideline2.Location = new Point(200, 235);
            lblGuideline2.Name = "lblGuideline2";
            lblGuideline2.Size = new Size(261, 22);
            lblGuideline2.TabIndex = 4;
            lblGuideline2.Text = "• Sử dụng tài khoản đã được cấp phép.";
            // 
            // lblGuideline3
            // 
            lblGuideline3.BackColor = Color.Transparent;
            lblGuideline3.Font = new Font("Segoe UI", 9F);
            lblGuideline3.ForeColor = Color.Gray;
            lblGuideline3.Location = new Point(200, 265);
            lblGuideline3.Name = "lblGuideline3";
            lblGuideline3.Size = new Size(238, 22);
            lblGuideline3.TabIndex = 5;
            lblGuideline3.Text = "• Đảm bảo mã lớp học là chính xác.";
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 10;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.FillColor = Color.Silver;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(540, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(90, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            // 
            // btnJoin
            // 
            btnJoin.BorderRadius = 10;
            btnJoin.CustomizableEdges = customizableEdges5;
            btnJoin.DisabledState.BorderColor = Color.DarkGray;
            btnJoin.FillColor = Color.DodgerBlue;
            btnJoin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(640, 360);
            btnJoin.Name = "btnJoin";
            btnJoin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnJoin.Size = new Size(119, 40);
            btnJoin.TabIndex = 7;
            btnJoin.Text = "Tham Gia";
            // 
            // FormThamGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnJoin);
            Controls.Add(btnCancel);
            Controls.Add(lblGuideline3);
            Controls.Add(lblGuideline2);
            Controls.Add(lblGuideline1);
            Controls.Add(txtMaThamGia);
            Controls.Add(lblMaThamGia);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormThamGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tham Gia Nhóm Học Phần";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaThamGia;
        private Guna.UI2.WinForms.Guna2TextBox txtMaThamGia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGuideline1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGuideline2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGuideline3;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnJoin;
    }
}