using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Application.Mappings;
using ServiceRadar.Application.Services;

namespace ServiceRadar.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        // Register WorkshopService in DI that supports the methods available on the Workshop entity
        services.AddScoped<IWorkshopService, WorkshopService>();

        // Register all AutoMapper mapping profile in DI
        services.AddAutoMapper(typeof(WorkshopMappingProfile));
    }
}
