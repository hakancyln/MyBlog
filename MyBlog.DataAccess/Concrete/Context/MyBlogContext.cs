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
		public virtual DbSet<About> About { get; set; }
		public virtual DbSet<Contact> Contact { get; set; }
		public virtual DbSet<Portfolio> Portfolio { get; set; }
		public virtual DbSet<Skills> Skills { get; set; }
		public virtual DbSet<Social> Social { get; set; }
		public virtual DbSet<User> User { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

		=> optionsBuilder.UseSqlServer("Data Source=DESKTOP-R04PVQ3\\SQLEXPRESS; Initial Catalog=MyBlogDB; Integrated Security=true; TrustServerCertificate=True");
	}
}
