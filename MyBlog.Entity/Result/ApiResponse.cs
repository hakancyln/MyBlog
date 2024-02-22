using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBlog.Entity.Result
{
	public class ApiResponse<T>
	{
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
		public ErrorInformation Error { get; set; }

		public ApiResponse()
		{

		}
		public ApiResponse(T data, bool success)
		{
			this.Data = data;
			this.Success = success;
		}
		public ApiResponse(T data, bool success, ErrorInformation error)
		{
			this.Data = data;
			this.Success = success;
			this.Error = error;
		}

		public ApiResponse(ErrorInformation error)
		{
			this.Error = error;
		}


		public static ApiResponse<T> FieldValidationError(List<string>? errorMessages = null, string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
		{
			return new ApiResponse<T>(ErrorInformation.FieldValidationError(errorMessages));
		}
	}
}
