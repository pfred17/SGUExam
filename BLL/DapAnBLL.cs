using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class DapAnBLL
    {
        private readonly DapAnDAL _dal = new DapAnDAL();

        public List<DapAnDTO> GetByCauHoi(long maCauHoi)
        {
            return _dal.GetByCauHoi(maCauHoi);
        }
        // Thêm danh sách đáp án
        public void ThemDapAn(List<DapAnDTO> list)
            => _dal.ThemDapAn(list);

        // Cập nhật 1 đáp án
        public void CapNhat(DapAnDTO da)
            => _dal.CapNhat(da);

        // Xóa 1 đáp án (DAL đã tự kiểm tra ràng buộc)
        public void Xoa(long maDapAn)
            => _dal.Xoa(maDapAn);

        // Kiểm tra đáp án đã được sử dụng trong bài làm chưa
        public bool CheckSuDung(long maDapAn)
            => _dal.CheckDapAnSuDung(maDapAn);

        // Lấy đáp án + trạng thái sử dụng (tiện cho giao diện)
        public List<(DapAnDTO DapAn, bool DaDuocSuDung)> GetWithUsage(long maCauHoi)
        {
            var list = _dal.GetByCauHoi(maCauHoi);
            var result = new List<(DapAnDTO, bool)>();

            foreach (var da in list)
                result.Add((da, _dal.CheckDapAnSuDung(da.MaDapAn)));

            return result;
        }
    }
}

