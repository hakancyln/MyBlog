using AutoMapper;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class PortfolioMapper: Profile
	{
		public PortfolioMapper()
		{
			CreateMap<Portfolio, PortfolioGetDTO>().ReverseMap();
			CreateMap<Portfolio, PortfolioCrudDTO>().ReverseMap();
		}
	}
}
