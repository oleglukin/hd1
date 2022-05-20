using hd1.Models;
using hd1.Repositories.InMemory;

namespace hd1.Repositories;

public interface IParcelLockerRepository : IInMemoryRepository<string, ParcelLocker>
{
}
