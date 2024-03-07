using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : BaseController
    {
        private readonly string url = "https://localhost:7200/";

        public AboutController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet("/Admin/About")]
        public async Task<IActionResult> About(AboutCrudDTO p)
        {

            UIResponse<AboutGetDTO> data = await GetAsync<AboutGetDTO>(url + "About/GetOne/1");
            return View(data);

        }


        [HttpPost("/UpdateAbout")]
        public async Task<JsonResult> UpdateAbout(AboutCrudDTO p)
        {
            p.Id = 1;
            if (p.Photo == null)
            {
                UIResponse<AboutGetDTO> data2 = await GetAsync<AboutGetDTO>(url + "About/GetOne/1");
                p.Photo = data2.Data.Photo;
                var data = await CrudAsync(p, url + "About/AddOrUpdate");

                if (data != null)
                {
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });
            }
            else
            {
                var data = await CrudAsync(p, url + "About/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });

            }
        }
    }
}
