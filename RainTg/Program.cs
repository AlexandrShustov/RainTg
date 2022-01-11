using Application;
using Application.Common.Interfaces;
using Application.Updates.Notifications;
using Domain.Options;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection(TelegramOptions.SectionName));
builder.Services.Configure<RaindropOptions>(builder.Configuration.GetSection(RaindropOptions.SectionName));

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddHostedService<UpdatesHostedService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    var token = endpoints.ServiceProvider.GetRequiredService<IOptions<TelegramOptions>>().Value.Token;
    endpoints.MapControllerRoute(
        name: "webhook",
        pattern: $"bot/{token}",
        defaults: new { controller = "Update", action = "Update" });

    endpoints.MapControllers();
});

app.Run();
