using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;

namespace GUI.modules
{
    partial class UC_ChiTietKiemTra
    {
        private IContainer components = null;

        private TabControl tabControl;
        private TabPage tabBangDiem;
        private TabPage tabPhanTich;
        private TabPage tabThongKeCauHoi;

        // Tab Bảng điểm
        private Guna2ComboBox cbLocLop;
        private Guna2ComboBox cbLocTrangThai;
        private Guna2TextBox txtTimKiem;
        private Guna2Button btnXuatBangDiem;
        private Guna2Button  btnExportPDF;
        private Guna2DataGridView tableBangDiem;

        // Phân tích - additional controls (were missing declarations)
        private Guna2ComboBox cbLocNhomPhanTich;
        private FlowLayoutPanel flowThongKeCard;
        private Chart chartDiemThi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new Container();

            // Suspend layout for performance while creating controls
            this.SuspendLayout();

            // TabControl and TabPages
            tabControl = new TabControl();
            tabBangDiem = new TabPage("Bảng điểm");
            tabPhanTich = new TabPage("Phân tích kết quả thi");
            tabThongKeCauHoi = new TabPage("Thống kê từng câu hỏi");

            // Tab Bảng điểm controls
            cbLocLop = new Guna2ComboBox();
            cbLocTrangThai = new Guna2ComboBox();
            txtTimKiem = new Guna2TextBox();
            btnXuatBangDiem = new Guna2Button();
            btnExportPDF = new Guna2Button();
            tableBangDiem = new Guna2DataGridView();

            // Phân tích controls (declare before use)
            cbLocNhomPhanTich = new Guna2ComboBox();
            flowThongKeCard = new FlowLayoutPanel();
            chartDiemThi = new Chart();

            // BeginInit for ISupportInitialize controls
            ((ISupportInitialize)(tableBangDiem)).BeginInit();
            ((ISupportInitialize)(chartDiemThi)).BeginInit();

            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.TabPages.Add(tabBangDiem);
            tabControl.TabPages.Add(tabPhanTich);
            tabControl.TabPages.Add(tabThongKeCauHoi);

            // 
            // tabBangDiem
            // 
            tabBangDiem.BackColor = Color.White;
            tabBangDiem.Padding = new Padding(8);
            tabBangDiem.Controls.Add(cbLocLop);
            tabBangDiem.Controls.Add(cbLocTrangThai);
            tabBangDiem.Controls.Add(txtTimKiem);
            tabBangDiem.Controls.Add(btnXuatBangDiem);
            tabBangDiem.Controls.Add(tableBangDiem);
            tabBangDiem.Controls.Add(btnExportPDF);

            // 
            // cbLocLop
            // 
            cbLocLop.BackColor = Color.Transparent;
            cbLocLop.BorderRadius = 2;
            cbLocLop.Cursor = Cursors.Hand;
            cbLocLop.DrawMode = DrawMode.OwnerDrawFixed;
            cbLocLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocLop.FocusedColor = Color.FromArgb(94, 148, 255);
            cbLocLop.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbLocLop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbLocLop.ForeColor = Color.FromArgb(68, 88, 112);
            cbLocLop.ItemHeight = 30;
            cbLocLop.Items.AddRange(new object[] { "Tất cả" });
            cbLocLop.Location = new Point(30, 30);
            cbLocLop.Name = "cbLocLop";
            cbLocLop.Size = new Size(130, 36);
            cbLocLop.StartIndex = 0;

            // 
            // cbLocTrangThai
            // 
            cbLocTrangThai.BackColor = Color.Transparent;
            cbLocTrangThai.BorderRadius = 2;
            cbLocTrangThai.Cursor = Cursors.Hand;
            cbLocTrangThai.DrawMode = DrawMode.OwnerDrawFixed;
            cbLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocTrangThai.FocusedColor = Color.FromArgb(94, 148, 255);
            cbLocTrangThai.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbLocTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbLocTrangThai.ForeColor = Color.FromArgb(68, 88, 112);
            cbLocTrangThai.ItemHeight = 30;
            cbLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đã nộp bài", "Chưa nộp bài" });
            cbLocTrangThai.Location = new Point(180, 30);
            cbLocTrangThai.Name = "cbLocTrangThai";
            cbLocTrangThai.Size = new Size(150, 36);
            cbLocTrangThai.StartIndex = 0;
            cbLocTrangThai.SelectedIndexChanged += cbLocTrangThai_SelectedIndexChanged;

            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 2;
            txtTimKiem.DefaultText = "";
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Location = new Point(350, 30);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm kiếm sinh viên...";
            txtTimKiem.Size = new Size(300, 36);

