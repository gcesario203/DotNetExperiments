using System.Reflection;
using EventBus.Messages.Common;
using MassTransit;
using Ordering.API.EventBusConsumer;
using Ordering.API.Extensions;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddMassTransit(config =>
{

    config.AddConsumer<BasketCheckoutConsumer>();


    config.UsingRabbitMq((context, rabbitConfig) =>
    {
        rabbitConfig.Host(builder.Configuration.GetValue<string>("EventBusSettings:HostAddress"));

        rabbitConfig.ReceiveEndpoint(EventBusConstants.BASKET_CHECKOUT_QUEUE, endpointConfig =>
        {
            endpointConfig.ConfigureConsumer<BasketCheckoutConsumer>(context);
        });
    });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<BasketCheckoutConsumer>();

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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase<OrderContext>((ctx, services) =>
{
    var logger = services.GetService<ILogger<OrderContextSeed>>();

    OrderContextSeed.SeedAsync(ctx, logger).Wait();
}).Run();
