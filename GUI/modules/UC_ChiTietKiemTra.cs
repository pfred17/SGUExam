using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = System.Drawing.Font;
using iTextFont = iTextSharp.text.Font;

using BLL;

namespace GUI.modules
{
    public partial class UC_ChiTietKiemTra : UserControl
    {
        private readonly long _maDe;
        private readonly DeThiBLL _deThiBLL = new DeThiBLL();
        private readonly DeThiCauHinhBLL _deThiCauHinhBLL = new DeThiCauHinhBLL();

        public UC_ChiTietKiemTra(long maDe)
        {
            InitializeComponent();

            _maDe = maDe;

            // Khởi tạo chart ở runtime (KHÔNG ở Designer)
            InitChart();

            // Load dữ liệu
            LoadBangDiem();
            LoadPhanTichKetQua();
            LoadThongKeCauHoi();
        }

        /// <summary>
        /// Khởi tạo Chart (chạy lúc runtime để tránh Designer override)
        /// </summary>
        private void InitChart()
        {
            // Clear trước để an toàn nếu Designer có bất kỳ cấu hình nào
            chartDiemThi.Series.Clear();
            chartDiemThi.ChartAreas.Clear();
            chartDiemThi.Legends.Clear();
            chartDiemThi.Titles.Clear();

            // ChartArea
            var chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "Mốc điểm";
            chartArea.AxisY.Title = "Số lượng sinh viên";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartArea.AxisX.LabelStyle.IsStaggered = false;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.IsMarginVisible = true;
            // Không đặt min/max ở đây cứng nếu bạn muốn Chart tự động scale.
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chartDiemThi.ChartAreas.Add(chartArea);

            // Legend (nếu cần)
            var legend = new Legend("Legend1");
            chartDiemThi.Legends.Add(legend);

            // Series
            var series = new Series("Số lượng sinh viên")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                // Color property sometimes yêu cầu set ở point level; nhưng set ở đây thường ổn
                Color = Color.FromArgb(33, 150, 243)
            };
            chartDiemThi.Series.Add(series);

            // Title
            chartDiemThi.Titles.Add("Thống kê điểm thi");
        }

