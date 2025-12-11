namespace GUI.modules
{
    partial class UC_ThemSVVaoNhom
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelContent = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            btnThemSV1 = new Guna.UI2.WinForms.Guna2Button();
            btnDong = new Button();
            tbMaSv = new TextBox();
            label1 = new Label();
            tabPage3 = new TabPage();
            btnClose = new Button();
            txtDuongDan = new TextBox();
            btnThemExcel = new Button();
            btnChonFileExcel = new Button();
            lbMaSv = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Controls.Add(tabControl);
            panelContent.CustomizableEdges = customizableEdges3;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(2);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelContent.Size = new Size(520, 280);
            panelContent.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage3);
            tabControl.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl.ItemSize = new Size(180, 45);
            tabControl.Location = new Point(2, 2);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(515, 278);
            tabControl.TabIndex = 0;
            tabControl.DrawItem += tabControl1_DrawItem;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChange;
            // 
            // tabPage1
            // 
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(btnThemSV1);
            tabPage1.Controls.Add(btnDong);
            tabPage1.Controls.Add(tbMaSv);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 49);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(507, 225);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Thêm thủ công";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnThemSV1
            // 
            btnThemSV1.BorderRadius = 2;
            btnThemSV1.CustomizableEdges = customizableEdges1;
            btnThemSV1.DisabledState.BorderColor = Color.DarkGray;
            btnThemSV1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemSV1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemSV1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemSV1.FillColor = Color.FromArgb(6, 101, 208);
            btnThemSV1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemSV1.ForeColor = Color.White;
            btnThemSV1.Location = new Point(257, 170);
            btnThemSV1.Name = "btnThemSV1";
            btnThemSV1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThemSV1.Size = new Size(212, 35);
            btnThemSV1.TabIndex = 5;
            btnThemSV1.Text = "THÊM SINH VIÊN";
            btnThemSV1.Click += btnThemSV1_Click;
            // 
            // btnDong
            // 
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = SystemColors.ControlDark;
            btnDong.Location = new Point(114, 170);
            btnDong.Margin = new Padding(2);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(100, 35);
            btnDong.TabIndex = 3;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // tbMaSv
            // 
            tbMaSv.BorderStyle = BorderStyle.FixedSingle;
            tbMaSv.Location = new Point(16, 55);
            tbMaSv.Margin = new Padding(2);
            tbMaSv.Name = "tbMaSv";
            tbMaSv.Size = new Size(453, 32);
            tbMaSv.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập mã sinh viên";
            // 
            // tabPage3
            // 
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(btnClose);
            tabPage3.Controls.Add(txtDuongDan);
            tabPage3.Controls.Add(btnThemExcel);
            tabPage3.Controls.Add(btnChonFileExcel);
            tabPage3.Location = new Point(4, 49);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(507, 225);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tham gia bằng excel";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(363, 169);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(98, 33);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // txtDuongDan
            // 
            txtDuongDan.BorderStyle = BorderStyle.FixedSingle;
            txtDuongDan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDuongDan.Location = new Point(142, 66);
            txtDuongDan.Margin = new Padding(2);
            txtDuongDan.Multiline = true;
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.Size = new Size(320, 36);
            txtDuongDan.TabIndex = 3;
            txtDuongDan.Text = "Chưa có tệp nào được chọn";
            // 
            // btnThemExcel
            // 
            btnThemExcel.Location = new Point(202, 169);
            btnThemExcel.Margin = new Padding(2);
            btnThemExcel.Name = "btnThemExcel";
            btnThemExcel.Size = new Size(139, 33);
            btnThemExcel.TabIndex = 2;
            btnThemExcel.Text = "Thêm sinh viên";
            btnThemExcel.UseVisualStyleBackColor = true;
            btnThemExcel.Click += btnThemExcel_Click;
            // 
            // btnChonFileExcel
            // 
            btnChonFileExcel.BackColor = Color.FromArgb(52, 152, 219);
            btnChonFileExcel.FlatAppearance.BorderSize = 0;
            btnChonFileExcel.FlatStyle = FlatStyle.Flat;
            btnChonFileExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChonFileExcel.ForeColor = Color.White;
            btnChonFileExcel.ImageAlign = ContentAlignment.MiddleLeft;
            btnChonFileExcel.Location = new Point(27, 66);
            btnChonFileExcel.Margin = new Padding(2);
            btnChonFileExcel.Name = "btnChonFileExcel";
            btnChonFileExcel.Size = new Size(110, 36);
            btnChonFileExcel.TabIndex = 0;
            btnChonFileExcel.Text = "Chọn tệp";
            btnChonFileExcel.TextAlign = ContentAlignment.TopCenter;
            btnChonFileExcel.UseVisualStyleBackColor = false;
            btnChonFileExcel.Click += btnChonTep_Click;
            // 
            // lbMaSv
            // 
            lbMaSv.BackColor = Color.Transparent;
            lbMaSv.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMaSv.Location = new Point(15, 34);
            lbMaSv.Name = "lbMaSv";
            lbMaSv.Size = new Size(111, 27);
            lbMaSv.TabIndex = 0;
            lbMaSv.Text = "Mã sinh viên";
            // 
            // UC_ThemSVVaoNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Margin = new Padding(2);
            Name = "UC_ThemSVVaoNhom";
            Size = new Size(520, 280);
            panelContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMaSv;
        private TabControl tabControl;
        private TabPage tabPage1;
        private Button btnDong;
        private TextBox tbMaSv;
        private Label label1;
        private TabPage tabPage3;
        private Button btnChonFileExcel;
        private Button btnThemExcel;
        private TextBox txtDuongDan;
        private Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnThemSV1;
    }
}
