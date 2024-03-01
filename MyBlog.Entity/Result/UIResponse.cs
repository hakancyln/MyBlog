using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Result
{
	public class UIResponse<T>
	{
		public int? StatusCode { get; set; }
		public string? Message { get; set; }

		public bool? Success { get; set; }

		public T? Data { get; set; }


		public UIResponse(T data, int statustCode, bool succes, string message)
		{
			StatusCode = statustCode;
			Success = succes;
			Message = message;
			Data = data;
		}
	}
}
