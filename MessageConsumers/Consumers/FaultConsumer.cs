using MassTransit;
using MessagingContracts;

namespace MessageConsumers.Consumers;

public class OrderCreatedFaultConsumer : IConsumer<Fault<OrderCreated>>
{
    public Task Consume(ConsumeContext<Fault<OrderCreated>> context)
    {
        Console.WriteLine($"Message failed permanently: {context.Message.Exceptions[0].Message}");
        return Task.CompletedTask;
    }
}


public class InventoryUpdatedFaultConsumer : IConsumer<Fault<InventoryUpdated>>
{
    public Task Consume(ConsumeContext<Fault<InventoryUpdated>> context)
    {
        Console.WriteLine($"Message failed permanently: {context.Message.Exceptions[0].Message}");
        return Task.CompletedTask;
    }
}

public class OutOfStockFaultConsumer : IConsumer<Fault<OutOfStock>>
{
    public Task Consume(ConsumeContext<Fault<OutOfStock>> context)
    {
        Console.WriteLine($"Message failed permanently: {context.Message.Exceptions[0].Message}");
        return Task.CompletedTask;
    }
}