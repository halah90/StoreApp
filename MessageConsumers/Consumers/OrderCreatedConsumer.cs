using MassTransit;
using MessageConsumers.Interfaces;
using MessagingContracts;

namespace MessageConsumers.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    private readonly IInventoryService inventoryService;
    public OrderCreatedConsumer(IInventoryService inventoryService)
    {
        this.inventoryService = inventoryService;
    }
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        await inventoryService.UpdateInventory(context.Message.ProductId);

    }
}

