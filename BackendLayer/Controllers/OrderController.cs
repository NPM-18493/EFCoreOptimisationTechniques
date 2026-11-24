using Microsoft.AspNetCore.Mvc;
using EFDatabaseLayer;
namespace BackendLayer.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet(Name = "GetOrders")]
    public IEnumerable<Order> Get()
    {
        var orders = _orderService.GetAllOrders();

        return orders;
    }
}
