using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

namespace MyBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;


        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/girisyap")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Log")]
        public async Task<IActionResult> Log(LoginCrudDTO p)
        {
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7200/User/Login", stringContent);
            if (ModelState.IsValid)
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonDataw = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UIResponse<LoginGetDTO>>(jsonDataw);
                    HttpContext.Session.SetString("Token", value.Data.Token);
                    HttpContext.Session.SetString("UserName", value.Data.UserName);
                   
                    var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/About/GetOne/1", null);
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<UIResponse<AboutGetDTO>>(jsonData2);
                    HttpContext.Session.SetString("NameSurname", value2.Data.NameSurname);
                    HttpContext.Session.SetString("Photo", value2.Data.Photo);

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, value.Data.UserName));
                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Json(new { success = true, redirectTo = Url.Action("Contact", "Contact", new { area = "Admin" }) });

                }
            }
            return Json(new { success = false, responseText = "Kullanýcý Adý yada þifre yanlýþ." });

        }
        [HttpPost("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Home");
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
        [HttpGet("/Error404")]
        public async Task<IActionResult> Error404()
        {
            return View();
        }
    }
}
