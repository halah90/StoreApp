using MassTransit;
using MessageConsumers.Interfaces;
using MessagingContracts;

namespace MessageConsumers.Services;

public class InventoryService : IInventoryService
{
    private readonly IBus bus;
    public InventoryService(IBus bus)
    {
        this.bus = bus;
    }

    public async Task<int> UpdateInventory(int productId)
    {
        if (CheckInStock(productId))
        {
            await bus.Publish(new InventoryUpdated(productId));
        }
        else
        {
            await bus.Publish(new OutOfStock(productId));
        }

        return 1;
    }

    private bool CheckInStock(int productId)
    {
        if (productId > 50)
        {
            return false;
        }

        return true;
    }
}