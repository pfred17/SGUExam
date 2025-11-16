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

        public UC_NhomHocPhan()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UC_NhomHocPhan_Load);

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
            ucThem.ResetFields();
            ucThem.Visible = true;
            ucThem.BringToFront();
        }
        private void AddItemToFlow(NhomHocPhanDTO nhom)
        {
            MonHocBLL monHocBLL = new MonHocBLL();
            MonHocDTO monHoc = monHocBLL.GetById(nhom.MaMH);

            UC_ItemNhomHocPhan item = new UC_ItemNhomHocPhan();
            item.SetData(nhom, monHoc);


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

            // Sửa
            //item.EditClicked += (s, e) =>
            //{
            //    if (ucThem == null)
            //        return;

            //    ucThem.SetEditMode(item.GetCurrentData());
            //    ucThem.Visible = true;
            //    ucThem.BringToFront();
            //};  ss1

            item.EditClicked += (s, e) =>
            {
                if (ucThem == null) return;
                ucThem.SetEditMode(item.GetCurrentData());
                ucThem.Visible = true;
                ucThem.BringToFront();
            };

            flowDanhSachNhom.Controls.Add(item);

        }
        private void UcThem_NhomHocPhanUpdated(object sender, NhomHocPhanDTO updatedNhom)
        {
            try
            {
                // Cập nhật lại giao diện item tương ứng
                MonHocBLL monHocBLL = new MonHocBLL();
                MonHocDTO monHocMoi = monHocBLL.GetById(updatedNhom.MaMH);

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
            MonHocDTO monHocMoi = monHocBLL.GetById(updatedNhom.MaMH);

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
    }
}
