using APIMonAn.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMonAn.Entities
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<CongThuc> CongThuc { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = DESKTOP-GAKP3K6; Database = APIMonAn; Trusted_Connection = True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}
