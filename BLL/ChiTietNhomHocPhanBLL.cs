using DAL;
using DocumentFormat.OpenXml.Bibliography;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietNhomHocPhanBLL
    {

        public static bool ThemSinhVienVaoNhom(string maND, long maNhom)
            => ChiTietNhomHocPhanDAL.Instance.ThemSinhVienVaoNhom(maND, maNhom);

        public static bool DaTonTaiTrongNhom(string maND, long maNhom)
            => ChiTietNhomHocPhanDAL.Instance.DaTonTaiTrongNhom(maND, maNhom);

        public static DataTable LayDanhSachSinhVienTrongNhom(long maNhom)
            => ChiTietNhomHocPhanDAL.Instance.LayDanhSachSinhVienTrongNhom(maNhom);

        public static bool XoaSinhVienKhoiNhom(string maND, long maNhom)
            => ChiTietNhomHocPhanDAL.Instance.XoaSinhVienKhoiNhom(maND, maNhom);
        public List<long> GetNhomHocPhanIdsByUser(string maNd)   {
            return ChiTietNhomHocPhanDAL.Instance.GetNhomHocPhanIdsByUser(maNd);
        }


    }
}
