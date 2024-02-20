using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
	public class Images : BaseEntity
	{
        public string Url { get; set; }
        public int PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
