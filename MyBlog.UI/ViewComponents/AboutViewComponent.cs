using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;

namespace MyBlog.UI.ViewComponents
{
	public class AboutViewComponent : ViewComponent
	{
		private readonly HttpClient _httpClient;

		public AboutViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7200/About/GetOne/1", null);
			var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/Skills/GetAll", null);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<AboutGetDTO>>(jsonData);
				var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<SkillsGetDTO>>>(jsonData2);
				AboutModel model = new AboutModel()
				{
					About = value,
					Skills = value2
				};
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return View(model);
			}

			return View();
		}
	}
}
