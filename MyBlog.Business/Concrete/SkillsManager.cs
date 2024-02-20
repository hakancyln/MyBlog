using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
	public class SkillsManager : GenericManager<SkillsCrudDTO, SkillsGetDTO, Skills>, ISkillsService
	{
		public SkillsManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
