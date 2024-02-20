using AutoMapper;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.DTO.UserDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class UserMapper : Profile
	{
        public UserMapper()
        {
			CreateMap<User, UserGetDTO>().ReverseMap();
			CreateMap<User, UserCrudDTO>().ReverseMap();
		}
    }
}
