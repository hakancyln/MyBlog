using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.UserDTO
{
	public class UserCrudDTO
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
