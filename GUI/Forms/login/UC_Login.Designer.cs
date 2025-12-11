namespace GUI.Forms.login
{
    partial class UC_Login
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblSubTitle = new Label();
            txtMssv = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            linkForgotPassword = new LinkLabel();
            linkSignup = new LinkLabel();
            lbErrorMSSV = new Label();
            lbErrorMatKhau = new Label();
            panelContent = new Guna.UI2.WinForms.Guna2Panel();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(35, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(310, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập!";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10.2F);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(42, 95);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(253, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Vui lòng đăng nhập để tiếp tục.";
            // 
            // txtMssv
            // 
            txtMssv.Animated = true;
            txtMssv.BorderColor = Color.FromArgb(226, 232, 240);
            txtMssv.BorderRadius = 10;
            txtMssv.Cursor = Cursors.IBeam;
            txtMssv.CustomizableEdges = customizableEdges1;
            txtMssv.DefaultText = "";
            txtMssv.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMssv.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMssv.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMssv.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMssv.FillColor = Color.FromArgb(248, 250, 252);
            txtMssv.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtMssv.FocusedState.FillColor = Color.White;
            txtMssv.Font = new Font("Segoe UI", 10.8F);
            txtMssv.ForeColor = Color.FromArgb(15, 23, 42);
            txtMssv.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtMssv.Location = new Point(40, 145);
            txtMssv.Margin = new Padding(4);
            txtMssv.Name = "txtMssv";
            txtMssv.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtMssv.PlaceholderText = "Mã số sinh viên";
            txtMssv.SelectedText = "";
            txtMssv.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMssv.Size = new Size(360, 50);
            txtMssv.TabIndex = 2;
            txtMssv.TextOffset = new Point(10, 0);
            txtMssv.KeyDown += txtMssv_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.Animated = true;
            txtPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtPassword.BorderRadius = 10;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtPassword.FocusedState.FillColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtPassword.IconRight = Properties.Resources.icon_blinds;
            txtPassword.IconRightCursor = Cursors.Hand;
            txtPassword.IconRightSize = new Size(50, 40);
            txtPassword.Location = new Point(40, 225);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(360, 50);
            txtPassword.TabIndex = 4;
            txtPassword.TextOffset = new Point(10, 0);
            txtPassword.IconRightClick += txtPassword_IconRightClick;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.Animated = true;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderRadius = 10;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.DodgerBlue;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.FillColor = Color.FromArgb(67, 56, 202);
            btnLogin.Location = new Point(40, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.BorderRadius = 10;
            btnLogin.ShadowDecoration.Color = Color.FromArgb(79, 70, 229);
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.ShadowDecoration.Depth = 15;
            btnLogin.ShadowDecoration.Enabled = true;
            btnLogin.ShadowDecoration.Shadow = new Padding(0, 3, 5, 3);
            btnLogin.Size = new Size(360, 55);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.ActiveLinkColor = Color.FromArgb(79, 70, 229);
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            linkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline;
            linkForgotPassword.LinkColor = Color.FromArgb(79, 70, 229);
            linkForgotPassword.Location = new Point(305, 290);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(121, 20);
            linkForgotPassword.TabIndex = 6;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Quên mật khẩu?";
            linkForgotPassword.TextAlign = ContentAlignment.TopRight;
            linkForgotPassword.VisitedLinkColor = Color.DodgerBlue;
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // linkSignup
            // 
            linkSignup.ActiveLinkColor = Color.FromArgb(79, 70, 229);
            linkSignup.AutoSize = true;
            linkSignup.Font = new Font("Segoe UI", 10F);
            linkSignup.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkSignup.LinkColor = Color.FromArgb(100, 116, 139);
            linkSignup.Location = new Point(92, 420);
            linkSignup.Name = "linkSignup";
            linkSignup.Size = new Size(266, 23);
            linkSignup.TabIndex = 8;
            linkSignup.TabStop = true;
            linkSignup.Text = "Chưa có tài khoản? Đăng ký ngay";
            linkSignup.TextAlign = ContentAlignment.MiddleCenter;
            linkSignup.LinkClicked += linkSignup_LinkClicked;
            // 
            // lbErrorMSSV
            // 
            lbErrorMSSV.AutoSize = true;
            lbErrorMSSV.Font = new Font("Segoe UI", 9F);
            lbErrorMSSV.ForeColor = Color.Red;
            lbErrorMSSV.Location = new Point(45, 199);
            lbErrorMSSV.Name = "lbErrorMSSV";
            lbErrorMSSV.Size = new Size(0, 20);
            lbErrorMSSV.TabIndex = 3;
            // 
            // lbErrorMatKhau
            // 
            lbErrorMatKhau.AutoSize = true;
            lbErrorMatKhau.Font = new Font("Segoe UI", 9F);
            lbErrorMatKhau.ForeColor = Color.Red;
            lbErrorMatKhau.Location = new Point(45, 279);
            lbErrorMatKhau.Name = "lbErrorMatKhau";
            lbErrorMatKhau.Size = new Size(0, 20);
            lbErrorMatKhau.TabIndex = 5;
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
            panelContent.Controls.Add(txtMssv);
            panelContent.Controls.Add(lbErrorMSSV);
            panelContent.Controls.Add(txtPassword);
            panelContent.Controls.Add(lbErrorMatKhau);
            panelContent.Controls.Add(linkForgotPassword);
            panelContent.Controls.Add(btnLogin);
            panelContent.Controls.Add(linkSignup);
            panelContent.CustomizableEdges = customizableEdges7;
            panelContent.FillColor = Color.White;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.BorderRadius = 20;
            panelContent.ShadowDecoration.Color = Color.Silver;
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelContent.ShadowDecoration.Depth = 10;
            panelContent.ShadowDecoration.Enabled = true;
            panelContent.Size = new Size(450, 500);
            panelContent.TabIndex = 0;
            // 
            // UC_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            Controls.Add(panelContent);
            Name = "UC_Login";
            Size = new Size(450, 500);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMssv;
        private System.Windows.Forms.Label lbErrorMSSV;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lbErrorMatKhau;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.LinkLabel linkSignup;
    }
}