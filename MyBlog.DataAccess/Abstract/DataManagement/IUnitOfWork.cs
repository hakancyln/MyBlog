using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Abstract.DataManagement
{
	public interface IUnitOfWork
	{
		public IRepository<T> GetRepository<T>() where T : BaseEntity;
		public Task<bool> SaveChangesAsync();
	}
}