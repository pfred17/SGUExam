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
            tbTimKiem.Location = new Point(156, 30);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(388, 31);
            tbTimKiem.TabIndex = 0;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // btnTaoDe
            // 
            btnTaoDe.BackColor = Color.FromArgb(94, 148, 255);
            btnTaoDe.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaoDe.ForeColor = Color.White;
            btnTaoDe.Location = new Point(917, 19);
            btnTaoDe.Margin = new Padding(0);
            btnTaoDe.Name = "btnTaoDe";
            btnTaoDe.Size = new Size(160, 50);
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
            flDeThi.Location = new Point(0, 109);
            flDeThi.Name = "flDeThi";
            flDeThi.Size = new Size(1120, 563);
            flDeThi.TabIndex = 3;
            flDeThi.WrapContents = false;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(50, 76);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(111, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "lblTieuDe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 4;
            label1.Text = "Tìm kiếm";
            label1.Click += label1_Click;
            // 
            // btnPrev
            // 
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.Location = new Point(904, 683);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(67, 36);
            btnPrev.TabIndex = 5;
            btnPrev.TabStop = false;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(1019, 683);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(67, 36);
            btnNext.TabIndex = 6;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lbPage
            // 
            lbPage.AutoSize = true;
            lbPage.Location = new Point(977, 689);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(27, 25);
            lbPage.TabIndex = 7;
            lbPage.Text = "lb";
            // 
            // UC_DeThiNhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
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
