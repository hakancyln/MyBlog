using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
	public interface IUserService : IGenericService<UserCrudDTO, UserGetDTO>
	{
		Task<ApiResponse<bool>> UpdateUserAsync(UserCrudDTO Entity);
		Task<ApiResponse<LoginGetDTO>> LoginAsync(LoginCrudDTO Entity);


	}
}
