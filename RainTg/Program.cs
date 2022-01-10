using Application;
using Application.Common.Interfaces;
using Domain.Options;
using Infrastructure;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection(TelegramOptions.SectionName));

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddHostedService<UpdatesHostedService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
