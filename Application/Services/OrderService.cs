using Application.Interfaces;
using Application.Models;
using MassTransit;
using MessagingContracts;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IBus bus;
    public OrderService(IBus bus)
    {
        this.bus = bus;
    }
    public async Task<int> CreateOrder(Order order)
    {
        if (order == null)
        {
            return 0;
        }

       await bus.Publish(new OrderCreated(order.Id, order.ProductId, order.Quantity));

        return order.Id;
    }
}