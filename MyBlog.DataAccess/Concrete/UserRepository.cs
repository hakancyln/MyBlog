using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.DataAccess.Concrete
{
	internal class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(DbContext context) : base(context)
		{
		}
	}
}
