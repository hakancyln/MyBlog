using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Result;
using Newtonsoft.Json;

namespace MyBlog.UI.ViewComponents
{
	public class PortfolioViewComponent:ViewComponent
	{
		private readonly HttpClient _httpClient;

		public PortfolioViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7200/Portfolio/GetAll", null);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<PortfolioGetDTO>>>(jsonData);
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return View(value);
			}

			return View();
		}
	}
}
