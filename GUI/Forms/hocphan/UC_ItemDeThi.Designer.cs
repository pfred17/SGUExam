namespace GUI.forms.hocphan
{
    partial class UC_ItemDeThi
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
            lbTenDe = new Label();
            lbNhom = new Label();
            lbThoiGian = new Label();
            btnXemChiTiet = new Button();
            btnSua = new Button();
            SuspendLayout();
            // 
            // lbTenDe
            // 
            lbTenDe.AutoSize = true;
            lbTenDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTenDe.Location = new Point(26, 12);
            lbTenDe.Margin = new Padding(2, 0, 2, 0);
            lbTenDe.Name = "lbTenDe";
            lbTenDe.Size = new Size(84, 25);
            lbTenDe.TabIndex = 0;
            lbTenDe.Text = "lbTenDe";
            // 
            // lbNhom
            // 
            lbNhom.AutoSize = true;
            lbNhom.Location = new Point(26, 43);
            lbNhom.Margin = new Padding(2, 0, 2, 0);
            lbNhom.Name = "lbNhom";
            lbNhom.Size = new Size(63, 20);
            lbNhom.TabIndex = 1;
            lbNhom.Text = "lbNhom";
            // 
            // lbThoiGian
            // 
            lbThoiGian.AutoSize = true;
            lbThoiGian.Location = new Point(26, 75);
            lbThoiGian.Margin = new Padding(2, 0, 2, 0);
            lbThoiGian.Name = "lbThoiGian";
            lbThoiGian.Size = new Size(81, 20);
            lbThoiGian.TabIndex = 2;
            lbThoiGian.Text = "lbThoiGian";
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.Aquamarine;
            btnXemChiTiet.FlatAppearance.BorderSize = 0;
            btnXemChiTiet.FlatStyle = FlatStyle.Flat;
            btnXemChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemChiTiet.Location = new Point(737, 36);
            btnXemChiTiet.Margin = new Padding(2);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(125, 34);
            btnXemChiTiet.TabIndex = 4;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LightSkyBlue;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(897, 36);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 34);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // UC_ItemDeThi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnSua);
            Controls.Add(btnXemChiTiet);
            Controls.Add(lbThoiGian);
            Controls.Add(lbNhom);
            Controls.Add(lbTenDe);
            Margin = new Padding(2);
            Name = "UC_ItemDeThi";
            Padding = new Padding(40, 0, 0, 0);
            Size = new Size(1050, 102);
            Load += UC_ItemDeThi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTenDe;
        private Label lbNhom;
        private Label lbThoiGian;
        private Button btnXemChiTiet;
        private Button btnSua;
    }
}
