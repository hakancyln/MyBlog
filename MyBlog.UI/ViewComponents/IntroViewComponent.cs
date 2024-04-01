using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Models;
using Newtonsoft.Json;

namespace MyBlog.UI.ViewComponents
{
	public class IntroViewComponent:ViewComponent
	{
		private readonly HttpClient _httpClient;

		public IntroViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var responseMessage = await _httpClient.PostAsync("https://localhost:7200/About/GetOne/1", null);
			var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/Social/GetAll", null);

			if (responseMessage.IsSuccessStatusCode&& responseMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<AboutGetDTO>>(jsonData);
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<SocialGetDTO>>>(jsonData2);
				IntroModel model = new IntroModel();
				model.Social = value2;
				model.About = value;
				return View(model);
			}

			return View();
		}
	}
}
