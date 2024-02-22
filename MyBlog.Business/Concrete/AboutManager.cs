using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;

namespace MyBlog.Business.Concrete
{
	public class AboutManager : GenericManager<AboutCrudDTO, AboutGetDTO, About>, IAboutService
	{
		public AboutManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
