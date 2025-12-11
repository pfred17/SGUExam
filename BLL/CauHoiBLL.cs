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
        private readonly DapAnBLL _dapAnBLL = new();
        private readonly ChuongBLL _chuongBLL = new();
        private readonly long _maND; // lưu userId

        public CauHoiBLL(long maND = 0)
        {
            _maND = maND;
        }

        #region Hàm Normalize & Helper
        public static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            text = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            text = sb.ToString().Normalize(NormalizationForm.FormC);
            return Regex.Replace(text, @"[^\p{L}\p{N}]", "")
                        .ToLowerInvariant()
                        .Trim();
        }

        private string LayDoKhoGoiY(double tyLeSai, int nguongDeMaxSai, int nguongKhoMinSai)
        {
            if (tyLeSai*100 <= nguongDeMaxSai) return "Dễ";
            if (tyLeSai*100 >= nguongKhoMinSai) return "Khó";
            return "Trung bình";
        }
        #endregion

        #region Lấy dữ liệu
        public CauHoiDTO? GetById(long maCauHoi) => _cauHoiDAL.GetById(maCauHoi);

        public List<DapAnDTO> GetDapAn(long maCauHoi) => _dapAnBLL.GetByCauHoi(maCauHoi);

        public List<(DapAnDTO, bool)> GetDapAnWithUsage(long maCauHoi)
               => _dapAnBLL.GetWithUsage(maCauHoi);


        public List<CauHoiDTO> GetAllForDisplay(
           long maMH = 0, long maChuong = 0, string doKho = "", string tuKhoa = "")
        {
            var list = _cauHoiDAL.GetAllForDisplay(_maND);
            string keywordNormalized = string.IsNullOrEmpty(tuKhoa) ? "" : Normalize(tuKhoa);

            HashSet<long>? dsChuong = null;
            if (maMH > 0)
                dsChuong = _chuongBLL.GetChuongByMonHoc(maMH)
                                    .Select(ch => ch.MaChuong)
                                    .ToHashSet();

            return list.Where(c =>
                (dsChuong == null || dsChuong.Contains(c.MaChuong)) &&
                (maChuong == 0 || c.MaChuong == maChuong) && // lọc theo chương
                (string.IsNullOrEmpty(doKho) || c.DoKho == doKho) && // lọc theo độ khó 
                (string.IsNullOrEmpty(keywordNormalized) || Normalize(c.NoiDung).Contains(keywordNormalized)) // lọc theo từ khóa 
            ).ToList();
        }
        #endregion

        #region Thêm, sửa, xóa
        public long ThemMoi(long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            long maCauHoi = _cauHoiDAL.ThemMoi(maChuong, noiDung, doKho, dapAnList);
            if (dapAnList?.Count > 0)
            {
                dapAnList.ForEach(da => da.MaCauHoi = maCauHoi);
                _dapAnBLL.ThemDapAn(dapAnList);
            }
            return maCauHoi;
        }

        public void CapNhat(long maCauHoi, long maChuong, string noiDung, string doKho, List<DapAnDTO> dapAnList)
        {
            _cauHoiDAL.CapNhat(maCauHoi, maChuong, noiDung, doKho, dapAnList);
        }

        public void Xoa(long maCauHoi) => _cauHoiDAL.Xoa(maCauHoi);

        public void CapNhatDoKho(long maCauHoi, string doKhoMoi)
        {
            if (string.IsNullOrEmpty(doKhoMoi))
                throw new ArgumentException("Độ khó mới không được để trống.");

            _cauHoiDAL.CapNhatDoKho(maCauHoi, doKhoMoi);
        }
        #endregion

        #region Trùng lặp & thống kê
        public List<CauHoiTrungLapDTO> LayCauHoiTrungLap()
        {
            var all = _cauHoiDAL.GetAllForDisplayTrungLap(_maND);
            return all
                .GroupBy(ch => new { NoiDungChuanHoa = Normalize(ch.NoiDung), ch.MaMonHoc }) // nội dung chuẩn hóa và cùng môn học
               .Where(nhom => nhom.Count() > 1)
                .Select(nhom =>
                {
                    var danhSach = nhom.OrderByDescending(x => x.MaCauHoi).ToList(); // Sắp xếp câu theo MaCauHoi giảm dần
                    return new CauHoiTrungLapDTO
                    {
                        Key = nhom.Key.NoiDungChuanHoa,     
                        SoLuong = nhom.Count(),
                        DanhSach = danhSach,
                        TacGia = danhSach.First().TacGia
                    };
                })
                .OrderByDescending(nhom => nhom.SoLuong) // Nhóm có nhiều câu trùng hơn sẽ đứng trước
                .ThenBy(nhom => nhom.DanhSach.First().MaCauHoi)
                .ToList();
        }

        public (int nhomTrung, int cauTrung, int cauDuyNhat) LayThongKeTrungLap()
        {
            var all = _cauHoiDAL.GetAllForDisplayTrungLap(_maND);
            var duplicateGroups = all
                .GroupBy(ch => new { Key = Normalize(ch.NoiDung), ch.MaMonHoc })
                .Where(g => g.Count() > 1);

            int nhomTrung = duplicateGroups.Count();
            int cauTrung = duplicateGroups.Sum(g => g.Count() - 1);
            int cauDuyNhat = all.Count - (nhomTrung + cauTrung);

            return (nhomTrung, cauTrung, cauDuyNhat);
        }
        #endregion

        #region Tính toán & gợi ý độ khó
        public List<CauHoiDTO> TinhToanVaDeXuatDoKho(long maMonHoc, int minLuotLam, int nguongDeMaxSai, int nguongKhoMinSai)
        {
            return _cauHoiDAL.LayThongKeDoKho(maMonHoc)
                .Where(ch => ch.SoLuotLam >= minLuotLam)
                .Select(ch =>
                {
                    ch.DoKhoGoiY = LayDoKhoGoiY(ch.TyLeSai, nguongDeMaxSai, nguongKhoMinSai);
                    return ch;
                })
                .OrderByDescending(ch => ch.DoKho != ch.DoKhoGoiY)
                .ThenByDescending(ch => ch.TyLeSai)
                .ToList();
        }
        #endregion
    }
}
