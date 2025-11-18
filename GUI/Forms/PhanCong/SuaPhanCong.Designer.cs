namespace GUI.forms.PhanCong
{
    partial class SuaPhanCong
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
            lblSua = new Label();
            lblMaPhanCong = new Label();
            txtMaPhanCong = new Guna.UI2.WinForms.Guna2TextBox();
            lblMonHoc = new Label();
            cbxMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            cbxGiangVien = new Guna.UI2.WinForms.Guna2ComboBox();
            lblGiangVien = new Label();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblSua
            // 
            lblSua.AutoSize = true;
            lblSua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSua.Location = new Point(162, 17);
            lblSua.Name = "lblSua";
            lblSua.Size = new Size(161, 21);
            lblSua.TabIndex = 1;
            lblSua.Text = "Điều chỉnh phân công";
            // 
            // lblMaPhanCong
            // 
            lblMaPhanCong.AutoSize = true;
            lblMaPhanCong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaPhanCong.Location = new Point(32, 52);
            lblMaPhanCong.Name = "lblMaPhanCong";
            lblMaPhanCong.Size = new Size(109, 21);
            lblMaPhanCong.TabIndex = 2;
            lblMaPhanCong.Text = "Mã phân công";
            // 
            // txtMaPhanCong
            // 
            txtMaPhanCong.BackColor = SystemColors.Control;
            txtMaPhanCong.CustomizableEdges = customizableEdges1;
            txtMaPhanCong.DefaultText = "";
            txtMaPhanCong.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMaPhanCong.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMaPhanCong.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMaPhanCong.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMaPhanCong.Enabled = false;
            txtMaPhanCong.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMaPhanCong.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaPhanCong.ForeColor = Color.Black;
            txtMaPhanCong.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMaPhanCong.Location = new Point(32, 79);
            txtMaPhanCong.Margin = new Padding(3, 4, 3, 4);
            txtMaPhanCong.Name = "txtMaPhanCong";
            txtMaPhanCong.PlaceholderForeColor = Color.Gray;
            txtMaPhanCong.PlaceholderText = "";
            txtMaPhanCong.SelectedText = "";
            txtMaPhanCong.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMaPhanCong.Size = new Size(419, 35);
            txtMaPhanCong.TabIndex = 3;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(32, 132);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(71, 21);
            lblMonHoc.TabIndex = 4;
            lblMonHoc.Text = "Môn học";
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.BackColor = Color.Transparent;
            cbxMonHoc.Cursor = Cursors.Hand;
            cbxMonHoc.CustomizableEdges = customizableEdges3;
            cbxMonHoc.DrawMode = DrawMode.OwnerDrawFixed;
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxMonHoc.Font = new Font("Segoe UI", 10F);
            cbxMonHoc.ForeColor = Color.FromArgb(68, 88, 112);
            cbxMonHoc.ItemHeight = 30;
            cbxMonHoc.Location = new Point(32, 161);
            cbxMonHoc.MaxDropDownItems = 5;
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbxMonHoc.Size = new Size(419, 36);
            cbxMonHoc.TabIndex = 5;
            // 
            // cbxGiangVien
            // 
            cbxGiangVien.BackColor = Color.Transparent;
            cbxGiangVien.Cursor = Cursors.Hand;
            cbxGiangVien.CustomizableEdges = customizableEdges5;
            cbxGiangVien.DrawMode = DrawMode.OwnerDrawFixed;
            cbxGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGiangVien.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxGiangVien.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxGiangVien.Font = new Font("Segoe UI", 10F);
            cbxGiangVien.ForeColor = Color.FromArgb(68, 88, 112);
            cbxGiangVien.ItemHeight = 30;
            cbxGiangVien.Location = new Point(32, 249);
            cbxGiangVien.MaxDropDownItems = 5;
            cbxGiangVien.Name = "cbxGiangVien";
            cbxGiangVien.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbxGiangVien.Size = new Size(419, 36);
            cbxGiangVien.TabIndex = 7;
            // 
            // lblGiangVien
            // 
            lblGiangVien.AutoSize = true;
            lblGiangVien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGiangVien.Location = new Point(32, 217);
            lblGiangVien.Name = "lblGiangVien";
            lblGiangVien.Size = new Size(71, 21);
            lblGiangVien.TabIndex = 6;
            lblGiangVien.Text = "Môn học";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.CustomizableEdges = customizableEdges7;
            btnSubmit.FillColor = Color.FromArgb(6, 101, 208);
            btnSubmit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(356, 305);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSubmit.Size = new Size(95, 36);
            btnSubmit.TabIndex = 21;
            btnSubmit.Text = "Cập nhật";
            btnSubmit.Click += this.btnSubmit_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DodgerBlue;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges9;
            btnClose.FillColor = Color.Silver;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(248, 305);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnClose.Size = new Size(86, 36);
            btnClose.TabIndex = 23;
            btnClose.Text = "Thoát";
            btnClose.Click += this.btnClose_Click;
            // 
            // SuaPhanCong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(lblSua);
            Controls.Add(lblMaPhanCong);
            Controls.Add(txtMaPhanCong);
            Controls.Add(lblMonHoc);
            Controls.Add(cbxMonHoc);
            Controls.Add(lblGiangVien);
            Controls.Add(cbxGiangVien);
            Controls.Add(btnSubmit);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SuaPhanCong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sua";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSua;
        private Label lblMaPhanCong;
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhanCong;
        private Label lblMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbxMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbxGiangVien;
        private Label lblGiangVien;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}