namespace hd1.Models;

public class ParcelLocker
{
    private string? _id;

    /// <summary>
    /// Parcel locker number
    /// </summary>
    public string Id
    {
        get => _id ?? string.Empty;
        set => _id ??= value; // can be assigned once only
    }

    public string? Address { get; set; }

    public bool Active { get; set; }
}
