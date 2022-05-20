using hd1.Models;

namespace hd1.Services;

public interface IOrderService
{
    public Order? GetOrder(int id);

    /// <summary>
    /// Cancel order and return true if cancelled successfully
    /// </summary>
    /// <param name="id">order id</param>
    public bool Cancel(int id);

    public bool Create(Order value);
}
