using MassTransit;
using MessageConsumers.Interfaces;
using MessagingContracts;

namespace MessageConsumers.Consumers;

public class InventoryUpdatedConsumer : IConsumer<InventoryUpdated>
{
    private readonly INotificationService notificationService;

    public InventoryUpdatedConsumer(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }
    public async Task Consume(ConsumeContext<InventoryUpdated> context)
    {
        await notificationService.NotifyInventoryUpdated(context.Message.ProductId);
    }
}