            // 
            // btnXuatBangDiem
            // 
            btnXuatBangDiem.BorderRadius = 2;
            btnXuatBangDiem.Cursor = Cursors.Hand;
            btnXuatBangDiem.FillColor = Color.FromArgb(6, 101, 208);
            btnXuatBangDiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatBangDiem.ForeColor = Color.White;
            btnXuatBangDiem.Location = new Point(900, 30);
            btnXuatBangDiem.Name = "btnXuatBangDiem";
            btnXuatBangDiem.Size = new Size(200, 40);
            btnXuatBangDiem.Text = "📄 Xuất bảng điểm";
            btnXuatBangDiem.Click += btnXuatBangDiem_Click;


            //btnExportPDF
            btnExportPDF.BorderRadius = 2;
            btnExportPDF.Cursor = Cursors.Hand;
            btnExportPDF.FillColor = Color.FromArgb(255, 0, 0);
            btnExportPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(690, 30);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(200, 40);
            btnExportPDF.Text = "📄 Xuất PDF";
            btnExportPDF.Click += btnExportPDF_Click;


            // =======================
            // CẤU HÌNH BẢNG
            // =======================
            // Basic
            tableBangDiem.AllowUserToAddRows = false;
            tableBangDiem.AllowUserToDeleteRows = false;
            tableBangDiem.AllowUserToResizeRows = false;
            tableBangDiem.ReadOnly = true;
            tableBangDiem.RowHeadersVisible = false;
            tableBangDiem.RowHeadersWidth = 4;
            // In your designer or initialization code

