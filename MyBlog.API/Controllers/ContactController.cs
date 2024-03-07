using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;

namespace MyBlog.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	[Authorize]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _service;

		public ContactController(IContactService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> GetAll()
		{
			var value = await _service.GetAllAsync();
			return Ok(value);
		}
        [HttpPost("{id}")]
        public async Task<IActionResult> GetOne(int id)
		{
			var deneme = new ContactGetDTO();
			deneme.Id = id;
			var value = await _service.GetAsync(id, x => true);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(ContactCrudDTO about)
		{
			ApiResponse<ContactGetDTO> value;
			if (about.Id == 0)
			{
				value = await _service.AddAsync(about);
				return Ok(value);
			}
			value = await _service.UpdateAsync(about);
			return Ok(value);
		}
        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(int id)
		{

			var value = await _service.RemoveAsync(id);
			return Ok(value);
		}
	}
}
