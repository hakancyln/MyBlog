using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBlog.UI.Middleware
{
    public class LoginCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.Contains("/Admin/"))
            {
                if (httpContext.Session.GetString("Token") == null)
                {
                    httpContext.Response.Redirect("/Login");
                    httpContext.Response.WriteAsync("Yetkisiz Giriş");
                }
            }

            return _next(httpContext);

        }
    }
    public static class LoginCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginCheckMiddleware>();
        }
    }
}
