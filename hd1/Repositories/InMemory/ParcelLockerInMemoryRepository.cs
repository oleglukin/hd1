using hd1.Models;
using hd1.SampleData;

namespace hd1.Repositories.InMemory;

public class ParcelLockerInMemoryRepository : InMemoryRepository<string, ParcelLocker>, IParcelLockerRepository
{
    public ParcelLockerInMemoryRepository()
    {
        var items = ReadSampleItems(SampleDataResource.ParcelLockers);
        foreach (var item in items)
        {
            Add(item.Id, item);
        }
    }
}
