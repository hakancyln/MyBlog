﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
	public class Skills: BaseEntity
	{
        public string Name { get; set; }
        public int Percentile { get; set; }
    }
}
