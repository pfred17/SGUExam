namespace GUI.Forms.login
{
    partial class UC_Register: UserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            titleRegister = new Label();
            lblSubTitle = new Label();
            txtRegisterMssv = new Guna.UI2.WinForms.Guna2TextBox();
            txtFullname = new Guna.UI2.WinForms.Guna2TextBox();
            txtRegisterPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtRegisterConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtRegisterEmail = new Guna.UI2.WinForms.Guna2TextBox();
            btnRegister = new Guna.UI2.WinForms.Guna2Button();
            linkLogin = new LinkLabel();
            panelContent = new Guna.UI2.WinForms.Guna2Panel();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // titleRegister
            // 
            titleRegister.AutoSize = true;
            titleRegister.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titleRegister.ForeColor = Color.FromArgb(30, 41, 59);
            titleRegister.Location = new Point(35, 15);
            titleRegister.Name = "titleRegister";
            titleRegister.Size = new Size(287, 50);
            titleRegister.TabIndex = 0;
            titleRegister.Text = "Create Account";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(40, 60);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(196, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Đăng ký thành viên mới.";
            // 
            // txtRegisterMssv
            // 
            txtRegisterMssv.Animated = true;
            txtRegisterMssv.BorderColor = Color.FromArgb(226, 232, 240);
            txtRegisterMssv.BorderRadius = 10;
            txtRegisterMssv.CustomizableEdges = customizableEdges1;
            txtRegisterMssv.DefaultText = "";
            txtRegisterMssv.FillColor = Color.FromArgb(248, 250, 252);
            txtRegisterMssv.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterMssv.FocusedState.FillColor = Color.White;
            txtRegisterMssv.Font = new Font("Segoe UI", 10F);
            txtRegisterMssv.ForeColor = Color.FromArgb(15, 23, 42);
            txtRegisterMssv.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterMssv.Location = new Point(40, 95);
            txtRegisterMssv.Margin = new Padding(3, 4, 3, 4);
            txtRegisterMssv.Name = "txtRegisterMssv";
            txtRegisterMssv.PlaceholderText = "Mã số sinh viên";
            txtRegisterMssv.SelectedText = "";
            txtRegisterMssv.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtRegisterMssv.Size = new Size(360, 45);
            txtRegisterMssv.TabIndex = 2;
            txtRegisterMssv.TextOffset = new Point(5, 0);
            txtRegisterMssv.KeyDown += Shared_KeyDown;
            // 
            // txtFullname
            // 
            txtFullname.Animated = true;
            txtFullname.BorderColor = Color.FromArgb(226, 232, 240);
            txtFullname.BorderRadius = 10;
            txtFullname.CustomizableEdges = customizableEdges3;
            txtFullname.DefaultText = "";
            txtFullname.FillColor = Color.FromArgb(248, 250, 252);
            txtFullname.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtFullname.FocusedState.FillColor = Color.White;
            txtFullname.Font = new Font("Segoe UI", 10F);
            txtFullname.ForeColor = Color.FromArgb(15, 23, 42);
            txtFullname.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtFullname.Location = new Point(40, 150);
            txtFullname.Margin = new Padding(3, 4, 3, 4);
            txtFullname.Name = "txtFullname";
            txtFullname.PlaceholderText = "Họ và tên";
            txtFullname.SelectedText = "";
            txtFullname.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFullname.Size = new Size(360, 45);
            txtFullname.TabIndex = 3;
            txtFullname.TextOffset = new Point(5, 0);
            txtFullname.KeyDown += Shared_KeyDown;
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.Animated = true;
            txtRegisterPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtRegisterPassword.BorderRadius = 10;
            txtRegisterPassword.CustomizableEdges = customizableEdges5;
            txtRegisterPassword.DefaultText = "";
            txtRegisterPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtRegisterPassword.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterPassword.FocusedState.FillColor = Color.White;
            txtRegisterPassword.Font = new Font("Segoe UI", 10F);
            txtRegisterPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtRegisterPassword.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterPassword.IconLeftSize = new Size(0, 0);
            txtRegisterPassword.IconRight = Properties.Resources.icon_blinds;
            txtRegisterPassword.IconRightCursor = Cursors.Hand;
            txtRegisterPassword.IconRightSize = new Size(50, 40);
            txtRegisterPassword.Location = new Point(40, 205);
            txtRegisterPassword.Margin = new Padding(3, 4, 3, 4);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.PasswordChar = '●';
            txtRegisterPassword.PlaceholderText = "Mật khẩu";
            txtRegisterPassword.SelectedText = "";
            txtRegisterPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtRegisterPassword.Size = new Size(360, 45);
            txtRegisterPassword.TabIndex = 4;
            txtRegisterPassword.TextOffset = new Point(5, 0);
            txtRegisterPassword.IconRightClick += txtRegisterPassword_IconRightClick;
            txtRegisterPassword.KeyDown += Shared_KeyDown;
            // 
            // txtRegisterConfirmPassword
            // 
            txtRegisterConfirmPassword.Animated = true;
            txtRegisterConfirmPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtRegisterConfirmPassword.BorderRadius = 10;
            txtRegisterConfirmPassword.CustomizableEdges = customizableEdges7;
            txtRegisterConfirmPassword.DefaultText = "";
            txtRegisterConfirmPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtRegisterConfirmPassword.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterConfirmPassword.FocusedState.FillColor = Color.White;
            txtRegisterConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtRegisterConfirmPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtRegisterConfirmPassword.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterConfirmPassword.Location = new Point(40, 260);
            txtRegisterConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtRegisterConfirmPassword.Name = "txtRegisterConfirmPassword";
            txtRegisterConfirmPassword.PasswordChar = '●';
            txtRegisterConfirmPassword.PlaceholderText = "Xác nhận mật khẩu";
            txtRegisterConfirmPassword.SelectedText = "";
            txtRegisterConfirmPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtRegisterConfirmPassword.Size = new Size(360, 45);
            txtRegisterConfirmPassword.TabIndex = 5;
            txtRegisterConfirmPassword.TextOffset = new Point(5, 0);
            txtRegisterConfirmPassword.KeyDown += Shared_KeyDown;
            // 
            // txtRegisterEmail
            // 
            txtRegisterEmail.Animated = true;
            txtRegisterEmail.BorderColor = Color.FromArgb(226, 232, 240);
            txtRegisterEmail.BorderRadius = 10;
            txtRegisterEmail.CustomizableEdges = customizableEdges9;
            txtRegisterEmail.DefaultText = "";
            txtRegisterEmail.FillColor = Color.FromArgb(248, 250, 252);
            txtRegisterEmail.FocusedState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterEmail.FocusedState.FillColor = Color.White;
            txtRegisterEmail.Font = new Font("Segoe UI", 10F);
            txtRegisterEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtRegisterEmail.HoverState.BorderColor = Color.FromArgb(79, 70, 229);
            txtRegisterEmail.Location = new Point(40, 315);
            txtRegisterEmail.Margin = new Padding(3, 4, 3, 4);
            txtRegisterEmail.Name = "txtRegisterEmail";
            txtRegisterEmail.PlaceholderText = "Email liên hệ";
            txtRegisterEmail.SelectedText = "";
            txtRegisterEmail.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtRegisterEmail.Size = new Size(360, 45);
            txtRegisterEmail.TabIndex = 6;
            txtRegisterEmail.TextOffset = new Point(5, 0);
            txtRegisterEmail.TextChanged += txtRegisterEmail_TextChanged;
            txtRegisterEmail.KeyDown += Shared_KeyDown;
            // 
            // btnRegister
            // 
            btnRegister.Animated = true;
            btnRegister.BackColor = Color.Transparent;
            btnRegister.BorderRadius = 10;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.CustomizableEdges = customizableEdges11;
            btnRegister.FillColor = Color.DodgerBlue;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.HoverState.FillColor = Color.FromArgb(67, 56, 202);
            btnRegister.Location = new Point(40, 380);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.BorderRadius = 10;
            btnRegister.ShadowDecoration.Color = Color.FromArgb(79, 70, 229);
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRegister.ShadowDecoration.Depth = 15;
            btnRegister.ShadowDecoration.Enabled = true;
            btnRegister.ShadowDecoration.Shadow = new Padding(0, 3, 5, 3);
            btnRegister.Size = new Size(360, 50);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;
            btnRegister.KeyDown += Shared_KeyDown;
            // 
            // linkLogin
            // 
            linkLogin.ActiveLinkColor = Color.FromArgb(79, 70, 229);
            linkLogin.AutoSize = true;
            linkLogin.Font = new Font("Segoe UI", 10F);
            linkLogin.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkLogin.LinkColor = Color.FromArgb(100, 116, 139);
            linkLogin.Location = new Point(111, 445);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(228, 23);
            linkLogin.TabIndex = 8;
            linkLogin.TabStop = true;
            linkLogin.Text = "Đã có tài khoản? Đăng nhập";
            linkLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.None;
            panelContent.BackColor = Color.Transparent;
            panelContent.BorderColor = Color.DodgerBlue;
            panelContent.BorderRadius = 20;
            panelContent.BorderThickness = 2;
            panelContent.Controls.Add(titleRegister);
            panelContent.Controls.Add(lblSubTitle);
            panelContent.Controls.Add(txtRegisterMssv);
            panelContent.Controls.Add(txtFullname);
            panelContent.Controls.Add(txtRegisterPassword);
            panelContent.Controls.Add(txtRegisterConfirmPassword);
            panelContent.Controls.Add(txtRegisterEmail);
            panelContent.Controls.Add(btnRegister);
            panelContent.Controls.Add(linkLogin);
            panelContent.CustomizableEdges = customizableEdges13;
            panelContent.FillColor = Color.White;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.BorderRadius = 20;
            panelContent.ShadowDecoration.Color = Color.Silver;
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelContent.ShadowDecoration.Depth = 10;
            panelContent.ShadowDecoration.Enabled = true;
            panelContent.Size = new Size(450, 500);
            panelContent.TabIndex = 0;
            // 
            // UC_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            Controls.Add(panelContent);
            Name = "UC_Register";
            Size = new Size(450, 500);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.Label titleRegister;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterMssv;
        private Guna.UI2.WinForms.Guna2TextBox txtFullname;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterEmail;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private System.Windows.Forms.LinkLabel linkLogin;
    }
}