using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBlog.Business.Concrete
{
	public class GenericManager<TCrud, TGet, TEntity> : IGenericService<TCrud, TGet> where TGet : class where TCrud : class where TEntity : BaseEntity
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public GenericManager(IMapper mapper, IUnitOfWork uow)
		{
			_mapper = mapper;
			_uow = uow;
		}
		public async Task<ApiResponse<TGet>> AddAsync(TCrud p)
		{
			var result = new ApiResponse<TGet>();
			var data = _mapper.Map<TEntity>(p);
			await _uow.GetRepository<TEntity>().AddAsync(data);
			result.Success = await _uow.SaveChangesAsync();
			return result;
		}

		public async Task<ApiResponse<IEnumerable<TGet>>> GetAllAsync(Expression<Func<TGet, bool>> Filter = null, params string[] IncludeProperties)
		{
			var result = new ApiResponse<IEnumerable<TGet>>();
			var data = await _uow.GetRepository<TEntity>().GetAllAsync();
			var mappdata = _mapper.Map<IEnumerable<TGet>>(data);
			result.Data = mappdata;
			return result;
		}

		public async Task<ApiResponse<TGet>> GetAsync(int id, Expression<Func<TGet, bool>> Filter, params string[] IncludeProperties)
		{
			var result = new ApiResponse<TGet>();
			var data = await _uow.GetRepository<TEntity>().GetAsync(x=>x.Id==id);
			var mappdata = _mapper.Map<TGet>(data);
			result.Data = mappdata;
			return result;
		}

		public async Task<ApiResponse<bool>> RemoveAsync(int p)
		{
			var result = new ApiResponse<bool>();
			await _uow.GetRepository<TEntity>().RemoveAsync(p);
			result.Data = await _uow.SaveChangesAsync();
			return result;
		}

		public async Task<ApiResponse<TGet>> UpdateAsync(TCrud p)
		{
			var result = new ApiResponse<TGet>();
			var data = _mapper.Map<TEntity>(p);
			await _uow.GetRepository<TEntity>().UpdateAsync(data);
			result.Success = await _uow.SaveChangesAsync();
			return result;
		}

	}
}
