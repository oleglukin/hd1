namespace hd1.Models;
    
public class Order
{
    /// <summary>
    /// Order number
    /// </summary>
    public int Id { get; set; }

    public int Status { get; set; }

    public OrderStatus StatusEnum => Status switch
    {
        1 => OrderStatus.Registered,
        2 => OrderStatus.Accepted,
        3 => OrderStatus.Dispatched,
        4 => OrderStatus.DeliveredToParcelLocker,
        5 => OrderStatus.DeliveredToCustomer,
        6 => OrderStatus.Cancelled,
        _ => OrderStatus.Invalid,
    };

    public string[]? Items { get; set; }

    public decimal Total { get; set; }

    public string? ParcelLockerId { get; set; }

    public string? CustomerPhoneNumber { get; set; }

    public string? CustomerFullName { get; set; }
}

public enum OrderStatus
{
    Invalid = 0,
    Registered = 1,
    Accepted = 2,
    Dispatched = 3,
    DeliveredToParcelLocker = 4,
    DeliveredToCustomer = 5,
    Cancelled = 6,
}
