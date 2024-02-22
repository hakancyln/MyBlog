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

		public ErrorInformation? ErrorInformation { get; set; }

		public T? Data { get; set; }


		public UIResponse(T data, int statustCode, ErrorInformation errorInformation, string message)
		{
			StatusCode = statustCode;
			ErrorInformation = errorInformation;
			Message = message;
			Data = data;
		}
	}
}
