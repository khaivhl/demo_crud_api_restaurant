using System.ComponentModel.DataAnnotations;

namespace APIMonAn.Entities
{
    public class LoaiMonAn
    {
        public int LoaiMonAnId { get; set; }

        public string TenLoai { get; set; }
        [MaxLength(20)]
        List<MonAn> MonAn { get; set; }
    }
}
