using AutoMapper;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class SocialMapper : Profile
	{
		public SocialMapper()
		{
			CreateMap<Social, SocialGetDTO>().ReverseMap();
			CreateMap<Social, SocialCrudDTO>().ReverseMap();
		}
	}
}
