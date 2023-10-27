using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using webapi.Context;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFContext>();

builder.Services.AddDefaultIdentity<ApiUser>
    (options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<EFContext>();

builder.Services.Configure<CookieAuthenticationOptions>(
  IdentityConstants.ApplicationScheme,
    x => x.Cookie.SameSite = SameSiteMode.None);

builder.Services.AddSession();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    //.AllowAnyOrigin()
    .AllowCredentials()
    .WithOrigins("https://localhost:5002")
);

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.Run();
