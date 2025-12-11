namespace GUI.Forms.login
{
    partial class UC_ForgotPassword: UserControl
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



        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            panelContent = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            txtEmailFP = new Guna.UI2.WinForms.Guna2TextBox();
            btnSendCode = new Guna.UI2.WinForms.Guna2Button();
            txtCode = new Guna.UI2.WinForms.Guna2TextBox();
            txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            linkBackToLogin = new LinkLabel();
            elipseUserControl = new Guna.UI2.WinForms.Guna2Elipse(components);
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.None;
            panelContent.BackColor = Color.Transparent;
            panelContent.BorderColor = Color.DodgerBlue;
            panelContent.BorderRadius = 20;
            panelContent.BorderThickness = 2;
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubTitle);
            panelContent.Controls.Add(txtEmailFP);
            panelContent.Controls.Add(btnSendCode);
            panelContent.Controls.Add(txtCode);
            panelContent.Controls.Add(txtNewPassword);
            panelContent.Controls.Add(btnSave);
            panelContent.Controls.Add(linkBackToLogin);
            panelContent.CustomizableEdges = customizableEdges11;
            panelContent.FillColor = Color.White;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.BorderRadius = 20;
            panelContent.ShadowDecoration.Color = Color.Silver;
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelContent.ShadowDecoration.Depth = 10;
            panelContent.ShadowDecoration.Enabled = true;
            panelContent.Size = new Size(450, 500);
            panelContent.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(40, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Khôi phục mật khẩu";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(45, 90);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(353, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Nhập email và mã xác nhận để đổi mật khẩu";
            // 
            // txtEmailFP
            // 
            txtEmailFP.Animated = true;
            txtEmailFP.BorderColor = Color.FromArgb(226, 232, 240);
            txtEmailFP.BorderRadius = 10;
            txtEmailFP.CustomizableEdges = customizableEdges1;
            txtEmailFP.DefaultText = "";
            txtEmailFP.FillColor = Color.FromArgb(248, 250, 252);
            txtEmailFP.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtEmailFP.FocusedState.FillColor = Color.White;
            txtEmailFP.Font = new Font("Segoe UI", 10F);
            txtEmailFP.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmailFP.Location = new Point(45, 140);
            txtEmailFP.Margin = new Padding(3, 4, 3, 4);
            txtEmailFP.Name = "txtEmailFP";
            txtEmailFP.PlaceholderText = "Nhập Email đăng ký";
            txtEmailFP.SelectedText = "";
            txtEmailFP.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmailFP.Size = new Size(250, 45);
            txtEmailFP.TabIndex = 2;
            txtEmailFP.TextOffset = new Point(5, 0);
            txtEmailFP.KeyDown += txtEmailFP_KeyDown;
            // 
            // btnSendCode
            // 
            btnSendCode.Animated = true;
            btnSendCode.BorderRadius = 10;
            btnSendCode.Cursor = Cursors.Hand;
            btnSendCode.CustomizableEdges = customizableEdges3;
            btnSendCode.FillColor = Color.DodgerBlue;
            btnSendCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendCode.ForeColor = Color.White;
            btnSendCode.Location = new Point(305, 140);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSendCode.Size = new Size(100, 45);
            btnSendCode.TabIndex = 3;
            btnSendCode.Text = "Gửi mã";
            btnSendCode.Click += btnSendCode_Click;
            // 
            // txtCode
            // 
            txtCode.Animated = true;
            txtCode.BorderColor = Color.FromArgb(226, 232, 240);
            txtCode.BorderRadius = 10;
            txtCode.CustomizableEdges = customizableEdges5;
            txtCode.DefaultText = "";
            txtCode.FillColor = Color.FromArgb(248, 250, 252);
            txtCode.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtCode.Font = new Font("Segoe UI", 10F);
            txtCode.ForeColor = Color.FromArgb(15, 23, 42);
            txtCode.Location = new Point(45, 205);
            txtCode.Margin = new Padding(3, 4, 3, 4);
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "Nhập mã xác nhận (Code)";
            txtCode.SelectedText = "";
            txtCode.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtCode.Size = new Size(360, 45);
            txtCode.TabIndex = 4;
            txtCode.TextOffset = new Point(5, 0);
            txtCode.KeyDown += txtCode_KeyDown;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Animated = true;
            txtNewPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtNewPassword.BorderRadius = 10;
            txtNewPassword.CustomizableEdges = customizableEdges7;
            txtNewPassword.DefaultText = "";
            txtNewPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtNewPassword.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.IconRight = Properties.Resources.icon_blinds;
            txtNewPassword.IconRightSize = new Size(50, 40);
            txtNewPassword.Location = new Point(45, 270);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.PlaceholderText = "Nhập mật khẩu mới";
            txtNewPassword.SelectedText = "";
            txtNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNewPassword.Size = new Size(360, 45);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.TextOffset = new Point(5, 0);
            txtNewPassword.IconRightClick += txtNewPassword_IconRightClick;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 10;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges9;
            btnSave.FillColor = Color.DodgerBlue;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(45, 345);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.BorderRadius = 10;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSave.ShadowDecoration.Depth = 15;
            btnSave.ShadowDecoration.Enabled = true;
            btnSave.ShadowDecoration.Shadow = new Padding(0, 3, 5, 3);
            btnSave.Size = new Size(360, 50);
            btnSave.TabIndex = 6;
            btnSave.Text = "Xác nhận đổi mật khẩu";
            btnSave.Click += btnSave_Click;
            // 
            // linkBackToLogin
            // 
            linkBackToLogin.ActiveLinkColor = Color.FromArgb(79, 70, 229);
            linkBackToLogin.AutoSize = true;
            linkBackToLogin.Font = new Font("Segoe UI", 10F);
            linkBackToLogin.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkBackToLogin.LinkColor = Color.FromArgb(100, 116, 139);
            linkBackToLogin.Location = new Point(122, 420);
            linkBackToLogin.Name = "linkBackToLogin";
            linkBackToLogin.Size = new Size(206, 23);
            linkBackToLogin.TabIndex = 7;
            linkBackToLogin.TabStop = true;
            linkBackToLogin.Text = "Quay lại trang đăng nhập";
            linkBackToLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkBackToLogin.LinkClicked += linkBackToLogin_LinkClicked;
            // 
            // elipseUserControl
            // 
            elipseUserControl.BorderRadius = 20;
            elipseUserControl.TargetControl = this;
            // 
            // UC_ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            Controls.Add(panelContent);
            Name = "UC_ForgotPassword";
            Size = new Size(450, 500);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #region
        private Guna.UI2.WinForms.Guna2Elipse elipseUserControl;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtEmailFP;
        private Guna.UI2.WinForms.Guna2Button btnSendCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCode;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.LinkLabel linkBackToLogin;
        #endregion
    }
}