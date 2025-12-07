namespace GUI.forms.hocphan
{
    partial class UC_DeThiNhomHocPhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_DeThiNhomHocPhan));
            tbTimKiem = new TextBox();
            btnTaoDe = new Button();
            flDeThi = new FlowLayoutPanel();
            lblTieuDe = new Label();
            label1 = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            lbPage = new Label();
            SuspendLayout();
            // 
            // tbTimKiem
            // 
            tbTimKiem.Location = new Point(125, 24);
            tbTimKiem.Margin = new Padding(2);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(372, 27);
            tbTimKiem.TabIndex = 0;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // btnTaoDe
            // 
            btnTaoDe.BackColor = Color.FromArgb(94, 148, 255);
            btnTaoDe.FlatAppearance.BorderSize = 0;
            btnTaoDe.FlatStyle = FlatStyle.Flat;
            btnTaoDe.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaoDe.ForeColor = Color.White;
            btnTaoDe.Location = new Point(965, 15);
            btnTaoDe.Margin = new Padding(0);
            btnTaoDe.Name = "btnTaoDe";
            btnTaoDe.Size = new Size(128, 40);
            btnTaoDe.TabIndex = 1;
            btnTaoDe.Text = "Tạo đề thi";
            btnTaoDe.UseVisualStyleBackColor = false;
            btnTaoDe.Click += btnTaoDe_Click;
            // 
            // flDeThi
            // 
            flDeThi.AutoScroll = true;
            flDeThi.BackColor = SystemColors.Control;
            flDeThi.FlowDirection = FlowDirection.TopDown;
            flDeThi.Location = new Point(0, 87);
            flDeThi.Margin = new Padding(2);
            flDeThi.Name = "flDeThi";
            flDeThi.Size = new Size(1118, 547);
            flDeThi.TabIndex = 3;
            flDeThi.WrapContents = false;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(40, 61);
            lblTieuDe.Margin = new Padding(2, 0, 2, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(96, 25);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "lblTieuDe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 4;
            label1.Text = "Tìm kiếm";
            // 
            // btnPrev
            // 
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.Location = new Point(943, 655);
            btnPrev.Margin = new Padding(2);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(54, 29);
            btnPrev.TabIndex = 5;
            btnPrev.TabStop = false;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(1039, 655);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(54, 29);
            btnNext.TabIndex = 6;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lbPage
            // 
            lbPage.AutoSize = true;
            lbPage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPage.Location = new Point(1001, 659);
            lbPage.Margin = new Padding(2, 0, 2, 0);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(24, 23);
            lbPage.TabIndex = 7;
            lbPage.Text = "lb";
            // 
            // UC_DeThiNhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbPage);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(label1);
            Controls.Add(lblTieuDe);
            Controls.Add(flDeThi);
            Controls.Add(btnTaoDe);
            Controls.Add(tbTimKiem);
            Margin = new Padding(0);
            Name = "UC_DeThiNhomHocPhan";
            Size = new Size(1120, 730);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnTaoDe;
        private FlowLayoutPanel flDeThi;
        private Label lblTieuDe;
        private Label label1;
        private Button btnPrev;
        private Button btnNext;
        private Label lbPage;
        private TextBox tbTimKiem;
    }
}
