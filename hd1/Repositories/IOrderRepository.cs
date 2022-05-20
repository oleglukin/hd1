using hd1.Models;
using hd1.Repositories.InMemory;

namespace hd1.Repositories;

public interface IOrderRepository : IInMemoryRepository<int, Order>
{
}
