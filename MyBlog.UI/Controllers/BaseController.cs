using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Result;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MyBlog.UI.Controllers
{
	public class BaseController: Controller
	{
		private readonly HttpClient _httpClient;
		public BaseController(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("http://localhost:7075/api/");
		}
		public  async Task<UIResponse<T>> UpdateAsync<T>(T p, string url) where T : class
		{
			_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var jsonData = JsonConvert.SerializeObject(p);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync(url, stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonDataw = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<T>>(jsonDataw);
				_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return value;
			}

			return null;
		}
		protected async Task<UIResponse<T>> AddAsync<T>(T p, string url) where T : class
		{
			_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var jsonData = JsonConvert.SerializeObject(p);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync(url, stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonDataw = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<T>>(jsonDataw);
				_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return value;
			}
			var jsonDataw2 = await responseMessage.Content.ReadAsStringAsync();
			var value2 = JsonConvert.DeserializeObject<UIResponse<T>>(jsonDataw2);
			_httpClient.DefaultRequestHeaders.Remove("Authorization");
			return value2;
		}
		protected async Task<bool> DeleteAsync(string url)
		{
			_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));

			HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
			if (responseMessage.IsSuccessStatusCode)
			{
				_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return true;
			}

			return false;
		}
		protected async Task<UIResponse<List<T>>> GetAllAsync<T>(string url) where T : class
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<List<T>>>(jsonData);
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return value;


			}
			else if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
			{
				_httpClient.DefaultRequestHeaders.Remove("Authorization");
				var forbiddenResponse = new UIResponse<List<T>>
					(
						data: null,
						statustCode: 401,
						succes: false,
						message: "Yetkisiz"
					);

				return forbiddenResponse;

			}
			else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
			{
				_httpClient.DefaultRequestHeaders.Remove("Authorization");
				var unauthorizedResponse = new UIResponse<List<T>>
					(
						data: null,
						statustCode: 401,
						succes: false,
						message: "Oturum Açılmadı"
					);

				return unauthorizedResponse;

			}

			return null;
		}
		protected async Task<UIResponse<T>> GetAsync<T>(string url) where T : class
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync(url,null);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<T>>(jsonData);
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return value;
			}

			return null;
		}
	}
}
