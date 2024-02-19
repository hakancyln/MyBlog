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
	public class ContactRepository : Repository<Contact>, IContactRepository
	{
		public ContactRepository(DbContext context) : base(context)
		{
		}
	}
}
