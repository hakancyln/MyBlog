using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using System.Security.Policy;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        public ContactController(HttpClient httpClient) : base(httpClient)
        {

        }
        
        [HttpGet("/Admin/Contact")]
        public async Task<IActionResult> Contact()
        {
            UIResponse<List<ContactGetDTO>> data = await GetAllAsync<ContactGetDTO>(url + "Contact/GetAll");
            return View(data);
        }
        [AllowAnonymous]
        [HttpPost("/CrudContact")]
		public async Task<IActionResult> CrudContact(ContactCrudDTO p)
		{
			var data = await CrudAsync(p, url + "Contact/AddOrUpdate");

			if (data != null)
			{
				return Json(new { success = true, responseText = " İşlem Başarılı" });
			}
			return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
		}

		[HttpPost("/DeleteContact")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var data = await DeleteAsync(url + "Contact/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
