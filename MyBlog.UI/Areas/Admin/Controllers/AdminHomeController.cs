using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminHomeController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly HttpClient _httpClient;


        public AdminHomeController(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/LogInfo")]
        public async Task<IActionResult> LogInfo(LoginCrudDTO p)
        {
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7200/User/Login", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "bht4jythuy" });

            }
            return Json(new { success = false, responseText = "Kullanıcı Adı yada şifre yanlış." });

        }
        [HttpPost("/LogUpdate")]
        public async Task<IActionResult> LogUpdate(UserCrudDTO p)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7200/User/AddOrUpdate", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync();
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return Json(new { success = true, redirectUrl = Url.Action("Login", "Home") });
            }
            return Json(new { success = false, responseText = "Kullanıcı Adı yada şifre yanlış." });

        }

    }
}
