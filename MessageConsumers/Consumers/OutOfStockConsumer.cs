using MassTransit;
using MessageConsumers.Interfaces;
using MessagingContracts;

namespace MessageConsumers.Consumers;

public class OutOfStockConsumer : IConsumer<OutOfStock>
{
    private readonly INotificationService notificationService;

    public OutOfStockConsumer(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    public async Task Consume(ConsumeContext<OutOfStock> context)
    {
        await this.notificationService.NotifyOutofStock(context.Message.ProductId);
    }
}

