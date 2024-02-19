using MyBlog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MyBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Head()
        {
            return PartialView();
        }

		public async Task<PartialViewResult> Intro()
		{
			return PartialView();
		}

		public async Task<PartialViewResult> About()
		{
			return PartialView();
		}

		public async Task<PartialViewResult> Resume()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> Portfolio()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> Service()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> Contact()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> Footer()
		{
			return PartialView();
		}
	}
}
