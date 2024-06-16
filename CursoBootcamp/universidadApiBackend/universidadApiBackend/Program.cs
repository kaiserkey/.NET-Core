// 1. usings to work with entity framework
using Microsoft.EntityFrameworkCore;
using universidadApiBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 2. connection with PotgreSQL 
const string CONNECTIONNAME = "netbootcamp";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. add context
builder.Services.AddDbContext<UniversityContext>(options  => options.UseNpgsql(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
