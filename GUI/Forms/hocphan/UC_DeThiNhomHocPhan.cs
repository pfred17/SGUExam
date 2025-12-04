using BLL;
using DTO;
using Guna.UI2.WinForms;
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
    public partial class UC_DeThiNhomHocPhan : UserControl
    {
        private List<DeThiDTO> _dsDeThi = new List<DeThiDTO>();
        private List<DeThiDTO> _dsDeThiLoc = new List<DeThiDTO>();    
        private int _currentPage = 1;
        private int _pageSize = 4;
        private int _totalPages = 1;
        public event Action<long> TaoDeThiClicked;

        private long _maNhom;
        private string _tenNhom;

        private readonly DeThiNhomBLL deThiBLL = new DeThiNhomBLL();
        public UC_DeThiNhomHocPhan()
        {
            InitializeComponent();
        }
        public void HienThiDeThiCuaNhom(long maNhom, string tenNhom)
        {
            _maNhom = maNhom;
            _tenNhom = tenNhom;

            lblTieuDe.Text = $"Đề thi - {tenNhom}";

            _dsDeThi = deThiBLL.LayDanhSachDeThiTheoNhom(maNhom);
            _dsDeThiLoc = _dsDeThi; // ban đầu chưa tìm → hiển thị toàn bộ

            tbTimKiem.Text = "";
            _currentPage = 1;
            _totalPages = (int)Math.Ceiling((double)_dsDeThiLoc.Count / _pageSize);

            HienThiTrang();
        }
        private void HienThiTrang()
        {
            flDeThi.Controls.Clear();
            flDeThi.Padding = new Padding(50, 10, 10, 10);

            if (_dsDeThiLoc.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "Không tìm thấy đề thi phù hợp.",
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flDeThi.Controls.Add(lbl);
                lbPage.Text = "0/0";
                return;
            }

            var dsTrang = _dsDeThiLoc
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            foreach (var de in dsTrang)
            {
                var item = new UC_ItemDeThi();
                item.SetData(de, _tenNhom);

                item.XoaClicked += (s, maDe) =>
                {
                    if (MessageBox.Show("Xóa đề thi này khỏi nhóm?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (deThiBLL.XoaDeThiKhoiNhom(maDe, _maNhom))
                        {
                            MessageBox.Show("Đã xóa thành công!");

                            _dsDeThi = deThiBLL.LayDanhSachDeThiTheoNhom(_maNhom);
                            ApDungTimKiem(); // cập nhật lại sau khi xóa
                        }
                    }
                };

                flDeThi.Controls.Add(item);
            }

            lbPage.Text = $"{_currentPage}/{_totalPages}";
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
        }
        private void ApDungTimKiem()
        {
            string tuKhoa = tbTimKiem.Text.Trim()
                                .ToLower()
                                .RemoveDiacritics();  // ✅ BỎ DẤU

            if (string.IsNullOrEmpty(tuKhoa))
            {
                _dsDeThiLoc = _dsDeThi;
            }
            else
            {
                _dsDeThiLoc = _dsDeThi
                    .Where(d =>
                        d.TenDe != null &&
                        d.TenDe.ToLower()
                               .RemoveDiacritics()   // ✅ BỎ DẤU TÊN ĐỀ
                               .Contains(tuKhoa)

                        || d.MaDe.ToString().Contains(tuKhoa)
                    )
                    .ToList();
            }

            _currentPage = 1;
            _totalPages = (int)Math.Ceiling((double)_dsDeThiLoc.Count / _pageSize);

            HienThiTrang();
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoDe_Click(object sender, EventArgs e)
        {
            if (_maNhom <= 0)
            {
                MessageBox.Show("Chưa chọn nhóm học phần!");
                return;
            }

            // ✅ _maNhom ĐÃ LÀ long → DÙNG TRỰC TIẾP
            TaoDeThiClicked?.Invoke(_maNhom);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                HienThiTrang();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                HienThiTrang();
            }
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApDungTimKiem();
        }
    }
}
