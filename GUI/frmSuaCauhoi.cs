using BLL;
using DTO;
using GUI.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSuaCauhoi : Form
    {
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //private readonly CauHoiBLL _cauHoiBLL = new CauHoiBLL();
        //private readonly MonHocBLL _monHocBLL = new MonHocBLL();
        //private readonly ChuongBLL _chuongBLL = new ChuongBLL();
        //private readonly DapAnBLL _dapAnBLL = new DapAnBLL();
        //private long _maCauHoi = 0;
        //private string _filePath = "";
        //public frmSuaCauhoi(long maCauHoi)
        //{
        //    InitializeComponent();
        //    _maCauHoi = maCauHoi; // Gán mã câu hỏi cần sửa

        //    // Tạo FlowLayoutPanel cho đáp án 
        //    flpDapAn = new FlowLayoutPanel
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoScroll = true,
        //        FlowDirection = FlowDirection.TopDown,
        //        WrapContents = false,
        //        Padding = new Padding(5)
        //    };
        //    pnlDapAnContainer.Controls.Add(flpDapAn);
        //}
        //private void frmSuaCauHoi_Load(object sender, EventArgs e)
        //{
        //    // 1. Load ComboBox
        //    LoadMonHoc();
        //    LoadMonHocFile();
        //    LoadDoKho();

        //    // 2. Load dữ liệu câu hỏi cần sửa
        //    LoadCauHoiData();
        //}
        //private void LoadMonHoc()
        //{
        //    var list = _monHocBLL.GetAllMonHoc();
        //    list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn môn học..." });
        //    cbMonHoc.DataSource = list;
        //    cbMonHoc.DisplayMember = "TenMH";
        //    cbMonHoc.ValueMember = "MaMH";
        //}

        //// METHOD LoadMonHocFile
        //private void LoadMonHocFile()
        //{
        //    var list = _monHocBLL.GetAllMonHoc();
        //    list.Insert(0, new MonHocDTO { MaMH = 0, TenMH = "Chọn môn học..." });
        //    cbMonHocFile.DataSource = list;
        //    cbMonHocFile.DisplayMember = "TenMH";
        //    cbMonHocFile.ValueMember = "MaMH";
        //}
        //// METHOD LoadChuong
        //private void LoadChuong(long maMH, ComboBox cb)
        //{
        //    if (maMH <= 0)
        //    {
        //        cb.DataSource = null;
        //        return;
        //    }
        //    var list = _chuongBLL.GetChuongByMonHoc(maMH);
        //    list.Insert(0, new ChuongDTO { MaChuong = 0, TenChuong = "Chọn chương..." });
        //    cb.DataSource = list;
        //    cb.DisplayMember = "TenChuong";
        //    cb.ValueMember = "MaChuong";
        //}

        //private void LoadDoKho()
        //{
        //    cbDoKho.Items.Clear();
        //    cbDoKho.Items.Add("Chọn độ khó...");
        //    cbDoKho.Items.Add("Dễ");
        //    cbDoKho.Items.Add("Trung bình");
        //    cbDoKho.Items.Add("Khó");
        //    cbDoKho.SelectedIndex = 0;
        //}
        //private void LoadCauHoiData()
        //{
        //    // Lấy thông tin câu hỏi từ BLL
        //    var cauHoi = _cauHoiBLL.GetById(_maCauHoi);
        //    if (cauHoi == null)
        //    {
        //        MessageBox.Show("Không tìm thấy câu hỏi!", "Lỗi");
        //        this.Close();
        //        return;
        //    }

        //    // Điền dữ liệu vào controls
        //    rtbNoiDung.Text = cauHoi.NoiDung;
        //    cbDoKho.Text = cauHoi.DoKho;

        //    // Chọn môn học và chương
        //    var monHoc = _monHocBLL.GetAllMonHoc()
        //        .FirstOrDefault(m => m.TenMH == cauHoi.TenMonHoc);

        //    if (monHoc != null)
        //    {
        //        cbMonHoc.SelectedValue = monHoc.MaMH;
        //        LoadChuong(monHoc.MaMH, cbChuong);
        //        cbChuong.SelectedValue = cauHoi.MaChuong;
        //    }

        //    // Load danh sách đáp án
        //    LoadDapAn();
        //}

        //private void LoadDapAn()
        //{
        //    // Xóa các đáp án cũ (nếu có)
        //    flpDapAn.Controls.Clear();
        //    _dapAnControls.Clear();

        //    // Lấy danh sách đáp án từ BLL
        //    var dapAnList = _dapAnBLL.GetByCauHoi(_maCauHoi);

        //    // Tạo DapAnControl cho mỗi đáp án
        //    foreach (var da in dapAnList)
        //    {
        //        var ctrl = new DapAnControl(da.NoiDung, da.Dung);
        //        _dapAnControls.Add(ctrl);
        //        flpDapAn.Controls.Add(ctrl);
        //    }
        //}

        //private void btnLuuCauHoi_Click(object sender, EventArgs e)
        //{
        //    // 1. Validate dữ liệu
        //    if (!ValidateInput()) return;

        //    // 2. Lấy dữ liệu từ form
        //    long maChuong = (long)cbChuong.SelectedValue;
        //    string noiDung = rtbNoiDung.Text.Trim();
        //    string doKho = cbDoKho.Text;

        //    // 3. Lấy danh sách đáp án
        //    var dapAnList = GetDapAnList();

        //    // 4. Kiểm tra phải có đúng 1 đáp án đúng
        //    int soDapAnDung = dapAnList.Count(x => x.Dung);
        //    if (soDapAnDung != 1)
        //    {
        //        MessageBox.Show("Phải chọn đúng 1 đáp án đúng!", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // 5. Gọi BLL để cập nhật
        //    try
        //    {
        //        _cauHoiBLL.CapNhat(_maCauHoi, maChuong, noiDung, doKho, dapAnList);
        //        MessageBox.Show("Cập nhật câu hỏi thành công!", "Thành công");
        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
        //    }
        //}
        //private bool ValidateInput()
        //{
        //    if (string.IsNullOrWhiteSpace(rtbNoiDung.Text))
        //    {
        //        MessageBox.Show("Vui lòng nhập nội dung câu hỏi!", "Lỗi");
        //        rtbNoiDung.Focus();
        //        return false;
        //    }

        //    if (cbMonHoc.SelectedValue == null || (long)cbMonHoc.SelectedValue == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn môn học!", "Lỗi");
        //        return false;
        //    }

        //    if (cbChuong.SelectedValue == null || (long)cbChuong.SelectedValue == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn chương!", "Lỗi");
        //        return false;
        //    }

        //    if (cbDoKho.SelectedIndex == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn độ khó!", "Lỗi");
        //        return false;
        //    }

        //    var dapAnList = GetDapAnList();
        //    if (dapAnList.Count < 2)
        //    {
        //        MessageBox.Show("Phải có ít nhất 2 đáp án!", "Lỗi");
        //        return false;
        //    }

        //    return true;
        //}
        //private List<DapAnDTO> GetDapAnList()
        //{
        //    return _dapAnControls
        //        .Where(c => !string.IsNullOrWhiteSpace(c.NoiDung))
        //        .Select(c => new DapAnDTO
        //        {
        //            NoiDung = c.NoiDung.Trim(),
        //            Dung = c.Dung
        //        })
        //        .ToList();
        //}
        //// ✅ THÊM METHOD btnChonFile_Click
        //private void btnChonFile_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        _filePath = openFileDialog1.FileName;
        //        txtDuongDan.Text = _filePath;
        //    }
        //}

        //private void btnThemCauTraLoi_Click(object sender, EventArgs e)
        //{
        //    // Tạo đáp án mới (rỗng)
        //    var ctrl = new DapAnControl("", false);
        //    _dapAnControls.Add(ctrl);
        //    flpDapAn.Controls.Add(ctrl);
        //}
        //private FlowLayoutPanel flpDapAn;
        //private List<DapAnControl> _dapAnControls = new List<DapAnControl>();

        //private void cbMonHocFile_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
