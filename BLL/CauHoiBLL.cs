using DAL;
using DTO;
using System.Text.RegularExpressions;
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

            // Lấy danh sách chương của môn học (nếu chọn môn)
            HashSet<long>? dsChuong = null;
            if (maMH > 0)
                dsChuong = _chuongBLL.GetChuongByMonHoc(maMH)
                                     .Select(ch => ch.MaChuong)
                                     .ToHashSet();

            return list.Where(c =>
                // Lọc theo môn học
                (dsChuong == null || dsChuong.Contains(c.MaChuong)) &&
                // Lọc theo chương
                (maChuong == 0 || c.MaChuong == maChuong) &&
                // Lọc theo độ khó
                (string.IsNullOrEmpty(doKho) || c.DoKho == doKho) &&
                // Lọc theo từ khóa
                (string.IsNullOrEmpty(keywordNormalized) || Normalize(c.NoiDung).Contains(keywordNormalized))
            ).ToList();
        }

        // Trong CauHoiBLL.cs
        public static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            // Bỏ dấu tiếng Việt
            text = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            text = sb.ToString().Normalize(NormalizationForm.FormC);

            // Chuẩn hóa: chữ thường, bỏ khoảng trắng, bỏ ký tự đặc biệt
            return Regex.Replace(text, @"[^\p{L}\p{N}]", "")  // xóa hết ký tự không phải chữ/số
                        .ToLowerInvariant()
                        .Trim();
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

        public List<CauHoiTrungLapDTO> LayCauHoiTrungLap()
        {
            var all = _cauHoiDAL.GetAllForDisplayTrungLap(); // mỗi câu chỉ xuất hiện 1 lần

            var groups = all
                .GroupBy(ch => Normalize(ch.NoiDung)) // nhóm theo nội dung chuẩn hóa
                .Where(g => g.Count() > 1)           // chỉ lấy nhóm > 1
                .Select(g =>
                {
                    var danhSach = g.OrderByDescending(x => x.MaCauHoi).ToList();
                    return new CauHoiTrungLapDTO
                    {
                        Key = g.Key,
                        SoLuong = g.Count(),
                        DanhSach = danhSach,
                        TacGia = danhSach.First().TacGia // tác giả câu mới nhất
                    };
                })
                .OrderByDescending(g => g.SoLuong)
                .ThenBy(g => g.DanhSach.First().MaCauHoi)
                .ToList();

            return groups;
        }


        /// Thống kê nhanh: số nhóm trùng, số câu trùng, số câu duy nhất
        public (int nhomTrung, int cauTrung, int cauDuyNhat) LayThongKeTrungLap()
        {
            var all = _cauHoiDAL.GetAllForDisplay();
            var duplicateGroups = all
                .GroupBy(ch => Normalize(ch.NoiDung))
                .Where(g => g.Count() > 1);

            int nhomTrung = duplicateGroups.Count();
            int cauTrung = duplicateGroups.Sum(g => g.Count() - 1); // trừ đi 1 câu giữ lại
            int cauDuyNhat = all.Count - (nhomTrung + cauTrung);

            return (nhomTrung, cauTrung, cauDuyNhat);
        }
    }
}
