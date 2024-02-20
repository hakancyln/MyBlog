using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
	public class Contact : BaseEntity
	{
		public string Name { get; set; }
		public string Mail { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
