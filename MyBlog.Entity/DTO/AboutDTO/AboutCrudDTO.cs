using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.ContactDTO
{
	public class AboutCrudDTO
	{
		public int Id { get; set; }
		public string NameSurname { get; set; }
		public DateTime BirthDate { get; set; }
		public string Job { get; set; }
		public string Mail { get; set; }
		public string Description { get; set; }
		public string Resume { get; set; }
		public string SkillText { get; set; }
		public string Photo { get; set; }
	}
}
