using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.ImageDTO
{
	public class ImageCrudDTO
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public int PortfolioId { get; set; }
	}
}
