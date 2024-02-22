using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
	public class UserManager : GenericManager<UserCrudDTO, UserGetDTO, User>, IUserService
	{
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		public UserManager(IMapper mapper, IUnitOfWork uow, IConfiguration configuration) : base(mapper, uow)
		{
			_uow = uow;
			_mapper = mapper;
			_configuration = configuration;
		}


		public async Task<ApiResponse<LoginGetDTO>> LoginAsync(LoginCrudDTO Entity)
		{
			var result = new ApiResponse<LoginGetDTO>();
			var data = await _uow.GetRepository<User>().GetAsync(x => x.Id == 1);
			var mappdata = _mapper.Map<LoginGetDTO>(data);


			if (data.UserName==Entity.UserName && BCrypt.Net.BCrypt.Verify(Entity.Password, data.Password))
			{

				var secretKey = _configuration["JWT:Token"];
				var issuer = _configuration["JWT:Issuer"];
				var audiance = _configuration["JWT:Audiance"];


				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.UTF8.GetBytes(secretKey);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Audience = audiance,
					Issuer = issuer,
					Expires = DateTime.Now.AddDays(20), // Token süresi (örn: 20 dakika)
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);

				LoginGetDTO loginGetDTO = new()
				{
					UserName = mappdata.UserName,
					Token = tokenHandler.WriteToken(token),
				};

				result.Data = loginGetDTO;
				return result;
			}
			result.Success = false;
			return result;
			
		}

		public async Task<ApiResponse<bool>> UpdateUserAsync(UserCrudDTO Entity)
		{
			var result = new ApiResponse<bool>();
			var data = _mapper.Map<User>(Entity);
			data.Password=BCrypt.Net.BCrypt.HashPassword(Entity.Password);
			await _uow.GetRepository<User>().UpdateAsync(data);
			result.Data = await _uow.SaveChangesAsync();
			return result;
		}
	}
}
