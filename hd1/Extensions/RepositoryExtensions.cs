using hd1.Repositories;
using hd1.Repositories.InMemory;

namespace hd1.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddDataStorage(this IServiceCollection services, IConfiguration appConfiguration)
    {
        var useInMemoryRepositories = appConfiguration.GetValue("UseInMemoryRepositories", defaultValue: true);

        if (useInMemoryRepositories)
        {
            services.AddSingleton<IParcelLockerRepository, ParcelLockerInMemoryRepository>();
            services.AddSingleton<IOrderRepository, OrderInMemoryRepository>();
        }
        else
        {
            // TODO: register real storage repositories, e.g. SQL database
            throw new NotImplementedException("Repositories not in memory are not implemented yet");
        }

        return services;
    }
}
