using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TacoslaEnredada_JRMJSC.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UsuarioDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsuarioDb") ?? throw new InvalidOperationException("Connection string 'UsuarioDb' not found.")));

//Permitir que los demas controladores puedan utilizara tributos de login de usuarios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Login/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        });
}   );

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
