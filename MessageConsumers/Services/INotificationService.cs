namespace MessageConsumers.Interfaces;

public interface INotificationService
{
    Task NotifyInventoryUpdated(int productId);
    Task NotifyOutofStock(int productId);
}