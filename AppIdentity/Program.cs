using AppIdentity.Context;
using AppIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBContext>(
        options => 
                    options.UseSqlServer
                    (
                        builder.Configuration.GetConnectionString("SQLServer")
                    )
    );

/* Esto sirve para configurar Identity en la aplicación, se agrega el contexto de la base de datos 
 * y se agrega el Identity con las entidades ApplicationUser y IdentityRole
 */
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DBContext>()
                .AddDefaultTokenProviders();

/* Esto sirve para configurar las opciones de Identity como la longitud mínima de la contraseña, etc.
 */
builder.Services.Configure<IdentityOptions>(
    options =>
                {
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = true;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.User.RequireUniqueEmail = true;
                }
);

/* Esto sirve para configurar las cookies de autenticación donde el 
 * path de login es /Account/Login y el path de acceso denegado es /Account/AccessDenied 
 * estos paths son los que se usan por defecto en el scaffold de Identity pero se pueden cambiar
 */
builder.Services.ConfigureApplicationCookie(
    options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            }
);

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
