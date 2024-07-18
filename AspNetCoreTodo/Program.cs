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

//jwt configuration 
var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]);

//add services configuration
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    }
    );

//add service jwt
builder.Services.AddAuthorization();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
