using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PortfolioController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PortfolioController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        [HttpGet("/Admin/Portfolio")]
        public async Task<IActionResult> Portfolio()
        {
            UIResponse<IEnumerable<PortfolioGetDTO>> data = await GetAllAsync<PortfolioGetDTO>(url + "Portfolio/GetAll");
            return View(data);
        }
        [HttpPost("/CrudPortfolio")]
        public async Task<IActionResult> CrudPortfolio(PortfolioCrudDTO p, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images/portfolio", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                p.Image = uniqueFileName;
                var data = await CrudAsync(p, url + "Portfolio/AddOrUpdate");

                if (data != null)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
            }
            else
            {
                var data = await CrudAsync(p, url + "Portfolio/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

            }

        }
        [HttpPost("/DeletePortfolio")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var data = await DeleteAsync(url+ "Portfolio/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
