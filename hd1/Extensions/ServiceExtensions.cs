using hd1.Services;

namespace hd1.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<IParcelLockerService, ParcelLockerService>();

        return services;
    }
}
