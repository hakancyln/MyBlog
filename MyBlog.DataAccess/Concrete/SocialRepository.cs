using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete
{
	internal class SocialRepository : Repository<Social>, ISocialRepository
	{
		public SocialRepository(DbContext context) : base(context)
		{
		}
	}
}
