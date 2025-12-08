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

namespace GUI.forms.hocphan
{
    public partial class frmChiTietSinhVien : Form
    {
        private string _mssv;
        private long _maNhom;
        public frmChiTietSinhVien(string mssv, long maNhom)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _mssv = mssv;
            _maNhom = maNhom;
            LoadThongTinSinhVien();

        }
       
        private void LoadThongTinSinhVien()
        {
            try
            {
                // 1. Lấy thông tin sinh viên
                UserDTO sv = UserDAL.Instance.GetUserByMSSV(_mssv, includeInactive: true);
                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                lbHoTen.Text = (sv.HoTen ?? "Chưa có");
                lbMSSV.Text = sv.MSSV;
                lbEmail.Text = (sv.Email ?? "Chưa có");
                lbGioiTinh.Text = (sv.GioiTinh == 0 ? "Nam" : "Nữ");

                // 2. Thông tin nhóm
                NhomHocPhanDTO nhom = new NhomHocPhanDAL().GetById(_maNhom);
                if (nhom != null)
                {
                    lbThongTin.Text = $" {nhom.MaMonHoc} - {nhom.TenMonHoc} - {nhom.TenNhom} - {nhom.HocKy} {nhom.NamHoc}";
                }
                else
                {
                    lbThongTin.Text = " Không xác định";
                }

                // 3. LẤY ĐIỂM TỪNG ĐỀ (mới thêm)
                LoadDiemSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDiemSinhVien()
        {
            try
            {
                // Lấy bảng điểm pivot của toàn nhóm
                DataTable dt = new NhomHocPhanDAL().LayBangDiemPivot(_maNhom);

                // Tìm dòng của sinh viên hiện tại
                DataRow[] rows = dt.Select($"MSSV = '{_mssv}'");

                if (rows.Length == 0)
                {
                    lbDiem.Text = "Chưa có dữ liệu điểm.";
                    return;
                }

                DataRow row = rows[0];
                var diemList = new List<string>();

                // Duyệt tất cả cột (trừ 2 cột đầu: MSSV, HoTen)
                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    string tenDe = dt.Columns[i].ColumnName;
                    object diemObj = row[i];

                    string diemText = diemObj == DBNull.Value || diemObj == null
                        ? "Chưa làm"
                        : diemObj.ToString();

                    // Định dạng đẹp: dùng dấu đầu dòng
                    diemList.Add($"• {tenDe}: {diemText}");
                }

                if (diemList.Count > 0)
                {
                    lbDiem.Text = string.Join("\n", diemList);
                }
                else
                {
                    lbDiem.Text = "Chưa có đề thi nào trong nhóm.";
                }
            }
            catch (Exception ex)
            {
                lbDiem.Text = "Chưa có đề thi trong nhóm" ;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
