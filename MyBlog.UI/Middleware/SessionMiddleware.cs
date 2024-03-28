using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBlog.UI.Middleware
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/admin") && !httpContext.Request.Path.Equals("/girisyap") && httpContext.Session.GetString("NameSurname") == null)
            {
                httpContext.Response.Redirect("/girisyap");
            }
            return _next(httpContext);
        }
    }
    public static class middExtensions
    {
        public static IApplicationBuilder Usemidd(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionMiddleware>();
        }
    }
}
