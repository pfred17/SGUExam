#nullable disable
using BLL;
using DAL;
using DTO;
using GUI.forms.hocphan;
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
        public event EventHandler QuayLaiClicked;
        private UC_DeThiNhomHocPhan ucDeThiNhom;
        private UC_ThemNhomHocPhan ucThem = null;
        private NhomHocPhanBLL nhomHocPhanBLL = new NhomHocPhanBLL();
        private readonly PermissionBLL _permissionBLL = new PermissionBLL();

        private readonly string _userId;

        private const int MaxColumns = 3;             // tối đa 3 item trên 1 hàng
        private const int MinItemWidth = 240;         // nếu flow quá nhỏ, sẽ giảm số cột
        private const int ItemHorizontalGap = 16;     // khoảng cách ngang giữa các item (margin-left+right)
        private const int ItemVerticalGap = 12;       // khoảng cách dọc giữa các item (margin-top+bottom)
        public UC_NhomHocPhan(string userId)
        {
            _userId = userId;
            InitializeComponent();
            HookSearchTextBox();
            loadPermission();
            this.Load += UC_NhomHocPhan_Load;
        }
        private void loadPermission()
        {
            //btnDetail = _permissionBLL.HasPermission(_userId, 1, "Xem");
            btnThemUC.Visible = _permissionBLL.HasPermission(_userId, 1, "Thêm");
        }
        private void HookSearchTextBox()
        {
            Control tbControl = this.Controls.Find("txtTimKiem", true).FirstOrDefault()
                                ?? this.Controls.Find("tbTimKiem", true).FirstOrDefault();

            if (tbControl is TextBox tb)
            {
                tb.TextChanged += (s, e) => PerformSearch(tb.Text.Trim());
            }
            else if (tbControl != null)
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
        }
        public UC_NhomHocPhan() : this(null) { }

        //search
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
                AdjustFlowChildrenSizes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void flowDanhSachNhom_SizeChanged(object sender, EventArgs e)
        {
            AdjustFlowChildrenSizes();
        }
        private void AdjustFlowChildrenSizes()
        {
            try
            {
                int containerWidth = flowDanhSachNhom.ClientSize.Width;
                if (containerWidth <= 0) return;
                int innerAvailable = containerWidth - flowDanhSachNhom.Padding.Left - flowDanhSachNhom.Padding.Right;
                int columns = MaxColumns;
                while (columns > 1 && (innerAvailable / columns) < MinItemWidth)
                    columns--;
                int gap = ItemHorizontalGap;
                int totalGap = gap * (columns + 1); 
                int itemWidth = Math.Max(100, (innerAvailable - totalGap) / columns);
                foreach (Control child in flowDanhSachNhom.Controls)
                {
                    child.Width = itemWidth;
                    child.Margin = new Padding(gap / 2, ItemVerticalGap / 2, gap / 2, ItemVerticalGap / 2);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AdjustFlowChildrenSizes error: " + ex.Message);
            }
        }
        private void AddItemToFlow(NhomHocPhanDTO nhom)
        {
            var item = new UC_ItemNhomHocPhan(_userId);
            item.SetData(nhom);
            item.Width = MinItemWidth;
            item.Margin = new Padding(ItemHorizontalGap / 2, ItemVerticalGap / 2, ItemHorizontalGap / 2, ItemVerticalGap / 2);

            item.ViewStudentClicked += (s, nhom) =>
            {
                var svNhom = new UC_SinhVienTrongNhom();
                svNhom.SetGroupInfo(nhom);
                this.Controls.Clear();
                this.Controls.Add(svNhom);
                svNhom.Dock = DockStyle.Fill;
            };
            item.DeleteClicked += (s, e) =>
                {
                    try
                    {
                        var data = item.GetCurrentData();
                        if (data == null || data.MaNhom <= 0)
                        {
                            MessageBox.Show("Không thể xóa nhóm này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (MessageBox.Show($"Xóa nhóm \"{data.TenNhom}\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (nhomHocPhanBLL.Delete(data.MaNhom))
                            {
                                flowDanhSachNhom.Controls.Remove(item);
                                item.Dispose();
                                MessageBox.Show("Đã xóa nhóm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AdjustFlowChildrenSizes();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

            item.EditClicked += (s, e) =>
            {
                InitUcThem();
                ucThem.SetEditMode(item.GetCurrentData());
                ucThem.Visible = true;
                ucThem.BringToFront();
            };
            item.DeThiClicked += (s, nhom) =>
            {
                if (ucDeThiNhom == null)
                    ucDeThiNhom = new UC_DeThiNhomHocPhan();

                this.Controls.Clear();
                this.Controls.Add(ucDeThiNhom);
                ucDeThiNhom.Dock = DockStyle.Fill;
                ucDeThiNhom.HienThiDeThiCuaNhom(nhom.MaNhom, nhom.TenNhom);
            };

            flowDanhSachNhom.Controls.Add(item);
            AdjustFlowChildrenSizes();
        }
        private void LoadDataItem()
        {
            try
            {
                flowDanhSachNhom.Controls.Clear();
                var list = nhomHocPhanBLL.GetAll();
                foreach (var nhom in list)
                {
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
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            InitUcThem();
            ucThem.ResetFields();
            ucThem.Visible = true;
            ucThem.BringToFront();
        }

        private void UpdateItemInFlow(NhomHocPhanDTO updatedNhom)
        {
            foreach (Control c in flowDanhSachNhom.Controls )
            {
                if (c is UC_ItemNhomHocPhan item && item.GetCurrentData()?.MaNhom == updatedNhom.MaNhom)
                {
                    var data = item.GetCurrentData();
                    if (data.MaNhom == updatedNhom.MaNhom)
                    {
                        item.SetData(updatedNhom);
                        break;
                    }
                }
            }
            MessageBox.Show("✅ Đã cập nhật nhóm học phần!", "Thông báo");
        }

        // lỗi sửa
        private void InitUcThem()
        {
            if (ucThem != null) return;

            ucThem = new UC_ThemNhomHocPhan(_userId);
            ucThem.Width = 624;
            ucThem.Height = 547;
            ucThem.Location = new Point((this.Width - ucThem.Width) / 2, (this.Height - ucThem.Height) / 2);
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

        

    }
}