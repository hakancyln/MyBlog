using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.API.Middleware;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.DataAccess.Concrete.Context;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] {}
					}
				});
});






builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<MyBlogContext>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<ISkillsService, SkillsManager>();
builder.Services.AddScoped<ISocialService, SocialManager>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(options =>
	{
		options.IncludeErrorDetails = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["JWT:Issuer"],
			ValidAudience = builder.Configuration["JWT:Audiance"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Token"]))
		};
	});


var app = builder.Build();
app.UseGlobalExceptionMiddleware();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseAuthorization();

app.MapControllers();

app.Run();
