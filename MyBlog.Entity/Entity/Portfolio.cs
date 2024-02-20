using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
	public class Portfolio : BaseEntity
	{
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Images> Image { get; set; }
    }
}