            var panelBangDiem = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 100, 0, 0), // 100px top space
                BackColor = Color.Transparent // or match your background
            };

            // Add tableBangDiem to this panel
            panelBangDiem.Controls.Add(tableBangDiem);
            tableBangDiem.Dock = DockStyle.Fill;

            // Add the panel to your tab/page/container
            tabBangDiem.Controls.Add(panelBangDiem);


            // Appearance
            tableBangDiem.BackgroundColor = Color.White;
            tableBangDiem.BorderStyle = BorderStyle.None;
            tableBangDiem.GridColor = Color.FromArgb(231, 229, 255);
            tableBangDiem.RowTemplate.Height = 45;
            tableBangDiem.EnableHeadersVisualStyles = false;

            // Header style
            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(242, 245, 250),
                ForeColor = Color.FromArgb(80, 80, 80),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                WrapMode = DataGridViewTriState.True,
                SelectionBackColor = Color.FromArgb(242, 245, 250),
                SelectionForeColor = Color.FromArgb(80, 80, 80)
            };
            tableBangDiem.ColumnHeadersDefaultCellStyle = headerStyle;
            tableBangDiem.ColumnHeadersHeight = 48;
            tableBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row style
            var rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(50, 50, 50),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(116, 185, 255),
                SelectionForeColor = Color.White,
                Padding = new Padding(6, 0, 6, 0)
            };
            tableBangDiem.DefaultCellStyle = rowStyle;
            tableBangDiem.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(250, 250, 250) };

            // Force vertical scrollbar only (prevent horizontal scroll)
            tableBangDiem.ScrollBars = ScrollBars.Vertical;

            // Columns: clear then add with AutoSizeMode=Fill and FillWeight (ratio)
            tableBangDiem.Columns.Clear();

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "MSSV",
                Name = "colMSSV",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12 // relative
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Họ và tên",
                Name = "colHoTen",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Điểm",
                Name = "colDiem",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 8
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Thời gian vào thi",
                Name = "colThoiGianVaoThi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 18
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Thời gian nộp bài",
                Name = "colThoiGianNopBai",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 18
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Thời gian thi (phút)",
                Name = "colThoiGianThi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12
            });

            tableBangDiem.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Trạng thái",
                Name = "colTrangThai",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });
            tableBangDiem.CellDoubleClick += tableBangDiem_CellDoubleClick;
            // Final refresh
            tableBangDiem.Refresh();

            // ------------------------------
            // Phân tích tab controls setup
            // ------------------------------

            // 
            // cbLocNhomPhanTich
            // 
            cbLocNhomPhanTich.BackColor = Color.Transparent;
            cbLocNhomPhanTich.BorderRadius = 2;
            cbLocNhomPhanTich.Cursor = Cursors.Hand;
            cbLocNhomPhanTich.DrawMode = DrawMode.OwnerDrawFixed;
            cbLocNhomPhanTich.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocNhomPhanTich.FocusedColor = Color.FromArgb(94, 148, 255);
            cbLocNhomPhanTich.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbLocNhomPhanTich.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbLocNhomPhanTich.ForeColor = Color.FromArgb(68, 88, 112);
            cbLocNhomPhanTich.ItemHeight = 30;
            cbLocNhomPhanTich.Items.AddRange(new object[] { "Tất cả" });
            cbLocNhomPhanTich.Location = new Point(30, 30);
            cbLocNhomPhanTich.Name = "cbLocNhomPhanTich";
            cbLocNhomPhanTich.Size = new Size(130, 36);
            cbLocNhomPhanTich.StartIndex = 0;

            // 
            // flowThongKeCard
            // 
            flowThongKeCard.Location = new Point(30, 80);
            flowThongKeCard.Size = new Size(1062, 250);
            flowThongKeCard.AutoScroll = false;
            flowThongKeCard.WrapContents = true;
            flowThongKeCard.BackColor = Color.Transparent;

            // Chart initialization (your code)
            chartDiemThi.Location = new Point(30, 320);
            chartDiemThi.Size = new Size(1062, 320);
            chartDiemThi.BackColor = Color.White;

            var chartArea = new ChartArea("ChartArea1");
            chartDiemThi.ChartAreas.Add(chartArea);

            var legend = new Legend("Legend1");
            chartDiemThi.Legends.Add(legend);

            var series = new Series("Số lượng sinh viên")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.FromArgb(33, 150, 243)
            };
            chartDiemThi.Series.Add(series);

            var area = chartDiemThi.ChartAreas[0];

            area.AxisX.Title = "Mốc điểm";
            area.AxisY.Title = "Số lượng sinh viên";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            area.AxisX.LabelStyle.IsStaggered = false;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.IsMarginVisible = true;

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 10.5;
            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;





            // Add controls to tabPhanTich
            tabPhanTich.BackColor = Color.White;
            tabPhanTich.AutoScroll = true;
            tabPhanTich.Controls.Add(cbLocNhomPhanTich);
            tabPhanTich.Controls.Add(flowThongKeCard);
            tabPhanTich.Controls.Add(chartDiemThi);

            // In UC_ChiTietKiemTra.Designer.cs, inside InitializeComponent (after tabThongKeCauHoi.BackColor = Color.White;)
            var flowThongKeCauHoi = new FlowLayoutPanel
            {
                Name = "flowThongKeCauHoi",
                Location = new Point(30, 60),
                Size = new Size(1062, 640),
                AutoScroll = true,
                BackColor = Color.Transparent,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };
            tabThongKeCauHoi.Controls.Add(flowThongKeCauHoi);
            tabControl.SelectedIndexChanged += (s, e) =>
            {
                if (tabControl.SelectedTab == tabThongKeCauHoi)
                    LoadThongKeCauHoi();
            };

            // Add a label for the title
            var lblTitle = new Label
            {
                Text = "Thống kê chi tiết theo câu hỏi",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(30, 20),
                AutoSize = true
            };
            tabThongKeCauHoi.Controls.Add(lblTitle);


            // 
            // UC_ChiTietKiemTra (this control)
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.Controls.Add(this.tabControl);
            this.Name = "UC_ChiTietKiemTra";
            this.Size = new Size(1122, 726);

            // EndInit calls
            ((ISupportInitialize)(tableBangDiem)).EndInit();
            ((ISupportInitialize)(chartDiemThi)).EndInit();

            // Resume layout
            this.ResumeLayout(false);
        }

        #endregion
    }
}
