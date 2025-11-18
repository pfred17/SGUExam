using DAL;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CauHoiBLL
    {
        private readonly CauHoiDAL _cauHoiDAL = new();
        private readonly DapAnDAL _dapAnDAL = new();

        // 1. Lấy danh sách hiển thị (4 cột)
        public List<CauHoiDTO> GetAllForDisplay(long maMH = 0, long maChuong = 0, string doKho = "", string tuKhoa = "")
        {
            var list = _cauHoiDAL.GetAllForDisplay();

            // Lọc theo môn học → chuong
            List<long>? listMaChuong = maMH > 0
                ? new ChuongBLL().GetByMonHoc(maMH).Select(c => c.MaChuong).ToList()
                : null;

            return list.Where(c =>
                (maMH == 0 || (listMaChuong?.Contains(c.MaChuong) ?? false)) &&
                (maChuong == 0 || c.MaChuong == maChuong) &&
                (string.IsNullOrEmpty(doKho) || c.DoKho == doKho) &&
                (string.IsNullOrEmpty(tuKhoa) || c.NoiDung.Contains(tuKhoa))
            ).ToList();
        }

        // 2. Lấy chi tiết 1 câu hỏi
        public CauHoiDTO? GetById(long maCauHoi) =>
            _cauHoiDAL.GetById(maCauHoi);

        // 3. Lấy danh sách đáp án của câu hỏi
        public List<DapAnDTO> GetDapAn(long maCauHoi) =>
            _dapAnDAL.GetByCauHoi(maCauHoi);

        // 4. Thêm mới câu hỏi
        public long ThemMoi(long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList) =>
            _cauHoiDAL.ThemMoi(maChuong, noiDung, doKho, dapAnList);

        // 5. Cập nhật câu hỏi
        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList) =>
            _cauHoiDAL.CapNhat(maCauHoi, maChuong, noiDung, doKho, dapAnList);

        // 6. Xóa mềm
        public void Xoa(long maCauHoi) =>
            _cauHoiDAL.Xoa(maCauHoi);
    }
}
