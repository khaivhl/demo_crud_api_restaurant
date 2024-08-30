using APIMonAn.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMonAn.Services;
using APIMonAn.Entities;

namespace APIMonAn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonAnController : ControllerBase
    {
        private readonly MonAnIServices services;

        public MonAnController()
        {
            services = new MonAnServices();
        }
        [HttpPost]  
        public IActionResult ThemMonAn([FromBody] MonAn monAn)
        {
            services.ThemMonAn(monAn);
            return Ok();
        }
        [HttpPut]
        public IActionResult SuaMonAn([FromBody]MonAn monAn)
        {
            services.SuaMonAn(monAn);
            return Ok();
        }
        [HttpDelete]
        public IActionResult XoaMonAn([FromQuery] int monAnId)
        {
            services.XoaMonAn(monAnId);
            return Ok();
        }
        //public IActionResult LayDSMonAn([FromQuery]string? tenMonAn,[FromQuery]string? nguyenLieuMonAn)
        //{
        //    var dsmonan = services.LayDsMonAn(tenMonAn, nguyenLieuMonAn);
        //    return Ok(dsmonan);
        //}
        
    }
}
