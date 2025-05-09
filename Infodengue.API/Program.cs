using Infodengue.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infodengue.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<InfodengueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();