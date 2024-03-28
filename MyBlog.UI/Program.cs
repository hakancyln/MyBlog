using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MyBlog.UI.Middleware;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    // Diðer kimlik doðrulama ayarlarýný burada yapabilirsiniz.
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    // Diðer cookie ayarlarýný burada yapabilirsiniz.
});

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient();
builder.Services.AddAuthorization(); // Yetkilendirme servisini ekleyin

var app = builder.Build();

// HTTP request pipeline'ýný yapýlandýrýn
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/Error{0}");





app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404 || context.Response.StatusCode == 401)
    {
        context.Request.Path = "/Error404";
        await next();
    }
});
app.UseStaticFiles();
app.UseRouting(); // Routing middleware'ini ekleyin

app.UseAuthentication(); // Yetkilendirme middleware'ini ekleyin
app.UseAuthorization(); // Yetkilendirme middleware'ini ekleyin (UseAuthentication'dan sonra olmalýdýr)

app.UseSession();
app.UseMiddleware<LoginCheckMiddleware>(); // Özel yetkilendirme middleware'ini ekleyin
app.UseMiddleware<SessionMiddleware>(); // Özel yetkilendirme middleware'ini ekleyin

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");
});

app.Run();
