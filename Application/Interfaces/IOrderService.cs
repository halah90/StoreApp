using Application.Models;

namespace Application.Interfaces;

public interface IOrderService
{
     Task<int> CreateOrder(Order order);

}