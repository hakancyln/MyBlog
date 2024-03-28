using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Result;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using MyBlog.Entity.DTO.PortfolioDTO;
using Newtonsoft.Json;
using System;
using MyBlog.UI.Controllers;

namespace MyBlog.UI.Areas.Admin.ViewComponents
{
    
    public class MessageViewComponent: ViewComponent 
    {
        private readonly HttpClient _httpClient;

        public MessageViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
            var responseMessage = await _httpClient.PostAsync("https://localhost:7200/Contact/GetAll", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<ContactGetDTO>>>(jsonData);
                //_httpClient.DefaultRequestHeaders.Remove("Authorization");
                value.Data=value.Data.OrderBy(x=>x.Date);
                return View(value);
            }

            return View();
        }
    }
}
