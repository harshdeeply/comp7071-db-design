
using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "server=localhost;user=root;password=password;database=hr-app";
builder.Services.AddDbContext<IAppDbContext, AppDbContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();
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
