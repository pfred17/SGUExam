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

        #region Get/Filter Câu hỏi
        public List<CauHoiDTO> GetAllForDisplay(long maMH = 0, long maChuong = 0, string doKho = "", string tuKhoa = "")
        {
            var list = _cauHoiDAL.GetAllForDisplay();
            string keywordNormalized = string.IsNullOrEmpty(tuKhoa) ? "" : Normalize(tuKhoa);

            HashSet<long>? dsChuong = null;
            if (maMH > 0)
                dsChuong = _chuongBLL.GetChuongByMonHoc(maMH)
                                     .Select(ch => ch.MaChuong)
                                     .ToHashSet();

            return list.Where(c =>
                (dsChuong == null || dsChuong.Contains(c.MaChuong)) &&
                (maChuong == 0 || c.MaChuong == maChuong) &&
                (string.IsNullOrEmpty(doKho) || c.DoKho == doKho) &&
                (string.IsNullOrEmpty(keywordNormalized) || Normalize(c.NoiDung).Contains(keywordNormalized))
            ).ToList();
        }
        #endregion

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

        public CauHoiDTO? GetById(long maCauHoi) =>_cauHoiDAL.GetById(maCauHoi);

        public List<DapAnDTO> GetDapAn(long maCauHoi) =>_dapAnDAL.GetByCauHoi(maCauHoi);
        public long ThemMoi(long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            long maCauHoi = _cauHoiDAL.ThemMoi(maChuong, noiDung, doKho, dapAnList);
            if (dapAnList != null && dapAnList.Count > 0)
            {
                foreach (var da in dapAnList)
                    da.MaCauHoi = maCauHoi;

                _dapAnDAL.ThemDapAn(dapAnList);
            }

            return maCauHoi;
        }

        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList) =>
            _cauHoiDAL.CapNhat(maCauHoi, maChuong, noiDung, doKho, dapAnList);


        // 6. Xóa mềm
        public void Xoa(long maCauHoi) =>
            _cauHoiDAL.Xoa(maCauHoi);

        #region cau hoi trung lap 
        public List<CauHoiTrungLapDTO> LayCauHoiTrungLap()
        {
            var all = _cauHoiDAL.GetAllForDisplayTrungLap(); 

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
                        TacGia = danhSach.First().TacGia 
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
        #endregion
        #region Điều chỉnh độ khó
        private string LayDoKhoGoiY(double tyLeSai, int nguongDeMaxSai, int nguongKhoMinSai)
        {
            if (tyLeSai <= nguongDeMaxSai) return "Dễ";
            if (tyLeSai >= nguongKhoMinSai) return "Khó";
            return "Trung bình";
        }

        public List<CauHoiDTO> TinhToanVaDeXuatDoKho(long maMonHoc, int minLuotLam, int nguongDeMaxSai, int nguongKhoMinSai)
        {
            return _cauHoiDAL.LayThongKeDoKho(maMonHoc)
                .Where(ch => ch.SoLuotLam >= minLuotLam)
                .Select(ch => { ch.DoKhoGoiY = LayDoKhoGoiY(ch.TyLeSai, nguongDeMaxSai, nguongKhoMinSai); return ch; })
                .OrderByDescending(ch => ch.DoKho != ch.DoKhoGoiY)
                .ThenByDescending(ch => ch.TyLeSai)
                .ToList();
        }

        public void CapNhatDoKho(long maCauHoi, string doKhoMoi)
        {
            if (string.IsNullOrEmpty(doKhoMoi)) throw new ArgumentException("Độ khó mới không được để trống.");
            _cauHoiDAL.CapNhatDoKho(maCauHoi, doKhoMoi);
        }
        #endregion
    }
}
