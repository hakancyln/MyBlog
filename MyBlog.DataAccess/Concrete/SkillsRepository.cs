using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.DataAccess.Concrete
{
	internal class SkillsRepository : Repository<Skills>, ISkillsRepository
	{
		public SkillsRepository(DbContext context) : base(context)
		{
		}
	}
}
