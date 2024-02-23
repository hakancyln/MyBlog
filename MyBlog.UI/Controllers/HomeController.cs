using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;

namespace MyBlog.UI.Controllers
{
	public class HomeController : BaseController
    {
		public HomeController(HttpClient httpClient) : base(httpClient)
		{
		}

		public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Head()
        {
            return PartialView();
        }
		public async Task<PartialViewResult> Contact()
		{
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Message()
        {
            return Ok("OK");
        }
    }
}
