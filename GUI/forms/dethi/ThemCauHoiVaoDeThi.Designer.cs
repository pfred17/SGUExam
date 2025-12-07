using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    partial class ThemCauHoiVaoDeThi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Left panel controls
        private Guna2Panel panelLeft;
        private Guna2TextBox txtSearch;
        private Guna2Button btnSearch;
        private Guna2ComboBox cbChuong;
        private Guna2ComboBox cbDoKho;
        private Label lblNoQuestion;
        private FlowLayoutPanel flpQuestions;
        private Guna2Panel panelPaging;
        private Guna2Button btnFirst, btnPrev, btnNext, btnLast;

        // Right panel controls
        private Guna2Panel panelRight;
        private Guna2ShadowPanel panelDeThiInfo;
        private Label lblSoLuongDe;
        private Label lblSoLuongTB;
        private Label lblSoLuongKho;
        private Guna2Button btnTaoDeThi;
        private Label lblTenDeThi;
        private Label lblThoiGian;
        private Label lblChuaCoCauHoi;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            // Khai báo các CustomizableEdges - Giữ nguyên
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelLeft = new Guna2Panel();
            txtSearch = new Guna2TextBox();
            btnSearch = new Guna2Button();
            cbChuong = new Guna2ComboBox();
            cbDoKho = new Guna2ComboBox();
            lblNoQuestion = new Label();
            flpQuestions = new FlowLayoutPanel();
            panelPaging = new Guna2Panel();
            btnFirst = new Guna2Button();
            btnPrev = new Guna2Button();
            btnNext = new Guna2Button();
            btnLast = new Guna2Button();
            panelRight = new Guna2Panel();
            panelDeThiInfo = new Guna2ShadowPanel();
            lblSoLuong = new Label();
            lblSoLuongDe = new Label();
            lblSoLuongTB = new Label();
            lblSoLuongKho = new Label();
            btnTaoDeThi = new Guna2Button();
            lblTenDeThi = new Label();
            lblThoiGian = new Label();
            lblChuaCoCauHoi = new Label();
            panelLeft.SuspendLayout();
            panelPaging.SuspendLayout();
            panelRight.SuspendLayout();
            panelDeThiInfo.SuspendLayout();
            SuspendLayout();

            // 
            // panelLeft (60% chiều rộng: 720px)
            // 
            panelLeft.Controls.Add(txtSearch);
            panelLeft.Controls.Add(btnSearch);
            panelLeft.Controls.Add(cbChuong);
            panelLeft.Controls.Add(cbDoKho);
            panelLeft.Controls.Add(lblNoQuestion);
            panelLeft.Controls.Add(flpQuestions);
            panelLeft.Controls.Add(panelPaging);
            panelLeft.CustomizableEdges = customizableEdges19;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.ShadowDecoration.CustomizableEdges = customizableEdges20;
            panelLeft.Size = new Size(720, 730); // 60% của 1200
            panelLeft.TabIndex = 0;

            // 
            // txtSearch
            // 
            txtSearch.CustomizableEdges = customizableEdges1;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(20, 15);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập từ khóa tìm kiếm...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearch.Size = new Size(610, 40); // Chiều rộng mới (720 - 20 - 60 - 30 = 610)
            txtSearch.TabIndex = 0;

            // 
            // btnSearch
            // 
            btnSearch.CustomizableEdges = customizableEdges3;
            btnSearch.FillColor = Color.FromArgb(0, 122, 255);
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(640, 15); // Vị trí mới
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSearch.Size = new Size(60, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍";

            // 
            // cbChuong
            // 
            cbChuong.BackColor = Color.Transparent;
            cbChuong.CustomizableEdges = customizableEdges5;
            cbChuong.DrawMode = DrawMode.OwnerDrawFixed;
            cbChuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuong.FocusedColor = Color.Empty;
            cbChuong.Font = new Font("Segoe UI", 10F);
            cbChuong.ForeColor = Color.FromArgb(68, 88, 112);
            cbChuong.ItemHeight = 30;
            cbChuong.Items.AddRange(new object[] { "Chọn chương", "Tất cả các chương" });
            cbChuong.Location = new Point(20, 70);
            cbChuong.Name = "cbChuong";
            cbChuong.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbChuong.Size = new Size(200, 36);
            cbChuong.TabIndex = 2;
            cbChuong.Text = "Chọn chương";

            // 
            // cbDoKho
            // 
            cbDoKho.BackColor = Color.Transparent;
            cbDoKho.CustomizableEdges = customizableEdges7;
            cbDoKho.DrawMode = DrawMode.OwnerDrawFixed;
            cbDoKho.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoKho.FocusedColor = Color.Empty;
            cbDoKho.Font = new Font("Segoe UI", 10F);
            cbDoKho.ForeColor = Color.FromArgb(68, 88, 112);
            cbDoKho.ItemHeight = 30;
            cbDoKho.Items.AddRange(new object[] { "Tất cả", "Dễ", "Trung bình", "Khó" });
            cbDoKho.Location = new Point(230, 70);
            cbDoKho.Name = "cbDoKho";
            cbDoKho.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbDoKho.Size = new Size(150, 36);
            cbDoKho.TabIndex = 3;
            cbDoKho.Text = "Độ khó";

            // 
            // lblNoQuestion
            // 
            lblNoQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNoQuestion.ForeColor = Color.Gray;
            lblNoQuestion.Location = new Point(20, 120);
            lblNoQuestion.Name = "lblNoQuestion";
            lblNoQuestion.Text = "Không có câu hỏi phù hợp.";
            lblNoQuestion.Visible = false;
            lblNoQuestion.Size = new Size(400, 25);
            lblNoQuestion.TabIndex = 4;

            // 
            // flpQuestions
            // 
            flpQuestions.AutoScroll = true;
            flpQuestions.FlowDirection = FlowDirection.TopDown;
            flpQuestions.WrapContents = false;
            flpQuestions.Location = new Point(10, 120);
            flpQuestions.Name = "flpQuestions";
            flpQuestions.Size = new Size(700, 550); // Chiều rộng mới
            flpQuestions.TabIndex = 5;
            // flpQuestions.Paint += flpQuestions_Paint; // Giữ nguyên

            // 
            // panelPaging - Căn giữa ở cuối panelLeft
            // 
            panelPaging.Controls.Add(btnFirst);
            panelPaging.Controls.Add(btnPrev);
            panelPaging.Controls.Add(btnNext);
            panelPaging.Controls.Add(btnLast);
            panelPaging.CustomizableEdges = customizableEdges17;
            panelPaging.Location = new Point(150, 680); // Vị trí căn giữa mới: (720 - 420) / 2 = 150
            panelPaging.Name = "panelPaging";
            panelPaging.ShadowDecoration.CustomizableEdges = customizableEdges18;
            panelPaging.Size = new Size(420, 40);
            panelPaging.TabIndex = 6;

            // 
            // btnFirst
            // 
            btnFirst.CustomizableEdges = customizableEdges9;
            btnFirst.Font = new Font("Segoe UI", 9F);
            btnFirst.ForeColor = Color.White;
            btnFirst.Location = new Point(-10, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnFirst.Size = new Size(50, 30);
            btnFirst.TabIndex = 0;
            btnFirst.Text = "<<";

            // 
            // btnPrev
            // 
            btnPrev.CustomizableEdges = customizableEdges11;
            btnPrev.Font = new Font("Segoe UI", 9F);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(50, 5);
            btnPrev.Name = "btnPrev";
            btnPrev.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnPrev.Size = new Size(40, 30);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<";

            // 
            // btnNext
            // 
            btnNext.CustomizableEdges = customizableEdges13;
            btnNext.Font = new Font("Segoe UI", 9F);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(330, 5);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnNext.Size = new Size(40, 30);
            btnNext.TabIndex = 2;
            btnNext.Text = ">";

            // 
            // btnLast
            // 
            btnLast.CustomizableEdges = customizableEdges15;
            btnLast.Font = new Font("Segoe UI", 9F);
            btnLast.ForeColor = Color.White;
            btnLast.Location = new Point(380, 5);
            btnLast.Name = "btnLast";
            btnLast.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnLast.Size = new Size(50, 30);
            btnLast.TabIndex = 3;
            btnLast.Text = ">>";

            // 
            // panelRight (40% chiều rộng: 480px)
            // 
            panelRight.Controls.Add(panelDeThiInfo);
            panelRight.CustomizableEdges = customizableEdges23;
            panelRight.Location = new Point(720, 0); // Bắt đầu từ 720px
            panelRight.Name = "panelRight";
            panelRight.ShadowDecoration.CustomizableEdges = customizableEdges24;
            panelRight.Size = new Size(460, 730); // 40% của 1200
            panelRight.TabIndex = 1;

            // 
            // panelDeThiInfo - Chiếm gần hết panelRight
            // 
            panelDeThiInfo.BackColor = Color.Transparent;
            panelDeThiInfo.Controls.Add(lblSoLuong);
            panelDeThiInfo.Controls.Add(lblSoLuongDe);
            panelDeThiInfo.Controls.Add(lblSoLuongTB);
            panelDeThiInfo.Controls.Add(lblSoLuongKho);
            panelDeThiInfo.Controls.Add(btnTaoDeThi);
            panelDeThiInfo.Controls.Add(lblTenDeThi);
            panelDeThiInfo.Controls.Add(lblThoiGian);
            panelDeThiInfo.Controls.Add(lblChuaCoCauHoi);
            panelDeThiInfo.FillColor = Color.White;
            panelDeThiInfo.Location = new Point(10, 10);
            panelDeThiInfo.Name = "panelDeThiInfo";
            panelDeThiInfo.ShadowColor = Color.Black;
            panelDeThiInfo.ShadowDepth = 50;
            panelDeThiInfo.Size = new Size(460, 710); // Kích thước mới
            panelDeThiInfo.TabIndex = 0;

            // 
            // lblSoLuong
            // 
            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSoLuong.Location = new Point(20, 20);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(100, 25);
            lblSoLuong.TabIndex = 0;

            // 
            // lblSoLuongDe (Dễ)
            // 
            lblSoLuongDe.Text = "DỄ 0/6";
            lblSoLuongDe.BackColor = Color.FromArgb(0, 122, 255);
            lblSoLuongDe.ForeColor = Color.White;
            lblSoLuongDe.TextAlign = ContentAlignment.MiddleCenter;
            lblSoLuongDe.Location = new Point(110, 20);
            lblSoLuongDe.Name = "lblSoLuongDe";
            lblSoLuongDe.Size = new Size(70, 25);
            lblSoLuongDe.TabIndex = 1;

            // 
            // lblSoLuongTB (Trung bình)
            // 
            lblSoLuongTB.Text = "TB 0/2";
            lblSoLuongTB.BackColor = Color.Orange;
            lblSoLuongTB.ForeColor = Color.White;
            lblSoLuongTB.TextAlign = ContentAlignment.MiddleCenter;
            lblSoLuongTB.Location = new Point(185, 20);
            lblSoLuongTB.Name = "lblSoLuongTB";
            lblSoLuongTB.Size = new Size(70, 25);
            lblSoLuongTB.TabIndex = 2;

            // 
            // lblSoLuongKho (Khó)
            // 
            lblSoLuongKho.Text = "KHÓ 0/2";
            lblSoLuongKho.BackColor = Color.Red;
            lblSoLuongKho.ForeColor = Color.White;
            lblSoLuongKho.TextAlign = ContentAlignment.MiddleCenter;
            lblSoLuongKho.Location = new Point(260, 20);
            lblSoLuongKho.Name = "lblSoLuongKho";
            lblSoLuongKho.Size = new Size(70, 25);
            lblSoLuongKho.TabIndex = 3;

            // 
            // lblTenDeThi
            // 
            lblTenDeThi.Text = "Test1";
            lblTenDeThi.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTenDeThi.Location = new Point(20, 70);
            lblTenDeThi.Name = "lblTenDeThi";
            lblTenDeThi.Size = new Size(200, 35);
            lblTenDeThi.TabIndex = 5;

            // 
            // lblThoiGian
            // 
            lblThoiGian.Text = "Thời gian: 45 phút";
            lblThoiGian.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblThoiGian.Location = new Point(20, 110);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(200, 20);
            lblThoiGian.TabIndex = 6;

            // 
            // lblChuaCoCauHoi - Hiển thị danh sách câu hỏi đã chọn
            // 
            lblChuaCoCauHoi.Text = _selectedQuestionIds.Count == 0
    ? "Chưa có câu hỏi nào được chọn"
    : $"Đã chọn {_selectedQuestionIds.Count} câu hỏi";
            lblChuaCoCauHoi.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblChuaCoCauHoi.ForeColor = Color.Gray;
            lblChuaCoCauHoi.Location = new Point(20, 150);
            lblChuaCoCauHoi.Size = new Size(420, 20);
            lblChuaCoCauHoi.TabIndex = 7;

            // 
            // btnTaoDeThi - Nút ở cuối panelRight
            // 
            btnTaoDeThi.CustomizableEdges = customizableEdges21;
            btnTaoDeThi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTaoDeThi.ForeColor = Color.White;
            btnTaoDeThi.FillColor = Color.FromArgb(40, 167, 69);
            btnTaoDeThi.Location = new Point(37, 650);
            btnTaoDeThi.Name = "btnTaoDeThi";
            btnTaoDeThi.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnTaoDeThi.Size = new Size(300, 45); // Chiều rộng mới
            btnTaoDeThi.TabIndex = 4;
            btnTaoDeThi.Text = "Tạo Đề Thi";


            // 
            // ThemCauHoiVaoDeThi (UserControl/Form chính)
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Name = "ThemCauHoiVaoDeThi";
            Size = new Size(1200, 730);
            panelLeft.ResumeLayout(false);
            panelPaging.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelDeThiInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblSoLuong;
    }
}
