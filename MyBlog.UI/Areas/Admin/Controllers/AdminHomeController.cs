using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
