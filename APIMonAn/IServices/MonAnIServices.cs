using APIMonAn.Entities;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;

namespace APIMonAn.IServices
{
    public interface MonAnIServices
    {
        public void ThemMonAn(MonAn monAn);
        public void SuaMonAn(MonAn manAn);
        public void XoaMonAn(int monAnId);
        public List<MonAn> LayDsMonAn(string? tenMon, string? tenNguyenLieu);
    }
}
