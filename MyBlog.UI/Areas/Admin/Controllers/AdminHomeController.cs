using Azure;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : BaseController
    {
        private readonly string url = "https://localhost:7200/";

        public AdminHomeController(HttpClient httpClient) : base(httpClient)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/About")]
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
                var data = await UpdateAsync<AboutCrudDTO>(p, url + "About/AddOrUpdate");
                
                if (data != null)
                {
                    ViewBag.Success = Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" }); ;
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                ViewBag.Error = Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });
            }
            else
            {
                var data = await UpdateAsync<AboutCrudDTO>(p, url + "About/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });

            }
        }

        [HttpGet("/Portfolio")]
        public async Task<IActionResult> Portfolio()
        {
            UIResponse<PortfolioGetDTO> data = await GetAsync<PortfolioGetDTO>(url + "Portfolio/GetAll");
            return View(data);
        }
        [HttpPost("/CrudPortfolio")]
        public async Task<IActionResult> CrudPortfolio(PortfolioCrudDTO p)
        {
            var data = await UpdateAsync<PortfolioCrudDTO>(p, url + "Portfolio/GetAll");

            return RedirectToAction();
        }
    }
}
