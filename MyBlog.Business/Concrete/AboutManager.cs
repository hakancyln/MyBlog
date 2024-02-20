using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
	public class AboutManager : GenericManager<AboutCrudDTO, AboutGetDTO, About>, IAboutService
	{
		public AboutManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
