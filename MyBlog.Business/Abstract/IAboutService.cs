using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.ContactDTO;

namespace MyBlog.Business.Abstract
{
	public interface IAboutService : IGenericService<AboutCrudDTO,AboutGetDTO>
	{
	}
}
