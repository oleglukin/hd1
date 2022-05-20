using hd1.Models;
using hd1.Repositories;

namespace hd1.Services;

public class ParcelLockerService : IParcelLockerService
{
    private readonly IParcelLockerRepository _repository;

    public ParcelLockerService(IParcelLockerRepository repository) => _repository = repository;

    public IEnumerable<ParcelLocker> GetActiveParcelLockers() => _repository.Filter(pl => pl.Active);

    public ParcelLocker? GetParcelLocker(string id) => _repository.GetById(id);
}
