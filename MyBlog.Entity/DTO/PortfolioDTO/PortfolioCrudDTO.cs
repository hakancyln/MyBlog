using MyBlog.Entity.Entity;

namespace MyBlog.Entity.DTO.PortfolioDTO
{
	public class PortfolioCrudDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public IEnumerable<Images> Images { get; set; }
	}
}
