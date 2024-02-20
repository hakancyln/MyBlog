using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
	public interface IUserService : IGenericService<UserCrudDTO, UserGetDTO>
	{
	}
}
