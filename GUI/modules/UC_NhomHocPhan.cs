#nullable disable
using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI.modules
{
    public partial class UC_NhomHocPhan : UserControl
    {
        private UC_ThemNhomHocPhan ucThem = null;
        private NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private string _userId;

        // Add these helper fields near the top of the class (for layout tuning)
        private const int MaxColumns = 3;             // tối đa 3 item trên 1 hàng
        private const int MinItemWidth = 240;         // nếu flow quá nhỏ, sẽ giảm số cột
        private const int ItemHorizontalGap = 16;     // khoảng cách ngang giữa các item (margin-left+right)
        private const int ItemVerticalGap = 12;       // khoảng cách dọc giữa các item (margin-top+bottom)


        public UC_NhomHocPhan(string userId)
        {
            _userId = userId;
            InitializeComponent();
            // Hook text changed of txtTimKiem (Designer name must match)
            //var tb = this.Controls.Find("txtTimKiem", true).FirstOrDefault() as TextBox;
            //if (tb != null)
            //    tb.TextChanged += (s, e) => PerformSearch(tb.Text.Trim());

            // Hook text changed of search box — support plain TextBox and Guna2TextBox, try common names and fallback search
            Control tbControl = this.Controls.Find("txtTimKiem", true).FirstOrDefault()
                                ?? this.Controls.Find("tbTimKiem", true).FirstOrDefault();

            if (tbControl is TextBox tb)
            {
                tb.TextChanged += (s, e) => PerformSearch(tb.Text.Trim());
            }
            else if (tbControl != null) // maybe Guna2TextBox or other
            {
                var textProp = tbControl.GetType().GetProperty("Text");
                var evt = tbControl.GetType().GetEvent("TextChanged");
                if (evt != null)
                {
                    evt.AddEventHandler(tbControl, new EventHandler((s, e) =>
                    {
                        var val = textProp?.GetValue(tbControl)?.ToString() ?? string.Empty;
                        PerformSearch(val.Trim());
                    }));
                }
            }
            else
            {
                // fallback: find any control with name contains "tim" and has TextChanged
                var any = this.Controls.Find("txtTimKiem", true).FirstOrDefault()
                          ?? this.Controls.Cast<Control>().SelectMany(c => c.Controls.Cast<Control>()).FirstOrDefault(c => c.Name?.ToLower().Contains("tim") == true);
                if (any != null)
                {
                    var textProp = any.GetType().GetProperty("Text");
                    var evt = any.GetType().GetEvent("TextChanged");
                    if (evt != null)
                    {
                        evt.AddEventHandler(any, new EventHandler((s, e) =>
                        {
                            var val = textProp?.GetValue(any)?.ToString() ?? string.Empty;
                            PerformSearch(val.Trim());
                        }));
                    }
                }
            }

            this.Load += UC_NhomHocPhan_Load;
        }
        public UC_NhomHocPhan() : this(null) { }

        //search
        // Replace previous PerformSearch implementation with this simple call to BLL
        // Replace existing PerformSearch with this version (includes Debug logging)
        private void PerformSearch(string query)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[SEARCH] Query raw: '{query}'");

                var results = nhomHocPhanBLL.Search(query ?? string.Empty) ?? new List<NhomHocPhanDTO>();

                System.Diagnostics.Debug.WriteLine($"[SEARCH] Results count: {results.Count}");

                // refresh UI
                flowDanhSachNhom.Controls.Clear();
                foreach (var nhom in results)
                {
                    AddItemToFlow(nhom);
                }

                // adjust layout sizes if you use AdjustFlowChildrenSizes
                AdjustFlowChildrenSizes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Replace the simple SizeChanged handler with a responsive one
        private void flowDanhSachNhom_SizeChanged(object sender, EventArgs e)
        {
            AdjustFlowChildrenSizes();
        }

        // Add this helper method to compute columns and size children so there are up to 3 items per row
        private void AdjustFlowChildrenSizes()
        {
            try
            {
                int containerWidth = flowDanhSachNhom.ClientSize.Width;
                if (containerWidth <= 0) return;

                // compute available width excluding padding of flow panel
                int innerAvailable = containerWidth - flowDanhSachNhom.Padding.Left - flowDanhSachNhom.Padding.Right;
                // determine number of columns: prefer MaxColumns but shrink if not enough width for MinItemWidth
                int columns = MaxColumns;
                while (columns > 1 && (innerAvailable / columns) < MinItemWidth)
                    columns--;

                // compute item width considering horizontal gaps between items
                // We'll use child's Margin.Left + Margin.Right as gap; ensure a reasonable gap
                int gap = ItemHorizontalGap;
                int totalGap = gap * (columns + 1); // left/right gaps around each column
                int itemWidth = Math.Max(100, (innerAvailable - totalGap) / columns);

                // set each child width and margin
                foreach (Control child in flowDanhSachNhom.Controls)
                {
                    // keep height as designed by UC_ItemNhomHocPhan; only set width
                    child.Width = itemWidth;

                    // enforce uniform margin so spacing is consistent
                    child.Margin = new Padding(gap / 2, ItemVerticalGap / 2, gap / 2, ItemVerticalGap / 2);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AdjustFlowChildrenSizes error: " + ex.Message);
            }
        }

        // After adding a new item, call AdjustFlowChildrenSizes so layout updates immediately.
        // Modify AddItemToFlow to call AdjustFlowChildrenSizes() at the end:
        private void AddItemToFlow(NhomHocPhanDTO nhom)
        {
            MonHocBLL monHocBLL = new MonHocBLL();
            MonHocDTO monHoc = monHocBLL.GetMonHocById(nhom.MaMH);
            UC_ItemNhomHocPhan item = new UC_ItemNhomHocPhan();
            item.SetData(nhom, monHoc);

            // set a reasonable default size and margin so design-time appearance is good before layout recalculation
            item.Width = MinItemWidth;
            item.Margin = new Padding(ItemHorizontalGap / 2, ItemVerticalGap / 2, ItemHorizontalGap / 2, ItemVerticalGap / 2);

            // attach handlers (existing code)...
            item.ViewStudentClicked += (s, nhom) =>
            {
                UC_SinhVienTrongNhom svNhom = new UC_SinhVienTrongNhom();
                svNhom.SetGroupInfo(nhom, monHoc);
                this.Controls.Clear();
                this.Controls.Add(svNhom);
                svNhom.Dock = DockStyle.Fill;
            };


            // Xử lý XÓA — lấy MaNhom tại thời điểm click từ item.GetCurrentData()

            item.DeleteClicked += (s, e) =>
                {
                    try
                    {
                        var data = item.GetCurrentData();
                        if (data == null)
                        {
                            MessageBox.Show("Dữ liệu item rỗng, không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        long maNhomToDelete = data.MaNhom;
                        if (maNhomToDelete <= 0)
                        {
                            MessageBox.Show($"Không thể xóa: MaNhom không hợp lệ ({maNhomToDelete}).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var confirm = MessageBox.Show(
                        $"Xác nhận xóa nhóm học phần (MaNhom = {maNhomToDelete})?",
                        "Xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                        if (confirm != DialogResult.Yes) return;
                        bool result = nhomHocPhanBLL.Delete(maNhomToDelete);
                        if (result)
                        {
                            flowDanhSachNhom.Controls.Remove(item);
                            item.Dispose();
                            MessageBox.Show("Đã xóa nhóm học phần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại! Kiểm tra quyền DB hoặc console log.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

            item.EditClicked += (s, e) =>
                {
                    //if (ucThem == null) return;
                    InitUcThem();
                    ucThem.SetEditMode(item.GetCurrentData());
                    ucThem.Visible = true;
                    ucThem.BringToFront();
                };
            flowDanhSachNhom.Controls.Add(item);
            // Immediately adjust sizes so the new item fits the row layout
            AdjustFlowChildrenSizes();
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }



        private void LoadDataItem()
        {
            try
            {
                flowDanhSachNhom.Controls.Clear();
                List<NhomHocPhanDTO> list = nhomHocPhanBLL.GetAll();
                foreach (var nhom in list)
                {
                    // Reuse AddItemToFlow so handlers are attached correctly
                    AddItemToFlow(nhom);
                }
                AdjustFlowChildrenSizes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhóm học phần: " + ex.Message);
            }
        }

        private void UC_NhomHocPhan_Load(object sender, EventArgs e)
        {
            LoadDataItem();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ucThem == null)
            {
                ucThem = new UC_ThemNhomHocPhan();
                // ✅ Thay bằng tọa độ cố định — cho nằm giữa màn hình cha và cách top 80px
                ucThem.Width = 780;
                ucThem.Height = 684;
                ucThem.Location = new Point((this.Width - ucThem.Width) / 2, 20);
                this.Controls.Add(ucThem);
                // Sự kiện đóng form
                ucThem.FormClosedEvent += (s, args) => ucThem.Visible = false;
                // Sự kiện thêm mới
                ucThem.NhomHocPhanAdded += (s, nhomHocPhan) =>
                {
                    AddItemToFlow(nhomHocPhan);
                    ucThem.Visible = false;
                };
                // Sự kiện cập nhật
                ucThem.NhomHocPhanUpdated += (s, updatedNhom) =>
                {
                    UpdateItemInFlow(updatedNhom);
                    ucThem.Visible = false;
                };
            }
            // reset fields mỗi khi mở (tạo hàm Reset trong UC_ThemNhomHocPhan)
            InitUcThem();
            ucThem.ResetFields();
            ucThem.Visible = true;
            ucThem.BringToFront();
        }

        private void UcThem_NhomHocPhanUpdated(object sender, NhomHocPhanDTO updatedNhom)
        {
            try
            {
                // Cập nhật lại giao diện item tương ứng
                MonHocBLL monHocBLL = new MonHocBLL();
                MonHocDTO monHocMoi = monHocBLL.GetMonHocById(updatedNhom.MaMH);
                // Tìm item tương ứng trong flow và update
                foreach (Control c in flowDanhSachNhom.Controls)
                {
                    if (c is UC_ItemNhomHocPhan item)
                    {
                        // So sánh mã nhóm
                        var dataField = typeof(UC_ItemNhomHocPhan)
                        .GetField("currentData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.GetValue(item) as NhomHocPhanDTO;
                        if (dataField != null && dataField.MaNhom == updatedNhom.MaNhom)
                        {
                            item.SetData(updatedNhom, monHocMoi);
                            break;
                        }
                    }
                }
                MessageBox.Show("✅ Đã cập nhật nhóm học phần!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật giao diện: " + ex.Message);
            }
        }
        private void UpdateItemInFlow(NhomHocPhanDTO updatedNhom)
        {
            MonHocBLL monHocBLL = new MonHocBLL();
            MonHocDTO monHocMoi = monHocBLL.GetMonHocById(updatedNhom.MaMH);
            foreach (Control c in flowDanhSachNhom.Controls)
            {
                if (c is UC_ItemNhomHocPhan item)
                {
                    var data = item.GetCurrentData();
                    if (data.MaNhom == updatedNhom.MaNhom)
                    {
                        item.SetData(updatedNhom, monHocMoi);
                        break;
                    }
                }
            }
            MessageBox.Show("✅ Đã cập nhật nhóm học phần!", "Thông báo");
        }
        private void btnTiemKiem_Click(object sender, EventArgs e)
        {
        }

        // lỗi sửa
        private void InitUcThem()
        {
            if (ucThem != null) return;

            ucThem = new UC_ThemNhomHocPhan();
            ucThem.Width = 780;
            ucThem.Height = 684;
            ucThem.Location = new Point((this.Width - ucThem.Width) / 2, 20);
            this.Controls.Add(ucThem);

            ucThem.FormClosedEvent += (s, args) => ucThem.Visible = false;

            ucThem.NhomHocPhanAdded += (s, nhom) =>
            {
                AddItemToFlow(nhom);
                ucThem.Visible = false;
            };

            ucThem.NhomHocPhanUpdated += (s, updated) =>
            {
                UpdateItemInFlow(updated);
                ucThem.Visible = false;
            };
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}