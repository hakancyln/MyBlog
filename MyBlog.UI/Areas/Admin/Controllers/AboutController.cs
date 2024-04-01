using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using Newtonsoft.Json.Linq;
using System.Security.Policy;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AboutController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet("/admin/hakkimda")]
        public async Task<IActionResult> About(AboutCrudDTO p)
        {

            UIResponse<AboutGetDTO> data = await GetAsync<AboutGetDTO>(url + "About/GetOne/1");
            if (data==null)
            {
                return View();

            }
            return View(data);

        }


        [HttpPost("/UpdateAbout")]
        public async Task<JsonResult> UpdateAbout(AboutCrudDTO p, IFormFile ImageFile)
        {
            p.Id = 1;
            if (ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                p.Photo = uniqueFileName;
                var data = await CrudAsync(p, url + "About/AddOrUpdate");

                if (data != null)
                {
                    HttpContext.Session.SetString("NameSurname", p.NameSurname);
                    HttpContext.Session.SetString("Photo", p.Photo);
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });
            }
            else
            {
                var data = await CrudAsync(p, url + "About/AddOrUpdate");
                if (data.Success == true)
                {
                    HttpContext.Session.SetString("NameSurname", p.NameSurname);
                    HttpContext.Session.SetString("Photo", p.Photo);
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });

            }
        }
    }
}
