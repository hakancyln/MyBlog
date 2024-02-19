using MyBlog.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete.Context
{
	public class MyBlogContext:DbContext
	{
		public MyBlogContext() { }
		public MyBlogContext(DbContextOptions<MyBlogContext> options)
			: base(options)
		{
		}
		public virtual DbSet<About> Abouts { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Portfolio> Portfolios { get; set; }
		public virtual DbSet<Skills> Skills { get; set; }
		public virtual DbSet<Social> Socials { get; set; }
		//public virtual DbSet<User> Users { get; set; }

	}
}
