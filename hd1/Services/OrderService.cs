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
            _orderRepository.Update(order);
        }
        else
        {
            Console.WriteLine($@"Cannot cancel. Order {id} is not found");
        }

        return result;
    }

    public bool Create(Order order)
    {
        var result = false;
        if (!order.ValidationErrors().Any()
            && _orderRepository.GetById(order.Id) is not null
            && LockerExistsAndActive(order)
            )
        {
            _orderRepository.Update(order);
            result = true;
        }
        // TODO log why it cannot create order if there are errors, maybe add try-catch
        return result;
    }

    public bool Update(Order order)
    {
        var result = false;
        if (!order.ValidationErrors().Any()
            && LockerExistsAndActive(order)
            )
        {
            _orderRepository.Create(order);
            result = true;
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
