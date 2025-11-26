using DAL;
using DTO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CauHoiBLL
    {
        private readonly CauHoiDAL _cauHoiDAL = new();
        private readonly DapAnDAL _dapAnDAL = new();
        private readonly ChuongBLL _chuongBLL = new();

        /// Lấy danh sách câu hỏi để hiển thị, hỗ trợ filter môn, chương, độ khó, từ khóa
        public List<CauHoiDTO> GetAllForDisplay(long maMH = 0, long maChuong = 0, string doKho = "", string tuKhoa = "")
        {
            var list = _cauHoiDAL.GetAllForDisplay();

            // Chuẩn hóa từ khóa
            string keywordNormalized = string.IsNullOrEmpty(tuKhoa) ? "" : Normalize(tuKhoa);

            return list.Where(c =>
                // Lọc theo môn học
                (maMH == 0 || _chuongBLL.GetChuongByMonHoc(maMH).Any(ch => ch.MaChuong == c.MaChuong)) &&
                // Lọc theo chương
                (maChuong == 0 || c.MaChuong == maChuong) &&
                // Lọc theo độ khó
                (string.IsNullOrEmpty(doKho) || c.DoKho == doKho) &&
                // Lọc theo từ khóa
                (string.IsNullOrEmpty(keywordNormalized) || Normalize(c.NoiDung).Contains(keywordNormalized))
            ).ToList();
        }

        // Hàm bỏ dấu + lowercase(để search tiếng Việt)
        private string Normalize(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            text = text.ToLower().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in text)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        /// Search theo từ khóa
        public List<CauHoiDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) 
            return _cauHoiDAL.GetAllForDisplay();
            string keyNorm = Normalize(keyword);
            return _cauHoiDAL.GetAllForDisplay()
                             .Where(c => Normalize(c.NoiDung).Contains(keyNorm))
                             .ToList();
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


        /// Lấy danh sách câu hỏi trùng
        public List<CauHoiTrungLapDTO> LayCauHoiTrungLap()
        {
            var danhSachCauHoi = _cauHoiDAL.GetAllForDisplay();

            return danhSachCauHoi
                .GroupBy(cauHoi => cauHoi.NoiDung.Trim())       // Nhóm theo nội dung câu hỏi
                .Where(nhom => nhom.Count() >= 2)               // Chỉ lấy nhóm có >= 2 phần tử
                .Select(nhom => new CauHoiTrungLapDTO
                {   
                    NoiDung = nhom.Key,                         // Key = nội dung câu hỏi sau khi trim
                    SoLuong = nhom.Count(),                     // Số câu trùng
                    DanhSach = nhom
                                .OrderByDescending(c => c.MaCauHoi)
                                .ToList()                       // Danh sách câu hỏi trong nhóm
                })
                .OrderByDescending(dto => dto.SoLuong)          // Sắp theo số lượng trùng
                .ThenByDescending(dto => dto.DanhSach.First().MaCauHoi)
                .ToList();
        }
        /// Thống kê nhanh: số nhóm trùng, số câu trùng, số câu duy nhất
        public (int NhomTrung,int cauTrung, int CauDuyNhat) LayThongKeTrungLap()
        {
            var tatca = _cauHoiDAL.GetAllForDisplay();
            var trungLap = LayCauHoiTrungLap();
            int tongCauTrungLap = trungLap.Sum(x => x.SoLuong);
            int soNhom = trungLap.Count;
            int cauDuyNhat = tatca.Count - tongCauTrungLap + soNhom;// mỗi nhóm chỉ tính 1 câu đại diện
            return (soNhom, tongCauTrungLap, cauDuyNhat);
        }
    }
}
