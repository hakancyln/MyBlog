using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBlog.UI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
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
                // Kullanıcı giriş yapmamışsa ve giriş yapma sayfasında değilse, giriş yapma sayfasına yönlendiriyoruz
                httpContext.Response.Redirect("/girisyap");
            }

            // Oturum süresi dolunca veya kimlik doğrulama süresi dolduğunda oturumu temizlemek için bu kodu ekleyebilirsiniz
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class middExtensions
    {
        public static IApplicationBuilder Usemidd(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionMiddleware>();
        }
    }
}
