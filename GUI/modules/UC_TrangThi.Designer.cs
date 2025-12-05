using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace GUI.modules
{
    partial class UC_TrangThi
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelCauHoi;
        private Label lblCauSo;
        private Label lblNoiDung;

        private Guna2Button btnTruoc;
        private Guna2Button btnTiep;

        private Guna2Panel panelInfo;
        private Label lblMaMon;
        private Label lblMon;
        private Label lblMSSV;
        private Label lblHoTen;
        private Label lblSoCau;
        private Label lblThoiGian;
        private Label lblNgayThi;

        private FlowLayoutPanel flowPanelSoCau;

        private Guna2Panel panelSubmitHolder;
        private Guna2Button btnNopBai;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            //================= MAIN CONTROL SIZE =================
            this.Size = new Size(1920, 1080);

            //================= PANEL CÂU HỎI =====================
            this.panelCauHoi = new Guna2Panel();
            this.panelCauHoi.Location = new Point(20, 20);
            this.panelCauHoi.Size = new Size(1400, 950);
            this.panelCauHoi.FillColor = Color.White;
            this.panelCauHoi.BorderColor = Color.Silver;
            this.panelCauHoi.BorderThickness = 1;
            this.panelCauHoi.ShadowDecoration.Enabled = true;
            this.panelCauHoi.ShadowDecoration.Depth = 8;

            //===== LABEL CÂU SỐ =====
            this.lblCauSo = new Label();
            this.lblCauSo.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            this.lblCauSo.Location = new Point(40, 30);
            this.lblCauSo.AutoSize = true;

            //===== LABEL NỘI DUNG =====
            this.lblNoiDung = new Label();
            this.lblNoiDung.Font = new Font("Segoe UI", 22F);
            this.lblNoiDung.Location = new Point(40, 120);
            this.lblNoiDung.Size = new Size(1320, 250);

            this.panelCauHoi.Controls.Add(this.lblCauSo);
            this.panelCauHoi.Controls.Add(this.lblNoiDung);

            //=============== NÚT TRƯỚC / TIẾP ==================
            int navBtnWidth = 200;
            int navBtnHeight = 60;
            int navMargin = 40;

            this.btnTruoc = CreateNavButton("◄ Câu trước");
            this.btnTruoc.Size = new Size(navBtnWidth, navBtnHeight);
            this.btnTruoc.Location = new Point(navMargin, panelCauHoi.Height - navBtnHeight - navMargin);

            this.btnTiep = CreateNavButton("Câu tiếp ►");
            this.btnTiep.Size = new Size(navBtnWidth, navBtnHeight);
            this.btnTiep.Location = new Point(panelCauHoi.Width - navBtnWidth - navMargin, panelCauHoi.Height - navBtnHeight - navMargin);

            this.panelCauHoi.Controls.Add(this.btnTruoc);
            this.panelCauHoi.Controls.Add(this.btnTiep);

            //================= PANEL INFO (PHẢI) =================
            this.panelInfo = new Guna2Panel();
            this.panelInfo.Location = new Point(1440, 20);
            this.panelInfo.Size = new Size(460, 950);
            this.panelInfo.FillColor = Color.White;
            this.panelInfo.BorderColor = Color.Silver;
            this.panelInfo.BorderThickness = 1;
            this.panelInfo.ShadowDecoration.Enabled = true;
            this.panelInfo.ShadowDecoration.Depth = 6;

            //===== THÔNG TIN LABELS =====
            this.lblMaMon = CreateInfoLabel(30);
            this.lblMon = CreateInfoLabel(80);
            this.lblMSSV = CreateInfoLabel(130);
            this.lblHoTen = CreateInfoLabel(180);
            this.lblSoCau = CreateInfoLabel(230);
            this.lblThoiGian = CreateInfoLabel(280);
            this.lblNgayThi = CreateInfoLabel(330);

            this.panelInfo.Controls.Add(this.lblMaMon);
            this.panelInfo.Controls.Add(this.lblMon);
            this.panelInfo.Controls.Add(this.lblMSSV);
            this.panelInfo.Controls.Add(this.lblHoTen);
            this.panelInfo.Controls.Add(this.lblSoCau);
            this.panelInfo.Controls.Add(this.lblThoiGian);
            this.panelInfo.Controls.Add(this.lblNgayThi);

            //================= FLOW SỐ CÂU =================
            this.flowPanelSoCau = new FlowLayoutPanel();
            this.flowPanelSoCau.Location = new Point(20, 400);
            this.flowPanelSoCau.Size = new Size(420, 400);
            this.flowPanelSoCau.AutoScroll = true;
            this.panelInfo.Controls.Add(this.flowPanelSoCau);

            //================= SUBMIT PANEL =================
            this.panelSubmitHolder = new Guna2Panel();
            this.panelSubmitHolder.Size = new Size(this.panelInfo.Width, 160);
            this.panelSubmitHolder.Location = new Point(0, this.panelInfo.Height - this.panelSubmitHolder.Height);

            this.btnNopBai = new Guna2Button();
            this.btnNopBai.Text = "NỘP BÀI";
            this.btnNopBai.FillColor = Color.FromArgb(255, 136, 0);
            this.btnNopBai.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnNopBai.BorderRadius = 14;

            int submitMargin = 60;
            this.btnNopBai.Location = new Point(submitMargin, submitMargin);
            this.btnNopBai.Size = new Size(this.panelSubmitHolder.Width - 2 * submitMargin, this.panelSubmitHolder.Height - 2 * submitMargin);

            this.panelSubmitHolder.Controls.Add(this.btnNopBai);
            this.panelInfo.Controls.Add(this.panelSubmitHolder);

            //================= ADD MAIN =================
            this.Controls.Add(this.panelCauHoi);
            this.Controls.Add(this.panelInfo);
        }

        //==================================================
        //                 HELPER FUNCTIONS
        //==================================================
        private Guna2Button CreateNavButton(string text)
        {
            var btn = new Guna2Button();
            btn.Text = text;
            btn.FillColor = Color.FromArgb(0, 122, 255);
            btn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.BorderRadius = 10;
            btn.HoverState.FillColor = Color.FromArgb(30, 104, 200);
            btn.PressedColor = Color.FromArgb(20, 82, 160);
            return btn;
        }

        private Label CreateInfoLabel(int top)
        {
            var lbl = new Label();
            lbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(50, 50, 50);
            lbl.Location = new Point(20, top);
            lbl.AutoSize = true;
            return lbl;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
