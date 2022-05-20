using hd1.Models;

namespace hd1.Services;

public interface IParcelLockerService
{
    public IEnumerable<ParcelLocker> GetActiveParcelLockers();

    public ParcelLocker? GetParcelLocker(string id);
}
