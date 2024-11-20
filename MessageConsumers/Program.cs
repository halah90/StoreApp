using MassTransit;
using MessageConsumers.Consumers;
using MessageConsumers.Interfaces;
using MessageConsumers.Services;
using static MassTransit.Logging.OperationName;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumer>();
    x.AddConsumer<InventoryUpdatedConsumer>();
    x.AddConsumer<OutOfStockConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("OrderCreated", e =>
        {
            e.UseMessageRetry(r => r.Exponential(5, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5)));

            e.ConfigureConsumer<OrderCreatedConsumer>(context);
        });
        
        cfg.ReceiveEndpoint("InventoryUpdated", e =>
        {
            e.UseMessageRetry(r => r.Exponential(5, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5)));

            e.ConfigureConsumer<InventoryUpdatedConsumer>(context);
        }); 

        cfg.ReceiveEndpoint("OutOfStock", e =>
        {
            e.UseMessageRetry(r => r.Exponential(5, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5)));

            e.ConfigureConsumer<OutOfStockConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});


builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();

app.Run();