namespace DTO
{
    public class DeThiDTO
    {
        public long MaDe { get; set; }
        public string TenDe { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public int ThoiGianLamBai { get; set; }
        public int CanhBaoNeuDuoi { get; set; }
        public int SoCauDe { get; set; }    
        public int SoCauTrungBinh { get; set; }
        public int SoCauKho { get; set; }
        public int TrangThai { get; set; }
        public List<long> NhomHocPhanIds { get; set; }
        public List<long> ChuongIds { get; set; }
        public DeThiCauHinhDTO CauHinh { get; set; }
        public string TenNhomHocPhan { get; set; }

    }
}
