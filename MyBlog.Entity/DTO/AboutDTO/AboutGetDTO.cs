using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.AboutDTO
{
	public class AboutGetDTO
	{
		public string NameSurname { get; set; }
		public DateOnly BirthDate { get; set; }
		public string Job { get; set; }
		public string Mail { get; set; }
		public string Description { get; set; }
		public string Resume { get; set; }
		public string SkillText { get; set; }
		public string Photo { get; set; }
	}
}
