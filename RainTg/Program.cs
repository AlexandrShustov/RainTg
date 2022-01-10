using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
