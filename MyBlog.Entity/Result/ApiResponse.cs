using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBlog.Entity.Result
{
	public class ApiResponse<T>
	{
        public T? Data { get; set; }
        public bool Succes { get; set; } = true;
    }
}
