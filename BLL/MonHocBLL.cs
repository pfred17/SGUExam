using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class MonHocBLL
    {
        private readonly MonHocDAL _dal = new MonHocDAL();
        public List<MonHocDTO> GetAllMonHocByStatus(int? trangThai = null)
        {
            return _dal.GetAllMonHocByStatus(trangThai);
        }
        public bool IsMonHocExists(long maMonHoc)
        {
            return _dal.IsMonHocExists(maMonHoc);
        }
        public MonHocDTO GetMonHocById(long maMonHoc)
        {
            return _dal.GetMonHocById(maMonHoc);
        }
        public long AddMonHoc(MonHocDTO monHoc)
        {
            return _dal.AddMonHoc(monHoc);
        }
        public bool IsMonHocReferenced(long maMonHoc)
        {
            return _dal.IsMonHocReferenced(maMonHoc);
        }
        public bool UpdateStatus(long maMonHoc, int trangThai)
        {
            return _dal.UpdateStatus(maMonHoc, trangThai);  
        }
        public int GetStatus(long maMonHoc)
        {
            return _dal.GetStatus(maMonHoc);
        }
        public bool UpdateMonHoc(MonHocDTO monHoc)
        {
            return _dal.UpdateMonHoc(monHoc);
        }
        public bool DeleteMonHoc(long maMonHoc)
        {
            return _dal.DeleteMonHoc(maMonHoc);
        }
        public List<MonHocDTO> GetMonHocPaged(int page, int pageSize, string? keyword = null, int? trangThai = null)
        {
            return _dal.GetMonHocPaged(page, pageSize, keyword, trangThai);
        }
        public int GetTotalMonHoc(string? keyword = null, int? trangThai = null)
        {
            return _dal.GetTotalMonHoc(keyword, trangThai);
        }
    }
}
