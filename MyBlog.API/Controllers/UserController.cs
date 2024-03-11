using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;

namespace MyBlog.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //[HttpPost]
        //public async Task<IActionResult> GetAll()
        //{
        //	var value = await _service.GetAllAsync();
        //	return Ok(value);
        //}
        [HttpPost]
        public async Task<IActionResult> GetOne()
        {
            int id = 1;
            var value = await _service.GetAsync(id, x => true);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCrudDTO data)
        {
            var value = await _service.LoginAsync(data);
            if (value.Success)
            {
                return Ok(value);

            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(UserCrudDTO data)
        {
            data.Id = 1;
            ApiResponse<UserGetDTO> value;
            if (data.Id == 0)
            {
                value = await _service.AddAsync(data);
                return Ok(value);
            }
            value = await _service.UpdateUserAsync(data);
            return Ok(value);
        }
        //[HttpPost]
        //public async Task<IActionResult> Remove(int id)
        //{

        //	var value = await _service.RemoveAsync(id);
        //	return Ok(value);
        //}
    }
}