        private void LoadBangDiem()
        {
            var bangDiem = _deThiBLL.GetAllBangDiemByDeThi(_maDe);

            tableBangDiem.Rows.Clear();
            foreach (var item in bangDiem)
            {
                int rowIdx = tableBangDiem.Rows.Add(
                    item.MSSV ?? "",
                    item.HoTen ?? "",
                    item.Diem.HasValue ? item.Diem.Value.ToString() : "",
                    item.ThoiGianVaoThi.HasValue ? item.ThoiGianVaoThi.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    item.ThoiGianNopBai.HasValue ? item.ThoiGianNopBai.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    item.ThoiGianThi.HasValue ? item.ThoiGianThi.Value.ToString() : "",
                    item.ThoiGianNopBai.HasValue ? "Đã nộp" : "Chưa nộp"
                );
                // Style cho trạng thái
                var cell = tableBangDiem.Rows[rowIdx].Cells["colTrangThai"];
                if (item.ThoiGianNopBai.HasValue)
                {
                    cell.Style.ForeColor = Color.FromArgb(0, 153, 0);
                }
                else
                {
                    cell.Style.ForeColor = Color.Red;
                }
                cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void cbLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bangDiem = _deThiBLL.GetAllBangDiemByDeThi(_maDe);

            string selected = cbLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            if (selected == "Đã nộp bài")
                bangDiem = bangDiem.Where(x => x.ThoiGianNopBai.HasValue).ToList();
            else if (selected == "Chưa nộp bài")
                bangDiem = bangDiem.Where(x => !x.ThoiGianNopBai.HasValue).ToList();

            tableBangDiem.Rows.Clear();
            foreach (var item in bangDiem)
            {
                int rowIdx = tableBangDiem.Rows.Add(
                    item.MSSV ?? "",
                    item.HoTen ?? "",
                    item.Diem.HasValue ? item.Diem.Value.ToString() : "",
                    item.ThoiGianVaoThi.HasValue ? item.ThoiGianVaoThi.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    item.ThoiGianNopBai.HasValue ? item.ThoiGianNopBai.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    item.ThoiGianThi.HasValue ? item.ThoiGianThi.Value.ToString() : "",
                    item.ThoiGianNopBai.HasValue ? "Đã nộp" : "Chưa nộp"
                );
                var cell = tableBangDiem.Rows[rowIdx].Cells["colTrangThai"];
                cell.Style.ForeColor = item.ThoiGianNopBai.HasValue ? Color.FromArgb(0, 153, 0) : Color.Red;
                cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void btnXuatBangDiem_Click(object sender, EventArgs e)
        {
            var bangDiem = _deThiBLL.GetAllBangDiemByDeThi(_maDe);
            if (bangDiem == null || bangDiem.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"BangDiem_{_maDe}_{DateTime.Now:yyyyMMdd}.xlsx",
                Title = "Lưu file Excel",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;
            string path = sfd.FileName;

            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("BangDiem");

                // Header
                ws.Cell(1, 1).Value = "STT";
                ws.Cell(1, 2).Value = "MSSV";
                ws.Cell(1, 3).Value = "Họ tên";
                ws.Cell(1, 4).Value = "Điểm";
                ws.Cell(1, 5).Value = "Thời gian vào thi";
                ws.Cell(1, 6).Value = "Thời gian nộp bài";
                ws.Cell(1, 7).Value = "Thời gian thi (phút)";
                ws.Cell(1, 8).Value = "Trạng thái";
                ws.Range(1, 1, 1, 8).Style.Font.SetBold();

                int r = 2;
                int stt = 1;
                foreach (var item in bangDiem)
                {
                    ws.Cell(r, 1).Value = stt++;
                    ws.Cell(r, 2).Value = item.MSSV ?? "";
                    ws.Cell(r, 3).Value = item.HoTen ?? "";
                    ws.Cell(r, 4).Value = item.Diem.HasValue ? item.Diem.Value.ToString() : "";
                    ws.Cell(r, 5).Value = item.ThoiGianVaoThi.HasValue ? item.ThoiGianVaoThi.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    ws.Cell(r, 6).Value = item.ThoiGianNopBai.HasValue ? item.ThoiGianNopBai.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    ws.Cell(r, 7).Value = item.ThoiGianThi.HasValue ? item.ThoiGianThi.Value.ToString() : "";
                    ws.Cell(r, 8).Value = item.ThoiGianNopBai.HasValue ? "Đã nộp" : "Chưa nộp";
                    r++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(path);
            }

            try
            {
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{path}\"");
                Clipboard.SetText(path);
            }
            catch
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
                catch { }
            }

            MessageBox.Show($"Xuất thành công.\nFile đã lưu: {path}\nĐường dẫn đã được copy vào clipboard.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            var bangDiem = _deThiBLL.GetAllBangDiemByDeThi(_maDe);
            if (bangDiem == null || bangDiem.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "PDF File (*.pdf)|*.pdf",
                FileName = $"BangDiem_{_maDe}_{DateTime.Now:yyyyMMdd}.pdf",
                Title = "Lưu file PDF",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;
            string path = sfd.FileName;

            try
            {
                var pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.Create));
                pdfDoc.Open();

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                var fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                var fontHeader = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                var fontData = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                var title = new Paragraph("BẢNG ĐIỂM CHI TIẾT", fontTitle);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                pdfDoc.Add(title);

                var table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 7f, 15f, 25f, 8f, 15f, 15f, 10f, 12f });

                string[] headers = { "STT", "MSSV", "Họ tên", "Điểm", "Vào thi", "Nộp bài", "TG Thi", "Trạng thái" };
                foreach (var header in headers)
                {
                    var cell = new PdfPCell(new Phrase(header, fontHeader));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.Padding = 5;
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                int stt = 1;
                foreach (var item in bangDiem)
                {
                    table.AddCell(new PdfPCell(new Phrase(stt++.ToString(), fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.MSSV ?? "", fontData)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.HoTen ?? "", fontData)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.Diem.HasValue ? item.Diem.Value.ToString() : "", fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.ThoiGianVaoThi.HasValue ? item.ThoiGianVaoThi.Value.ToString("dd/MM/yyyy HH:mm") : "", fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.ThoiGianNopBai.HasValue ? item.ThoiGianNopBai.Value.ToString("dd/MM/yyyy HH:mm") : "", fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.ThoiGianThi.HasValue ? item.ThoiGianThi.Value.ToString() : "", fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(item.ThoiGianNopBai.HasValue ? "Đã nộp" : "Chưa nộp", fontData)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                }

                pdfDoc.Add(table);
                pdfDoc.Close();

                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{path}\"");
                    Clipboard.SetText(path);
                }
                catch { }

                MessageBox.Show($"Xuất thành công.\nFile đã lưu: {path}", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tableBangDiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header or invalid row
            if (e.RowIndex < 0) return;

            // Get MSSV from the selected row
            var row = tableBangDiem.Rows[e.RowIndex];
            var mssv = row.Cells["colMSSV"].Value?.ToString();
            if (string.IsNullOrEmpty(mssv)) return;

            // Get DeThi info (you already have _maDe)
            long maDe = _maDe;

            // Get user info (from your BLL or DTO)
            var userBLL = new UserBLL();
            var user = userBLL.GetUserByMSSV(mssv);
            if (user == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get exam result data
            var deThiBLL = new DeThiBLL();
            var ketQua = deThiBLL.GetKetQuaBaiThi(maDe, mssv); // Ensure this exists

            if (ketQua == null)
            {
                MessageBox.Show("Sinh viên chưa có kết quả bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dethiCauHinh = new DeThiCauHinhBLL();
            var cauHinh = dethiCauHinh.GetByMaDe(maDe);

            // Open KetQuaBaiThi form
            var form = new GUI.forms.dethi.KetQuaBaiThi(
                ketQua.DsCauHoi, ketQua.SoCauDung, ketQua.Diem, user, cauHinh
            );
            form.ShowDialog();
        }

        private void LoadPhanTichKetQua()
        {
            var bangDiem = _deThiBLL.GetBangDiemByDeThi(_maDe);

            int daNop = bangDiem.Count;
            int chuaNop = 0;
            int khongThi = 0;

            decimal diemTB = bangDiem.Any(x => x.Diem.HasValue)
                ? (decimal)bangDiem.Where(x => x.Diem.HasValue).Average(x => x.Diem.Value)
                : 0;

            int diemNhoHon1 = bangDiem.Count(x => x.Diem.HasValue && x.Diem.Value <= 1);
            int diemNhoHon5 = bangDiem.Count(x => x.Diem.HasValue && x.Diem.Value <= 5);
            int diemLonHon5 = bangDiem.Count(x => x.Diem.HasValue && x.Diem.Value >= 5);

            decimal diemCaoNhat = bangDiem.Any(x => x.Diem.HasValue)
                ? bangDiem.Where(x => x.Diem.HasValue).Max(x => x.Diem.Value)
                : 0;

            // XÓA CARD CŨ
            flowThongKeCard.Controls.Clear();

            // THÊM CARD
            flowThongKeCard.Controls.Add(CreateThongKeCard(daNop.ToString(), "Thí sinh đã nộp", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(chuaNop.ToString(), "Thí sinh chưa nộp", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(khongThi.ToString(), "Thí sinh không thi", "👤"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemTB.ToString("0.##"), "Điểm trung bình", "🌐"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemNhoHon1.ToString(), "Điểm <= 1", "🗑"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemNhoHon5.ToString(), "Điểm <= 5", "👎"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemLonHon5.ToString(), "Điểm >= 5", "🏅"));
            flowThongKeCard.Controls.Add(CreateThongKeCard(diemCaoNhat.ToString("0.##"), "Điểm cao nhất", "👥"));

            // ---------------------------
            // 1) TÍNH BUCKET 1 → 10
            // ---------------------------

            var diemBuckets = new int[10]; // index 0 = ≤1, index 9 = ≤10

            foreach (var item in bangDiem)
            {
                if (item.Diem.HasValue)
                {
                    int bucket = (int)Math.Ceiling(item.Diem.Value);
                    if (bucket < 1) bucket = 1;
                    if (bucket > 10) bucket = 10;

                    diemBuckets[bucket - 1]++;
                }
            }

            Debug.WriteLine("diemBuckets: " + string.Join(", ", diemBuckets));

            // ---------------------------
            // 2) LẤY / TẠO SERIES
            // ---------------------------
            Series series;

            if (chartDiemThi.Series.IndexOf("Số lượng sinh viên") >= 0)
            {
                series = chartDiemThi.Series["Số lượng sinh viên"];
            }
            else
            {
                series = new Series("Số lượng sinh viên")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Color = Color.FromArgb(33, 150, 243)
                };
                chartDiemThi.Series.Add(series);
            }

            // ---------------------------
            // 3) VẼ DỮ LIỆU
            // ---------------------------
            series.Points.Clear();
            for (int i = 1; i <= 10; i++)
            {
                series.Points.AddXY(i, diemBuckets[i - 1]);
                series.Points[i - 1].Label = diemBuckets[i - 1].ToString();
            }

            // ---------------------------
            // 4) TRỤC X: CUSTOM LABELS "≤ i"
            // ---------------------------
            var area = chartDiemThi.ChartAreas[0];

            area.AxisX.CustomLabels.Clear();
            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 10.5;
            area.AxisY.Minimum = 0;

            for (int i = 1; i <= 10; i++)
            {
                area.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, $"≤ {i}");
            }

            area.RecalculateAxesScale();
        }


        // Tạo card thống kê
        private Panel CreateThongKeCard(string value, string label, string icon)
        {
            var card = new Panel
            {
                Width = 250,
                Height = 100,
                BackColor = Color.White,
                Margin = new Padding(15, 15, 0, 0),
                BorderStyle = BorderStyle.None
            };
            card.Padding = new Padding(20, 15, 20, 15);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Location = new Point(10, 50),
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 100, 100)
            });
            card.Controls.Add(new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 24, FontStyle.Regular),
                Location = new Point(180, 25),
                AutoSize = true,
                ForeColor = Color.FromArgb(33, 150, 243)
            });
            return card;
        }
       

