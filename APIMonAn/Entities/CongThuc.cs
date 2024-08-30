using System.ComponentModel.DataAnnotations;

namespace APIMonAn.Entities
{
    public class CongThuc
    {
        public int CongThucId { get; set; }
        public int? MonAnId { get; set; }
        public int? NguyenLieuId { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public MonAn? MonAn { get; set; }
        public NguyenLieu? NguyenLieu { get; set; }
    }
}
