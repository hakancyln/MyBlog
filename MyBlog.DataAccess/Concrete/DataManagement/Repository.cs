using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete.DataManagement
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(DbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<EntityEntry<T>> AddAsync(T Entity)
		{
			return await _dbSet.AddAsync(Entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)
		{
			IQueryable<T> query = _dbSet;


			if (Filter != null)
			{
				query = query.Where(Filter);
			}
			if (IncludeProperties.Length > 0)
			{
				foreach (string includeProperty in IncludeProperties)
				{
					query = query.Include(includeProperty);
				}
			}
			return await Task.Run(() => query);

		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
		{
			IQueryable<T> query = _dbSet;

			if (IncludeProperties.Length > 0)
			{
				foreach (string includeProperty in IncludeProperties)
				{
					query = query.Include(includeProperty);
				}
			}



			return await query.SingleOrDefaultAsync(Filter);
		}

		public async Task RemoveAsync(int Entity)
		{
			var a=await _dbSet.FindAsync(Entity);
			await Task.Run(() => _dbSet.Remove(a));
		}

		public async Task UpdateAsync(T Entity)
		{
			await Task.Run(() => _dbSet.Update(Entity));
		}
	}
}
