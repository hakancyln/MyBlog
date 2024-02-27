using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
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
        public async Task<IActionResult> About()
        {
            UIResponse<AboutGetDTO> data= await GetAsync<AboutGetDTO>(url+ "About/GetOne/1");
            return View(data);
        }
        [HttpPost("/UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(AboutCrudDTO data)
        {
            data.Id = 1;
            
            return RedirectToAction();
        }
    }
}
