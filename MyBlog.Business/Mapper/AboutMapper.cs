using AutoMapper;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;

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