        private void LoadThongKeCauHoi()
        {
            var flowThongKeCauHoi = tabThongKeCauHoi.Controls["flowThongKeCauHoi"] as FlowLayoutPanel;
            if (flowThongKeCauHoi == null) return;

            flowThongKeCauHoi.Controls.Clear();

            var thongKeList = new DeThiBLL().GetThongKeCauHoi(_maDe); // _maDe: current test id

            foreach (var cauHoi in thongKeList)
            {
                var panel = new Panel
                {
                    Width = flowThongKeCauHoi.Width - 40,
                    Height = 280,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(16),
                    Margin = new Padding(0, 0, 0, 18)
                };

                var lblCauHoi = new Label
                {
                    Text = $"Câu {cauHoi.Index}: {cauHoi.NoiDung}",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(8, 8)
                };
                panel.Controls.Add(lblCauHoi);

                int y = lblCauHoi.Bottom + 10;
                for (int i = 0; i < cauHoi.DapAns.Count; i++)
                {
                    var da = cauHoi.DapAns[i];
                    var lblDapAn = new Label
                    {
                        Text = $"{(char)('A' + i)}. {da.NoiDung} ({da.TiLeChon:P2})",
                        Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                        ForeColor = Color.FromArgb(80, 80, 80),
                        AutoSize = true,
                        Location = new Point(16, y)
                    };
                    panel.Controls.Add(lblDapAn);

                    y += lblDapAn.Height + 2;

                    var bar = new ProgressBar
                    {
                        Value = Math.Min(100, Math.Max(0, (int)(da.TiLeChon * 100))),
                        Maximum = 100,
                        Width = panel.Width - 40,
                        Height = 14,
                        Location = new Point(16, y),
                        // ForeColor không ảnh hưởng nhiều tới ProgressBar mặc định, để nguyên
                        BackColor = Color.FromArgb(230, 233, 237)
                    };
                    panel.Controls.Add(bar);

                    y += bar.Height + 8;
                }

                // Đáp án đúng
                if (cauHoi.DapAnDungIndex >= 0)
                {
                    var lblDung = new Label
                    {
                        Text = $"Đáp án đúng: {(char)('A' + cauHoi.DapAnDungIndex)}",
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(110, 170, 60),
                        AutoSize = true,
                        Padding = new Padding(8, 4, 8, 4),
                        Location = new Point(16, y)
                    };
                    panel.Controls.Add(lblDung);
                }

                flowThongKeCauHoi.Controls.Add(panel);
            }
        }
    }
}
