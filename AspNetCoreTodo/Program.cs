using AspNetCoreTodo.Context;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Añade servicios al contenedor.
builder.Services.AddRazorPages();

//add database context
builder.Services.AddDbContext<DBContext>(opciones =>
                                                     opciones.UseSqlServer(
                                                         builder.Configuration.GetConnectionString("SQLServer")
                                                         )
                                                     );

// Add services to the container.
builder.Services.AddControllersWithViews();

//add services scoped: ITodoItemService, TodoItemService
builder.Services.AddScoped<ITodoItemService, TodoItemService>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
