using System.ComponentModel.DataAnnotations;

namespace APIMonAn.Entities
{
    public class MonAn
    {
        public int MonAnId { get; set; }

        public string TenMon { get; set; }
        public int LoaiMonAnId { get; set; }
        public int GiaBan { get; set; }
        public string GioiThieu { get; set; }
        public string? CachLam { get; set; }
        public LoaiMonAn? LoaiMonAn { get; set; }
        public List<CongThuc> CongThuc { get; set; }
    }
}
