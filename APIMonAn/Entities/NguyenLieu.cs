using System.ComponentModel.DataAnnotations;

namespace APIMonAn.Entities
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        public string TenNguyenLieu { get; set; }
        [MaxLength(20)]
        List<CongThuc> CongThuc { get; set; }
    }
}
