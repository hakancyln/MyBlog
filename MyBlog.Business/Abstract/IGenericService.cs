using MyBlog.Entity.DTO;
using MyBlog.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{

	public interface IGenericService<TCrud, TGet>
	{
		Task<ApiResponse<TGet>> GetAsync(int id,Expression<Func<TGet, bool>> Filter, params string[] IncludeProperties);
		Task<ApiResponse<IEnumerable<TGet>>> GetAllAsync(Expression<Func<TGet, bool>> Filter = null, params string[] IncludeProperties);

		Task<ApiResponse<bool>> AddAsync(TCrud Entity);

		Task<ApiResponse<bool>> UpdateAsync(TCrud Entity);

		Task<ApiResponse<bool>> RemoveAsync(int id);

	}
}

