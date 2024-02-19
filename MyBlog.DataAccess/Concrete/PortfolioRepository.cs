using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.DataAccess.Concrete
{
	public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
	{
		public PortfolioRepository(DbContext context) : base(context)
		{
		}
	}
}
