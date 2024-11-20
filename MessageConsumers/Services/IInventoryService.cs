namespace MessageConsumers.Interfaces;

public interface IInventoryService
{
    Task<int> UpdateInventory(int productId);
}