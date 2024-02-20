using AutoMapper;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class SkillsMapper : Profile
	{
		public SkillsMapper()
		{
			CreateMap<Skills, SkillsGetDTO>().ReverseMap();
			CreateMap<Skills, SkillsCrudDTO>().ReverseMap();
		}
	}
}
