using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SocialController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SocialController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet("/Admin/Social")]
        public async Task<IActionResult> Social()
        {
            UIResponse<List<SocialGetDTO>> data = await GetAllAsync<SocialGetDTO>(url + "Social/GetAll");
            return View(data);
        }
        [HttpPost("/CrudSocial")]
        public async Task<IActionResult> CrudSocial(SocialCrudDTO p, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                p.Image = uniqueFileName;
                var data = await CrudAsync(p, url + "Social/AddOrUpdate");

                if (data != null)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
            }
            else
            {
                var data = await CrudAsync(p, url + "Social/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

            }

        }
        [HttpPost("/DeleteSocial")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            var data = await DeleteAsync(url + "Social/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
