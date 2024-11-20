using MassTransit;
using MessageConsumers.Consumers;
using MessageConsumers.Interfaces;
using MessageConsumers.Services;
using static MassTransit.Logging.OperationName;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumer>(configurator =>
    {
        configurator.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
    });

    x.AddConsumer<InventoryUpdatedConsumer>(configurator =>
    {
        configurator.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5))); 
    });

    x.AddConsumer<OutOfStockConsumer>(configurator =>
    {
        configurator.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5))); 
    });

    x.AddConsumer<OrderCreatedFaultConsumer>();
    x.AddConsumer<InventoryUpdatedFaultConsumer>();
    x.AddConsumer<OutOfStockFaultConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("fault-queue", e =>
        {
            e.ConfigureConsumer<OrderCreatedFaultConsumer>(context);
            e.ConfigureConsumer<InventoryUpdatedFaultConsumer>(context);
            e.ConfigureConsumer<OutOfStockFaultConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});


builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();

app.Run();