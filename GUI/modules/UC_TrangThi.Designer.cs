namespace GUI.modules
{
    partial class UC_TrangThi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelCauHoi = new System.Windows.Forms.Panel();
            this.lblCauSo = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();

            this.radioDapAn = new System.Collections.Generic.List<RadioButton>();
            for (int i = 0; i < 4; i++)
            {
                var r = new RadioButton
                {
                    Font = new System.Drawing.Font("Segoe UI", 16),
                    Location = new System.Drawing.Point(40, 160 + i * 60),
                    AutoSize = true
                };
                this.radioDapAn.Add(r);
            }

            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnTiep = new System.Windows.Forms.Button();

            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSoCau = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblNgayThi = new System.Windows.Forms.Label();
            this.btnNopBai = new System.Windows.Forms.Button();


            // ===== PANEL CÂU HỎI =====
            this.panelCauHoi.Location = new System.Drawing.Point(20, 20);
            this.panelCauHoi.Size = new System.Drawing.Size(820, 660);
            this.panelCauHoi.BackColor = System.Drawing.Color.White;
            this.panelCauHoi.BorderStyle = BorderStyle.FixedSingle;

            this.lblCauSo.Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold);
            this.lblCauSo.Location = new System.Drawing.Point(20, 10);
            this.lblCauSo.AutoSize = true;

            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            this.lblNoiDung.Location = new System.Drawing.Point(20, 60);
            this.lblNoiDung.Size = new System.Drawing.Size(780, 80);

            this.panelCauHoi.Controls.Add(this.lblCauSo);
            this.panelCauHoi.Controls.Add(this.lblNoiDung);

            foreach (var r in this.radioDapAn)
                this.panelCauHoi.Controls.Add(r);

            this.btnTruoc.Text = "◄ Câu trước";
            this.btnTruoc.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.btnTruoc.Size = new System.Drawing.Size(180, 55);
            this.btnTruoc.Location = new System.Drawing.Point(20, 580);

            this.btnTiep.Text = "Câu tiếp ►";
            this.btnTiep.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.btnTiep.Size = new System.Drawing.Size(180, 55);
            this.btnTiep.Location = new System.Drawing.Point(620, 580);

            this.panelCauHoi.Controls.Add(this.btnTruoc);
            this.panelCauHoi.Controls.Add(this.btnTiep);


            // ===== PANEL THÔNG TIN =====
            this.panelInfo.Location = new System.Drawing.Point(860, 20);
            this.panelInfo.Size = new System.Drawing.Size(400, 660);
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(74, 144, 226);
            this.panelInfo.BorderStyle = BorderStyle.FixedSingle;

            AddInfoLabel(this.lblMaMon, 20);
            AddInfoLabel(this.lblMon, 60);
            AddInfoLabel(this.lblMSSV, 100);
            AddInfoLabel(this.lblHoTen, 140);
            AddInfoLabel(this.lblSoCau, 180);
            AddInfoLabel(this.lblThoiGian, 220);
            AddInfoLabel(this.lblNgayThi, 260);

            int panelWidth = this.panelInfo.Width;

            // Chiều rộng nút
            int buttonWidth = 200;
            int buttonHeight = 50;

            // Đặt nút nằm chính giữa phía dưới, cách mép dưới 20px
            this.btnNopBai.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnNopBai.Location = new System.Drawing.Point(
                (panelWidth - buttonWidth) / 2,      // Chính giữa theo chiều ngang
                this.panelInfo.Height - buttonHeight - 20 // Cách mép dưới 20px
            );

            // Thiết lập font, màu
            this.btnNopBai.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.btnNopBai.BackColor = System.Drawing.Color.Red;
            this.btnNopBai.ForeColor = System.Drawing.Color.White;

            this.panelInfo.Controls.Add(this.btnNopBai);


            // ===== MAIN CONTROL =====
            this.Controls.Add(this.panelCauHoi);
            this.Controls.Add(this.panelInfo);
            this.Size = new System.Drawing.Size(1500, 800);
        }

        private void AddInfoLabel(Label lbl, int top)
        {
            lbl.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            lbl.Location = new System.Drawing.Point(20, top);
            lbl.ForeColor = System.Drawing.Color.White;
            lbl.AutoSize = true;
            this.panelInfo.Controls.Add(lbl);
        }

        #endregion

        private System.Windows.Forms.Panel panelCauHoi;
        private System.Windows.Forms.Label lblCauSo;
        private System.Windows.Forms.Label lblNoiDung;
        private List<RadioButton> radioDapAn;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnTiep;

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSoCau;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblNgayThi;
        private System.Windows.Forms.Button btnNopBai;
    }
}