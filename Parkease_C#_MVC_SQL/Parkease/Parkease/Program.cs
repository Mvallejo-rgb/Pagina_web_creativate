using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Parkease.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicationDBcontext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 41))));

builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10485760; 
});

// 🔹 Agregar soporte para autenticación con Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login"; 
        options.AccessDeniedPath = "/Home/AccesoDenegado";
    });

// 🔹 Agregar sesiones y acceso al contexto HTTP
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true; 
});
builder.Services.AddHttpContextAccessor();  

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseExceptionHandler("/Home/Error500");
app.UseStatusCodePagesWithReExecute("/Home/Error{0}");

app.UseStaticFiles();  
app.UseRouting();  
app.UseSession();   
app.UseAuthentication(); 
app.UseAuthorization();  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();