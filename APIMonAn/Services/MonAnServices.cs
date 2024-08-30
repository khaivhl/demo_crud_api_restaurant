using APIMonAn.Entities;
using APIMonAn.IServices;
using Microsoft.EntityFrameworkCore;
using services.AddSingleton<..>;

namespace APIMonAn.Services
{
    public class MonAnServices : MonAnIServices
    {
        private readonly AppDbContext dbContext;

        public MonAnServices()
        {
            dbContext = new AppDbContext();
        }

        public List<MonAn> LayDsMonAn(string tenMon, string tenNguyenLieu)
        {
            var lst = dbContext.MonAn.Include(x => x.CongThuc).ThenInclude(x => x.NguyenLieu).ToList();
            if (!string.IsNullOrEmpty(tenMon))
            {
                lst = lst.Where(x => x.TenMon.ToLower().Contains(tenMon.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(tenNguyenLieu))
            {
                lst = lst.Where(x => x.CongThuc.Any(y => y.NguyenLieu.TenNguyenLieu.ToLower().Contains(tenNguyenLieu.ToLower()))).ToList();
            }
            return lst;
        }

        public void SuaMonAn(MonAn monAn)
        {
            using ( var tran = dbContext.Database.BeginTransaction())
            {
                    if (dbContext.MonAn.Any(x=>x.MonAnId==monAn.MonAnId))
                    {
                        if (monAn.CongThuc == null || monAn.CongThuc.Count() == 0)
                        {
                            var lstCongThucHienTai = dbContext.CongThuc.Where(x => x.MonAnId == monAn.MonAnId);
                            dbContext.RemoveRange(lstCongThucHienTai);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var lstCongThucHienTai = dbContext.CongThuc.Where(x => x.MonAnId == monAn.MonAnId);
                            var lstCongThucDelete = new List<CongThuc>();
                            foreach (var congthuc in lstCongThucHienTai)
                            {
                                if (!monAn.CongThuc.Any(x => x.MonAnId == congthuc.MonAnId))
                                {
                                    lstCongThucDelete.Add(congthuc);
                                }
                                else
                                {
                                    var congthucmoi = monAn.CongThuc.FirstOrDefault(x => x.CongThucId == congthuc.CongThucId);
                                    var nguyenlieumoi = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuId == congthucmoi.NguyenLieuId);
                                    congthuc.SoLuong = congthucmoi.SoLuong;
                                    congthuc.DonViTinh = congthucmoi.DonViTinh;
                                    monAn.CachLam += nguyenlieumoi.TenNguyenLieu + congthuc.SoLuong + congthuc.DonViTinh + ";";
                                    dbContext.Update(congthuc);
                                    dbContext.SaveChanges();
                                }
                            }
                            dbContext.RemoveRange(lstCongThucDelete);
                            dbContext.SaveChanges();
                            foreach (var chitiet in monAn.CongThuc)
                                {
                                if (!lstCongThucHienTai.Any(x=>x.MonAnId==chitiet.MonAnId))
                                {
                                     chitiet.MonAnId = monAn.MonAnId;
                                }
                            }
                        }
                        monAn.CongThuc = null;
                        dbContext.Update(monAn);
                        dbContext.SaveChanges();
                        tran.Commit();
                    }
                    else
                    {
                        tran.Rollback();
                        throw new Exception("mon an khong ton tai");
                    }
                    
            }
        }

        public void ThemMonAn(MonAn monAn)
        {
            using (var tran = dbContext.Database.BeginTransaction())
            {

                if (dbContext.LoaiMonAn.Any(x => x.LoaiMonAnId == monAn.LoaiMonAnId))
                {
                    var lstCongThucMonAn = monAn.CongThuc;
                    monAn.CongThuc = null;
                    dbContext.Add(monAn);
                    dbContext.SaveChanges();
                    foreach (var congthuc in lstCongThucMonAn)
                    {
                        //if ( dbContext.NguyenLieu.Any(x => x.NguyenLieuId == congthuc.NguyenLieuId))
                        //{
                            congthuc.MonAnId = monAn.MonAnId;
                            dbContext.CongThuc.Add(congthuc);
                            var monancanthem = dbContext.MonAn.FirstOrDefault(x=>x.MonAnId==congthuc.MonAnId);
                            var nguyenlieucanthem = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuId == congthuc.NguyenLieuId);
                            monancanthem.CachLam += nguyenlieucanthem.TenNguyenLieu + congthuc.SoLuong + congthuc.DonViTinh + ";";
                            dbContext.MonAn.Update(monancanthem);
                           
                        //}
                        //else
                        //{
                        //    tran.Rollback();
                        //    throw new Exception(" nguyen lieu khong ton tai");
                        //}
                    }
                    dbContext.SaveChanges();
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                    throw new Exception("Loai mon khong ton tai");
                }
            }
        }

        public void XoaMonAn(int monAnId)
        {
            using (var tran = dbContext.Database.BeginTransaction())
            {
                var ma = dbContext.MonAn.FirstOrDefault(x => x.MonAnId == monAnId);
                if (ma!=null)
                {
                    dbContext.Remove(ma);
                    dbContext.SaveChanges();
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                    throw new Exception("Loai mon an id khong ton tai");
                }
            }
        }

        
    }
}
