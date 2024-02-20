using AutoMapper;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class AboutMapper : Profile
	{
		public AboutMapper() 
		{ 
			CreateMap<About, AboutGetDTO>();
			CreateMap<AboutCrudDTO, About>();

			CreateMap<About, AboutCrudDTO>().ReverseMap();
		}

	}
}
