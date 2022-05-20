using System.Text.RegularExpressions;

namespace hd1.Models;
    
public class Order
{
    private int? _id;
    /// <summary>
    /// Order number
    /// </summary>
    public int Id
    {
        get => _id ?? 0;
        set => _id ??= value; // can be assigned once only
    }

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

    private const int MaximumItems = 10;

    public string[]? Items { get; set; }

    public decimal Total { get; set; }

    public string? ParcelLockerId { get; set; }

    private const string PhoneNumberRegexp = @"\+7\d\d\d-\d\d\d-\d\d-\d\d";

    public string? CustomerPhoneNumber { get; set; }

    public string? CustomerFullName { get; set; }

    public IEnumerable<string> ValidationErrors()
    {
        var errors = new List<string>();
        if (StatusEnum is OrderStatus.Invalid)
        {
            errors.Add("Invalid status");
        }

        if (Items is not null && Items.Length > MaximumItems)
        {
            errors.Add($"Number of order items ({Items.Length}) is larger than maximum allowed ({MaximumItems})");
        }

        if (CustomerPhoneNumber is null ||
            !Regex.IsMatch(CustomerPhoneNumber, PhoneNumberRegexp))
        {
            errors.Add("Customer phone number is unknown or has invalid format");
        }

        return errors;
    }
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
