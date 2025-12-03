namespace GUI.Forms.nhomhocphan
{
    partial class UC_NhomHocPhanUser
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnJoin = new Guna.UI2.WinForms.Guna2Button();
            flpNhomHocPhan = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Animated = true;
            txtSearch.AutoRoundedCorners = true;
            txtSearch.BorderRadius = 21;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges5;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(104, 25);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã nhóm học phần để tìm kiếm...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSearch.Size = new Size(400, 45);
            txtSearch.TabIndex = 0;
            txtSearch.TextOffset = new Point(10, 0);
            txtSearch.TextChanged +=txtSearch_TextChanged;
            // 
            // btnJoin
            // 
            btnJoin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnJoin.Animated = true;
            btnJoin.BorderRadius = 10;
            btnJoin.Cursor = Cursors.Hand;
            btnJoin.CustomizableEdges = customizableEdges7;
            btnJoin.DisabledState.BorderColor = Color.DarkGray;
            btnJoin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnJoin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnJoin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnJoin.FillColor = Color.DodgerBlue;
            btnJoin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(611, 25);
            btnJoin.Name = "btnJoin";
            btnJoin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnJoin.Size = new Size(200, 45);
            btnJoin.TabIndex = 1;
            btnJoin.Text = "THAM GIA NHÓM";
            btnJoin.Click += btnJoin_Click;
            // 
            // flpNhomHocPhan
            // 
            flpNhomHocPhan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpNhomHocPhan.AutoScroll = true;
            flpNhomHocPhan.BackColor = Color.White;
            flpNhomHocPhan.Location = new Point(30, 95);
            flpNhomHocPhan.Name = "flpNhomHocPhan";
            flpNhomHocPhan.Padding = new Padding(10);
            flpNhomHocPhan.Size = new Size(870, 530);
            flpNhomHocPhan.TabIndex = 2;
            // 
            // UC_NhomHocPhanUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(flpNhomHocPhan);
            Controls.Add(btnJoin);
            Controls.Add(txtSearch);
            Name = "UC_NhomHocPhanUser";
            Size = new Size(933, 653);
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnJoin;
        private FlowLayoutPanel flpNhomHocPhan;
    }
}
