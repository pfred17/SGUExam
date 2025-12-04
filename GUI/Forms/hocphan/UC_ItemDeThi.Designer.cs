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
            btnXoa = new Button();
            btnXemChiTiet = new Button();
            btnSua = new Button();
            SuspendLayout();
            // 
            // lbTenDe
            // 
            lbTenDe.AutoSize = true;
            lbTenDe.Location = new Point(33, 15);
            lbTenDe.Name = "lbTenDe";
            lbTenDe.Size = new Size(75, 25);
            lbTenDe.TabIndex = 0;
            lbTenDe.Text = "lbTenDe";
            // 
            // lbNhom
            // 
            lbNhom.AutoSize = true;
            lbNhom.Location = new Point(33, 54);
            lbNhom.Name = "lbNhom";
            lbNhom.Size = new Size(77, 25);
            lbNhom.TabIndex = 1;
            lbNhom.Text = "lbNhom";
            // 
            // lbThoiGian
            // 
            lbThoiGian.AutoSize = true;
            lbThoiGian.Location = new Point(33, 94);
            lbThoiGian.Name = "lbThoiGian";
            lbThoiGian.Size = new Size(96, 25);
            lbThoiGian.TabIndex = 2;
            lbThoiGian.Text = "lbThoiGian";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.HotPink;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(859, 43);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(118, 43);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.Aquamarine;
            btnXemChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemChiTiet.Location = new Point(581, 43);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(128, 43);
            btnXemChiTiet.TabIndex = 4;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LightSkyBlue;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(725, 43);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(118, 43);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // UC_ItemDeThi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnSua);
            Controls.Add(btnXemChiTiet);
            Controls.Add(btnXoa);
            Controls.Add(lbThoiGian);
            Controls.Add(lbNhom);
            Controls.Add(lbTenDe);
            Name = "UC_ItemDeThi";
            Padding = new Padding(50, 0, 0, 0);
            Size = new Size(1015, 128);
            Load += UC_ItemDeThi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTenDe;
        private Label lbNhom;
        private Label lbThoiGian;
        private Button btnXoa;
        private Button btnXemChiTiet;
        private Button btnSua;
    }
}
