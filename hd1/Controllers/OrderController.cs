using hd1.Models;
using hd1.Services;
using Microsoft.AspNetCore.Mvc;

namespace hd1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    // GET api/<OrderController>/5
    /// <summary>
    /// Tracking order (get info by id)
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return _orderService.GetOrder(id) switch
        {
            { } order => Ok(order),
            _ => NotFound(),
        };
    }

    // POST api/<OrderController>
    /// <summary>
    /// Create new order
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] Order value)
    {
        return _orderService.Create(value) switch
        {
            true => Ok(),
            _ => StatusCode(500),
            // TODO implement more specific error: Forbidden if ParcelLocker is not active
        };
    }

    // PUT api/<OrderController>/5
    /// <summary>
    /// Update order information
    /// </summary>
    [HttpPut]
    public IActionResult Put([FromBody] Order value)
    {
        return _orderService.Update(value) switch
        {
            true => Ok(),
            _ => StatusCode(500),
        };
    }

    [HttpPut("cancel/{id}")]
    public IActionResult Cancel(int id)
    {
        return _orderService.Cancel(id) switch
        {
            true => Ok(),
            _ => StatusCode(500),
        };
    }
}
