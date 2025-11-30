using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class MonHocBLL
    {
        private readonly MonHocDAL _dal = new MonHocDAL();
        public List<MonHocDTO> GetAllMonHoc()
        {
            return _dal.GetAllMonHoc();
        }
        public bool IsMonHocExists(long maMH)
        {
            return _dal.IsMonHocExists(maMH);
        }
        public MonHocDTO? GetMonHocById(long maMonHoc)
        {
            return _dal.GetMonHocById(maMonHoc);
        }
        public long AddMonHoc(MonHocDTO monHoc)
        {
            return _dal.AddMonHoc(monHoc);
        }
        public bool UpdateMonHoc(MonHocDTO monHoc)
        {
            return _dal.UpdateMonHoc(monHoc);
        }
        public bool DeleteMonHoc(long monHocId)
        {
            return _dal.DeleteMonHoc(monHocId);
        }
        public bool IsMonHocReferenced(long maMH)
        {
            return _dal.IsMonHocReferenced(maMH); 
        }
        public List<MonHocDTO> GetMonHocPaged(int page, int pageSize, string? keyword = null)
        {
            return _dal.GetMonHocPaged(page, pageSize, keyword);
        }
        public int GetTotalMonHoc(string? keyword = null)
        {
            return _dal.GetTotalMonHoc(keyword);
        }
    }
}
