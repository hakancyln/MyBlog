using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.DataAccess.Concrete.Context;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete.DataManagement
{
	public class UnitOfWork : IUnitOfWork
	{
		private Dictionary<Type, object> _repositories;
		private readonly MyBlogContext _context;

		public UnitOfWork(MyBlogContext context)
		{
			_repositories = new Dictionary<Type, object>();
			_context = context;
		}
		public async Task<bool> SaveChangesAsync()
		{
			var result = false;

			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
					result = true;
				}
				catch
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
			return result;
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{		
			if (_repositories.ContainsKey(typeof(IRepository<T>)))
			{
				return (IRepository<T>)_repositories[typeof(IRepository<T>)];
			}

			var repository = new Repository<T>(_context);
			_repositories.Add(typeof(IRepository<T>), repository);
			return repository;
		}
	}
}
