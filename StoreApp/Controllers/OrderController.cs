using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] Order order)
    {
        var result = await orderService.CreateOrder(order);

        return Ok(result);
    }
}
