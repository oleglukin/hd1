using hd1.Models;
using hd1.Repositories;

namespace hd1.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IParcelLockerRepository _parcelLockerRepository;

    public OrderService(IOrderRepository or, IParcelLockerRepository plr) => 
        (_orderRepository, _parcelLockerRepository) = (or, plr);
    
    public Order? GetOrder(int id) => _orderRepository.GetById(id);

    public bool Cancel(int id)
    {
        var result = false;

        var order = _orderRepository.GetById(id);
        if (order is not null && order.StatusEnum is not OrderStatus.Cancelled)
        {
            order.Status = (int)OrderStatus.Cancelled;
            result = _orderRepository.Update(order.Id, order);
        }
        else
        {
            Console.WriteLine($@"Cannot cancel. Order {id} is not found"); // TODO log errors with ILogger
        }

        return result;
    }

    public bool Create(Order order)
    {
        var result = false;
        if (order.ValidationErrors().Any())
        {
            Console.WriteLine(string.Join('\n', order.ValidationErrors()));
        }
        else if (_orderRepository.GetById(order.Id) is not null)
        {
            Console.WriteLine($@"Order with id {order.Id} already exists. Cannot create");
        }
        else if (!LockerExistsAndActive(order))
        {
            Console.WriteLine($@"Locker {order.ParcelLockerId} doesn't exist or is not active");
        }
        else
        {
            result = _orderRepository.Create(order.Id, order);
        }
        return result;
    }

    public bool Update(Order order)
    {
        var result = false;
        if (!order.ValidationErrors().Any()
            && LockerExistsAndActive(order)
            )
        {
            result = _orderRepository.Update(order.Id, order);
        }
        // TODO log why it cannot update order if there are errors, maybe add try-catch
        return result;
    }

    private bool LockerExistsAndActive(Order order)
    {
        var locker = _parcelLockerRepository.GetById(order.ParcelLockerId ?? string.Empty);
        return locker is not null && locker.Active;
    }
}
