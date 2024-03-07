using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.ContactDTO
{
	public class ContactCrudDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Mail { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }= DateTime.Now;
		public bool IsRead { get; set; }=false;
	}
}
