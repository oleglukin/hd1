using hd1.Models;
using hd1.SampleData;

namespace hd1.Repositories.InMemory;

public class OrderInMemoryRepository : InMemoryRepository<int, Order>, IOrderRepository
{
    public OrderInMemoryRepository()
    {
        var items = ReadSampleItems(SampleDataResource.Orders);
        foreach (var item in items)
        {
            Add(item.Id, item);
        }
    }
}
