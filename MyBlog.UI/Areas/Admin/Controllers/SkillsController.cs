using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using System.Security.Policy;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillsController : BaseController
    {
        private readonly string url = "https://localhost:7200/";

        public SkillsController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet("/admin/yeteneklerim")]
        public async Task<IActionResult> Skills()
        {
            UIResponse<IEnumerable<SkillsGetDTO>> data = await GetAllAsync<SkillsGetDTO>(url + "Skills/GetAll");
            return View(data);
        }
        [HttpPost("/CrudSkills")]
        public async Task<IActionResult> CrudSkills(SkillsCrudDTO p)
        {
            var data = await CrudAsync(p, url + "Skills/AddOrUpdate");

            if (data != null)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
        }
        [HttpPost("/DeleteSkills")]
        public async Task<IActionResult> DeleteSkills(int id)
        {
            var data = await DeleteAsync(url + "Skills/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
