using MessageConsumers.Interfaces;

namespace MessageConsumers.Services;

public class NotificationService: INotificationService
{
    private readonly ILogger<NotificationService> logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        this.logger = logger;
    }

    public Task NotifyInventoryUpdated(int productId)
    {
        this.logger.LogInformation("Product updated with id: {ProductId}", productId);

        return Task.CompletedTask;
    }
    
    public Task NotifyOutofStock(int productId)
    {
        this.logger.LogInformation("Product out of stock with id: {ProductId}", productId);

        return Task.CompletedTask;
    }
}