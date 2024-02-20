using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.PortfolioDTO
{
	public class PortfolioGetDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public IEnumerable<Images> Image { get; set; }
	}
}
