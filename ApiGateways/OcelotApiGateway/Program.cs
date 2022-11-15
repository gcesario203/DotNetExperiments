using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var environment = hostingContext.HostingEnvironment.EnvironmentName;

    config.AddJsonFile($"ocelot.{environment}.json", true, true);
});

builder.Host.ConfigureLogging((hostingContext, loggingBuilder) =>
{
    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

    loggingBuilder.AddConsole();

    loggingBuilder.AddDebug();
});

builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot();

app.Run();
