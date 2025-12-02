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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelContent = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            btnDong = new Button();
            btnThemSV = new Button();
            tbMaSv = new TextBox();
            label1 = new Label();
            tabPage3 = new TabPage();
            rtbKetQua = new RichTextBox();
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
            panelContent.CustomizableEdges = customizableEdges1;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelContent.Size = new Size(650, 350);
            panelContent.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage3);
            tabControl.ItemSize = new Size(135, 35);
            tabControl.Location = new Point(3, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(644, 347);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChange;
            // 
            // tabPage1
            // 
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(btnDong);
            tabPage1.Controls.Add(btnThemSV);
            tabPage1.Controls.Add(tbMaSv);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(636, 304);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Thêm thủ công";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(445, 230);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(112, 34);
            btnDong.TabIndex = 3;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // btnThemSV
            // 
            btnThemSV.Location = new Point(243, 230);
            btnThemSV.Name = "btnThemSV";
            btnThemSV.Size = new Size(174, 34);
            btnThemSV.TabIndex = 2;
            btnThemSV.Text = "Thêm sinh viên";
            btnThemSV.UseVisualStyleBackColor = true;
            btnThemSV.Click += btnThemSV_Click;
            // 
            // tbMaSv
            // 
            tbMaSv.Location = new Point(22, 112);
            tbMaSv.Name = "tbMaSv";
            tbMaSv.Size = new Size(395, 31);
            tbMaSv.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 64);
            label1.Name = "label1";
            label1.Size = new Size(215, 32);
            label1.TabIndex = 0;
            label1.Text = "Nhập mã sinh viên";
            // 
            // tabPage3
            // 
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(rtbKetQua);
            tabPage3.Controls.Add(btnClose);
            tabPage3.Controls.Add(txtDuongDan);
            tabPage3.Controls.Add(btnThemExcel);
            tabPage3.Controls.Add(btnChonFileExcel);
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(636, 304);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tham gia bằng excel";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbKetQua
            // 
            rtbKetQua.Location = new Point(34, 122);
            rtbKetQua.Name = "rtbKetQua";
            rtbKetQua.Size = new Size(284, 142);
            rtbKetQua.TabIndex = 5;
            rtbKetQua.Text = "";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(465, 230);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // txtDuongDan
            // 
            txtDuongDan.Location = new Point(178, 54);
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.Size = new Size(399, 31);
            txtDuongDan.TabIndex = 3;
            txtDuongDan.Text = "Chưa có tệp nào được chọn";
            // 
            // btnThemExcel
            // 
            btnThemExcel.Location = new Point(337, 230);
            btnThemExcel.Name = "btnThemExcel";
            btnThemExcel.Size = new Size(112, 34);
            btnThemExcel.TabIndex = 2;
            btnThemExcel.Text = "Thêm vào hệ thống";
            btnThemExcel.UseVisualStyleBackColor = true;
            btnThemExcel.Click += btnThemExcel_Click;
            // 
            // btnChonFileExcel
            // 
            btnChonFileExcel.BackColor = Color.FromArgb(52, 152, 219);
            btnChonFileExcel.ForeColor = Color.White;
            btnChonFileExcel.Location = new Point(34, 49);
            btnChonFileExcel.Name = "btnChonFileExcel";
            btnChonFileExcel.Size = new Size(138, 40);
            btnChonFileExcel.TabIndex = 0;
            btnChonFileExcel.Text = "Chọn tệp";
            btnChonFileExcel.UseVisualStyleBackColor = false;
            btnChonFileExcel.Click += btnChonTep_Click;
            // 
            // lbMaSv
            // 
            lbMaSv.BackColor = Color.Transparent;
            lbMaSv.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMaSv.Location = new Point(15, 34);
            lbMaSv.Name = "lbMaSv";
            lbMaSv.Size = new Size(133, 32);
            lbMaSv.TabIndex = 0;
            lbMaSv.Text = "Mã sinh viên";
            // 
            // UC_ThemSVVaoNhom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Name = "UC_ThemSVVaoNhom";
            Size = new Size(650, 350);
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
        private Button btnThemSV;
        private TextBox tbMaSv;
        private Label label1;
        private TabPage tabPage3;
        private Button btnChonFileExcel;
        private Button btnThemExcel;
        private TextBox txtDuongDan;
        private Button btnClose;
        private RichTextBox rtbKetQua;
    }
}
