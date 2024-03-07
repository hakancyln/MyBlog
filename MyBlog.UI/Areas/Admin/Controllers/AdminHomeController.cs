using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
    }
}
